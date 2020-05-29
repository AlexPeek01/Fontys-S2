using DAL;
using DAL.Interface;
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
            servicedb = new ServiceDB();
        }
        public void InsertNewServiceData(Service service)
        {
            // Convert date to required format
            string datestring = service.Date.ToString("yyyy-MM-dd HH:mm:ss");
            servicedb.InsertNewServiceData(service, datestring);
        }
    }
}
