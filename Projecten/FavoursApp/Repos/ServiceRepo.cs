using AdditionalFiles;
using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using DAL.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly IServiceDB servicecontext;
        public ServiceRepo()
        {
            if (Beans.dataSource == "sql") servicecontext = new ServiceDB();
            else if (Beans.dataSource == "memory") servicecontext = new ServiceMemoryContext();
        }
        public Service GetServiceDataById(string serviceID) => servicecontext.GetServiceDataById(serviceID);
        public void InsertNewServiceData(Service service, string datestring) => servicecontext.InsertNewServiceData(service, datestring);
    }
}
