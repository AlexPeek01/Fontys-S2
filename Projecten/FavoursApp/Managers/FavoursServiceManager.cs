using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursServiceManager : IServiceManager
    {
        private readonly IServiceDB servicedal;
        public FavoursServiceManager(IServiceDB implementation)
        {
            servicedal = implementation;
        }
        public void InsertNewServiceData(Service service)
        {
            // Convert date to required format
            string datestring = service.Date.ToString("yyyy-MM-dd HH:mm:ss");
            servicedal.InsertNewServiceData(service, datestring);
        }
        public Service GetServiceDataById(string serviceID) => servicedal.GetServiceDataById(serviceID);
        public List<Service> GetServices(string ID) => servicedal.GetServicesByNetworkID(ID);
    }
}
