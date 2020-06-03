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
        private IUserDB usercontext;
        public UserRepo()
        {
            if (Beans.dataSource == "sql") usercontext = new UserDB();
            else usercontext = new UserMemoryContext();
        }

        public User GetUserDataByUsername(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void InsertNewProfileData(string id, string username, string hashedpassword, string email) => usercontext.InsertNewProfileData(id, username, hashedpassword, email);
    }
}
