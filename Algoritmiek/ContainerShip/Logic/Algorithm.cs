using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Algorithm
    {

        /*
        Eerst gekoeld
        Dan de normale
        Als laatste waardevolle
        Balanschecken
        min 50% van gewicht benut checken
        Gewicht bovenop container checken
         */
        private static int startingPosition = 0;
        public static Container[,,] placeContainerArray(Ship ship)
        {
            Container[,,] containerArray = new Container[ship.Length, ship.Width, ship.Height];
            foreach (Container c in ship.ContainerList)
            {
                int optimalPosition = CheckOptimalPosition(containerArray, ship);

                for (int l = 0; l <= ship.Length - 1; l++)
                {
                    if (c.Cooled)
                        l = 0;
                    for (int h = 0; h <= ship.Height - 1; h++)
                    {
                        for (int w = startingPosition - 1; w <= optimalPosition - 1; w++)
                        {
                            if (!c.Placed && CheckUnderForValuable(containerArray, l, w, h, ship) && CheckEmptyPosition(containerArray, l, w, h) && CheckSpacesAround(containerArray, l, w, h, ship) && NotFloating(containerArray, l, w, h) && CheckWeightOnTop(containerArray, l, w, h))
                            {
                                containerArray[l, w, h] = c;
                                AddWeight(w, c, ship);
                                c.Placed = true;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    if (c.Cooled)
                        l = ship.Length - 1;
                }
            }

            //////////////////////////////////////////////////////////////

            int i = 0;
            foreach (Container c in containerArray)
            {
                if (c != null)
                {
                    i++;
                }
            }
            Console.WriteLine(i);
            return containerArray;
        }
        public static bool NotOnTheEdge(int length, Ship ship)
        {
            return (length > 1 && length < ship.Length - 1);
        }

        //Fix this monstrosity underneath
        public static bool CheckUnderForValuable(Container[,,] ca, int length, int width, int height, Ship ship)
        {
            if (height > 0 && ca[length, width, height - 1] != null)
            {
                if (ca[length, width, height - 1].Valuable)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if ()
            {

            }
            
            
        }
        public static bool CheckSpacesAround(Container[,,] ca, int length, int width, int height, Ship ship)
        {
            bool inFront = false;
            bool behind = false;
            bool inFrontVal = false;
            bool behindVal = false;
            if (NotOnTheEdge(length, ship))
            {
                if (ca[length + 1, width, height] != null && ca[length + 1, width, height].Valuable)
                {
                    inFrontVal = true;
                    if(ca[length + 2, width, height] == null)
                    {
                        inFront = true;
                    }
                }
                else
                {
                    inFront = true;
                }
                if (ca[length - 1, width, height] != null && ca[length - 1, width, height].Valuable)
                {
                    behindVal = true;
                    if (ca[length - 2, width, height] == null)
                    {
                        behind = true;
                    }
                }
                else
                {
                    behind = true;
                }
                
            }
            else
            {
                if(length < ship.Length / 2)
                {
                    if (ca[length + 1, width, height] != null && ca[length + 1, width, height].Valuable)
                    {
                        inFrontVal = true;
                        if (ca[length + 2, width, height] == null)
                        {
                            inFront = true;
                        }
                    }
                }
                else
                {
                    if (ca[length - 1, width, height] != null && ca[length - 1, width, height].Valuable)
                    {
                        behindVal = true;
                        if (ca[length - 2, width, height] == null)
                        {
                            behind = true;
                        }
                    }
                }
            }
            if (inFront && behind || !inFrontVal && !behindVal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool SpaceForValuable(Container[,,] ca, int length, int width, int height)
        {
            return (ca[length + 1, width, height] == null || ca[length - 1, width, height] == null);
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
                weightOnTop += ca[length, width, i].Weight;
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
                ship.RightSideWeight += c.Weight;
            }
            else if (width < ship.Width / 2 + 1)
            {
                ship.LeftSideWeight += c.Weight;
            }
        }
    }
}
