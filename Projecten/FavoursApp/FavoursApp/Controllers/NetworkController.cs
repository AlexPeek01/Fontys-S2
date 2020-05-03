using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoursApp.Models;
using Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FavoursApp.Controllers
{
    public class NetworkController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public NetworkController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            List<string> usersNetworks = FavoursNetworkManager.GetNetworkIDsByUserID(user.Id);
            Network[] networkData;
            List<Network> networks = new List<Network>();
            foreach (string networkid in usersNetworks)
            {
                networks.Add(FavoursNetworkManager.GetNetworkData(networkid));
            }
            networkData = networks.ToArray();
            return View(networkData);
        }
        [HttpGet]
        public IActionResult Page(string id)
        {
            return View();
        }
        public void ShowCreatedEvent()
        {

        }
        [HttpGet]
        public IActionResult CreateNetwork()
        {
            return RedirectToAction("Index", "Network");
        }
        [HttpPost]
        public async Task<IActionResult> CreateNetwork(CreateNetworkModel model2)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            model2.id = IdentificationManager.GetUniqueKey();
            if (ModelState.IsValid)
            {
                Network newNetwork = new Network(model2.name, model2.memberLimit);
                newNetwork.ID = model2.id;
                newNetwork.Description = model2.description;
                newNetwork.Image = model2.image.Split("base64,")[1];
                newNetwork.Password = model2.password;
                newNetwork.UserCount = 1;
                FavoursNetworkManager.InsertNewNetworkData(newNetwork, user.Id);
                return RedirectToAction("Page", "Network", newNetwork.ID);
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return RedirectToAction("Index");
        }
    }
}