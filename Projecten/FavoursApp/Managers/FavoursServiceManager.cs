using AdditionalFiles.Interfaces.IDAL;
using DAL;
using DAL.Memory;
using Managers.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursServiceManager : IServiceManager
    {
        private readonly IServiceDB servicedb;
        public FavoursServiceManager()
        {
            if (AdditionalFiles.Beans.dataSource == "sql")
            {
                servicedb = new ServiceDB();
            }
            else if (AdditionalFiles.Beans.dataSource == "memory")
            {
                servicedb = new ServiceMemoryContext();
            }
        }
        public void InsertNewServiceData(Service service)
        {
            // Convert date to required format
            string datestring = service.Date.ToString("yyyy-MM-dd HH:mm:ss");
            servicedb.InsertNewServiceData(service, datestring);
        }
        public Service GetServiceDataById(string serviceID)
        {
            return servicedb.GetServiceDataById(serviceID);
        }
    }
}
