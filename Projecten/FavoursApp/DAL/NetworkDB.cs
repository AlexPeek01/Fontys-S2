using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class NetworkDB
    {
        public static string[] GetCategorieIDs(string id)
        {
            return SQLConnection.ExecuteSearchQuery($"Select CategoryID From categorynetworkconnection Where NetworkID='{id}'").ToArray();
        }
        public static List<string> GetCategoryNamesByID(string[] categoryIds)
        {
            string query = "SELECT CategoryName FROM category WHERE CategoryID=";
            foreach (string s in categoryIds)
            {
                query += "'" + s + "'" + " OR CategoryID=";
            }
            query = query.Substring(0, query.Length - 15);
            return SQLConnection.ExecuteSearchQuery(query);
        }
        public static List<string> GetNetworkIdsByUserID(string UserID)
        {
            return SQLConnection.ExecuteSearchQuery($"Select NetworkID From UserNetworkConnection Where UserID='{UserID}'");
        }
        public static List<Network> GetUsersNetworksData(List<string> networkIds)
        {
            string query = $"Select * From Netwerken Where NetwerkID='";
            List<string[]> networkData;
            List<Network> networks = new List<Network>();
            if (networkIds.Count > 0)
            {
                foreach(string id in networkIds)
                {
                    query += id + "' OR NetwerkID='";
                }
                query = query.Substring(0, query.Length - 15);
                networkData = SQLConnection.ExecuteSearchQueryWithArrayReturn(query);
                foreach(string[] data in networkData)
                {
                    Network network = new Network(data[0]);
                    network.NetworkName = data[1];
                    network.Password = data[2];
                    network.ImageID = data[3];
                    network.Description = data[4];
                    network.Visible = data[5] == "0" ? 0 : 1;
                    network.UserCount = Convert.ToInt32(data[6]);
                    network.MemberLimit = Convert.ToInt32(data[7]);
                    networks.Add(network);
                }
            }
            return networks;
        }
        public static Network GetNetworkDataByNetworkID(string networkId)
        {
            List<string> networkData = SQLConnection.ExecuteSearchQuery($"Select * From Netwerken Where NetwerkID='{networkId}'");
            Network network = new Network(networkData[0]);
            network.NetworkName = networkData[1];
            network.Image = networkData[3];
            string[] splitimage = network.Image.Split('/');
            network.ImageID = splitimage[splitimage.Length - 1];
            network.Description = networkData[4];
            network.UserCount = Convert.ToInt32(networkData[6]);
            network.MemberLimit = Convert.ToInt32(networkData[7]);
            return network;
        }
        public static void InsertNewNetworkData(Network network)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Netwerken (NetwerkID,NetwerkNaam,Wachtwoord,Afbeelding,Beschrijving,Visible,UserCount,UserLimit) VALUES('{network.ID}','{network.NetworkName}','{network.Password}','{network.Image}','{network.Description}','{network.Visible}','{network.UserCount}','{network.MemberLimit}')");
        }
        public static void CreateUserNetworkConnection(string UserID, string NetworkID)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO UserNetworkConnection (NetworkID,UserID) VALUES('{NetworkID}','{UserID}')");
        }
        public static List<Service> GetServicesByNetworkID(string ID)
        {
            List<string[]> networkData = SQLConnection.ExecuteSearchQueryWithArrayReturn($"SELECT * FROM services WHERE NetworkID='{ID}'");
            List<Service> serviceList = new List<Service>();
            foreach (string[] data in networkData)
            {
                Service service = new Service();
                service.ServiceID = data[0];
                service.NetworkID = data[1];
                service.PostersID = data[2];
                service.Title = data[3];
                service.Description = data[4];
                service.Images = data[5];
                service.Date = Convert.ToDateTime(data[6]);
                service.Visibility = data[7] == "0" ? false : true;
                service.Category = data[8];
                serviceList.Add(service);
            }
            return serviceList;
        }
    }
}
