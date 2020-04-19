using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Logic
{
    public class Network
    {
        private int netwerkId { get; set; }
        private string netwerkNaam { get; set; }
        private string wachtwoord { get; set; }
        private List<Event> eventList { get; set; }
        private List<Category> categoryList { get; set; }
        private List<User> userList { get; set; }
        public Network(string _netwerkNaam)
        {
            this.netwerkNaam = _netwerkNaam;
            userList = new List<User>();
            categoryList = new List<Category>();
            eventList = new List<Event>();
        }
        public string NetwerkNaam
        {
            get
            {
                return netwerkNaam;
            }
        }
    }
}
