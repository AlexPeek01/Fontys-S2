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
            string[] categorieID = SQLConnection.ExecuteSearchQuery($"Select CategoryID From categorynetworkconnection Where NetworkID='{id}'").ToArray();
            string query = "SELECT CategoryName FROM category WHERE CategoryID=";
            foreach(string s in categorieID)
            {
                query += "'" + s + "'" + " OR CategoryID=";
            }
            query = query.Substring(0, query.Length - 15);
            return SQLConnection.ExecuteSearchQuery(query);
        }
        public static List<string> GetNetworkIDsByUserID(string UserID)
        {
            return SQLConnection.ExecuteSearchQuery($"Select NetworkID From UserNetworkConnection Where UserID='{UserID}'");
        }
        public static Network GetNetworkData(string networkId)
        {
            List<string> networkData = SQLConnection.ExecuteSearchQuery($"Select * From Netwerken Where NetwerkID='{networkId}'");
            Network network = new Network();
            //TODO find a way to keep the ID set private.
            network.ID = networkData[0];
            network.NetworkName = networkData[1];
            network.Image = networkData[3];
            network.Description = networkData[4];
            network.UserCount = Convert.ToInt32(networkData[6]);
            network.Memberlimit = Convert.ToInt32(networkData[7]);
            return network;
        }
        public static Network[] GetUsersNetworks(string userID)
        {
            List<string> usersNetworks = FavoursNetworkManager.GetNetworkIDsByUserID(userID);
            List<Network> networks = new List<Network>();
            foreach (string networkid in usersNetworks)
            {
                networks.Add(FavoursNetworkManager.GetNetworkData(networkid));
            }
            return networks.ToArray();
        }
        public static void InsertNewNetworkData(Network network, string UserID)
        {
            network.Image = network.Image.Split("base64,")[1];
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Netwerken (NetwerkID,NetwerkNaam,Wachtwoord,Afbeelding,Beschrijving,Visible,UserCount,UserLimit) VALUES('{network.ID}','{network.NetworkName}','{network.Password}','{network.Image}','{network.Description}','{network.Visible}','{network.UserCount}','{network.Memberlimit}')");
            CreateUserNetworkConnection(UserID, network.ID);
        }
        public static void CreateUserNetworkConnection(string UserID, string NetworkID)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO UserNetworkConnection (NetworkID,UserID) VALUES('{NetworkID}','{UserID}')");
        }
    }
}
