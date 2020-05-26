using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User
    {
        public string UserId { get; private set; }
        public string FirstName { get; set; }
        public string Insertion { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public User(string UserId)
        {
            
        }
    }
}
