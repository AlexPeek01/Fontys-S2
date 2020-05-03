using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers
{
    public class FavoursNetworkManager
    {
        public static List<string> GetNetworkIDsByUserID(string UserID)
        {
            return SQLConnection.ExecuteSearchQuery($"Select NetworkID From UserNetworkConnection Where UserID='{UserID}'");
        }
        public static Network GetNetworkData(string networkId)
        {
            List<string> networkData = SQLConnection.ExecuteSearchQuery($"Select * From Netwerken Where NetwerkID='{networkId}'");
            Network network = new Network(networkData[1], Convert.ToInt32(networkData[7]));
            //TODO find a way to keep the ID set private.
            network.ID = networkData[0];
            network.Image = networkData[3];
            network.Description = networkData[4];
            network.UserCount = Convert.ToInt32(SQLConnection.ExecuteSearchQuery($"Select Count(UserID) From UserNetworkConnection Where NetworkID='{networkId}'")[0]);
            return network;
        }
        public static void InsertNewNetworkData(Network network, string UserID)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Netwerken (NetwerkID,NetwerkNaam,Wachtwoord,Afbeelding,Beschrijving,Visible,UserCount,UserLimit) VALUES('{network.ID}','{network.NetworkName}','{network.Password}','{network.Image}','{network.Description}','{network.Visible}','{network.UserCount}','{network.Memberlimit}')");
            CreateUserNetworkConnection(UserID, network.ID);
        }
        public static void CreateUserNetworkConnection(string UserID, string NetworkID)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO UserNetworkConnection (NetworkID,UserID) VALUES('{NetworkID}','{UserID}')");
        }
    }
}
