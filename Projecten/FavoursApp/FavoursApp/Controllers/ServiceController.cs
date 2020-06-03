using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managers;
using Managers.Interfaces;
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