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
        public Train PlaceAnimalsInTrain(List<Animal> animalList, Train train)
        {
            // Input checks
            if (animalList == null) animalList = new List<Animal>();
            if (train == null) return new Train();

            // Place each animal
            foreach (Animal animal in animalList)
            {
                Wagon optimalWagon = train.FindOptimalWagon(animal);
                if (optimalWagon != null)
                {
                    optimalWagon.AddAnimalToWagon(animal);
                }
                else
                {
                    train.CreateWagon().AddAnimalToWagon(animal);
                }
            }
            return train;
        }
    }
}
