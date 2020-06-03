using AdditionalFiles.Interfaces.IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Memory
{
    public class UserMemoryContext : IUserDB
    {
        public User GetUserDataByUsername(string username, string HashedPassword)
        {
            List<User> users = new List<User>()
            {
                new User("1") { Username = "Alex1", HashedPassword = "AlexWW1" },
                new User("2") { Username = "Alex2", HashedPassword = "AlexWW2" },
                new User("3") { Username = "Alex3", HashedPassword = "AlexWW3" },
                new User("4") { Username = "Alex2", HashedPassword = "AlexWW4" },
            };
            foreach(User user in users)
            {
                if(username ==  user.Username && HashedPassword == user.HashedPassword)
                {
                    return user;
                }
            }
            return null;
        }

        public void InsertNewProfileData(string id, string username, string hashedpassword, string email)
        {

        }
    }
}
