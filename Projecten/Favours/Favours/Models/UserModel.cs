using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Models
{
    public class UserModel
    {
        private int userId { get; set; }
        private string voornaam { get; set; }
        private string tussenvoegsel { get; set; }
        private string achternaam { get; set; }
        List<NetworkModel> networkList { get; set; }

        public UserModel(int _networkId, string _networkName)
        {
            this.userId = _networkId;
            this.networkName = _networkName;
            userList = new List<UserModel>();
            categoryList = new List<CategorieModel>();
            eventList = new List<EventModel>();
        }
    }
}
