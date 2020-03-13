using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aritmiek_ContainerShip
{
    class Domain
    {
        public static void CreateContainer(int weight, bool isValuable, bool cooledContainer)
        {
            if(weight > 30000 || weight < 4000)
            {
                System.Windows.MessageBox.Show("Weight has to be between 4000 and 30000");
            }
            else
            {
                Container container = new Container(weight, isValuable, cooledContainer);
                Container.unsortedContainerList.Add(container);
            }
        }
        public static List<Container> SortContainer(List<Container> unsortedContainerList)
        {
            var sorted = from container in unsortedContainerList
                         orderby container.weight descending
                         select container;
            return sorted.ToList<Container>();
        }
        public static void SplitArray(List<Container> sortedArrayList, Ship ship)
        {
            int[,,] leftSideOfShip = new int[ship.length, ((ship.width) / 2), ship.height];
            int[,,] rightSideOfShip = new int[ship.length, ((ship.width) / 2), ship.height];
        }
        //To-do split array - compare weight - place container
        public static void PlaceContainer(List<Container> containerList, Ship ship)
        {
            SplitArray(containerList, ship);
            //  z x x x x x x x x x x x x x x x x x x x x x x x x x
            //  y
            //  y
            //  y
            //  y
            //  y
            int posLength = 0; //x
            int posWidth = 0; //y
            int posHeight = 0; //z
            foreach (Container c in containerList)
            {
                if (c.cooledContainer == true && !Container.unplaceableContainerList.Contains(c))
                {
                    if (posWidth < ship.width && posHeight < ship.height)
                    {
                        ship.position[posLength, posWidth, posHeight] = c;
                        //CheckBalance(ship.position, ship);
                        posWidth++;
                    }
                    else if(posWidth >= ship.width)
                    {
                        posWidth = 0;
                        posHeight++;
                        if (posHeight < ship.height)
                        {
                        ship.position[posLength, posWidth, posHeight] = c;
                        posWidth++;
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("No more room for this container");
                            Container.unplaceableContainerList.Add(c);
                        }
                    }
                }
            }
        }
    }
}
