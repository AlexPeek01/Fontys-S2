using AdditionalFiles.Interfaces.IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Memory
{
    public class ServiceMemoryContext : IServiceDB
    {
        public Service GetServiceDataById(string serviceID)
        {
            throw new NotImplementedException();
        }

        public void InsertNewServiceData(Service service, string datestring)
        {
            throw new NotImplementedException();
        }
    }
}
