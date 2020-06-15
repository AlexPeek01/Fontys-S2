using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public enum Size : ushort
    {
        Large = 5,
        Medium = 3,
        Small = 1
    }
    public enum Type : ushort
    {
        Carnivore,
        Herbivore,
    }
    public class Animal
    {
        public Size animalSize { get; private set; }
        public Type animalType { get; private set; }
        public string animalName { get; private set; }
        public Animal(Type _carnivore, Size _size, string _animalName)
        {
            this.animalType = _carnivore;
            this.animalSize = _size;
            this.animalName = _animalName;
        }
    }
}
