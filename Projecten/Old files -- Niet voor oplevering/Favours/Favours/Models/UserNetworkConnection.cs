using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Models
{
    public class UserNetworkConnection
    {
        private int UserID { get; set; }
        private int NetworkID { get; set; }
        public UserNetworkConnection(int _userId, int _networkId)
        {
            UserID = _userId;
            NetworkID = _networkId;
        }
        
    }
}
