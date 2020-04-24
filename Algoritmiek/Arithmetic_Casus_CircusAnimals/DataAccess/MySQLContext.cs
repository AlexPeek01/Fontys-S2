using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals.DataAccess
{
    public class MySQLContext
    {
        private const string connectionString = "server=localhost;database=s2-algoritmiek-circusanimals;uid=root;pwd=;";
        public static void MySqlQuery(int wagonId, string animalType, int trainId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    //INSERT INTO, UPDATE AND DELETE
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO train (wagonId,animalType,trainId) VALUES (@wagonId,@animalType,@trainId)", connection))
                    {
                        cmd.Parameters.AddWithValue("@wagonId", wagonId);
                        cmd.Parameters.AddWithValue("@animalType", animalType);
                        cmd.Parameters.AddWithValue("@trainId", trainId);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static int GetTrainCount()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    //INSERT INTO, UPDATE AND DELETE
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT trainId) FROM train", connection))
                    {
                        int trainCount = -1;
                        connection.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            trainCount = Convert.ToInt32(reader["COUNT(DISTINCT trainId)"]);
                        }
                        connection.Close();
                        return trainCount;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
