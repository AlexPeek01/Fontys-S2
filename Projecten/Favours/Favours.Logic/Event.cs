using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favours.Logic
{
    public class Event
    {
        private int dienstId { get; set; }
        private int gebruikersId { get; set; }
        private string titel { get; set; }
        private string beschrijving { get; set; }
        private string[] afbeeldingen;
        private DateTime datum { get; set; }
        private bool zichtbaar { get; set; }

        public Event(int _gebruikersId, string _titel, string _beschrijving)
        {
            afbeeldingen = new string[9];
            this.gebruikersId = _gebruikersId;
            this.titel = _titel;
            this.beschrijving = _beschrijving;
        }
    }
}
