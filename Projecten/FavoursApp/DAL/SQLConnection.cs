using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class SQLConnection
    {
        private static MySqlConnection CreateConnection()
        {
            MySqlConnection cnn;
            string connectionString = "server=studmysql01.fhict.local;database=dbi430284;uid=dbi430284;pwd=482034;";
            //string connectionString = $"server=ns1-442.axc.nl;database=alexpfw442_favours;uid=alexpfw442_favours;pwd=sruovaf2!;";
            cnn = new MySqlConnection(connectionString);
            return cnn;
        }
        public static MySqlCommand AddCmdParameters(MySqlCommand cmd, List<string[]> parameters)
        {
            foreach (string[] array in parameters)
            {
                cmd.Parameters.AddWithValue(array[0], array[1]);
            }
            return cmd;
        }
        public static List<string[]> ExecuteSearchQueryWithArrayReturn(string query, List<string[]> parameters)
        {
            string[] tempStrArr;
            List<string[]> values = new List<string[]>();
            MySqlConnection cnn = CreateConnection();
            MySqlCommand cmd = new MySqlCommand();
            AddCmdParameters(cmd, parameters);
            cmd.CommandText = query;
            cmd.Connection = cnn;
            cnn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            values.Clear();
            try
            {
                while (reader.Read())
                {
                    tempStrArr = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        tempStrArr[i] = reader[i].ToString();
                    }
                    values.Add(tempStrArr);
                }
            }
            catch (Exception e)
            {
                string eString = e.ToString();
            }
            cnn.Close();
            return values;
        }

        public static List<string> ExecuteSearchQuery(string query, List<string[]> parameters)
        {
            List<string> values = new List<string>();
            MySqlConnection cnn = CreateConnection();
            MySqlCommand cmd = new MySqlCommand();
            AddCmdParameters(cmd, parameters);
            cmd.CommandText = query;
            cmd.Connection = cnn;
            cnn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            values.Clear();
            try
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        values.Add(reader[i].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                string eString = e.ToString();
            }
            cnn.Close();
            return values;
        }

        public static void ExecuteNonSearchQuery(string query, List<string[]> parameters)
        {
            MySqlConnection cnn = CreateConnection();
            MySqlCommand cmd = new MySqlCommand();
            AddCmdParameters(cmd, parameters);
            cmd.CommandText = query;
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static List<string> ExecuteGetStringQuery(string query, List<string[]> parameters)
        {
            List<string> values = new List<string>();
            MySqlConnection cnn = CreateConnection();
            MySqlCommand cmd = new MySqlCommand();
            AddCmdParameters(cmd, parameters);
            cmd.CommandText = query;
            cmd.Connection = cnn;
            cnn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            values.Clear();
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    values.Add(reader.GetString(i));
                }
            }
            cnn.Close();
            return values;
        }
    }
}
