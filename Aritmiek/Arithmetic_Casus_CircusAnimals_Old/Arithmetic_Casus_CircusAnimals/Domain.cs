using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals
{
    class Domain
    {
        public static void CreateAnimal(bool isCarnivore, int size, string animalName, bool isPlaced)
        {
            Animal animal = new Animal(isCarnivore, size, animalName, isPlaced);
            Animal.oldAnimalList.Add(animal);
        }
        public static void AddAnimal(int i, Wagon wagon, List<Animal> list)
        {
            wagon.animalsInWagon.Add(list[i]);
            wagon.spaceAvailable -= list[i].size;
        }
        public static List<Animal> SortList(List<Animal> aList)
        {
            var sorted = from animal in aList
                         orderby animal.carnivore descending
                         select animal;
            return sorted.ToList<Animal>();
        }
        public static void PlaceAnimalInWagon()
        {
            List<Animal> sortedAnimalList = SortList(Animal.oldAnimalList);
            for (int i = 0; i < sortedAnimalList.Count(); i++)
            {

                    if (sortedAnimalList[i].carnivore == true)
                    {
                        Wagon wagon = new Wagon(i, 10);
                        Wagon.wagonList.Add(wagon);
                        Wagon.wagonList[Wagon.wagonList.Count - 1].animalsInWagon.Add(sortedAnimalList[i]);
                        Wagon.wagonList[Wagon.wagonList.Count - 1].spaceAvailable -= sortedAnimalList[i].size;
                    }
                    else if (sortedAnimalList[i].carnivore == false)
                    {
                        bool wagonNotFound = true;
                        foreach (Wagon w in Wagon.wagonList)
                        {
                            if (w.animalsInWagon[0].carnivore == true && w.spaceAvailable >= sortedAnimalList[i].size && w.animalsInWagon[0].size < sortedAnimalList[i].size)
                            {
                                AddAnimal(i, w, sortedAnimalList);
                                wagonNotFound = false;
                                break;
                            }
                            else if (w.animalsInWagon[0].carnivore == false && w.spaceAvailable >= sortedAnimalList[i].size)
                            {
                                AddAnimal(i, w, sortedAnimalList);
                                wagonNotFound = false;
                                break;
                            }
                        }
                        if (wagonNotFound == true)
                        {
                            Wagon wagon = new Wagon(Wagon.wagonList.Count, 10);
                            Wagon.wagonList.Add(wagon);
                            AddAnimal(i, wagon, sortedAnimalList);
                            wagonNotFound = false;
                        }
                }
            }
        }
        public static double CalculateEfficiency()
        {
            double totalSpaceAvailable = 0;
            foreach (Wagon w in Wagon.wagonList)
            {
                totalSpaceAvailable += (10 - w.spaceAvailable);
            }
            return (totalSpaceAvailable / (Wagon.wagonList.Count * 10)) * 100;
        }
    }
}