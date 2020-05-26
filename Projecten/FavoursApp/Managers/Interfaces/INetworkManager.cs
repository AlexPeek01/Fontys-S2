using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Interfaces
{
    public interface INetworkManager
    {
        List<string> GetNetworksCategories(string id);
        List<string> GetNetworkIDsByUserID(string UserID);
        Network GetNetworkData(string networkId);
        Network[] GetUsersNetworks(string userID);
        string InsertNewNetworkData(Network network, string UserID);
        void CreateUserNetworkConnection(string UserID, string NetworkID);
        List<Service> GetServices(string ID);
    }
}
