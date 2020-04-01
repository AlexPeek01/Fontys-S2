using Arithmetic_Casus_CircusAnimals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arithmetic_Casus_CircusAnimals.DataAccess;

namespace LogicLayer
{
    public class Algoritmiek
    {
        public static bool CheckWagon(Animal animal, Wagon w)
        {
            //Checks if the first animal in the wagon is a carnivore, if the animal still fits in the wagon and if the animal is bigger than the carnivore
            if (w._animalList[0]._carnivore && w._spaceAvailable >= animal._size && w._animalList[0]._size < animal._size)
                return false;
            //Checks if the first animal in the wagon is a herbivore and if the animal still fits in the wagon
            else if (!w._animalList[0]._carnivore && w._spaceAvailable >= animal._size)
                return false;
            else
                return true;
        }
        public static Train PlaceAnimalsInTrain(List<Animal> sortedAnimalList)
        {
            Train train = new Train(Train.GetTrainCount());
            foreach (Animal a in sortedAnimalList)
            {
                if (a._carnivore)
                    Wagon.CreateWagon(a, train);
                else
                {
                    bool wagonNotFound = true;
                    foreach (Wagon w in train._wagonsInTrain)
                    {
                        wagonNotFound = CheckWagon(a, w);
                        if (!wagonNotFound)
                        {
                            Wagon.AddAnimalToWagon(a, w);
                            break;
                        }
                    }
                    if (wagonNotFound)
                        Wagon.CreateWagon(a, train);
                }
            }
            return train;
        }
    }
}
