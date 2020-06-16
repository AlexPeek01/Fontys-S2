using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursUserManager : IUserManager
    {
        private readonly IUserDB userdal;
        public FavoursUserManager(IUserDB implementation)
        {
            userdal = implementation;
        }
        public void InsertNewProfileData(string id, string username, string hashedpassword, string email) => userdal.InsertNewProfileData(id, username, hashedpassword, email);
        public User GetUserDataByUsername(string username, string HashedPassword) => userdal.GetUserDataByUsername(username, HashedPassword);
        public User GetUserData(string userid) => userdal.GetUserData(userid);
    }
}
