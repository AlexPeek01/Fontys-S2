using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aritmiek_ContainerShip2
{
    class Domain
    {
        private static int centerLength = 0;
        private static int centerHeight = 0;
        private static int rightLength = 0;
        private static int rightWidth = 0;
        private static int rightHeight = 0;
        private static int leftLength = 0;
        private static int leftWidth = 0;
        private static int leftHeight = 0;
        private static int cooledContainerCount = 0;

        public static void CreateContainer(int weight, bool isValuable, bool cooledContainer)
        {
            if (weight > 30000 || weight < 4000)
            {
                System.Windows.MessageBox.Show("Weight has to be between 4000 and 30000");
            }
            else
            {
                Container container = new Container(weight, isValuable, cooledContainer);
                Container.unsortedContainerList.Add(container);
            }
        }
        public static string CheckBalance(Container[,,] leftArray, Container[,,] rightArray, Container[,,] centerArray,Ship ship, Container d)
        {
            int centerContainerCount = 0;
            int leftWeight = 0;
            int rightWeight = 0;
            int centerIsFull = 0;

            if(ship.width % 2 != 0)
            {
                foreach (Container c in centerArray)
                {
                    if (c != null)
                        centerContainerCount++;
                }
            }
            foreach(Container c in leftArray)
            {
                if (c != null)
                    leftWeight += c.weight;
            }
            foreach(Container c in rightArray)
            {
                if (c != null)
                    rightWeight += c.weight;
            }
            for(int i = 0; i < ship.length; i++)
            {
                if (!CheckAccumulatedWeight(centerArray, i, 0, d, ship))
                    centerIsFull++;
            }
            if (centerContainerCount != centerArray.Length && ship.width % 2 != 0 && centerIsFull != ship.length)
                return "center";
            else if(leftWeight >= rightWeight)
                return "right";
            else
                return "left";
        }
        public static bool CheckAccumulatedWeight(Container[,,] array, int x, int y, Container containerToPlace, Ship ship)
        {
            if (y > 0)
                y = y - 1;
            int accumulatedWeight = 0;
            for(int z = 1; z < ship.height; z++)
            {
                if(array[x,y,z] != null)
                    accumulatedWeight += array[x, y, z].weight;
            }
            accumulatedWeight += containerToPlace.weight;
            if (accumulatedWeight > 120000)
                return false;
            else
                return true; 
        }
        public static bool ContainerLimitReached(bool isValuable, bool isCooled, int length, int width, int height, List<Container> containerList)
        {
            if (isCooled)
                cooledContainerCount++;
            if (length * width * height == containerList.Count)
            {
                System.Windows.MessageBox.Show("Container limit reached!");
                return true;
            }
            else if (cooledContainerCount - 1 == length * width)
            {
                System.Windows.MessageBox.Show("Cooled container limit reached!");
                return true;
            }
            else
                return false;
        }
        public static List<Container> SortContainer(List<Container> unsortedContainerList)
        {
            var sortedContainerList = unsortedContainerList.OrderByDescending(s => s.cooledContainer).ThenByDescending(s => s.weight);
            return sortedContainerList.ToList<Container>();
        }
        public static void UnplacableContainerHandler(Container c)
        {
            System.Windows.MessageBox.Show("No more room for this container");
            Container.unplaceableContainerList.Add(c);
        }
        public static void PlaceContainer(List<Container> containerList, Ship ship)
        {
            foreach (Container c in containerList)
            {
                if (c.cooledContainer == true && !Container.unplaceableContainerList.Contains(c))
                {
                    if (CheckBalance(ship.leftSideArray, ship.rightSideArray, ship.centerArray, ship, c) == "center" && CheckAccumulatedWeight(ship.centerArray, 0, 0, c, ship))
                    {
                        PlaceCenter(ship, c);
                    }
                    else if (CheckBalance(ship.leftSideArray, ship.rightSideArray, ship.centerArray, ship, c) == "right" && CheckAccumulatedWeight(ship.rightSideArray, rightLength, rightWidth, c, ship))
                    {
                        PlaceRightSide(ship, c);
                    }
                    else if (CheckBalance(ship.leftSideArray, ship.rightSideArray, ship.centerArray, ship, c) == "left" && CheckAccumulatedWeight(ship.leftSideArray, leftWidth, leftWidth, c, ship))
                    {
                        PlaceLeftSide(ship, c);
                    }
                    else
                    {
                        UnplacableContainerHandler(c);
                    }
                }
                else if (c.cooledContainer == false && !Container.unplaceableContainerList.Contains(c) && c.isValuable == false)
                {
                    if (CheckBalance(ship.leftSideArray, ship.rightSideArray, ship.centerArray, ship, c) == "center")
                    {
                        PlaceCenter(ship, c);
                    }
                    else if (CheckBalance(ship.leftSideArray, ship.rightSideArray, ship.centerArray, ship, c) == "right")
                    {
                        PlaceRightSide(ship, c);
                    }
                    else if (CheckBalance(ship.leftSideArray, ship.rightSideArray, ship.centerArray, ship, c) == "left")
                    {
                        PlaceLeftSide(ship, c);
                    }
                    else
                    {
                        UnplacableContainerHandler(c);
                    }
                }
                else
                {
                    UnplacableContainerHandler(c);
                }
            }
        }
        public static void PlaceRightSide(Ship ship, Container c)
        {
            bool accumulatedWeight = CheckAccumulatedWeight(ship.rightSideArray, rightLength, rightWidth, c, ship);
            if (!accumulatedWeight && rightHeight < ship.height && rightLength < ship.length || rightHeight >= ship.height && rightLength < ship.length)
            {
                rightHeight = 0;
                if(rightLength < ship.length - 1)
                    rightLength++;
                ship.rightSideArray[rightLength, rightWidth, rightHeight] = c;
                if (rightHeight < ship.height)
                    rightHeight++;
            }
            else if (rightHeight < ship.height && accumulatedWeight)
            {
                ship.rightSideArray[rightLength, rightWidth, rightHeight] = c;
                rightHeight++;
            }
            else if (rightHeight >= ship.height && rightLength >= ship.length && rightWidth < ship.width / 2)
            {
                rightHeight = 0;
                rightWidth = 0;
                if (rightWidth <= ship.width / 2)
                    rightWidth++;
                ship.rightSideArray[rightLength, rightWidth, rightHeight] = c;
            }   
            else
            {
                UnplacableContainerHandler(c);
            }
        }
            public static void PlaceCenter(Ship ship, Container c)
        {
            bool accumulatedWeight = CheckAccumulatedWeight(ship.centerArray, centerLength, 0, c, ship);
            if (!accumulatedWeight && centerLength < ship.length || centerHeight >= ship.height && centerLength < ship.length)
            {
                centerHeight = 0;
                if (centerLength < ship.length - 1)
                    centerLength++;
                ship.centerArray[centerLength, 0, centerHeight] = c;
                if(centerHeight < ship.height)
                    centerHeight++;
            }
            else if (centerHeight < ship.height && accumulatedWeight)
            {
                ship.centerArray[centerLength, 0, centerHeight] = c;
                centerHeight++;
            }
            else
            {
                UnplacableContainerHandler(c);
            }
        }
        public static void PlaceLeftSide(Ship ship, Container c)
        {
            bool accumulatedWeight = CheckAccumulatedWeight(ship.leftSideArray, leftLength, leftWidth, c, ship);
            if (!accumulatedWeight && leftHeight < ship.height && leftLength < ship.length || leftHeight >= ship.height && leftLength < ship.length)
            {
                leftHeight = 0;
                if (leftLength < ship.length - 1)
                    leftLength++;
                ship.leftSideArray[leftLength, 0, leftHeight] = c;
                if(leftHeight < ship.height)
                leftHeight++;
            }
            else if (leftHeight < ship.height && accumulatedWeight && leftLength < ship.length)
            {
                ship.leftSideArray[leftLength, 0, leftHeight] = c;
                leftHeight++;
            }
            else if (leftHeight >= ship.height && leftLength >= ship.length && leftWidth < ship.width / 2)
            {
                leftHeight = 0;
                leftWidth = 0;
                if (leftWidth <= ship.width / 2)
                    leftWidth++;
                ship.leftSideArray[leftLength, leftWidth, leftHeight] = c;
            }
            else
            {
                UnplacableContainerHandler(c);
            }
        }
    }
}
