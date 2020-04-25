using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoursApp.Models
{
    public class CreateNetworkModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string password { get; set; }
        public string image { get; set; }
        public int memberLimit { get; set; }
        public bool visible { get; set; }
    }
}
