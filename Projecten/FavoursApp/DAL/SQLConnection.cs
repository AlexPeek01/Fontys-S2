﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class SQLConnection
    {
        private MySqlDataReader reader;
        private static MySqlConnection CreateConnection()
        {
            MySqlConnection cnn;
            string connectionString = $"server=ns1-442.axc.nl;database=alexpfw442_favours;uid=alexpfw442_favours;pwd=sruovaf2!;";
            cnn = new MySqlConnection(connectionString);
            return cnn;
        }
        public static List<string[]> ExecuteSearchQueryWithArrayReturn(string query)
        {
            string[] tempStrArr;
            List<string[]> values = new List<string[]>();
            MySqlConnection cnn = CreateConnection();
            MySqlCommand cmd = new MySqlCommand();
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

        public static List<string> ExecuteSearchQuery(string query)
        {
            List<string> values = new List<string>();
            MySqlConnection cnn = CreateConnection();
            MySqlCommand cmd = new MySqlCommand();
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
        public static List<string>[] ExecuteSearchQueryArray(string[] query)
        {
            List<string>[] values = new List<string>[query.Length];
            MySqlConnection cnn = CreateConnection();
            MySqlCommand[] cmd = new MySqlCommand[query.Length];
            for (int i = 0; i < cmd.Length; i++)
            {
                cmd[i] = new MySqlCommand();
                cmd[i].CommandText = query[i];
                cmd[i].Connection = cnn;
            }
            cnn.Open();
            for (int i = 0; i < cmd.Length; i++)
            {
                MySqlDataReader reader = cmd[i].ExecuteReader();
                values[i].Clear();
                try
                {
                    while (reader.Read())
                    {
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            values[i].Add(reader[j].ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    string eString = e.ToString();
                }
            }

            cnn.Close();
            return values;
        }

        public static void ExecuteNonSearchQuery(string query)
        {
            MySqlConnection cnn = CreateConnection();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void ExecuteNonSearchQueryArray(string[] query)
        {
            MySqlConnection cnn = CreateConnection();

            MySqlCommand[] cmd = new MySqlCommand[query.Length];
            for (int i = 0; i < cmd.Length; i++)
            {
                cmd[i] = new MySqlCommand();
                cmd[i].CommandText = query[i];
                cmd[i].Connection = cnn;
            }
            cnn.Open();
            for (int i = 0; i < cmd.Length; i++)
            {
                cmd[i].ExecuteNonQuery();
            }
            cnn.Close();
        }

        public static List<string> ExecuteGetStringQuery(string query)
        {
            List<string> values = new List<string>();
            MySqlConnection cnn = CreateConnection();
            MySqlCommand cmd = new MySqlCommand();
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