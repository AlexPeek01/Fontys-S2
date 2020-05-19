using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Network
    {
        public string ID { get; private set; }
        public string NetworkName { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string ImageID { get; set; }
        public int UserCount { get; set; }
        public int MemberLimit { get; set; }
        public int Visible { get; set; }
        public Network(string NetworkID)
        {
            this.ID = NetworkID;
        }
        public Network()
        {

        }
    }
}
