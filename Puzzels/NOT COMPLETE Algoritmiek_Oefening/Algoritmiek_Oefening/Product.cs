using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmiek_Oefening
{
    class Product
    {
        private string _name;
        private double _price;
        public Product(string name, double price)
        {
            this._name = name;
            this._price = price;
        }
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public double price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
    }
}
