using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionalFiles.Interfaces.IManagers
{
    public interface IServiceManager
    {
        void InsertNewServiceData(Service service);
        Service GetServiceDataById(string serviceID);
        List<Service> GetServices(string ID);

    }
}
