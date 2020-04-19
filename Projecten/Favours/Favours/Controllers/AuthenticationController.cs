using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Favours.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Favours.Data;
using Microsoft.AspNetCore.Http;

namespace Favours.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserInfo") != null)
            {
                return RedirectToAction("Index", "Network");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel lm)
        {
            string authCode = CreateSessionCookie.getAuthToken(lm.Email);
            List<string> userData = SQLConnection.ExecuteSearchQuery($"Select UserID,Email,Password From Users Where Email='{lm.Email.ToLower()}'");
            string password = getHashSha256(lm.Wachtwoord);
            if (password == userData.ToArray()[2])
            {
                HttpContext.Session.SetString("UserInfo", authCode);
                HttpContext.Session.SetInt32("UserID", Int32.Parse(userData[0]));
                return RedirectToAction("Index", "Network");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(NewUserModel newUser)
        {
            newUser.Password = getHashSha256(newUser.Password);
            Logic.AuthenticationCode authCode = new Logic.AuthenticationCode();
            newUser.AuthCode = authCode.GenerateAuthToken();
            newUser.InsertUserInDatabase(newUser);
            return RedirectToAction("Login","Authentication");
        }
        private string getHashSha256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}