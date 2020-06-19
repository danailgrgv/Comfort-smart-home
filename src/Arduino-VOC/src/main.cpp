#include <Arduino.h>
#include <Wire.h>

#define VOC_Addr 0x5A
byte VOC_data[9];
const int green = 10;
const int red = 9;
int co2 = 0;
int voc = 0;

void setup()
{

  Wire.begin(); // Initialise I2C communication as MASTER
  Serial.begin(9600);
  pinMode(green, OUTPUT);
  pinMode(red, OUTPUT);
}

void loop()
{
  // Request 9 bytes of data
  Wire.requestFrom(VOC_Addr, 9);

  // Read 9 bytes of data
  if (Wire.available() == 9)
  {
    for (int i = 0; i < 9; i++)
    {
      VOC_data[i] = Wire.read();
    }
    digitalWrite(green, HIGH);
    digitalWrite(red, LOW);
  }
  else
  {
    digitalWrite(green, LOW);
    digitalWrite(red, HIGH);
    Serial.println("Connection lost with the VOC sensor!!");
  }

  // Convert the data
  // review datasheet page 10 + 11
  co2 = (VOC_data[0] * 256) + (VOC_data[1]);
  voc = (VOC_data[7] * 256) + (VOC_data[8]);

  Serial.print("CO2 = ");
  Serial.print(co2);
  Serial.print("ppm / ");
  Serial.print("VOC = ");
  Serial.print(voc);
  Serial.println("ppb");

  delay(1000);
}
