using AdditionalFiles;
using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IRepos;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos
{
    public class NetworkRepo : INetworkRepo
    {
        private readonly INetworkDB networkcontext;
        public NetworkRepo(INetworkDB implementation)
        {
            networkcontext = implementation;
        }
        public bool CheckPermission(string userid, string networkid) => networkcontext.CheckPermission(networkid, userid);
        public void CreateUserNetworkConnection(string UserID, string NetworkID) => networkcontext.CreateUserNetworkConnection(UserID, NetworkID);
        public string[] GetCategorieIDs(string id) => networkcontext.GetCategorieIDs(id);
        public List<string> GetCategoryNamesByID(string[] categoryIds) => networkcontext.GetCategoryNamesByID(categoryIds);
        public Network GetNetworkDataByNetworkID(string networkId) => networkcontext.GetNetworkDataByNetworkID(networkId);
        public List<Network> GetUsersNetworksData(string userid) => networkcontext.GetUsersNetworksData(userid);
        public void InsertNewNetworkData(Network network) => networkcontext.InsertNewNetworkData(network);
        public void RemoveUserNetworkCon(string userId, string networkId) => networkcontext.RemoveUserNetworkCon(userId, networkId);
        public string GetHashedPassword(string networkid) => networkcontext.GetHashedPassword(networkid);
        public List<Network> GetPublicNetworks() => networkcontext.GetPublicNetworks();
    }
}
