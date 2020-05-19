using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursNetworkManager
    {
        public static List<string> GetNetworksCategories(string id)
        {
            string[] categorieIDs = NetworkDB.GetCategorieIDs(id);
            return NetworkDB.GetCategoryNamesByID(categorieIDs);
        }
        public static List<string> GetNetworkIDsByUserID(string UserID)
        {
            return NetworkDB.GetNetworkIdsByUserID(UserID);
        }
        public static Network GetNetworkData(string networkId)
        {
            return NetworkDB.GetNetworkDataByNetworkID(networkId);
        }
        public static Network[] GetUsersNetworks(string userID)
        {
            List<string> usersNetworks = FavoursNetworkManager.GetNetworkIDsByUserID(userID);
            List<Network> networks = new List<Network>();
            return NetworkDB.GetUsersNetworksData(usersNetworks).ToArray();
        }
        public static string InsertNewNetworkData(Network network, string UserID)
        {
            Network networkWithID = new Network(IdentificationManager.GetUniqueKey());
            networkWithID.NetworkName = network.NetworkName;
            networkWithID.Description = network.Description;
            networkWithID.Image = network.Image;
            networkWithID.Password = network.Password;
            networkWithID.MemberLimit = network.MemberLimit;
            networkWithID.UserCount = 1;
            networkWithID.Visible = network.Visible;
            NetworkDB.InsertNewNetworkData(networkWithID);
            CreateUserNetworkConnection(UserID, networkWithID.ID);
            return networkWithID.ID;
        }
        public static void CreateUserNetworkConnection(string UserID, string NetworkID)
        {
            NetworkDB.CreateUserNetworkConnection(UserID, NetworkID);
        }
        public static List<Service> GetServices(string ID)
        {
            return NetworkDB.GetServicesByNetworkID(ID);
        }
    }
}
