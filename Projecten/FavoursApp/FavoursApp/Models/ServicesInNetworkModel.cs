using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace FavoursApp.Models
{
    public class ServicesInNetworkModel
    {
        public Network network { get; private set; }
        public List<Service> serviceList { get; private set; }
        public ServicesInNetworkModel(Network network, List<Service> serviceList)
        {
            this.network = network;
            this.serviceList = serviceList;
        }
    }
}
