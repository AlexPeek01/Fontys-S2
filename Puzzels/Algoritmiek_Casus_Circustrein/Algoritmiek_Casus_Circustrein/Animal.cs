using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmiek_Casus_Circustrein
{
    class Animal
    {
        public static List<Animal> animalList = new List<Animal>();
        private bool _carnivore;
        private int _size;
        public Animal(bool carnivore, int size)
        {
            this._carnivore = carnivore;
            this._size = size;
        }
        public bool carnivore
        {
            get
            {
                return _carnivore;
            }
            set
            {
                _carnivore = value;
            }
        }
        public int size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
    }
}
