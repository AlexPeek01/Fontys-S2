using AdditionalFiles.Interfaces.IDAL;
using DAL;
using DAL.Memory;
using Managers.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursNetworkManager : INetworkManager
    {
        private readonly INetworkDB networkdb;
        public FavoursNetworkManager()
        {
            if (AdditionalFiles.Beans.dataSource == "sql") networkdb = new NetworkDB();
            else networkdb = new NetworkMemoryContext();
        }
        public List<string> GetNetworkIDsByUserID(string UserID) => networkdb.GetNetworkIdsByUserID(UserID);
        public Network GetNetworkData(string networkId) => networkdb.GetNetworkDataByNetworkID(networkId);
        public void CreateUserNetworkConnection(string UserID, string NetworkID) => networkdb.CreateUserNetworkConnection(UserID, NetworkID);
        public List<Service> GetServices(string ID) => networkdb.GetServicesByNetworkID(ID);
        public void RemoveUserNetworkCon(string userId, string networkId) => networkdb.RemoveUserNetworkCon(userId, networkId);
        public List<string> GetNetworksCategories(string id)
        {
            string[] categorieIDs = networkdb.GetCategorieIDs(id);
            return networkdb.GetCategoryNamesByID(categorieIDs);
        }
        public Network[] GetUsersNetworks(string userID)
        {
            List<string> usersNetworks = GetNetworkIDsByUserID(userID);
            return networkdb.GetUsersNetworksData(usersNetworks).ToArray();
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
            networkdb.InsertNewNetworkData(networkWithID);
            CreateUserNetworkConnection(UserID, networkWithID.ID);
            return networkWithID.ID;
        }

    }
}
