using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using FavoursApp.Models;
using Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models;

namespace FavoursApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceManager servicemanager;
        private readonly IUserManager usermanager;
        public ServiceController(IConfiguration config)
        {
            Factory factory = new Factory();
            servicemanager = factory.GetServiceManager(config["HandlerType"]);
            usermanager = factory.GetUserManager(config["HandlerType"]);
        }
        public IActionResult Service(string serviceID)
        {
            Service service = servicemanager.GetServiceDataById(serviceID);
            User user = usermanager.GetUserData(service.PostersID);
            return View(new ServiceWithUser(user, service));
        }
        [HttpGet]
        public IActionResult Message(string posterid, string serviceid)
        {
            if (string.IsNullOrEmpty(posterid) || string.IsNullOrEmpty(serviceid)) return RedirectToAction("Index", "Network");
            Service service = servicemanager.GetServiceDataById(serviceid);
            User user = usermanager.GetUserData(posterid);
            return View(new ServiceWithUser(user, service));
        }
        [HttpPost]
        public IActionResult Message(string email, string message, string overloading)
        {
            return RedirectToAction("Index", "Network");
        }
    }
}