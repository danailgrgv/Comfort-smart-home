#include <Arduino.h>
#include <SoftwareSerial.h>

#define rxPin A5
#define txPin A4
SoftwareSerial CM1106 = SoftwareSerial(rxPin, txPin); // set up a new serial port
const int green = 10;
const int red = 9;
int CO2_Value;
byte CO2_data[4];                      //To save the read values
byte GetCO2[4] = {0x11, 0x01, 0x01, 0xED}; //The command to ask for CO2 values from the sensor (datasheet page 9)
bool toggle = false;
int x;
void handleSerial();

void setup()
{
  Serial.begin(9600);
  CM1106.begin(9600);
  pinMode(rxPin, INPUT);
  pinMode(txPin, OUTPUT);
  pinMode(green, OUTPUT);
  pinMode(red, OUTPUT);
}

void loop()
{
  
  for (unsigned int i = 0; i < sizeof(GetCO2) / sizeof(GetCO2[0]); i++) //To send the Command to the sensor
  {
    CM1106.write(GetCO2[i]);
  }
  handleSerial();                                          //To read the response from the sensor
  CO2_Value = (CO2_data[2] * 256) + (CO2_data[3]); //Formula to calculate ppm (datasheet page 9)
  if (CO2_Value <= 0 || CO2_Value > 5000)
  {
    digitalWrite(green, LOW);
    digitalWrite(red, HIGH);
    Serial.println("Connection lost with the CO2 sensor!!");
  }
  else
  {
  Serial.print("CO2 = ");
  Serial.print(CO2_Value);
  Serial.println("ppm");
    digitalWrite(green, HIGH);
    digitalWrite(red, LOW);
  }
  delay(100); //Sampling frequency
}

void handleSerial()
{
  if (CM1106.available() == 0)
  {
    CO2_data[3] = 0;
    CO2_data[2] = 0;
  }
  while (CM1106.available() > 0)
  {
    byte c = CM1106.read();
    if (c == 0x16)
    {
      x = 0;
      toggle = true;
    }
    else if (toggle == true)
    {
      CO2_data[x] = c;
      if (x > 3) //the length of the response
      {
        toggle = false;
        CM1106.flush();
        break;
      }
      x++;
    }
  }
}