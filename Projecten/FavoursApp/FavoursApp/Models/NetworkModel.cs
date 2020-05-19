using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoursApp.Models
{
    public class NetworkModel
    {
        public string NetworkName { get; set; }
        public string Description { get; set; }
        public string Password { get; private set; }
        public string Image { get; set; }
        public string ImageID { get; set; }
        public int UserCount { get; set; }
        public int MemberLimit { get; set; }
        public int Visible { get; set; }
    }
}
