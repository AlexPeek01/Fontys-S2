using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using FavoursApp.Models;
using Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models;
using Org.BouncyCastle.Asn1.Cms;
using Repos;

namespace FavoursApp.Controllers
{
    public class NetworkController : Controller
    {
        #region Setup
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly INetworkManager networkManager;
        private readonly IServiceManager serviceManager;
        private readonly IImageManager imagemanager;
        private readonly IIdentificationManager identificationmanager;

        public NetworkController(IHostingEnvironment _hostingEnvironment, IConfiguration config)
        {
            Factory factory = new Factory();
            networkManager = factory.GetNetworkManager(config["HandlerType"]);
            serviceManager = factory.GetServiceManager(config["HandlerType"]);
            imagemanager = factory.GetImageManager(config["HandlerType"]);
            identificationmanager = factory.GetIdentificationManager(config["HandlerType"]);
            this._hostingEnvironment = _hostingEnvironment;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            // Get a users networks
            string userid = HttpContext.Session.GetString("UserData");
            Network[] networkData = networkManager.GetUsersNetworks(userid);
            return View(networkData);
        }
        [HttpGet]
        public IActionResult Search()
        {
            List<Network> publicNetworkList = networkManager.GetPublicNetworks();
            return View(publicNetworkList);
        }
        [HttpGet]
        public IActionResult JoinNetwork(string networkid)
        {
            Network network = networkManager.GetNetworkData(networkid);
            return View(network);
        }
        [HttpPost]
        public IActionResult JoinNetwork(JoinNetworkModel joinmodel)
        {
            if (joinmodel.Password != null)
            {
                string hashedPassword = identificationmanager.Encrypt(joinmodel.Password);
                if (hashedPassword == networkManager.GetHashedPassword(joinmodel.NetworkID))
                {
                    networkManager.CreateUserNetworkConnection(HttpContext.Session.GetString("UserData"), joinmodel.NetworkID);
                    return RedirectToAction("nw", "Network", new { id = joinmodel.NetworkID });
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult nw(string id)
        {
            // Retrieve needed data
            if (!networkManager.CheckPermission(id, HttpContext.Session.GetString("UserData")))
            {
                return RedirectToAction("JoinNetwork", "Network", new { networkid = id });
            }
            Network network = networkManager.GetNetworkData(id);
            List<Service> services = serviceManager.GetServices(id);
            string[] categories = networkManager.GetNetworksCategories(id).ToArray();

            // Pass data to view
            ServicesInNetworkModel model = new ServicesInNetworkModel(network, services);
            ViewData["NetworkID"] = id;
            ViewData["categories"] = categories;
            return View(model);
        }
        public async Task<IActionResult> CreateService(IFormFile image, Service service)
        {
            // Set service model data
            service.Images = await SaveImage(image); ;
            service.ServiceID = identificationmanager.GetUniqueKey();
            service.PostersID = HttpContext.Session.GetString("UserData");
            // Insert data into datasource
            serviceManager.InsertNewServiceData(service);
            return RedirectToAction("nw", "Network", new { id = service.NetworkID });
        }
        public async Task<IActionResult> CreateNetwork(Network model2, IFormFile image)
        {
            // Handle image file
            model2.Image = await SaveImage(image);
            model2.Password = identificationmanager.Encrypt(model2.Password);
            if (ModelState.IsValid)
            {
                // Insert new network into datasource
                string userId = HttpContext.Session.GetString("UserData");
                string networkID = networkManager.InsertNewNetworkData(model2, userId);
                return RedirectToAction("nw", "Network", new { id = networkID });
            }
            return RedirectToAction("Index");
        }
        public void LeaveNetwork(string networkID)
        {
            string userid = HttpContext.Session.GetString("UserData");
            networkManager.RemoveUserNetworkCon(userid, networkID);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            if (image != null)
            {
                string filename = imagemanager.GetImageName(image.ContentType.Split('/')[1]);
                string filepath = imagemanager.GetFilePath(_hostingEnvironment.WebRootPath, filename);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                    await image.CopyToAsync(fileStream);
                return filename;
            }
            return "";
        }
    }
}