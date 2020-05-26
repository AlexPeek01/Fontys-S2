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
using Managers.Interfaces;

namespace FavoursApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager favoursusermanager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.favoursusermanager = new FavoursUserManager();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
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
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Get userdata by username
                User user = favoursusermanager.GetUserDataByUsername(model.Username);

                // Set userid in session cookie
                HttpContext.Session.SetString("UserData", user.UserId);

                return RedirectToAction("Index", "Network");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Delete logged in user cookie
            //HttpContext.Session.Remove("UserData");
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}