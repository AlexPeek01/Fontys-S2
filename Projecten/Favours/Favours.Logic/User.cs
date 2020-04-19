using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Logic
{
    public class User
    {
        private int gebruikersId { get; set; }
        private string gebruikersnaam { get; set; }
        private string wachtwoord { get; set; }
        private string voornaam { get; set; }
        private string tussenvoegsel { get; set; }
        private string achternaam { get; set; }
        private string emailadress { get; set; }
        private string telefoonnr { get; set; }
        private List<Event> eventList;
        private List<Network> networkList;
        

        public User(string _gebruikersnaam, string _wachtwoord)
        {
            eventList = new List<Event>();
            networkList = new List<Network>();
            this.gebruikersnaam = _gebruikersnaam;
            this.wachtwoord = _wachtwoord;
        }
    }
}
