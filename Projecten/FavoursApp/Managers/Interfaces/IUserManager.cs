using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Interfaces
{
    public interface IUserManager
    {
        void InsertNewProfileData(string id, string username, string hashedpassword, string email);
        User GetUserDataByUsername(string username);
    }
}
