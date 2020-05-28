using DAL;
using Managers.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursUserManager : IUserManager
    {
        UserDB userDB = new UserDB();
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
