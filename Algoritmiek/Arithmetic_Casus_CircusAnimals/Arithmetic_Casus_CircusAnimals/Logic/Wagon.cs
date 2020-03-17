using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals
{
    public class Wagon
    {
        ///////////////////////////Fields
        public static List<Wagon> wagonList = new List<Wagon>();
        private int wagonId;
        private int spaceAvailable;
        public List<Animal> animalsInWagon;

        ///////////////////////////Constructor
        public Wagon(int _wagonId, int _spaceAvailable)
        {
            this.wagonId = _wagonId;
            this.spaceAvailable = _spaceAvailable;
            animalsInWagon = new List<Animal>();
        }

        ///////////////////////////Get/Set
        public int _wagonId
        {
            get { return wagonId; }
            set { wagonId = value; }
        }
        public int _spaceAvailable
        {
            get { return spaceAvailable; }
            set { spaceAvailable = value; }
        }

        ///////////////////////////Methods
        public static void AddAnimalToWagon(int i, Wagon wagon, List<Animal> list, int trainId)
        {
            wagon.animalsInWagon.Add(list[i]);
            wagon.spaceAvailable -= list[i]._size;
            DAL.MySQLManager.MySqlQuery(wagon.wagonId, list[i]._animalName, trainId);
        }

        public static void PlaceAnimalsInWagon(List<Animal> sortedAnimalList, int trainId)
        {
            for (int i = 0; i < sortedAnimalList.Count(); i++)
            {
                if (sortedAnimalList[i]._carnivore == true)
                {
                    Wagon wagon = new Wagon(wagonList.Count, 10);
                    AddAnimalToWagon(i, wagon, sortedAnimalList, trainId);
                    wagonList.Add(wagon);
                }
                else if (sortedAnimalList[i]._carnivore == false)
                {
                    bool wagonNotFound = true;
                    foreach (Wagon w in wagonList)
                    {
                        if (w.animalsInWagon[0]._carnivore == true && w.spaceAvailable >= sortedAnimalList[i]._size && w.animalsInWagon[0]._size < sortedAnimalList[i]._size)
                        {
                            AddAnimalToWagon(i, w, sortedAnimalList, trainId);
                            wagonNotFound = false;
                            break;
                        }
                        else if (w.animalsInWagon[0]._carnivore == false && w.spaceAvailable >= sortedAnimalList[i]._size)
                        {
                            AddAnimalToWagon(i, w, sortedAnimalList, trainId);
                            wagonNotFound = false;
                            break;
                        }
                    }
                    if (wagonNotFound == true)
                    {
                        Wagon wagon = new Wagon(wagonList.Count, 10);
                        wagonList.Add(wagon);
                        AddAnimalToWagon(i, wagon, sortedAnimalList, trainId);
                    }
                }
            }
        }
    }
}
