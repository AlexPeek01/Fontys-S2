using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Favours.Data;
using Microsoft.AspNetCore.Mvc;

namespace Favours.Controllers
{
    public class NetwerkController : Controller
    {
        public IActionResult Index()
        {
            List<string> netwerkendata = SQLConnection.ExecuteSearchQuery($"Select * From Netwerken");
            string[] netwerknaam = new string[netwerkendata.Count/5];
            string[] netwerkafbeelding = new string[netwerkendata.Count / 5];
            string[] netwerkbeschrijving = new string[netwerkendata.Count / 5];
            int j = 0;
            for (int i = 0; i < netwerkendata.Count; i++)
            {
                i++;
                netwerknaam[j] = netwerkendata[i];
                i += 2;
                netwerkafbeelding[j] = netwerkendata[i];
                i++;
                netwerkbeschrijving[j] = netwerkendata[i];
                j++;
            }
            ViewData["netwerknaam"] = netwerknaam;
            ViewData["netwerkafbeelding"] = netwerkafbeelding;
            ViewData["netwerkbeschrijving"] = netwerkbeschrijving;
            return View();
        }
    }
}