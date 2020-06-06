using AdditionalFiles;
using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using DAL.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos
{
    public class NetworkRepo : INetworkRepo
    {
        private readonly INetworkDB networkcontext;
        public NetworkRepo()
        {
            if (Beans.dataSource == "sql") networkcontext = new NetworkDB();
            else if (Beans.dataSource == "memory") networkcontext = new NetworkMemoryContext();
        }
        public void CreateUserNetworkConnection(string UserID, string NetworkID) => networkcontext.CreateUserNetworkConnection(UserID, NetworkID);
        public string[] GetCategorieIDs(string id) => networkcontext.GetCategorieIDs(id);
        public List<string> GetCategoryNamesByID(string[] categoryIds) => networkcontext.GetCategoryNamesByID(categoryIds);
        public Network GetNetworkDataByNetworkID(string networkId) => networkcontext.GetNetworkDataByNetworkID(networkId);
        public List<string> GetNetworkIdsByUserID(string UserID) => networkcontext.GetNetworkIdsByUserID(UserID);
        public List<Service> GetServicesByNetworkID(string ID) => networkcontext.GetServicesByNetworkID(ID);
        public List<Network> GetUsersNetworksData(List<string> networkIds) => networkcontext.GetUsersNetworksData(networkIds);
        public void InsertNewNetworkData(Network network) => networkcontext.InsertNewNetworkData(network);
        public void RemoveUserNetworkCon(string userId, string networkId) => networkcontext.RemoveUserNetworkCon(userId, networkId);
    }
}
