using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UserDB
    {
        public static void InsertNewProfileData(string id)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Users (Id) VALUES('{id}')");
        }
    }
}
