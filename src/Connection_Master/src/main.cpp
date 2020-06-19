#include <Arduino.h>
#include <Wire.h>
#include <ESP8266WiFi.h>
#include <espnow.h>

char buf[40]; //To save the values from Nucleo

// REPLACE WITH RECEIVER MAC Address
uint8_t broadcastAddress1[] = {0x50, 0x02, 0x91, 0xE0, 0x5E, 0x37};//LCD
uint8_t broadcastAddress2[] = {0xF4, 0xCF, 0xA2, 0x68, 0x6B, 0x4E};//Laptop

// Structure example to send data
// Must match the receiver structure
typedef struct struct_message
{
  char str[40];
} struct_message;

// Create a struct_message called myData
struct_message myData;
struct_message *ptr = &myData;

// Callback when data is sent
void OnDataSent(uint8_t *mac_addr, uint8_t sendStatus)
{
  Serial.print("Last Packet Send Status: ");
  if (sendStatus == 0)
  {
    Serial.println("Delivery success");
  }
  else
  {
    Serial.println("Delivery fail");
  }
}

void setup()
{
  // Init Serial Monitor
  Serial.begin(9600);

  // Set device as a Wi-Fi Station
  WiFi.mode(WIFI_STA);

  // Init ESP-NOW
  if (esp_now_init() != 0)
  {
    Serial.println("Error initializing ESP-NOW");
    return;
  }

  // Once ESPNow is successfully Init, we will register for Send CB to
  // get the status of Trasnmitted packet
  esp_now_set_self_role(ESP_NOW_ROLE_CONTROLLER);
  esp_now_register_send_cb(OnDataSent);

  // Register peer
  esp_now_add_peer(broadcastAddress1, ESP_NOW_ROLE_SLAVE, 1, NULL, 0);
  esp_now_add_peer(broadcastAddress2, ESP_NOW_ROLE_SLAVE, 1, NULL, 0);
}

void loop()
{
  //Read from the Nucleo
  if (Serial.available() > 0)
  {
    while (Serial.read() != '&')
    {
    }
    
    Serial.readBytesUntil('@', buf, 99);
    Serial.println(buf);
  }
  
  //Set values to send
  strcpy(ptr->str, buf); //coppy data from the buffer to the string to be sent

  // Send message via ESP-NOW
  esp_now_send(broadcastAddress1, (uint8_t *)&myData, sizeof(myData));
  esp_now_send(broadcastAddress2, (uint8_t *)&myData, sizeof(myData));

  delay(250);
}

