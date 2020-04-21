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
        private int wagonId;
        private int spaceAvailable;
        private List<Animal> animalsInWagon;

        ///////////////////////////Constructor
        public Wagon(int _wagonId, int _spaceAvailable)
        {
            this.wagonId = _wagonId;
            this.spaceAvailable = _spaceAvailable;
            animalsInWagon = new List<Animal>();
        }

        ///////////////////////////Get/Set
        public int _wagonId
        {
            get { return wagonId; }
            private set { wagonId = value; }
        }
        public int _spaceAvailable
        {
            get { return spaceAvailable; }
            private set { spaceAvailable = value; }
        }
        public List<Animal> _animalList
        {
            get { return animalsInWagon; }
            private set { }
        }


        ///////////////////////////Methods
        public void AddAnimalToWagon(Animal animal)
        {
            animalsInWagon.Add(animal);
            spaceAvailable -= animal._size;
        }
        public bool CheckWagon(Animal animal)
        {
            /*Checkt of het eerste dier in de wagon een carnivoor is, of er ruimte is voor het dier dat je wilt plaatsen en ofdat het dier
            dat je wilt plaatsen groter is dan de carnivoor.*/
            if (_animalList[0]._carnivore && _spaceAvailable >= animal._size && _animalList[0]._size < animal._size)
                return false;
            //Checkt of het eerste dier in de wagon een herbivoor is en of er ruimte is voor het dier dat je wilt plaatsen.
            else if (!_animalList[0]._carnivore && _spaceAvailable >= animal._size)
                return false;
            else
                return true;
        }
    }
}
