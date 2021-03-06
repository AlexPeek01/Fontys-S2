﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdditionalFiles.Interfaces.IManagers
{
    public interface INetworkManager
    {
        List<string> GetNetworksCategories(string id);
        Network[] GetUsersNetworks(string userID);
        Network GetNetworkData(string networkId);
        string InsertNewNetworkData(Network network, string UserID);
        void CreateUserNetworkConnection(string UserID, string NetworkID);
        void RemoveUserNetworkCon(string userId, string networkId);
        bool CheckPermission(string networkid, string userid);
        string GetHashedPassword(string networkid);
        List<Network> GetPublicNetworks();
    }
}
