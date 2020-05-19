using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class AnimalSorter
    {
        //public void ChooseOptimalWagonUse(Wagon wagon, List<Animal> animalList)
        //{
        //    int[] animalArray = new int[10];
        //    int smallCount = 0;
        //    int mediumCount = 0;
        //    int largeCount = 0;
        //    foreach (Animal animal in animalList)
        //    {
        //        if (!animal.carnivore)
        //        {
        //            if (animal.animalSize == 5)
        //            {
        //                largeCount++;
        //            }
        //            else if (animal.animalSize == 3)
        //            {
        //                mediumCount++;
        //            }
        //            else if (animal.animalSize == 1)
        //            {
        //                smallCount++;
        //            }
        //        }
        //    }
        //    int spaceLeft = 10 - wagon.spaceAvailable;
        //    if (spaceLeft == 9)
        //    {
        //        if (largeCount > 0 && mediumCount > 0 && smallCount > 0)
        //        {
        //            animalArray[0] = 5;
        //            animalArray[1] = 3;
        //            animalArray[2] = 1;
        //        }
        //        else if (largeCount == 0 && mediumCount > 1 && smallCount > 0)
        //        {
        //            animalArray[0] = 3;
        //            animalArray[1] = 3;

        //        }
        //    }
        //    else if (spaceLeft == 7)
        //    {

        //    }
        //    else if (spaceLeft == 5 && !wagon.animalsInWagon[0].carnivore)
        //    {
        //        if (largeCount > 0 && mediumCount > 0 && smallCount > 0)
        //        {
        //            animalArray[0] = 5;
        //        }
        //        else if (largeCount == 0 && mediumCount > 0 && smallCount > 1)
        //        {
        //            animalArray[0] = 3;
        //            animalArray[1] = 1;
        //            animalArray[2] = 1;
        //        }
        //        else if (largeCount == 0 && mediumCount == 0 && smallCount >= 5)
        //        {
        //            animalArray[0] = 1;
        //            animalArray[1] = 1;
        //            animalArray[2] = 1;
        //            animalArray[3] = 1;
        //            animalArray[4] = 1;
        //        }
        //    }
        //}
    }
}
