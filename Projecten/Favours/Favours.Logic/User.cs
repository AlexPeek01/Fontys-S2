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
        public int GetUserID()
        {
            return userId;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string GetFirstName()
        {
            return firstName;
        }
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public string GetInsertion()
        {
            return insertion;
        }
        public void SetInsertion(string insertion)
        {
            this.insertion = insertion;
        }
        public string GetLastName()
        {
            return lastName;
        }
        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }
        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public string GetPhone()
        {
            return phone;
        }
        public void SetPhone(string phone)
        {
            this.phone = phone;
        }
    }
}
