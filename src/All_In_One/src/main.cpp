
#include <Arduino.h>
#include <Wire.h>
#include <SoftwareSerial.h>

#define rxPin A5
#define txPin A4
#define VOC_Addr 0x5A
#define SHT3X_Addr 0x44

#define rx1Pin A1
#define tx1Pin A0
SoftwareSerial MCU = SoftwareSerial(rx1Pin, tx1Pin); // set up a new serial port

byte VOC_data[9];
byte SHT3X_data[6];
byte CO2_data[4];
SoftwareSerial CM1106 = SoftwareSerial(rxPin, txPin); // set up a new serial port
byte GetCO2[4] = {0x11, 0x01, 0x01, 0xED};            //The command to ask for CO2 values from the sensor (datasheet page 9)

const int green = 10;
const int red = 9;
int voc, CO2_Value, temp;
float cTemp, fTemp, humidity;
char Temp_state, CO2_state, Voc_state;
bool toggle = false;
int x;
void handleSerial();

//#######################################################################################################################
void setup()
{
  Wire.begin(); // Initialise I2C communication as MASTER
  Serial.begin(9600);
  CM1106.begin(9600); //The Software Serial
  pinMode(rxPin, INPUT);
  pinMode(txPin, OUTPUT);
  pinMode(green, OUTPUT);
  pinMode(red, OUTPUT);
  MCU.begin(9600);
  pinMode(rx1Pin, INPUT);
  pinMode(tx1Pin, OUTPUT);
}
//#######################################################################################################################
void loop()
{
  delay(100);
  //================================VOC=====================================

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
    Voc_state = 'T';
  }
  else
  {
    digitalWrite(green, LOW);
    digitalWrite(red, HIGH);
    Voc_state = 'F';
    Serial.println("Connection lost with the VOC sensor!!");
  }

  // Convert the data
  // review datasheet page 10 + 11
  voc = (VOC_data[7] * 256) + (VOC_data[8]);

  delay(100);

  //================================TEMPERATURE=====================================

  Wire.beginTransmission(SHT3X_Addr); // Start I2C Transmission
  // Send 16-bit command byte
  Wire.write(0x2C);
  Wire.write(0x06);
  Wire.endTransmission();
  delay(200);

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
    Temp_state = 'T';
  }
  else
  {
    digitalWrite(green, LOW);
    digitalWrite(red, HIGH);
    Temp_state = 'F';
    Serial.println("Connection lost with the Temperatrue/Humidity sensor!!");
  }

  // Convert the data
  // review datasheet page 11

  temp = (SHT3X_data[0] * 256) + SHT3X_data[1];
  cTemp = -45.0 + (175.0 * temp / 65535.0);
  fTemp = (cTemp * 1.8) + 32.0;
  humidity = (100.0 * ((SHT3X_data[3] * 256.0) + SHT3X_data[4])) / 65535.0;

  delay(100);

  //================================CO2=====================================

  for (unsigned int i = 0; i < sizeof(GetCO2) / sizeof(GetCO2[0]); i++) //To send the Command to the sensor
  {
    CM1106.write(GetCO2[i]);
  }
  handleSerial();                                  //To read the response from the sensor
  CO2_Value = (CO2_data[2] * 256) + (CO2_data[3]); //Formula to calculate ppm (datasheet page 9)
  if (CO2_Value <= 0 || CO2_Value > 5000)
  {
    digitalWrite(green, LOW);
    digitalWrite(red, HIGH);
    CO2_state = 'F';
    Serial.println("Connection lost with the CO2 sensor!!");
  }
  else
  {
    digitalWrite(green, HIGH);
    digitalWrite(red, LOW);
    CO2_state = 'T';
  }

  //================================PRINT TO SERIAL=====================================

  // Serial.print("Temperature = ");
  // Serial.print(cTemp);
  // Serial.print("C , ");
  // Serial.print(fTemp);
  // Serial.print("F / ");
  // Serial.print("Relative Humidity = ");
  // Serial.print(humidity);
  // Serial.print("%RH / ");
  // Serial.print("CO2 = ");
  // Serial.print(CO2_Value);
  // Serial.print("ppm / ");
  // Serial.print("VOC = ");
  // Serial.print(voc);
  // Serial.println("ppb");
  // Serial.println("===========================================================================================");

  //================================SEND TO WIFI=====================================
  delay(100);
  MCU.write('&');

  MCU.write('#');
  MCU.write(Temp_state);
  String s = String(cTemp);
  for (int i = 0; i < s.length(); i++)
  {
    MCU.write(s[i]);
  }
  MCU.write('$');

  s = String(fTemp);
  for (int i = 0; i < s.length(); i++)
  {
    MCU.write(s[i]);
  }
  MCU.write('$');

  s = String(humidity);
  for (int i = 0; i < s.length(); i++)
  {
    MCU.write(s[i]);
  }
  MCU.write('$');

  MCU.write(CO2_state);
  s = String(CO2_Value);
  for (int i = 0; i < s.length(); i++)
  {
    MCU.write(s[i]);
  }
  MCU.write('$');

  MCU.write(Voc_state);
  s = String(voc);
  for (int i = 0; i < s.length(); i++)
  {
    MCU.write(s[i]);
  }
  MCU.write('$');
  MCU.write('%');

  MCU.write('@');
  delay(100);
}


//#######################################################################################################################

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
      if (x > 3)
      {
        toggle = false;
        CM1106.flush();
        break;
      }
      x++;
    }
  }
}