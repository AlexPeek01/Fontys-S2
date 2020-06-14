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
        private readonly IIdentificationManager identificationmanager;
        public FavoursNetworkManager(INetworkRepo implementation, IIdentificationManager imp_identification)
        {
            networkrepo = implementation;
            identificationmanager = imp_identification;
        }
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
        public Network[] GetUsersNetworks(string userID) => networkrepo.GetUsersNetworksData(userID).ToArray();
        public string InsertNewNetworkData(Network network, string UserID)
        {
            Network networkWithID = new Network(identificationmanager.GetUniqueKey())
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
