using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Algorithm2
    {
        public static void PlaceContainers(Ship ship)
        {
            foreach (Container container in ship.ContainerList)
            {
                PlaceContainer(FindMinimalColumnWeight(ship), container);
            }
        }
        public static void PlaceContainer(Column column, Container container)
        {
            column.containers.Add(container);
        }
        public static Column FindMinimalColumnWeight(Ship ship)
        {
            int minWeightColumn = Int32.MaxValue;
            Column optimalColumn = null;
            foreach (Slice slice in ship.slices)
            {
                foreach (Column column in slice.columns)
                {
                    int columnWeight = 0;
                    foreach (Container c in column.containers)
                    {
                        columnWeight += c.weight;
                    }
                    if (columnWeight == 0)
                    {
                        return column;
                    }
                    if (columnWeight < minWeightColumn)
                    {
                        minWeightColumn = columnWeight;
                        optimalColumn = column;
                    }
                }
            }
            return optimalColumn;
        }
        public static int[] LeftOrRightSide(Ship ship)
        {
            int centerRowIndex = ship.Width / 2;
            int[] widthIndex = new int[2];
            if (ship.Width % 2 != 0)
            {
                if (ship.LeftSideWeight >= ship.RightSideWeight)
                {
                    widthIndex[0] = centerRowIndex;
                    widthIndex[1] = ship.Width - 1;
                    return widthIndex;
                }
                widthIndex[0] = 0;
                widthIndex[1] = centerRowIndex;
                return widthIndex;
            }
            else
            {
                if (ship.LeftSideWeight >= ship.RightSideWeight)
                {
                    widthIndex[0] = ship.Width / 2;
                    widthIndex[1] = ship.Width - 1;
                    return widthIndex;
                }
                widthIndex[0] = 0;
                widthIndex[1] = ship.Width / 2 - 1;
                return widthIndex;
            }
        }
        public static bool RunChecks()
        {
            return false;
        }
        public static void AddWeight(int width, Container c, Ship ship)
        {

        }
    }
}
