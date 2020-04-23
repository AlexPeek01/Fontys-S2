using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Logic
{
    public class User
    {
        private int userId;
        private string email;
        private string password;
        private string firstName;
        private string insertion;
        private string lastName;
        private string phone;
        private List<Service> eventList;
        private List<Network> networkList;
        public User(string _email, string _password)
        {
            eventList = new List<Service>();
            networkList = new List<Network>();
            this.email = _email;
            this.password = _password;
        }
    }
}
