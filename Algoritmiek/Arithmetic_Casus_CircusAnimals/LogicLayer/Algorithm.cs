using Arithmetic_Casus_CircusAnimals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer
{
    public class Algorithm
    {
        public Algorithm()
        {
        }
        
        public Train PlaceAnimalsInTrain(List<Animal> animalList)
        {
            List<Animal> sortedAnimalList = MainLogic.SortList(animalList);
            Train train = new Train(Train.GetTrainCount());
            foreach (Animal a in sortedAnimalList)
            {
                if (a._carnivore)                   
                    train.CreateWagon(a);        //Als het dier dat geplaatst moet worden een carnivoor is maak een nieuwe wagon aan.
                else
                {
                    bool wagonNotFound = true;
                    foreach (Wagon w in train._wagonsInTrain)
                    {
                        wagonNotFound = w.CheckWagon(a);      //Checkt of een wagen geschikt is voor het dier dat je wilt plaatsen.
                        if (!wagonNotFound)
                        {
                            w.AddAnimalToWagon(a);      //Als er een wagon beschikbaar is wordt het dier aan die wagon toegevoegd.
                            break;
                        }
                    }
                    if (wagonNotFound)
                        train.CreateWagon(a);        //Als er geen wagon beschikbaar is wordt er een nieuwe wagon aangemaakt.
                }
            }
            return train;
        }
    }
}
