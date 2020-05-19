using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursUserManager
    {
        public void InsertNewProfileData(string id)
        {
            UserDB.InsertNewProfileData(id);
        }
    }
}
