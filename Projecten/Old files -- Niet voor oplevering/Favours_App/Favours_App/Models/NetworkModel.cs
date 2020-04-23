using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours_App.Models
{
    public class NetworkModel
    {
        public List<Service> serviceList;
        private string networkName { get; set; }
        
        public NetworkModel(string _networkName)
        {
            serviceList = new List<Service>();
            networkName = _networkName;
        }
        public NetworkModel()
        {

        }
    }
}
