using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Animal
    {
        ///////////////////////////Fields
        public static List<Animal> oldAnimalList = new List<Animal>();
        private bool carnivore;
        private int size;
        private string animalName;

        ///////////////////////////Constructor
        public Animal(bool _carnivore, int _size, string _animalName)
        {
            this.carnivore = _carnivore;
            this.size = _size;
            this.animalName = _animalName;
        }
        ///////////////////////////Get/Set
        public bool _carnivore
        {
            get { return carnivore; }
            set { carnivore = value; }
        }
        public int _size
        {
            get { return size; }
            set { size = value; }
        }
        public string _animalName
        {
            get { return animalName; }
            set { animalName = value; }
        }

        ///////////////////////////Methods
        public static void CreateAnimal(bool isCarnivore, int size, string animalName)
        {
            Animal animal = new Animal(isCarnivore, size, animalName);
            oldAnimalList.Add(animal);
        }
        
    }
}
