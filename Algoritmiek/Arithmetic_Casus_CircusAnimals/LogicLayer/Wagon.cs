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
            if (animal != null && spaceAvailable >= animal.animalSize)
            {
                animalsInWagon.Add(animal);
                spaceAvailable -= animal.animalSize;
            }
        }
        /// <summary>
        /// Controleert of een wagon veilig is om een bepaalde herbivoor in te plaatsen.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CanPlaceAnimalChecks(Animal animal)
        {
            if (animal != null && spaceAvailable >= animal.animalSize)
            {
                if (animalsInWagon[0].carnivore && animalsInWagon[0].animalSize < animal.animalSize)
                    return true;
                else if (!animalsInWagon[0].carnivore)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}