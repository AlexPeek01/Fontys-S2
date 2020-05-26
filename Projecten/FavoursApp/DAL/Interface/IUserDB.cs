using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IUserDB
    {
        void InsertNewProfileData(string id, string username, string hashedpassword, string email);
        User GetUserDataByUsername(string username);
    }
}
