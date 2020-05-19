using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FavoursApp.Models;
using Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FavoursApp.Controllers
{
    public class NetworkController : Controller
    {
        #region Setup
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public NetworkController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHostingEnvironment _hostingEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._hostingEnvironment = _hostingEnvironment;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            Network[] networkData = FavoursNetworkManager.GetUsersNetworks(user.Id);
            return View(networkData);
        }
        [HttpGet]
        public IActionResult nw(string id)
        {
            ViewData["NetworkID"] = id;
            Network network = FavoursNetworkManager.GetNetworkData(id);
            List<Service> services = FavoursNetworkManager.GetServices(id);
            ServicesInNetworkModel model = new ServicesInNetworkModel(network, services);
            string[] categories = FavoursNetworkManager.GetNetworksCategories(id).ToArray();
            ViewData["categories"] = categories;
            return View(model);
        }
        public async Task<IActionResult> CreateService(IFormFile image, Service service)
        {
            service.Images = ImageManager.SaveImage(image, _hostingEnvironment).ToString();
            var user = await userManager.GetUserAsync(HttpContext.User);
            service.PostersID = user.Id;
            service.ServiceID = IdentificationManager.GetUniqueKey();
            FavoursServiceManager.InsertNewServiceData(service);
            return RedirectToAction("nw", "Network");
            //return View(service);
        }
        [HttpGet]
        public IActionResult CreateNetwork()
        {
            return RedirectToAction("Index", "Network");
        }
        public async Task<IActionResult> CreateNetwork(Network model2, IFormFile image)
        {
            model2.Image = ImageManager.SaveImage(image, _hostingEnvironment);
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                string networkID = FavoursNetworkManager.InsertNewNetworkData(model2, user.Id);
                return RedirectToAction("nw", "Network", new { id = networkID });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return RedirectToAction("Index");
        }
    }
}