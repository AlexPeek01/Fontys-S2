using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Service
    {
        //TODO Make ID's private
        public string ServiceID { get; set; }
        public string NetworkID { get; set; }
        public string PostersID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Images;
        public DateTime Date;
        public bool Visibility;
        public Service(string ServiceID, string NetworkID, string PostersID)
        {
            this.ServiceID = ServiceID;
            this.NetworkID = NetworkID;
            this.PostersID = PostersID;
        }
        public Service()
        {

        }
    }
}
