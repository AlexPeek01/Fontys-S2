using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Logic
{
    public class Network
    {
        private int networkId;
        private string networkName;
        private string password;
        private int memberLimit;
        private bool visibility;
        private List<Service> eventList;
        private List<Category> categoryList;
        private List<User> userList;
        public Network(string _networkName)
        {
            this.networkName = _networkName;
            userList = new List<User>();
            categoryList = new List<Category>();
            eventList = new List<Service>();
        }
    }
}
