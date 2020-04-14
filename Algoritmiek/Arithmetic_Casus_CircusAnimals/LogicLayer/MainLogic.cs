using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MainLogic
    {
        public static List<Animal> SortList(List<Animal> aList)
        {
            //Zet de carnivoren vooraan in de lijst.
            var sorted = from animal in aList
                         orderby animal._carnivore descending
                         select animal;
            return sorted.ToList<Animal>();
        }
        
        public static double CalculateEfficiency(Train train)
        {
            //Berekent hoe efficient de ruimte gebruikt is.
            double totalSpaceAvailable = 0;
            foreach (Wagon w in train._wagonsInTrain)
                totalSpaceAvailable += (10 - w._spaceAvailable);
            return (totalSpaceAvailable / (train._wagonsInTrain.Count * 10)) * 100;
        }

    }
}