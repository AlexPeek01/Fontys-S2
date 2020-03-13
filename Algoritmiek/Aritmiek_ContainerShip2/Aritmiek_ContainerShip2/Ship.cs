using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aritmiek_ContainerShip2
{
    class Ship
    {
        public Container[,,] leftSideArray;
        public Container[,,] centerArray;
        public Container[,,] rightSideArray;
        public int length;
        public int width;
        public int height;
        public Ship(int length, int width, int height)
        {
            leftSideArray = new Container[length, width/2, height];
            centerArray = new Container[length, 1, height];
            rightSideArray = new Container[length, width/2, height];
            this.length = length;
            this.width = width;
            this.height = height;
        }
    }
}
