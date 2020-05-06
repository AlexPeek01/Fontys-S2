using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MainLogic
    {
        /// <summary>
        /// Genereert de output string om te displayen waar de dieren geplaatst worden.
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public string CreateOutputString(Train train)
        {
            string outputstring = "";
            foreach (Wagon wagon in train.wagonsInTrain)
            {
                outputstring += "Wagon" + wagon.wagonId + " contains: " + '\n';
                foreach(Animal animal in wagon.animalsInWagon)
                {
                    outputstring += "   - " + animal.animalName + '\n';
                }
                outputstring += '\n';
            }
            return outputstring;
        }
        /// <summary>
        /// Berekent hoe efficient de ruimte gebruikt is.
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        public double CalculateEfficiency(Train train)
        {
            double totalSpaceAvailable = 0;
            foreach (Wagon w in train.wagonsInTrain)
                totalSpaceAvailable += (10 - w.spaceAvailable);
            return (totalSpaceAvailable / (train.wagonsInTrain.Count * 10)) * 100;
        }

    }
}