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
        public static bool CheckMeasurements(Animal animal, Wagon w)
        {
            if (w._animalList[0]._carnivore && w._spaceAvailable >= animal._size && w._animalList[0]._size < animal._size)
                return false;
            else if (!w._animalList[0]._carnivore && w._spaceAvailable >= animal._size)
                return false;
            else
                return true;
        }
        public static Train PlaceAnimalsInWagon(List<Animal> sortedAnimalList)
        {
            Train train = new Train(Train.GetTrainCount());
            foreach (Animal a in sortedAnimalList)
            {
                if (a._carnivore)
                    Wagon.CreateWagon(a, train);
                else
                {
                    bool wagonNotFound = true;
                    foreach (Wagon w in train.wagonsInTrain)
                    {
                        wagonNotFound = CheckMeasurements(a, w);
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
            train.SaveTrainToDb(train);
            return train;
        }
    }
}
