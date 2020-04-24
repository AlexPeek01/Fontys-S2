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
        /// <summary>
        /// Als het dier dat geplaatst moet worden een carnivoor is, wordt er een nieuwe wagon aangemaakt.
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="train"></param>
        /// <returns></returns>
        public bool CheckForCarnivore(Train train)
        {
            if (carnivore)
            {
                train.CreateWagon(this);
                return true;
            }
            return false;
        }
    }
}
