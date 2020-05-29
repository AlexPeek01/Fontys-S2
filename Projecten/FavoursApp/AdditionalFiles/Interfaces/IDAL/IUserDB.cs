using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IUserDB
    {
        User GetUserDataByUsername(string username);
        void InsertNewProfileData(string id, string username, string hashedpassword, string email);
    }
}
