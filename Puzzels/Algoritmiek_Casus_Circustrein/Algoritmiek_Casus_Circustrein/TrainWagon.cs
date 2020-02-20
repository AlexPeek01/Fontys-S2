using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmiek_Casus_Circustrein
{
    class TrainWagon
    {
        public static List<TrainWagon> trainWagonList = new List<TrainWagon>();
        private bool _hasCarnivore;
        private int _space;
        public TrainWagon(bool hasCarnivore, int space)
        {
            this._hasCarnivore = hasCarnivore;
            this._space = space;
        }

        public bool hasCarnivore
        {
            get
            {
                return _hasCarnivore;
            }
            set
            {
                _hasCarnivore = value;
            }
        }
        public int space
        {
            get
            {
                return _space;
            }
            set
            {
                _space = value;
            }
        }
    }
}
