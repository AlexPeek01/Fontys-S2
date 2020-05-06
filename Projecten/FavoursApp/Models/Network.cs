using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Network
    {
        private string id;
        private string networkName;
        private string description;
        private string password;
        private string image;
        private int userCount;
        private int memberLimit;
        private int visible;
        private List<Service> eventList;
        private List<Category> categoryList;
        private List<User> userList;
        public Network()
        {
            userList = new List<User>();
            categoryList = new List<Category>();
            eventList = new List<Service>();
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string NetworkName
        {
            get { return networkName; }
            set { networkName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Image
        {
            get { return image; }
            set { image = value; }
        }
        public int UserCount
        {
            get { return userCount; }
            set { userCount = value; }
        }
        public int Memberlimit
        {
            get { return memberLimit; }
            set { memberLimit = value; }
        }
        public int Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }
}
