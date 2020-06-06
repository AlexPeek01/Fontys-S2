using AdditionalFiles;
using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using DAL.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly IUserDB usercontext;
        public UserRepo()
        {
            if (Beans.dataSource == "sql") usercontext = new UserDB();
            else if (Beans.dataSource == "memory") usercontext = new UserMemoryContext();
        }
        public User GetUserDataByUsername(string username, string password) => usercontext.GetUserDataByUsername(username, password);
        public void InsertNewProfileData(string id, string username, string hashedpassword, string email) => usercontext.InsertNewProfileData(id, username, hashedpassword, email);
    }
}
