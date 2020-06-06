using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using DAL.Memory;
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
        public FavoursUserManager()
        {
            userrepo = new UserRepo();
        }
        public void InsertNewProfileData(string id, string username, string hashedpassword, string email)
        {
            userrepo.InsertNewProfileData(id, username, hashedpassword, email);
        }
        public User GetUserDataByUsername(string username, string HashedPassword)
        {
            return userrepo.GetUserDataByUsername(username, HashedPassword);
        }
    }
}
