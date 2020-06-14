using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionalFiles.Interfaces.IRepos
{
    public interface INetworkRepo
    {
        List<string> GetCategoryNamesByID(string[] categoryIds);
        List<Network> GetUsersNetworksData(string userID);
        Network GetNetworkDataByNetworkID(string networkId);
        string[] GetCategorieIDs(string id);
        void InsertNewNetworkData(Network network);
        void CreateUserNetworkConnection(string UserID, string NetworkID);
        void RemoveUserNetworkCon(string userId, string networkId);
        bool CheckPermission(string userid, string networkid);
        string GetHashedPassword(string networkid);
        List<Network> GetPublicNetworks();
    }
}
