using AdditionalFiles.Interfaces.IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UserDB : IUserDB
    {
        public void InsertNewProfileData(string id, string username, string hashedpassword, string email)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@UserID", id},
                new string[] { "@Username", username },
                new string[] { "@Password", hashedpassword},
                new string[] { "@Email", email }
            };
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Users (Id, Email, UserName, HashedPassword) VALUES(@UserID, @Username, @Password, @Email)", parameters);
        }
        public User GetUserDataByUsername(string username, string HashedPassword)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@Username", username},
                new string[] { "@Password", HashedPassword }
            };
            string[] userdata = SQLConnection.ExecuteSearchQuery($"SELECT * FROM users WHERE UserName = @Username AND HashedPassword = @Password", parameters).ToArray();
            if(userdata.Length > 0)
            {
                User user = new User(userdata[0])
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
        public User GetUserData(string userid)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@UserID", userid},
            };
            string[] userdata = SQLConnection.ExecuteSearchQuery($"SELECT * FROM users WHERE Id = @UserID", parameters).ToArray();
            if (userdata.Length > 0)
            {
                User user = new User(userdata[0])
                {
                    Email = userdata[1],
                    Username = userdata[2],
                    HashedPassword = userdata[3],
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
