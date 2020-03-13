using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aritmiek_Containerschip3
{
    class Container
    {
        private bool valuable;
        private bool cooled;
        private int weight;
        public Container (bool _valuable, bool _cooled, int _weight)
        {
            this.valuable = _valuable;
            this.cooled = _cooled;
            this.weight = _weight;
        }
        public bool _valuable
        {
            get { return valuable; }
            set { valuable = value; }
        }
        public bool _cooled
        {
            get { return cooled; }
            set { cooled = value; }
        }
        public int _weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}
