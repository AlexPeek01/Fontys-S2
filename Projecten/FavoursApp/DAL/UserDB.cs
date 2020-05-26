using Models;
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
        public User GetUserDataByUserID(string userId)
        {
            string[] userdata = SQLConnection.ExecuteSearchQuery($"SELECT * FROM users WHERE Id = {userId}").ToArray();
            if(userdata.Length > 0)
            {
                User user = new User(userdata[0])
                {
                    FirstName = userdata[1],
                    Insertion = userdata[2],
                    LastName = userdata[3],
                    Phone = userdata[4],
                };
                return user;
            }
            return null;
        }
    }
}
