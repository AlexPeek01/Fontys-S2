using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetic_Casus_CircusAnimals.DataAccess;

namespace LogicLayer
{
    public class Wagon
    {
        public int wagonId { get; private set; }
        public int spaceAvailable { get; private set; }
        public bool carnivoreInWagon { get; private set; }
        public List<Animal> animalsInWagon { get; private set; }

        public Wagon(int _wagonId, int _spaceAvailable)
        {
            this.wagonId = _wagonId;
            this.spaceAvailable = _spaceAvailable;
            animalsInWagon = new List<Animal>();
        }
        /// <summary>
        /// Voegt een dier toe aan een wagon en verminderd de ruimte beschikbaar.
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimalToWagon(Animal animal)
        {
            animalsInWagon.Add(animal);
            spaceAvailable -= animal.animalSize;
        }
        /// <summary>
        /// Controleert of een wagon veilig is om een bepaalde herbivoor in te plaatsen.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CheckWagon(Animal animal)
        {
            if (animalsInWagon[0].carnivore && spaceAvailable >= animal.animalSize && animalsInWagon[0].animalSize < animal.animalSize)
                return false;
            else if (!animalsInWagon[0].carnivore && spaceAvailable >= animal.animalSize)
                return false;
            else
                return true;
        }
    }
}
