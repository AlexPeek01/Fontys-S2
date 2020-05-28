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
        public string Email { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public User(string UserId)
        {
            this.UserId = UserId;
        }
    }
}
