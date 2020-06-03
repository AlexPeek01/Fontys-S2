using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FavoursApp.Models;
using Managers;
using Managers.Interfaces;
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
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly INetworkManager networkManager;
        private readonly IServiceManager serviceManager;

        public NetworkController(IHostingEnvironment _hostingEnvironment)
        {
            if (networkManager == null) networkManager = new FavoursNetworkManager();
            if (serviceManager == null) serviceManager = new FavoursServiceManager();
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
        public IActionResult nw(string id)
        {
            // Retrieve needed data
            Network network = networkManager.GetNetworkData(id);
            List<Service> services = networkManager.GetServices(id);
            string[] categories = networkManager.GetNetworksCategories(id).ToArray();

            // Pass data to view
            ServicesInNetworkModel model = new ServicesInNetworkModel(network, services);
            ViewData["NetworkID"] = id;
            ViewData["categories"] = categories;
            return View(model);
        }
        public async Task<IActionResult> CreateService(IFormFile image, Service service)
        {
            // Handle image file
            string filename = ImageHelper.GetImageName(image.ContentType.Split('/')[1]);
            await ImageHelper.SaveImage(image, _hostingEnvironment, filename);

            // Set service model data
            service.Images = filename;
            service.ServiceID = IdentificationHelper.GetUniqueKey();
            service.PostersID = HttpContext.Session.GetString("UserData");
            // Insert data into datasource
            serviceManager.InsertNewServiceData(service);
            return RedirectToAction("nw", "Network", new { id = service.NetworkID });
        }
        public async Task<IActionResult> CreateNetwork(Network model2, IFormFile image)
        {
            // Handle image file
            string filename = ImageHelper.GetImageName(image.ContentType.Split('/')[1]);
            await ImageHelper.SaveImage(image, _hostingEnvironment, filename);
            model2.Image = filename;

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
    }
}