using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Container
    {
        private int weight;
        private bool cooled;
        private bool valuable;
        private bool placed;
        
        public Container(int _weight, bool _cooled, bool _valuable, bool _placed)
        {
            this.weight = _weight;
            this.cooled = _cooled;
            this.valuable = _valuable;
            this.placed = _placed;
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public bool Cooled
        {
            get { return cooled; }
            set { cooled = value; }
        }
        public bool Valuable
        {
            get { return valuable; }
            set { valuable = value; }
        }
        public bool Placed
        {
            get { return placed; }
            set { placed = value; }
        }
    }
}
