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
        public Train()
        {
            wagonsInTrain = new List<Wagon>();
        }
        /// <summary>
        /// Slaat de trein op in de database
        /// </summary>
        public void SaveTrainToDb()
        {
            trainId = MySQLContext.GetTrainCount();
            foreach (Wagon w in wagonsInTrain)
            {
                foreach(Animal a in w.animalsInWagon)
                {
                    MySQLContext.MySqlQuery(w.wagonId, a.animalName, trainId);
                }
            }
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
        /// Als er een wagon veilig is, wordt het dier aan die wagon toegevoegd.
        /// </summary>
        /// <param name="train"></param>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CheckForViableWagon(Animal animal)
        {
            foreach (Wagon wagon in wagonsInTrain)
            {
                if (!wagon.CheckWagon(animal))
                {
                    wagon.AddAnimalToWagon(animal);
                    return true;
                }
            }
            return false;
        }
    }
}
