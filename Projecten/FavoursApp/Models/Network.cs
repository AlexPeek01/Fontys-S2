using System;
using System.Collections.Generic;
using System.Text;

namespace Models
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
        public int GetNetworkID()
        {
            return networkId;
        }
        public string GetNetworkName()
        {
            return networkName;
        }
        public void SetNetworkName(string networkName)
        {
            this.networkName = networkName;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public int GetMemberLimit()
        {
            return memberLimit;
        }
        public void SetMemberLimit(int limit)
        {
            this.memberLimit = limit;
        }
        public bool GetVisibility()
        {
            return visibility;
        }
        public void SetVisibility(bool visibility)
        {
            this.visibility = visibility;
        }
    }
}
