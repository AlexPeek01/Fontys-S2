using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionalFiles.Interfaces.IRepos
{
    public interface IServiceRepo
    {
        void InsertNewServiceData(Service service, string datestring);
        Service GetServiceDataById(string serviceID);
        List<Service> GetServicesByNetworkID(string ID);

    }
}
