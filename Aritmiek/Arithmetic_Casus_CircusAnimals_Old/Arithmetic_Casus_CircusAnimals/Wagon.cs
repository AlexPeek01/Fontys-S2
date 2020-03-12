using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals
{
    class Wagon
    {
        public static List<Wagon> wagonList = new List<Wagon>();
        public int wagonId;
        public int spaceAvailable;
        public List<Animal> animalsInWagon;
        public Wagon(int wagonId, int spaceAvailable)
        {
            this.wagonId = wagonId;
            this.spaceAvailable = spaceAvailable;
            animalsInWagon = new List<Animal>();
        }
    }
}
