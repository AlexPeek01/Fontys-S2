using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionalFiles.Interfaces.IManagers
{
    public interface IUserManager
    {
        User GetUserDataByUsername(string username, string password);
        void InsertNewProfileData(string id, string username, string hashedpassword, string email);
        User GetUserData(string userid);
    }
}
