using AdditionalFiles;
using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly IServiceDB servicecontext;
        public ServiceRepo(IServiceDB implementation)
        {
            servicecontext = implementation;
        }
        public Service GetServiceDataById(string serviceID) => servicecontext.GetServiceDataById(serviceID);
        public void InsertNewServiceData(Service service, string datestring) => servicecontext.InsertNewServiceData(service, datestring);
        public List<Service> GetServicesByNetworkID(string ID) => servicecontext.GetServicesByNetworkID(ID);

    }
}
