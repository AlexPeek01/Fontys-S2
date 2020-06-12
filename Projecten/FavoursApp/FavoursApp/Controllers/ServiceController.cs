using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models;

namespace FavoursApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceManager servicemanager;
        public ServiceController(IConfiguration config)
        {
            Factory factory = new Factory();
            servicemanager = factory.GetServiceManager(config["HandlerType"]);
        }
        public IActionResult Service(string serviceID)
        {
            return View(servicemanager.GetServiceDataById(serviceID));
        }
    }
}