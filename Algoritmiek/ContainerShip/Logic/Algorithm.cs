using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Algorithm
    {
        private static List<Container> unplacableContainersList = new List<Container>();
        private static int startingPosition = 0;

        public static Container[,,] placeContainerArray(Ship ship)
        {
            Container[,,] containerArray = new Container[ship.Length, ship.Width, ship.Height];
            CheckPositionAndPlace(ship, ship.ContainerList, containerArray);
            foreach (Container c in ship.ContainerList)
            {
                if (!c.placed)
                {
                    unplacableContainersList.Add(c);
                }
            }
            CheckPositionAndPlace(ship, unplacableContainersList, containerArray);
            float totalWeight = ship.LeftSideWeight + ship.RightSideWeight;
            float leftSidePerc = (ship.LeftSideWeight / totalWeight) * 100;
            float rightSidePerc = (ship.RightSideWeight / totalWeight) * 100;
            //if()
            Console.WriteLine((ship.LeftSideWeight / totalWeight) * 100);
            Console.WriteLine((ship.RightSideWeight / totalWeight) * 100);
            return containerArray;
        }
        public static void CheckPositionAndPlace(Ship ship, List<Container> list, Container[,,] containerArray)
        {
            foreach (Container c in ship.ContainerList)
            {
                int optimalPosition = CheckOptimalPosition(ship);
                if(list.Count < ship.ContainerList.Count)
                {
                    startingPosition = 1;
                    optimalPosition = ship.Width;
                }
                for (int h = 0; h <= ship.Height - 1; h++)
                {
                    for (int l = ship.Length - 1; l >= 0; l--)
                    {
                        if (c.cooled)
                            l = 0;
                        for (int w = startingPosition - 1; w <= optimalPosition - 1; w++)
                        {
                            if (RunChecks(c, containerArray, l, w, h, ship))
                            {
                                containerArray[l, w, h] = c;
                                AddWeight(w, c, ship);
                                c.placed = true;
                                break;
                            }
                        }
                    }

                }
            }
        }
        public static bool RunChecks(Container c, Container[,,] containerArray, int l, int w, int h, Ship ship)
        {
            if (!c.placed
                && CheckValuableState(containerArray, l, w, h)
                && CheckEmptyPosition(containerArray, l, w, h)
                && NotFloating(containerArray, l, w, h)
                && CheckWeightOnTop(containerArray, l, w, h))
            {
                if (c.valuable && SpaceForValuable(containerArray, l, w, h, ship))
                    return true;
                else if (c.valuable)
                    return false;

                return true;
            }
            return false;
        }
        public static bool CheckValuableState(Container[,,] ca, int length, int width, int height)
        {
            if (length != 0 && length != ca.GetLength(0) - 1)
            {
                Container posPlusOne = ca[length + 1, width, height];
                Container posMinusOne = ca[length - 1, width, height];
                if (posPlusOne != null && posPlusOne.valuableBlocked || posMinusOne != null && posMinusOne.valuableBlocked)
                {
                    return false;
                }
                else
                {
                    if (posPlusOne != null && posPlusOne.valuable)
                    {
                        posPlusOne.valuableBlocked = true;
                    }
                    if (posMinusOne != null && posMinusOne.valuable)
                    {
                        posMinusOne.valuableBlocked = true;
                    }
                    return true;
                }
            }
            else if (length == 0)
            {
                Container posPlusOne = ca[length + 1, width, height];
                if (posPlusOne != null && posPlusOne.valuableBlocked)
                {
                    return false;
                }
                else
                {
                    if (posPlusOne != null && posPlusOne.valuable)
                    {
                        posPlusOne.valuableBlocked = true;
                    }
                    return true;
                }
            }
            else
            {
                Container posMinusOne = ca[length - 1, width, height];
                if (posMinusOne != null && posMinusOne.valuableBlocked)
                {
                    return false;
                }
                else
                {
                    if (posMinusOne != null && posMinusOne.valuable)
                    {
                        posMinusOne.valuableBlocked = true;
                    }
                    return true;
                }
            }
        }

        public static bool SpaceForValuable(Container[,,] ca, int length, int width, int height, Ship ship)
        {
            if (length == 0 || length == ship.Length - 1)
            {
                return true;
            }
            else if (length > 0 && length < ship.Length - 1)
            {
                if (ca[length + 1, width, height] == null || ca[length - 1, width, height] == null)
                    return true;
            }
            return false;
        }
        public static bool NotFloating(Container[,,] ca, int length, int width, int height)
        {
            return (height > 0 && ca[length, width, height - 1] != null || height == 0);
        }
        public static bool CheckWeightOnTop(Container[,,] ca, int length, int width, int height)
        {
            int weightOnTop = 0;
            for (int i = 0; i < height; i++)
            {
                weightOnTop += ca[length, width, i].weight;
            }
            return weightOnTop < 120000;
        }
        public static int CheckOptimalPosition(Ship ship)
        {
            if (ship.Width % 2 != 0)
            {
                if (ship.LeftSideWeight >= ship.RightSideWeight)
                {
                    startingPosition = (ship.Width / 2) + 2;
                    return ship.Width;
                }
                else
                {
                    startingPosition = 1;
                    return ship.Width / 2 + 1;
                }
            }
            else
            {
                if (ship.LeftSideWeight >= ship.RightSideWeight)
                {
                    startingPosition = (ship.Width / 2) + 1;
                    return ship.Width;
                }
                else
                {
                    startingPosition = 1;
                    return ship.Width / 2;
                }
            }
        }
        public static bool CheckEmptyPosition(Container[,,] ca, int length, int width, int height)
        {
            return (ca[length, width, height] == null);
        }
        public static void AddWeight(int width, Container c, Ship ship)
        {
            if (width > ship.Width / 2)
            {
                ship.RightSideWeight += c.weight;
            }
            else if (width < ship.Width / 2 + 1)
            {
                ship.LeftSideWeight += c.weight;
            }
        }
    }
}
