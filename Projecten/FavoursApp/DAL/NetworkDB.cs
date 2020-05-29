using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class NetworkDB : INetworkDB
    {
        public string[] GetCategorieIDs(string id)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@NetworkID", id},
            };
            return SQLConnection.ExecuteSearchQuery($"Select CategoryID From categorynetworkconnection Where NetworkID=@NetworkID", parameters).ToArray();
        }
        public List<string> GetCategoryNamesByID(string[] categoryIds)
        {

            List<string[]> parameters = new List<string[]>();
            string query = "SELECT CategoryName FROM category WHERE CategoryID=";
            for (int i = 0; i < categoryIds.Length; i++)
            {
                parameters.Add(new string[] { "@" + i.ToString(), categoryIds[i] });
                query += "'" + "@" + i.ToString() + "'" + " OR CategoryID=";
            }
            query = query.Substring(0, query.Length - 15);
            return SQLConnection.ExecuteSearchQuery(query, parameters);
        }
        public List<string> GetNetworkIdsByUserID(string UserID)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@UserID", UserID}
            };
            return SQLConnection.ExecuteSearchQuery($"Select NetworkID From UserNetworkConnection Where UserID=@UserID", parameters);
        }
        public List<Network> GetUsersNetworksData(List<string> networkIds)
        {
            List<string[]> parameters = new List<string[]>();
            string query = $"Select * From Netwerken Where NetwerkID=";
            List<string[]> networkData;
            List<Network> networks = new List<Network>();
            if (networkIds.Count > 0)
            {
                for (int i = 0; i < networkIds.Count; i++)
                {
                    parameters.Add(new string[] { "@" + i.ToString(), networkIds[i] });
                    query += "@" + i.ToString() + " OR NetwerkID=";
                }
                query = query.Substring(0, query.Length - 14);
                networkData = SQLConnection.ExecuteSearchQueryWithArrayReturn(query, parameters);
                foreach (string[] data in networkData)
                {
                    Network network = new Network(data[0]);
                    network.NetworkName = data[1];
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
        public Network GetNetworkDataByNetworkID(string networkId)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@NetworkID", networkId }
            };
            List<string> networkData = SQLConnection.ExecuteSearchQuery($"Select * From Netwerken Where NetwerkID=@NetworkID", parameters);
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
        public void InsertNewNetworkData(Network network)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@NetworkID", network.ID },
                new string[] { "@NetwerkNaam", network.NetworkName },
                new string[] { "@Wachtwoord", network.Password },
                new string[] { "@Afbeelding", network.Image },
                new string[] { "@Beschrijving", network.Description },
                new string[] { "@Visible", network.Visible.ToString() },
                new string[] { "@UserCount", network.UserCount.ToString() },
                new string[] { "@UserLimit", network.MemberLimit.ToString() }
            };
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Netwerken (NetwerkID,NetwerkNaam,Wachtwoord,Afbeelding,Beschrijving,Visible,UserCount,UserLimit) " +
                $"VALUES(@NetworkID,@NetwerkNaam,@Wachtwoord,@Afbeelding,@Beschrijving,@Visible,@UserCount,@UserLimit)", parameters);
        }
        public void CreateUserNetworkConnection(string UserID, string NetworkID)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@NetworkID", NetworkID },
                new string[] { "@UserID", UserID }
            };
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO UserNetworkConnection (NetworkID,UserID) VALUES(@NetworkID,@UserID)", parameters);
        }
        public List<Service> GetServicesByNetworkID(string ID)
        {
            List<string[]> parameters = new List<string[]>()
            {
                new string[] { "@NetworkID", ID },
            };
            List<string[]> networkData = SQLConnection.ExecuteSearchQueryWithArrayReturn($"SELECT * FROM services WHERE NetworkID=@NetworkID", parameters);
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
