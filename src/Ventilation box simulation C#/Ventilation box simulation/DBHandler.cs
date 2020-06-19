using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ventilation_box_simulation
{
    class DBHandler
    {
       
        private MySqlConnection connection;

        public DBHandler()
        {

            //string connectionInfo = @"Server = studmysql01.fhict.local; Uid = dbi361859; Database = dbi361859; Pwd = DBProject;";
            string connectionInfo =
              @"Server=studmysql01.fhict.local;" +
              "database=dbi361859;" +
              "user id=dbi361859" +
              "password=DBproject;" +
              "connect timeout=30;";
            connection = new MySqlConnection(connectionInfo);
        }

        public int AddData(float tempC, float tempF, float humid, int co2, int voc)
        {
            String sql = @"INSERT INTO `sensordata`(`input_nr`, `tempC`, `tempF`, `humid`, `co2`, `voc`, `time_loged`, `gr_nr`) VALUES(NULL,@param1,@param2,@param3,@param4,@param5,@param6,@param7)";

            MySqlCommand command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("param1", tempC);
            command.Parameters.AddWithValue("param2", tempF);
            command.Parameters.AddWithValue("param3", humid);
            command.Parameters.AddWithValue("param4", co2);
            command.Parameters.AddWithValue("param5", voc);
            command.Parameters.AddWithValue("param6", DateTime.Now.ToString("yyyy’-‘MM’-‘dd’ ’HH’:’mm’:’ss"));
            command.Parameters.AddWithValue("param7", "7");

            try
            {
                connection.Open();
                int nrOfRecordsChanged = command.ExecuteNonQuery();
                return nrOfRecordsChanged;

            }

            catch
            {

                MessageBox.Show("Something went wrong!");
                return -1;

            }

            finally
            {
                connection.Close();
            }
        }
        public string getDataFromOtherGroups(int gr_nr)
        {
            String sql = @"SELECT `input_nr`, `tempC`, `tempF`, `humid`, `co2`, `voc`, `time_loged`, `gr_nr` FROM `sensordata` WHERE `gr_nr`=@param";

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("param1", gr_nr);
            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int inputnr = Convert.ToInt32(reader["input_nr"]);
                    double tempc = Convert.ToDouble(reader["tempC"]);
                    double tempf = Convert.ToDouble(reader["tempF"]);
                    double humid = Convert.ToDouble(reader["humid"]);
                    int co2 = Convert.ToInt32(reader["co2"]);
                    int voc = Convert.ToInt32(reader["voc"]);
                    DateTime dateTime = Convert.ToDateTime(reader["time_loged"]);
                     int ggr_nr = Convert.ToInt32(reader["gr_nr"]);
                    break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return "string";
        }
    }
}
