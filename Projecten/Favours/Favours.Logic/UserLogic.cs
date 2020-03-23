using Favours.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Favours.Logic
{
    public class UserLogic
    {

        public string getUserByName(string name)
        {
            UserData userData = new UserData();
            return userData.getUserByName(name);
        }

    }
}
