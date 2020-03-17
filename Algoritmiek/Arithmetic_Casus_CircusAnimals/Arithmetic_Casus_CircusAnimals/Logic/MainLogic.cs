using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals
{
    class MainLogic
    {
        public static List<Animal> SortList(List<Animal> aList)
        {
            var sorted = from animal in aList
                         orderby animal._carnivore descending
                         select animal;
            return sorted.ToList<Animal>();
        }
        
        public static double CalculateEfficiency()
        {
            double totalSpaceAvailable = 0;
            foreach (Wagon w in Wagon.wagonList)
                totalSpaceAvailable += (10 - w._spaceAvailable);
            return (totalSpaceAvailable / (Wagon.wagonList.Count * 10)) * 100;
        }
    }
}