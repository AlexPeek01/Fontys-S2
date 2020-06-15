using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetic_Casus_CircusAnimals.DataAccess;

namespace LogicLayer
{
    public class Train
    {
        public List<Wagon> wagonsInTrain { get; private set; }
        public int trainId { get; private set; }
        public Train() => wagonsInTrain = new List<Wagon>();
        public Wagon FindOptimalWagon(Animal animal)
        {
            // Input checks
            if (animal == null) throw new ArgumentException("Animal can't be null");

            if (animal.animalType == Type.Carnivore) return null;
            foreach (Wagon wagon in wagonsInTrain)
            {
                if (wagon.CanPlaceAnimalChecks(animal))
                    return wagon;
            }
            return null;
        }
        /// <summary>
        /// Als er geen wagon beschikbaar is wordt er een nieuwe wagon aangemaakt.
        /// </summary>
        /// <param name="animal"></param>
        public Wagon CreateWagon()
        {
            Wagon wagon = new Wagon(wagonsInTrain.Count, 10);
            wagonsInTrain.Add(wagon);
            return wagon;
        }
        /// <summary>
        /// Slaat de trein op in de database
        /// </summary>
        public void SaveTrainToDb()
        {
            trainId = MySQLContext.GetTrainCount();
            foreach (Wagon w in wagonsInTrain)
            {
                foreach (Animal a in w.animalsInWagon)
                {
                    MySQLContext.MySqlQuery(w.wagonId, a.animalName, trainId);
                }
            }
        }
    }
}
