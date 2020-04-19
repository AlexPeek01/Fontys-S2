using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Algorithm
    {
        private static int startingPosition = 0;
        public static Container[,,] placeContainerArray(Ship ship)
        {
            Container[,,] containerArray = new Container[ship.Length, ship.Width, ship.Height];
            foreach (Container c in ship.ContainerList)
            {
                int optimalPosition = CheckOptimalPosition(containerArray, ship);
                for (int l = ship.Length - 1; l >= 0; l--)
                {
                    if (c.cooled)
                        l = 0;
                    for (int h = 0; h <= ship.Height - 1; h++)
                    {
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
            return containerArray;
        }
        public static bool RunChecks(Container c, Container[,,] containerArray, int l, int w, int h, Ship ship)
        {
            if (!c.placed
                && CheckValuableState(containerArray, l, w, h)
                && CheckEmptyPosition(containerArray, l, w, h)
                && NotFloating(containerArray, l, w, h)
                && CheckWeightOnTop(containerArray, l, w, h)
                && SpaceForValuable(containerArray, l, w, h, ship)
                )
            {
                return true;
            }
            return false;
        }
        //Sumting goes wrong here
        public static bool CheckValuableState(Container[,,] ca, int length, int width, int height)
        {
            if (length > 0 && length < ca.GetLength(0) - 1)
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
            else
            {
                return true;
            }
        }

        //Fix this monstrosity underneath
        public static bool SpaceForValuable(Container[,,] ca, int length, int width, int height, Ship ship)
        {
            if (length > 1 && length < ship.Length - 1)
            {
                return (ca[length + 1, width, height] == null || ca[length - 1, width, height] == null);
            }
            else
            {
                return true;
            }
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
        public static int CheckOptimalPosition(Container[,,] ca, Ship ship)
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
            if (width >= ship.Width / 2)
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
