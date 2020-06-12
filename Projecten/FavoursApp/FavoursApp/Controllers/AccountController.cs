using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FavoursApp.Models;
using Managers;
using Microsoft.AspNetCore.Http;
using Models;
using AdditionalFiles.Interfaces.IManagers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace FavoursApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager favoursusermanager;
        public AccountController(IConfiguration config)
        {
            this.favoursusermanager = new Factory().GetUserManager(config["HandlerType"]);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle required data
                string id = IdentificationHelper.GetUniqueKey();
                string hashedPassword = IdentificationHelper.Encrypt(model.Password);

                // Insert new user into database
                favoursusermanager.InsertNewProfileData(id, model.Username, hashedPassword, model.Email);

                return RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Hash input password
                string HashedPassword = IdentificationHelper.Encrypt(model.Password);

                // Get userdata by username
                User user = favoursusermanager.GetUserDataByUsername(model.Username, HashedPassword);

                if(user != null)
                {
                    HttpContext.Session.SetString("UserData", user.UserId);
                    return RedirectToAction("Index", "Network");
                }
                    
            }
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Delete logged in user cookie
            HttpContext.Session.Remove("UserData");
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult Settings()
        {
            string userid = HttpContext.Session.GetString("UserData");
            User user = favoursusermanager.GetUserData(userid);
            return View(user);
        }
        [HttpPost]
        public IActionResult Settings(User user)
        {
            
            return View(user);
        }
    }
}