using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursUserManager
    {
        public static void InsertNewProfileData(string id)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Users (Id) VALUES('{id}')");
        }
    }
}
