using DAL;
using Managers.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursNetworkManager : INetworkManager
    {
        public readonly INetworkDB networkdb;
        public FavoursNetworkManager()
        {
            if (networkdb == null) networkdb = new NetworkDB();
        }
        public List<string> GetNetworksCategories(string id)
        {
            string[] categorieIDs = networkdb.GetCategorieIDs(id);
            return networkdb.GetCategoryNamesByID(categorieIDs);
        }
        public List<string> GetNetworkIDsByUserID(string UserID)
        {
            return networkdb.GetNetworkIdsByUserID(UserID);
        }
        public Network GetNetworkData(string networkId)
        {
            return networkdb.GetNetworkDataByNetworkID(networkId);
        }
        public Network[] GetUsersNetworks(string userID)
        {
            List<string> usersNetworks = GetNetworkIDsByUserID(userID);
            List<Network> networks = new List<Network>();
            return networkdb.GetUsersNetworksData(usersNetworks).ToArray();
        }
        public string InsertNewNetworkData(Network network, string UserID)
        {
            Network networkWithID = new Network(IdentificationHelper.GetUniqueKey());
            networkWithID.NetworkName = network.NetworkName;
            networkWithID.Description = network.Description;
            networkWithID.Image = network.Image;
            networkWithID.Password = network.Password;
            networkWithID.MemberLimit = network.MemberLimit;
            networkWithID.UserCount = 1;
            networkWithID.Visible = network.Visible;
            networkdb.InsertNewNetworkData(networkWithID);
            CreateUserNetworkConnection(UserID, networkWithID.ID);
            return networkWithID.ID;
        }
        public void CreateUserNetworkConnection(string UserID, string NetworkID)
        {
            networkdb.CreateUserNetworkConnection(UserID, NetworkID);
        }
        public List<Service> GetServices(string ID)
        {
            return networkdb.GetServicesByNetworkID(ID);
        }
    }
}
