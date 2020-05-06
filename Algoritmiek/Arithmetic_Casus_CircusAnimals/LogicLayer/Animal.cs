using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Animal
    {
        public enum size : ushort
        {
            Large = 5,
            Medium = 3,
            Small = 1
        }
        public int animalSize { get; private set; }
        public bool carnivore { get; private set; }
        public string animalName { get; private set; }
        public Animal(bool _carnivore, size _size, string _animalName)
        {
            this.carnivore = _carnivore;
            this.animalSize = Convert.ToInt32(_size);
            this.animalName = _animalName;
        }
        public void PlaceAnimal(Train train, Wagon wagon)
        {
            if (wagon != null)
            {
                wagon.AddAnimalToWagon(this);
            }
            else
            {
                Wagon newWagon = train.CreateWagon();
                newWagon.AddAnimalToWagon(this);
            }
        }
    }
}
