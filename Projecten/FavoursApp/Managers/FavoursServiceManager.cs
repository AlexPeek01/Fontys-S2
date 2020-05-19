using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursServiceManager
    {
        public static void InsertNewServiceData(Service service)
        {
            string datestring = service.Date.ToString("yyyy-MM-dd HH:mm:ss");
            ServiceDB.InsertNewServiceData(service, datestring);
        }
    }
}
