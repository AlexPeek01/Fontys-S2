using AdditionalFiles.Interfaces.IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Memory
{
    public class NetworkMemoryContext : INetworkDB
    {
        public void CreateUserNetworkConnection(string UserID, string NetworkID)
        {
            // Not to be tested
        }

        public string[] GetCategorieIDs(string id)
        {
            List<string[,]> categoryIds = new List<string[,]>()
            {
                new string[,] { {"1"},{"1"} },
                new string[,] { {"1"},{"2"} },
                new string[,] { {"1"},{"3"} },
                new string[,] { {"2"},{"3"} },
                new string[,] { {"2"},{"4"} },
                new string[,] { {"2"},{"5"} },
            };
            return null;
        }

        public List<string> GetCategoryNamesByID(string[] categoryIds)
        {
            return null;
        }

        public Network GetNetworkDataByNetworkID(string networkId)
        {
            return null;
        }

        public List<string> GetNetworkIdsByUserID(string UserID)
        {
            return null;
        }

        public List<Service> GetServicesByNetworkID(string ID)
        {
            return null;
        }

        public List<Network> GetUsersNetworksData(List<string> networkIds)
        {
            return null;
        }
        public void InsertNewNetworkData(Network network)
        {

        }

        public void RemoveUserNetworkCon(string userId, string networkId)
        {
            throw new NotImplementedException();
        }
    }
}
