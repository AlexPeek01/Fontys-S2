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
                if (c.Cooled && !c.Valuable)
                {
                    for (int h = 0; h <= ship.Height - 1; h++)
                    {
                        for (int w = startingPosition - 1; w <= optimalPosition - 1; w++)
                        {
                            if (!c.Placed)
                            {
                                if (CheckEmptyPosition(containerArray, 0, w, h) && CheckSpacesAround(containerArray, 0, w, h))
                                {
                                    if (NotFloating(containerArray, 0, w, h))
                                    {
                                        if (CheckWeightOnTop(containerArray, 0, w, h))
                                        {
                                            containerArray[0, w, h] = c;
                                            AddWeight(w, c, ship);
                                            c.Placed = true;
                                            break;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }

                    }
                }
                else if (!c.Cooled && !c.Valuable)
                {
                    for (int l = 0; l <= ship.Length - 1; l++)
                    {
                        for (int h = 0; h <= ship.Height - 1; h++)
                        {
                            for (int w = startingPosition - 1; w <= optimalPosition - 1; w++)
                            {
                                if (!c.Placed)
                                {
                                    if (CheckEmptyPosition(containerArray, l, w, h) && CheckSpacesAround(containerArray, l, w, h))
                                    {
                                        if (NotFloating(containerArray, l, w, h))
                                        {
                                            if (CheckWeightOnTop(containerArray, l, w, h))
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
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }

                        }
                    }
                }
                else if (c.Cooled && c.Valuable)
                {
                    for (int h = 0; h <= ship.Height - 1; h++)
                    {
                        for (int w = startingPosition - 1; w <= optimalPosition - 1; w++)
                        {
                            if (!c.Placed)
                            {
                                if (CheckEmptyPosition(containerArray, 0, w, h) && CheckSpacesAround(containerArray, 0, w, h))
                                {
                                    if (NotFloating(containerArray, 0, w, h))
                                    {
                                        if (CheckWeightOnTop(containerArray, 0, w, h))
                                        {
                                            if (SpaceForValuable(containerArray, 0, w, h))
                                            {
                                                containerArray[0, w, h] = c;
                                                AddWeight(w, c, ship);
                                                c.Placed = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }

                    }
                }
                else if (!c.Cooled && c.Valuable)
                {
                    for (int l = 0; l <= ship.Length - 1; l++)
                    {
                        for (int h = 0; h <= ship.Height - 1; h++)
                        {
                            for (int w = startingPosition - 1; w <= optimalPosition - 1; w++)
                            {
                                if (!c.Placed)
                                {
                                    if (CheckEmptyPosition(containerArray, l, w, h) && CheckSpacesAround(containerArray, l, w, h))
                                    {
                                        if (NotFloating(containerArray, l, w, h))
                                        {
                                            if (CheckWeightOnTop(containerArray, l, w, h))
                                            {
                                                if (SpaceForValuable(containerArray, l, w, h))
                                                {
                                                    containerArray[l, w, h] = c;
                                                    AddWeight(w, c, ship);
                                                    c.Placed = true;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }

                        }
                    }
                }
            }
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
        //Fix this monstrosity underneath
        public static bool CheckSpacesAround(Container[,,] ca, int length, int width, int height)
        {
            if (length + 2 > ca.GetLength(0) - 1 && height - 1 > 0 && height + 1 < ca.GetLength(2) || length - 2 < 0 && height - 1 > 0 && height + 1 < ca.GetLength(2))
            {
                if (!ca[length, width, height - 1].Valuable)
                return true;
            }
            else if (length + 2 > ca.GetLength(0) - 1 && height <= 0 || length - 2 < 0 && height <= 0)
            {
                return true;
            }
            else if (ca[length + 1, width, height] != null)
            {
                if (ca[length + 1, width, height].Valuable && !ca[length, width, height - 1].Valuable)
                {
                    return ca[length + 2, width, height] == null;
                }
            }
            else if (ca[length - 1, width, height] != null)
            {
                if (ca[length - 1, width, height].Valuable && !ca[length, width, height - 1].Valuable)
                {
                    return ca[length - 2, width, height] == null;
                }
            }
            return false;
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
