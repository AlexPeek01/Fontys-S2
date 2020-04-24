using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


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
            List<string> networkData;
            List<string> networkName = new List<string>();
            List<string> networkImage = new List<string>();
            List<string> networkDescription = new List<string>();
            foreach (string networkid in usersNetworks)
            {
                networkData = FavoursNetworkManager.GetNetworkData(networkid);
                networkName.Add(networkData[1]);
                networkImage.Add(networkData[3]);
                networkDescription.Add(networkData[4]);
            }
            string[] networkNameArray = networkName.ToArray();
            string[] networkImageArray = networkImage.ToArray();
            string[] networkDescriptionArray = networkDescription.ToArray();
            ViewData["netwerknaam"] = networkNameArray;
            ViewData["netwerkafbeelding"] = networkImageArray;
            ViewData["netwerkbeschrijving"] = networkDescriptionArray;
            return View();
        }
    }
}