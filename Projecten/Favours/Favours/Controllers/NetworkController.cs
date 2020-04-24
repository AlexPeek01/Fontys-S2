using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Managers;

namespace Favours.Controllers
{
    public class NetworkController : Controller
    {
        public IActionResult Index()
        {
            int UserID = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            List<string> usersNetworks = UserManager.GetNetworksByUserID(UserID);
            List<string> networkData = NetworkManager.GetNetworkData();

            string[] networkName = new string[networkData.Count/5];
            string[] networkImage = new string[networkData.Count / 5];
            string[] networkDescription = new string[networkData.Count / 5];
            int j = 0;
            for (int i = 0; i < usersNetworks.Count; i++)
            {
                i++;
                networkName[j] = networkData[i];
                i += 2;
                networkImage[j] = networkData[i];
                i++;
                networkDescription[j] = networkData[i];
                j++;
            }
            ViewData["netwerknaam"] = networkName;
            ViewData["netwerkafbeelding"] = networkImage;
            ViewData["netwerkbeschrijving"] = networkDescription;
            return View();
        }
    }
}