using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface INetworkDB
    {
        string[] GetCategorieIDs(string id);
        List<string> GetCategoryNamesByID(string[] categoryIds);
        List<string> GetNetworkIdsByUserID(string UserID);
        List<Network> GetUsersNetworksData(List<string> networkIds);
        Network GetNetworkDataByNetworkID(string networkId);
        void InsertNewNetworkData(Network network);
        void CreateUserNetworkConnection(string UserID, string NetworkID);
        List<Service> GetServicesByNetworkID(string ID);
    }
}
