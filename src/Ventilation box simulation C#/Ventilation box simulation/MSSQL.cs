using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventilation_box_simulation
{
    class MSSQL
    {

        public void PushData(float tempC, float tempF, float humid, int co2, int voc)
        {
            using (SqlConnection connection = new SqlConnection("Server=mssql.fhict.local;Database=dbi361859_sensordata;User Id=dbi361859_sensordata;Password=datasensor;"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    DateTime myDateTime = DateTime.Now;
                    string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO sensor_data ( tempC, tempF, humid, co2, voc,datetime, gr_nr) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";
                    command.Parameters.AddWithValue("param1", tempC);
                    command.Parameters.AddWithValue("param2", tempF);
                    command.Parameters.AddWithValue("param3", humid);
                    command.Parameters.AddWithValue("param4", co2);
                    command.Parameters.AddWithValue("param5", voc);
                    command.Parameters.AddWithValue("param6", sqlFormattedDate);
                    command.Parameters.AddWithValue("param7", "7");

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(Convert.ToString(e)); // error here
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    //    public List<DataDB> GetData(int gr_nr)
    //    {
    //        using (SqlCommand command = new SqlCommand())
    //        {
    //            List<DataDB> datad = new List<DataDB>();
    //            using (SqlConnection objConn = new SqlConnection("Server=mssql.fhict.local;Database=dbi361859_sensordata;User Id=dbi361859_sensordata;Password=datasensor;"))
    //            {

    //                SqlDataAdapter sensordata = new SqlDataAdapter("SELECT ID, tempC, tempF, humid, co2, voc, datetime, gr_nr FROM dbo.sensor_data WHERE datetime = (SELECT MAX(datetime) FROM dbo.sensor_data WHERE gr_nr = @param)"
    //, objConn); command.Parameters.AddWithValue("param", tempC);
    //                DataSet dsPubs = new DataSet("ID,tempC,tempF,humid,co2,voc,datetime,gr_nr");
    //                sensordata.FillSchema(dsPubs, SchemaType.Source, "sensor_data");
    //                sensordata.Fill(dsPubs, "sensor_data");
    //                DataTable tblID, tblTempC, tblTempF, tblHumid, tblCo2, tblVOC, tblDatetime, tblGrNr;
    //                tblTempC = dsPubs.Tables["tempC"];
    //                tblTempF = dsPubs.Tables["tempF"];
    //                tblHumid = dsPubs.Tables["humid"];
    //                tblCo2 = dsPubs.Tables["co2"];
    //                tblVOC = dsPubs.Tables["voc"];
    //                tblDatetime = dsPubs.Tables["datetime"];
    //                tblGrNr = dsPubs.Tables["gr_nr"];
    //                tblID = dsPubs.Tables["ID"];
    //                datad.Add(new DataDB(Convert.ToInt32(tblID), Convert.ToSingle(tblTempC), Convert.ToSingle(tblTempF), Convert.ToSingle(tblHumid), Convert.ToInt32(tblVOC), Convert.ToInt32(tblCo2), Convert.ToDateTime(tblDatetime), Convert.ToInt32(tblGrNr)));

    //            }
    //        }
    //        return datad;
    //    }
        public List<DataDB> GetData(int gr_nr)
        {
            List<DataDB> datad = new List<DataDB>();
            using (SqlConnection connection = new SqlConnection("Server=mssql.fhict.local;Database=dbi361859_sensordata;User Id=dbi361859_sensordata;Password=datasensor;"))
            {
                
                using (SqlCommand command = new SqlCommand())
                {
                    DateTime myDateTime = DateTime.Now;
                    string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT ID, tempC, tempF, humid, co2, voc, datetime, gr_nr FROM dbo.sensor_data WHERE datetime = (SELECT MAX(datetime) FROM dbo.sensor_data WHERE gr_nr = @param)";
                    command.Parameters.AddWithValue("param", gr_nr);


                    try
                    {
                        

                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            float tblTempC = Convert.ToSingle(reader["tempC"]);
                            float  tblTempF = Convert.ToSingle(reader["tempF"]);
                            float tblHumid = Convert.ToSingle(reader["humid"]);
                            int  tblCo2 = Convert.ToInt32(reader["co2"]);
                            int tblVOC = Convert.ToInt32(reader["voc"]);
                            DateTime tblDatetime = Convert.ToDateTime(reader["datetime"]);
                            int tblGrNr = Convert.ToInt32(reader["gr_nr"]);
                            int tblID = Convert.ToInt32(reader["ID"]);
                            datad.Add(new DataDB(tblID,tblTempC, tblTempF, tblHumid, tblVOC, tblCo2, tblDatetime, tblGrNr));
                           
                        }

                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show(Convert.ToString(e)); // error here
                    }
                    finally
                    {
                        connection.Close();
                    }
                    return datad;
                }
            }
        }

    }
}
