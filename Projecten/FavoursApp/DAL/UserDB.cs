using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UserDB
    {
        public void InsertNewProfileData(string id, string username, string hashedpassword, string email)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Users (Id, Email, UserName, HashedPassword) VALUES('{id}', '{email}','{username}','{hashedpassword}')");
        }
        public User GetUserDataByUsername(string username, string HashedPassword)
        {
            string[] userdata = SQLConnection.ExecuteSearchQuery($"SELECT * FROM users WHERE UserName = '{username}' AND HashedPassword = '{HashedPassword}'").ToArray();
            if(userdata.Length > 0)
            {
                User user = new User(userdata[0], userdata[3])
                {
                    Email = userdata[1],
                    Username = userdata[2],
                    FirstName = userdata[4],
                    Insertion = userdata[5],
                    LastName = userdata[6],
                    Phone = userdata[7]
                };
                return user;
            }
            return null;
        }
    }
}
