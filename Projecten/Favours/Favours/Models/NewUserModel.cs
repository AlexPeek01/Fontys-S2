using Favours.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Models
{
    public class NewUserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string AuthCode { get; set; }
        public NewUserModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public NewUserModel()
        {

        }
        public void InsertUserInDatabase(NewUserModel newUser)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Users (Email,Password,AuthCode) VALUES ('{newUser.Email}','{newUser.Password}','{newUser.AuthCode}')");
        }
    }
}
