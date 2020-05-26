using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursUserManager
    {
        UserDB userDB = new UserDB();
        public void InsertNewProfileData(string id)
        {
            UserDB.InsertNewProfileData(id);
        }
        public User GetUserDataByUserID(string userId)
        {
            return userDB.GetUserDataByUserID(userId);
        }
    }
}
