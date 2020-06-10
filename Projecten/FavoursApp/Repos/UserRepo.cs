using AdditionalFiles;
using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly IUserDB usercontext;
        public UserRepo(IUserDB implementation)
        {
            usercontext = implementation;
        }
        public User GetUserDataByUsername(string username, string password) => usercontext.GetUserDataByUsername(username, password);
        public void InsertNewProfileData(string id, string username, string hashedpassword, string email) => usercontext.InsertNewProfileData(id, username, hashedpassword, email);
    }
}
