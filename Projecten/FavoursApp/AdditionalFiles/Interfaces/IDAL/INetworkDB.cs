using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface INetworkDB
    {
        List<string> GetCategoryNamesByID(string[] categoryIds);
        List<string> GetNetworkIdsByUserID(string UserID);
        List<Service> GetServicesByNetworkID(string ID);
        List<Network> GetUsersNetworksData(List<string> networkIds);
        Network GetNetworkDataByNetworkID(string networkId);
        string[] GetCategorieIDs(string id);
        void InsertNewNetworkData(Network network);
        void CreateUserNetworkConnection(string UserID, string NetworkID);
    }
}
