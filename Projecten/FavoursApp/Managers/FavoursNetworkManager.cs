using DAL;
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
        public static List<string> GetNetworkData(string networkId)
        {
            return SQLConnection.ExecuteSearchQuery($"Select * From Netwerken Where NetwerkID='{networkId}'");
        }
        public static void InsertNewProfileData(string id)
        {
            SQLConnection.ExecuteNonSearchQuery($"INSERT INTO Users (Id) VALUES('{id}')");
        }
    }
}
