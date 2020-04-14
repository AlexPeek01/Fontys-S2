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
            /*Checkt of het eerste dier in de wagon een carnivoor is, of er ruimte is voor het dier dat je wilt plaatsen en ofdat het dier
            dat je wilt plaatsen groter is dan de carnivoor.*/
            if (w._animalList[0]._carnivore && w._spaceAvailable >= animal._size && w._animalList[0]._size < animal._size)
                return false;
            //Checkt of het eerste dier in de wagon een herbivoor is en of er ruimte is voor het dier dat je wilt plaatsen.
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
                    Wagon.CreateWagon(a, train);        //Als het dier dat geplaatst moet worden een carnivoor is maak een nieuwe wagon aan.
                else
                {
                    bool wagonNotFound = true;
                    foreach (Wagon w in train._wagonsInTrain)
                    {
                        wagonNotFound = CheckWagon(a, w);      //Checkt of een wagen geschikt is voor het dier dat je wilt plaatsen.
                        if (!wagonNotFound)
                        {
                            Wagon.AddAnimalToWagon(a, w);      //Als er een wagon beschikbaar is wordt het dier aan die wagon toegevoegd.
                            break;
                        }
                    }
                    if (wagonNotFound)
                        Wagon.CreateWagon(a, train);        //Als er geen wagon beschikbaar is wordt er een nieuwe wagon aangemaakt.
                }
            }
            return train;
        }
    }
}
