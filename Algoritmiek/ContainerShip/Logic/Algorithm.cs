using System;
using System.Collections.Generic;
using System.Linq;
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
            CheckPositionAndPlace(ship, ship.ContainerList, containerArray, false);
            CheckPositionAndPlace(ship, unplacableContainersList, containerArray, true);
            float totalWeight = ship.LeftSideWeight + ship.RightSideWeight;
            float leftSidePerc = (ship.LeftSideWeight / totalWeight) * 100;
            float rightSidePerc = (ship.RightSideWeight / totalWeight) * 100;
            //if()
            Console.WriteLine((ship.LeftSideWeight / totalWeight) * 100);
            Console.WriteLine((ship.RightSideWeight / totalWeight) * 100);
            return containerArray;
        }
        public static void CheckPositionAndPlace(Ship ship, List<Container> list, Container[,,] containerArray, bool secondRun)
        {
            foreach (Container c in list)
            {
                List<Location> locations = new List<Location>();
                int optimalPosition = CheckOptimalPosition(ship);
                if (secondRun == true)
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
                                Location location = new Location(l, w, h, c);
                                locations.Add(location);
                            }
                            
                        }
                    }
                }
                PlaceContainer(containerArray, locations, ship);
                if (!c.placed && list != unplacableContainersList)
                {
                    unplacableContainersList.Add(c);
                }
            }
        }
        public static void PlaceContainer(Container[,,] containerArray, List<Location> possiblePositions, Ship ship)
        {
            Location toUseLoc = null;
            int height = ship.Height;
            foreach (Location location in possiblePositions)
            {
                if (location.height == 0)
                {
                    toUseLoc = location;
                    break;
                }
                else
                {
                    if(location.height < height)
                    {
                        toUseLoc = location;
                        height = location.height;
                    }
                }
            }
            if(toUseLoc != null)
            {
                containerArray[toUseLoc.length, toUseLoc.width, toUseLoc.height] = toUseLoc.container;
                AddWeight(toUseLoc.width, toUseLoc.container, ship);
                containerArray[toUseLoc.length, toUseLoc.width, toUseLoc.height].placed = true;
            }
        }
        public static bool RunChecks(Container c, Container[,,] containerArray, int l, int w, int h, Ship ship)
        {
            if (!c.placed
                && CheckValuableState(containerArray, l, w, h)
                && CheckEmptyPosition(containerArray, l, w, h)
                && ValuableUnderneath(containerArray, l, w, h)
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
        public static bool ValuableUnderneath(Container[,,] ca, int length, int width, int height)
        {
            if (height > 1 && ca[length, width, height - 1] != null)
            {
                if(ca[length, width, height - 1].valuable)
                {
                    return false;
                }
            }
            return true;
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
        //Needs some fixing
        public static bool CheckWeightOnTop(Container[,,] ca, int length, int width, int height)
        {
            int weightOnTop = 0;
            //for (int i = 1; i < height; i++)
            //{
            //    weightOnTop += ca[length, width, i].weight;
            //}
            return weightOnTop < 120000;
        }
        public static int CheckOptimalPosition(Ship ship)
        {
            if (ship.Width % 2 != 0)
            {
                if (ship.LeftSideWeight >= ship.RightSideWeight)
                {
                    //Rechterkant
                    startingPosition = (ship.Width / 2) + 1; //Confirmed //Used to be + 2
                    return ship.Width; //Confirmed
                }
                else
                {
                    //Linkerkant
                    startingPosition = 1; //Confirmed
                    return ship.Width / 2 + 1; //Confirmed
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
            //Line under this something is broken
            if (width >= ship.Width / 2 + 1) //Zeker goed
            {
                ship.RightSideWeight += c.weight;
            }
            if (width <= ship.Width / 2 + 1) //Confirmed
            {
                ship.LeftSideWeight += c.weight;
            }
        }
    }
}
