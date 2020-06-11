using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursUserManager : IUserManager
    {
        private readonly IUserRepo userrepo;
        public FavoursUserManager(IUserRepo implementation)
        {
            userrepo = implementation;
        }
        public void InsertNewProfileData(string id, string username, string hashedpassword, string email)
        {
            userrepo.InsertNewProfileData(id, username, hashedpassword, email);
        }
        public User GetUserDataByUsername(string username, string HashedPassword)
        {
            return userrepo.GetUserDataByUsername(username, HashedPassword);
        }
        public User GetUserData(string userid) => userrepo.GetUserData(userid);
    }
}
