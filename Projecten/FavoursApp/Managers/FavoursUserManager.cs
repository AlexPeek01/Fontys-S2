using AdditionalFiles.Interfaces.IDAL;
using DAL;
using DAL.Memory;
using Managers.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursUserManager : IUserManager
    {
        private readonly IUserDB userDB;
        public FavoursUserManager()
        {
            if (AdditionalFiles.Beans.dataSource == "sql")
            {
                userDB = new UserDB();
            }
            else if (AdditionalFiles.Beans.dataSource == "memory")
            {
                userDB = new UserMemoryContext();
            }
            
        }
        public void InsertNewProfileData(string id, string username, string hashedpassword, string email)
        {
            userDB.InsertNewProfileData(id, username, hashedpassword, email);
        }
        public User GetUserDataByUsername(string username, string HashedPassword)
        {
            return userDB.GetUserDataByUsername(username, HashedPassword);
        }
    }
}
