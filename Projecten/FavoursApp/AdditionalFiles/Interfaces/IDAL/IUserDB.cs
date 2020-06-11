using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionalFiles.Interfaces.IDAL
{
    public interface IUserDB
    {
        User GetUserDataByUsername(string username, string HashedPassword);
        void InsertNewProfileData(string id, string username, string hashedpassword, string email);
        User GetUserData(string userid);
    }
}
