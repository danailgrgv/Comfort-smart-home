using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace Ventilation_box_simulation
{
    class DataDB
    {
        public int ID { get; set; }
        public float TempC { get; set; }
        public float TempF { get; set; }
        public float Humid { get; set; }
        public int Voc { get; set; }
        public int Co2Sensor  { get; set; }
        public DateTime TimeLogged { get; set; }
        public int GrNr { get; set; }
        public DataDB(int id, float tempc,float tempf, float humid,int voc,int co2,DateTime timelogged,int grnr)
        {
            this.ID = id;
            this.TempC = tempc;
            this.TempF = tempf;
            this.Humid = humid;
            this.Co2Sensor = co2;
            this.Voc = voc;
            this.TimeLogged = timelogged;
            this.GrNr = grnr;
        }
       
        
    }
}
