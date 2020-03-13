using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals
{
    public class Animal
    {
        ///////////////////////////Fields
        public static List<Animal> oldAnimalList = new List<Animal>();
        private bool carnivore;
        private int size;
        private string animalName;
        private bool isPlaced;

        ///////////////////////////Constructor
        public Animal(bool _carnivore, int _size, string _animalName, bool _isPlaced)
        {
            this.carnivore = _carnivore;
            this.size = _size;
            this.animalName = _animalName;
            this.isPlaced = _isPlaced;
        }
        ///////////////////////////Get/Set
        public bool Carnivore
        {
            get { return carnivore; }
            set { carnivore = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public string AnimalName
        {
            get { return animalName; }
            set { animalName = value; }
        }
        public bool IsPlaced
        {
            get { return IsPlaced; }
            set { IsPlaced = value; }
        }
        ///////////////////////////Methods
        public static void CreateAnimal(bool isCarnivore, int size, string animalName, bool isPlaced)
        {
            Animal animal = new Animal(isCarnivore, size, animalName, isPlaced);
            oldAnimalList.Add(animal);
        }
        public static void PlaceAnimalInWagon()
        {
            int trainCount = DAL.MySQLManager.GetTrainCount();
            List<Animal> sortedAnimalList = MainLogic.SortList(oldAnimalList);
            for (int i = 0; i < sortedAnimalList.Count(); i++)
            {

                if (sortedAnimalList[i].Carnivore == true)
                {
                    Wagon wagon = new Wagon(i, 10);
                    Wagon.AddAnimal(i, wagon, sortedAnimalList, trainCount);
                    Wagon.wagonList.Add(wagon);
                }
                else if (sortedAnimalList[i].Carnivore == false)
                {
                    bool wagonNotFound = true;
                    foreach (Wagon w in Wagon.wagonList)
                    {
                        if (w.animalsInWagon[0].Carnivore == true && w.spaceAvailable >= sortedAnimalList[i].Size && w.animalsInWagon[0].Size < sortedAnimalList[i].Size)
                        {
                            Wagon.AddAnimal(i, w, sortedAnimalList, trainCount);
                            wagonNotFound = false;
                            break;
                        }
                        else if (w.animalsInWagon[0].Carnivore == false && w.spaceAvailable >= sortedAnimalList[i].Size)
                        {
                            Wagon.AddAnimal(i, w, sortedAnimalList, trainCount);
                            wagonNotFound = false;
                            break;
                        }
                    }
                    if (wagonNotFound == true)
                    {
                        Wagon wagon = new Wagon(Wagon.wagonList.Count, 10);
                        Wagon.wagonList.Add(wagon);
                        Wagon.AddAnimal(i, wagon, sortedAnimalList, trainCount);
                        wagonNotFound = false;
                    }
                }
            }
        }
    }
}
