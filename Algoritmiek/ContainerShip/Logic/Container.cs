using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Container
    {
        public int weight { get; set; }
        public bool cooled { get; set; }
        public bool valuable { get; set; }
        public bool placed { get; set; }
        public bool valuableBlocked { get; set; }
        
        public Container(int _weight, bool _cooled, bool _valuable, bool _placed, bool _valuableBlocked)
        {
            this.weight = _weight;
            this.cooled = _cooled;
            this.valuable = _valuable;
            this.placed = _placed;
            this.valuableBlocked = _valuableBlocked;
        }
    }
}
