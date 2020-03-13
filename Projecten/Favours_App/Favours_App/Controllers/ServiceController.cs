using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Favours_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Favours_App.Controllers
{
    public class ServiceController : Controller
    {
        NetworkModel network1 = new NetworkModel();
        private List<Service> serviceMock = new List<Service>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                network1.serviceList.Add(service);
                return RedirectToAction("GetAllServices");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult GetAllServices()
        {
            return View(network1.serviceList);
        }
    }
}