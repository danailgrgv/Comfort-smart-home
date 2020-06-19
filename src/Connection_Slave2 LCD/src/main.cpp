#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <espnow.h>
#include <LiquidCrystal.h>

LiquidCrystal lcd(D6, D5, D1, D2, D3, D4);

float cTemp = 0, humidity = 0;
bool Temp_state = true, CO2_state = true, Voc_state = true;
int voc, co2;


// Structure example to receive data
// Must match the sender structure
typedef struct struct_message
{
  char str[40];
} struct_message;

// Create a struct_message called myData
struct_message myData;

// Callback function that will be executed when data is received
void OnDataRecv(uint8_t *mac, uint8_t *incomingData, uint8_t len)
{
  memcpy(&myData, incomingData, sizeof(myData));

  String T, H, C, V;
  byte index = 1;
  if (myData.str[index] == 'T') //get temp sensor status
  {
    Temp_state = true;
  }
  else
  {
    Temp_state = false;
  }
  index++;
  while (myData.str[index] != '$') //get temp C value
  {
    T = T + myData.str[index];
    index++;
  }
  index++;
  while (myData.str[index] != '$') //drop temp F value
  {
    index++;
  }
  index++;
  while (myData.str[index] != '$') //get humidity value
  {
    H = H + myData.str[index];
    index++;
  }
  index++;
  if (myData.str[index] == 'T') //get Co2 sensor satus
  {
    CO2_state = true;
  }
  else
  {
    CO2_state = false;
  }
  index++;
  while (myData.str[index] != '$') //get Co2 value
  {
    C = C + myData.str[index];
    index++;
  }
  index++;
  if (myData.str[index] == 'T') //get Voc sensor status
  {
    Voc_state = true;
  }
  else
  {
    Voc_state = false;
  }
  index++;
  while (myData.str[index] != '$') // get Voc value
  {
    V = V + myData.str[index];
    index++;
  }

  //convert all values
  cTemp = T.toDouble();
  humidity = H.toDouble();
  co2 = C.toInt();
  voc = V.toInt();

  //show the updated info on the LCD
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("T ");
  lcd.setCursor(2, 0);
  if (Temp_state == true)
  {
    lcd.print(cTemp);
  }
  else
  {
    lcd.print("Err");
  }
  lcd.setCursor(8, 0);
  lcd.print("CO2 ");
  lcd.setCursor(12, 0);
  if (CO2_state == true)
  {
    lcd.print(co2);
  }
  else
  {
    lcd.print("Err");
  }
  lcd.setCursor(0, 1);
  lcd.print("H ");
  lcd.setCursor(2, 1);
  if (Temp_state == true)
  {
    lcd.print(humidity);
  }
  else
  {
    lcd.print("Err");
  }
  lcd.setCursor(8, 1);
  lcd.print("VOC ");
  lcd.setCursor(12, 1);
  if (Voc_state == true)
  {
    lcd.print(voc);
  }
  else
  {
    lcd.print("Err");
  }
}

void setup()
{
  lcd.begin(16, 2);    //lcd has 16 columns and 2 rows
  lcd.setCursor(0, 0); //upper left corner

  // Set device as a Wi-Fi Station
  WiFi.mode(WIFI_STA);

  // Init ESP-NOW
  if (esp_now_init() != 0)
  {
    Serial.println("Error initializing ESP-NOW");
    return;
  }

  // Once ESPNow is successfully Init, we will register for recv CB to
  // get recv packer info
  esp_now_set_self_role(ESP_NOW_ROLE_SLAVE);
  esp_now_register_recv_cb(OnDataRecv);
}

void loop()
{
}