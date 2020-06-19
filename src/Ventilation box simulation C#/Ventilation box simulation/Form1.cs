using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventilation_box_simulation
{
    public partial class Form1 : Form
    {
        MSSQL msql;
        private List<DataDB> dataG1;
        private List<DataDB> dataG3;
        private List<DataDB> dataG5;
        int voc, CO2;
        float tempC, tempF, humidity;
        const int CO2TH = 2000;
        const int VOCTH = 500;
        int dutyCycle;
        bool[] states = new bool[3];
        
        
        public Form1()
        {
            InitializeComponent();
            refreshLabels();
            dutyCycle = 0;
            spSensorBoard.Open();
            msql = new MSSQL();
        }

        private void timerGetValues_Tick(object sender, EventArgs e)
        {
            getValues();
            calculateDutyCycle();
            refreshLabels();
        }

        void getValues()
        {
            if(spSensorBoard.IsOpen)
            {
                if(spSensorBoard.BytesToRead > 0)
                {
                    String line = spSensorBoard.ReadLine();
                    line = line.Trim();
                    string[] values = new string[5];
                    
                    char[] valuesC = line.ToCharArray();
                    int counter= 0;
                    int j = 0;
                    if (valuesC[0] == '#')
                    {
                        for (int i = 1; i < line.Length; i++)
                        {
                            if (valuesC[i] == 'T')
                            {
                                states[j] = true;
                                j++;
                            }
                            else if (valuesC[i] == 'F')
                            {
                                states[j] = false;
                                j++;
                            }
                            else if (valuesC[i] == '%')
                            {
                                break;
                            }
                            else if (valuesC[i] == '$')
                            {
                                counter++;
                            }
                            else
                            {
                                values[counter] += valuesC[i];
                            }
                        }
                        tempC = float.Parse(values[0]);
                        tempC /= 100;
                        tempF = float.Parse(values[1]);
                        tempF /= 100;
                        humidity = float.Parse(values[2]);
                        humidity /= 100;
                        CO2 = Int32.Parse(values[3]);
                        voc = Int32.Parse(values[4]);
                    }
                    else
                    { }
                }
            }
        }

        private void timerSendData_Tick(object sender, EventArgs e)
        {
            msql.PushData(tempC, tempF, humidity, CO2, voc);

            dataG1 = msql.GetData(1);
            foreach (var item in dataG1)
            {
                lblGr1.Text = "Group: " + item.GrNr + " - TempC: " + item.TempC + " - TempF: " + item.TempF + " - Humidity: " + item.Humid + " - Co2: " + item.Co2Sensor + " - VOC: " + item.Voc + " - Date and Time: " + item.TimeLogged;
            }

            dataG3 = msql.GetData(3);
            foreach (var item in dataG3)
            {
                lblGr3.Text = "Group: " + item.GrNr + " - TempC: " + item.TempC + " - TempF: " + item.TempF + " - Humidity: " + item.Humid + " - Co2: " + item.Co2Sensor + " - VOC: " + item.Voc + " - Date and Time: " + item.TimeLogged;
            }

            dataG5 = msql.GetData(5);
            foreach (var item in dataG5)
            {
                lblGr5.Text = "Group: " + item.GrNr + " - TempC: " + item.TempC + " - TempF: " + item.TempF + " - Humidity: " + item.Humid + " - Co2: " + item.Co2Sensor + " - VOC: " + item.Voc + " - Date and Time: " + item.TimeLogged;
            }
            
        }


        void calculateDutyCycle()
        {
            int tempDC=0, humidDC=0;

            lblTemp.ForeColor = Color.Black;
            lblHumidity.ForeColor = Color.Black;
            lblCO2.ForeColor = Color.Black;
            lblVOC.ForeColor = Color.Black;
            if (states[0] == false)
            {
                tempC = 0;
                humidity = 0;
            }
            if (states[1] == false)
            {
                CO2 = 0;
            }
            if (states[2] == false)
            {
                voc = 0;
            }
            
            //calculate based on the tresholds
            tempDC = map((float)tempC, 24, 30, 0, 100);
            humidDC = map((float)humidity, 50, 70, 0, 100);
            if (humidDC >= tempDC)
            {
                dutyCycle = humidDC;
            }
            else
            {
                dutyCycle = tempDC;
            }
            if (humidDC > 50)
            {
                lblHumidity.ForeColor = Color.Orange;
                if (humidDC >= 100)
                {
                    lblHumidity.ForeColor = Color.Red;
                }
            }
            
            if (tempDC > 50)
            {
                lblTemp.ForeColor = Color.Orange;
                if (tempDC >= 100)
                {
                    lblTemp.ForeColor = Color.Red;
                }
            }

            if (CO2 > CO2TH || voc > VOCTH)
            {
                dutyCycle = 100;
                if (CO2 > CO2TH)
                {
                    lblCO2.ForeColor = Color.Red;
                }
               
                if (voc > VOCTH)
                {
                    lblVOC.ForeColor = Color.Red;
                }
               
            }

            if (dutyCycle >= 100) { dutyCycle = 100; lblFan.ForeColor = Color.Red; }
            else if (dutyCycle < 1) { dutyCycle = 0; lblFan.ForeColor = Color.Black; }
            else
            {
                lblFan.ForeColor = Color.Black;
            }
        }

        void refreshLabels()
        {
            lblCO2.Text = $"CO2 levels = {CO2} ppm";
            lblVOC.Text = $"VOC levels = {voc} ppb";
            lblTemp.Text = $"Temperature = {tempC}°C/{tempF}°F";
            lblHumidity.Text = $"Relative Himidity = {humidity}%";
            lblFan.Text = $"Ventilation duty cycle currently at {dutyCycle}%";
            if (states[0] == false)
            {
                lblTemp.Text = $"Temperature sensor disconnected!";
                lblHumidity.Text = $"Humidity sensor disconnected!";
                lblTemp.ForeColor = Color.Gray;
                lblHumidity.ForeColor = Color.Gray;
            }
            if (states[1] == false)
            {
                lblCO2.Text = $"CO2 sensor disconnected!";
                lblCO2.ForeColor = Color.Gray;
            }
            if (states[2] == false)
            {
                lblVOC.Text = $"VOC sensor disconnected!";
                lblVOC.ForeColor = Color.Gray;
            }

            if (dutyCycle > 0) { pbAirflow.Visible = true;}
            else
            {
                pbAirflow.Visible = false;
            }
        }

        int map(float s, float a1, float a2, int b1, int b2)
        {
            return (int)(b1 + (s - a1) * (b2 - b1) / (a2 - a1));
        }
    }
}
