using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aritmiek_ContainerShip2
{
    class Container
    {
        public static List<Container> unplaceableContainerList = new List<Container>();
        public static List<Container> unsortedContainerList = new List<Container>();
        public int weight;
        public bool isValuable;
        public bool cooledContainer;
        public Container(int weight, bool isValuable, bool cooledContainer)
        {
            this.weight = weight;
            this.isValuable = isValuable;
            this.cooledContainer = cooledContainer;
        }
    }
}
