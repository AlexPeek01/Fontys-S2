using Arithmetic_Casus_CircusAnimals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer
{
    public class Algorithm
    {
        public Algorithm() { }
        /// <summary>
        /// Het algoritme dat alle checks doet.
        /// </summary>
        /// <param name="animalList"></param>
        /// <returns></returns>
        public Train PlaceAnimalsInTrain(List<Animal> animalList)
        {
            List<Animal> sortedAnimalList = MainLogic.SortList(animalList);
            Train train = new Train();
            foreach (Animal animal in sortedAnimalList)
            {
                if (animal.carnivore)
                {
                    Wagon wagon = train.CreateWagon();
                    wagon.AddAnimalToWagon(animal);
                    continue;
                }
                else if (train.CheckForViableWagon(animal))
                    continue;
                else
                {
                    Wagon wagon = train.CreateWagon();
                    wagon.AddAnimalToWagon(animal);
                }
            }
            return train;
        }
    }
}
