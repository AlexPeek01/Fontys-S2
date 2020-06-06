using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using Managers;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FavoursApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceManager servicemanager;
        public ServiceController()
        {
            servicemanager = new FavoursServiceManager();
        }
        public IActionResult Service(string serviceID)
        {
            return View(servicemanager.GetServiceDataById(serviceID));
        }
    }
}