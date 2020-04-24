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
        ///////////////////////////Fields
        public int wagonId { get; private set; }
        public int spaceAvailable { get; private set; }
        public bool carnivoreInWagon { get; private set; }
        public List<Animal> animalsInWagon { get; private set; }

        ///////////////////////////Constructor
        public Wagon(int _wagonId, int _spaceAvailable)
        {
            this.wagonId = _wagonId;
            this.spaceAvailable = _spaceAvailable;
            animalsInWagon = new List<Animal>();
        }
        ///////////////////////////Methods
        public void AddAnimalToWagon(Animal animal)
        {
            if (animal.carnivore)
            {
                carnivoreInWagon = true;
            }
            animalsInWagon.Add(animal);
            spaceAvailable -= animal.animalSize;
        }
        public bool CheckWagonSafety(Animal animal)
        {
            /*Checkt of het eerste dier in de wagon een carnivoor is, of er ruimte is voor het dier dat je wilt plaatsen en ofdat het dier
            dat je wilt plaatsen groter is dan de carnivoor.*/
            if (animalsInWagon[0].carnivore && spaceAvailable >= animal.animalSize && animalsInWagon[0].animalSize < animal.animalSize)
                return false;
            //Checkt of het eerste dier in de wagon een herbivoor is en of er ruimte is voor het dier dat je wilt plaatsen.
            else if (!animalsInWagon[0].carnivore && spaceAvailable >= animal.animalSize)
                return false;
            else
                return true;
        }
    }
}
