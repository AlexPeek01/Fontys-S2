using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using DAL.Memory;
using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursServiceManager : IServiceManager
    {
        private readonly IServiceRepo servicerepo;
        public FavoursServiceManager()
        {
            servicerepo = new ServiceRepo();
        }
        public void InsertNewServiceData(Service service)
        {
            // Convert date to required format
            string datestring = service.Date.ToString("yyyy-MM-dd HH:mm:ss");
            servicerepo.InsertNewServiceData(service, datestring);
        }
        public Service GetServiceDataById(string serviceID) => servicerepo.GetServiceDataById(serviceID);
    }
}
