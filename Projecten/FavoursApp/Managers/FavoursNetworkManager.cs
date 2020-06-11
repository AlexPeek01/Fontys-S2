using AdditionalFiles;
using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursNetworkManager : INetworkManager
    {
        private readonly INetworkRepo networkrepo;
        public FavoursNetworkManager(INetworkRepo implementation)
        {
            networkrepo = implementation;
        }
        public List<string> GetNetworkIDsByUserID(string UserID) => networkrepo.GetNetworkIdsByUserID(UserID);
        public Network GetNetworkData(string networkId) => networkrepo.GetNetworkDataByNetworkID(networkId);
        public bool CheckPermission(string networkid, string userid) => networkrepo.CheckPermission(userid, networkid);
        public void CreateUserNetworkConnection(string UserID, string NetworkID) => networkrepo.CreateUserNetworkConnection(UserID, NetworkID);
        public string GetHashedPassword(string networkid) => networkrepo.GetHashedPassword(networkid);
        public void RemoveUserNetworkCon(string userId, string networkId) => networkrepo.RemoveUserNetworkCon(userId, networkId);
        public List<string> GetNetworksCategories(string id)
        {
            string[] categorieIDs = networkrepo.GetCategorieIDs(id);
            return networkrepo.GetCategoryNamesByID(categorieIDs);
        }
        public Network[] GetUsersNetworks(string userID)
        {
            List<string> usersNetworks = GetNetworkIDsByUserID(userID);
            return networkrepo.GetUsersNetworksData(usersNetworks).ToArray();
        }
        public string InsertNewNetworkData(Network network, string UserID)
        {
            Network networkWithID = new Network(IdentificationHelper.GetUniqueKey())
            {
                NetworkName = network.NetworkName,
                Description = network.Description,
                Image = network.Image,
                Password = network.Password,
                MemberLimit = network.MemberLimit,
                UserCount = 1,
                Visible = network.Visible,
            };
            networkrepo.InsertNewNetworkData(networkWithID);
            CreateUserNetworkConnection(UserID, networkWithID.ID);
            return networkWithID.ID;
        }
        public List<Network> GetPublicNetworks() => networkrepo.GetPublicNetworks();
    }
}
