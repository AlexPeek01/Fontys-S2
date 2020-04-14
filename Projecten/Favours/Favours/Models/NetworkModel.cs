using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Models
{
    public class NetworkModel
    {
        private int networkId { get; set; }
        private string networkName { get; set; }
        private List<EventModel> eventList { get; set; }
        private List<CategorieModel> categoryList { get; set; }
        private List<UserModel> userList { get; set; }
        public NetworkModel(int _networkId, string _networkName)
        {
            this.networkId = _networkId;
            this.networkName = _networkName;
            userList = new List<UserModel>();
            categoryList = new List<CategorieModel>();
            eventList = new List<EventModel>();
        }
    }
}
