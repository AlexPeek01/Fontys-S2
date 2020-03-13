using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aritmiek_ContainerShip
{
    class Ship
    {
        public Container[, ,] position;
        public int length;
        public int width;
        public int height;
        public Ship(int length, int width, int height)
        {
            position = new Container[length, width, height];
            this.length = length;
            this.width = width;
            this.height = height;
        }
    }
}
