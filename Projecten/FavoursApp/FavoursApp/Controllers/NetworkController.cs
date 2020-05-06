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
            Network[] networkData = FavoursNetworkManager.GetUsersNetworks(user.Id);
            return View(networkData);
        }
        [HttpGet]
        public IActionResult nw(string id)
        {
            Network network = FavoursNetworkManager.GetNetworkData(id);
            string[] categories = FavoursNetworkManager.GetNetworksCategories(id).ToArray();
            ViewData["categories"] = categories;
            return View(network);
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
        public async Task<IActionResult> CreateNetwork(Network model2)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            model2.ID = IdentificationManager.GetUniqueKey();
            if (ModelState.IsValid)
            {
                model2.UserCount = 1;
                FavoursNetworkManager.InsertNewNetworkData(model2, user.Id);
                return RedirectToAction("nw", "Network", new { id = model2.ID });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return RedirectToAction("Index");
        }
    }
}