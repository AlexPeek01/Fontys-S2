using AdditionalFiles;
using AdditionalFiles.Interfaces.IDAL;
using AdditionalFiles.Interfaces.IManagers;
using AdditionalFiles.Interfaces.IRepos;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursNetworkManager : INetworkManager
    {
        private readonly INetworkDB networkdal;
        private readonly IIdentificationManager identificationmanager;
        public FavoursNetworkManager(INetworkDB implementation, IIdentificationManager imp_identification)
        {
            networkdal = implementation;
            identificationmanager = imp_identification;
        }
        public Network GetNetworkData(string networkId) => networkdal.GetNetworkDataByNetworkID(networkId);
        public bool CheckPermission(string networkid, string userid) => networkdal.CheckPermission(userid, networkid);
        public void CreateUserNetworkConnection(string UserID, string NetworkID) => networkdal.CreateUserNetworkConnection(UserID, NetworkID);
        public string GetHashedPassword(string networkid) => networkdal.GetHashedPassword(networkid);
        public void RemoveUserNetworkCon(string userId, string networkId) => networkdal.RemoveUserNetworkCon(userId, networkId);
        public List<string> GetNetworksCategories(string id)
        {
            string[] categorieIDs = networkdal.GetCategorieIDs(id);
            return networkdal.GetCategoryNamesByID(categorieIDs);
        }
        public Network[] GetUsersNetworks(string userID) => networkdal.GetUsersNetworksData(userID).ToArray();
        public string InsertNewNetworkData(Network network, string UserID)
        {
            Network networkWithID = new Network(identificationmanager.GetUniqueKey())
            {
                NetworkName = network.NetworkName,
                Description = network.Description,
                Image = network.Image,
                Password = network.Password,
                MemberLimit = network.MemberLimit,
                UserCount = 0,
                Visible = network.Visible,
            };
            networkdal.InsertNewNetworkData(networkWithID);
            CreateUserNetworkConnection(UserID, networkWithID.ID);
            return networkWithID.ID;
        }
        public List<Network> GetPublicNetworks() => networkdal.GetPublicNetworks();
    }
}
