using AdditionalFiles.Interfaces.IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Memory
{
    public class NetworkMemoryContext// : INetworkDB
    {
        public void CreateUserNetworkConnection(string UserID, string NetworkID)
        {
            // Not to be tested
        }

        public string[] GetCategorieIDs(string id)
        {
            if (id == "1")
            {
                return new string[] { "1", "2", "3", "4" };
            }
            else if (id == "2")
            {
                return new string[] { "2", "4", "6", "8" };
            }
            else return new string[0];
        }

        public List<string> GetCategoryNamesByID(string[] categoryIds)
        {
            List<string> categoryNames = new List<string>();
            foreach(string s in categoryIds)
            {
                if(s == "1")
                    categoryNames.Add("Naam1");
                else if(s == "2")
                    categoryNames.Add("Naam2");
                else if (s == "3")
                    categoryNames.Add("Naam3");
                else if (s == "4")
                    categoryNames.Add("Naam4");
                else if (s == "5")
                    categoryNames.Add("Naam5");
                else if (s == "6")
                    categoryNames.Add("Naam6");
                else if (s == "7")
                    categoryNames.Add("Naam7");
                else if (s == "8")
                    categoryNames.Add("Naam8");
            }
            return categoryNames;
        }

        public Network GetNetworkDataByNetworkID(string networkId)
        {
            Network network1 = new Network()
            {
                NetworkName = "NAME_NETWORK_1",
            };
            Network network2 = new Network()
            {
                NetworkName = "NAME_NETWORK_2",
            };
            if (networkId == "networkid1")
            {
                return network1;
            }
            else if (networkId == "networkid2")
            {
                return network2;
            }
            return null;
        }

        public List<string> GetNetworkIdsByUserID(string UserID)
        {
            List<string> networkids1 = new List<string>()
            {
                "1",
                "2",
                "3",
            };
            List<string> networkids2 = new List<string>()
            {
                "9",
                "8",
                "7",
            };
            if(UserID == "1")
                return networkids1;

            if (UserID == "2")
                return networkids2;

            return new List<string>();
        }
        public List<Service> GetServicesByNetworkID(string ID)
        {
            Service service1 = new Service()
            {
                ServiceID = "111",
            };
            Service service2 = new Service()
            {
                ServiceID = "222",
            };
            Service service3 = new Service()
            {
                ServiceID = "333",
            };
            Service service4 = new Service()
            {
                ServiceID = "444",
            };
            List<Service> servicelist1 = new List<Service>()
            {
                service1,
                service2,
            };
            List<Service> servicelist2 = new List<Service>()
            {
                service3,
                service4,
            };
            if(ID == "networkid1")
            {
                return servicelist1;
            }
            else if (ID == "networkid2")
            {
                return servicelist2;
            }
            return new List<Service>();
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
