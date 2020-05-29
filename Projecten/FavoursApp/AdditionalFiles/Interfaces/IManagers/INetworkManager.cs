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
        List<Service> GetServices(string ID);
        Network[] GetUsersNetworks(string userID);
        Network GetNetworkData(string networkId);
        string InsertNewNetworkData(Network network, string UserID);
        void CreateUserNetworkConnection(string UserID, string NetworkID);
    }
}
