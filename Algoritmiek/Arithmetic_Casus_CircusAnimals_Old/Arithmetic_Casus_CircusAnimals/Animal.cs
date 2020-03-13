using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals
{
    class Animal
    {
        public static List<Animal> oldAnimalList = new List<Animal>();
        public bool carnivore;
        public int size;
        public string animalName;
        public bool isPlaced;
        public Animal(bool carnivore, int size, string animalName, bool isPlaced)
        {
            this.carnivore = carnivore;
            this.size = size;
            this.animalName = animalName;
            this.isPlaced = isPlaced;
        }
    }
}
