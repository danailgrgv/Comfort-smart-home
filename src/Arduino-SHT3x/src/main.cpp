#include <Arduino.h>
#include <Wire.h>

#define SHT3X_Addr 0x44
byte SHT3X_data[6];
const int green = 10;
const int red = 9;

void setup()
{ 
  Wire.begin();  // Initialise I2C communication as MASTER
  Serial.begin(9600); 
  pinMode(green, OUTPUT);
  pinMode(red, OUTPUT);
}

void loop()
{

  Wire.beginTransmission(SHT3X_Addr);   // Start I2C Transmission
  // Send 16-bit command byte
  Wire.write(0x2C);
  Wire.write(0x06);
  Wire.endTransmission();
  delay(500);

  // Request 6 bytes of data
  Wire.requestFrom(SHT3X_Addr, 6);

  // Read 6 bytes of data
  // temp msb, temp lsb, temp crc, hum msb, hum lsb, hum crc
  //datasheet page 8

  if (Wire.available() == 6)
  {
    SHT3X_data[0] = Wire.read();
    SHT3X_data[1] = Wire.read();
    SHT3X_data[2] = Wire.read();
    SHT3X_data[3] = Wire.read();
    SHT3X_data[4] = Wire.read();
    SHT3X_data[5] = Wire.read();
    digitalWrite(green, HIGH);
    digitalWrite(red, LOW);
  }
  else
  {
    digitalWrite(green, LOW);
    digitalWrite(red, HIGH);
    Serial.println("Connection lost with the Temperatrue/Humidity sensor!!");
  }

  // Convert the data
  // review datasheet page 11

  int temp = (SHT3X_data[0] * 256) + SHT3X_data[1];
  float cTemp = -45.0 + (175.0 * temp / 65535.0);
  float fTemp = (cTemp * 1.8) + 32.0;
  float humidity = (100.0 * ((SHT3X_data[3] * 256.0) + SHT3X_data[4])) / 65535.0;

  // Output data to serial monitor
  Serial.print("Temperature in Celsius :");
  Serial.print(cTemp);
  Serial.println(" C");
  Serial.print("Temperature in Fahrenheit :");
  Serial.print(fTemp);
  Serial.println(" F");
  Serial.print("Relative Humidity :");
  Serial.print(humidity);
  Serial.println(" %RH");

  delay(1000);
}
