using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetic_Casus_CircusAnimals.DataAccess;

namespace LogicLayer
{
    public class Wagon
    {
        ///////////////////////////Fields
        private int wagonId;
        private int spaceAvailable;
        private List<Animal> animalsInWagon;

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
        public List<Animal> _animalList
        {
            get { return animalsInWagon; }
        }

        ///////////////////////////Methods
        public static void AddAnimalToWagon(Animal animal, Wagon wagon)
        {
            wagon.animalsInWagon.Add(animal);
            wagon.spaceAvailable -= animal._size;
        }
        public static void CreateWagon(Animal animal, Train train)
        {
            Wagon wagon = new Wagon(train.wagonsInTrain.Count, 10);
            Wagon.AddAnimalToWagon(animal, wagon);
            train.wagonsInTrain.Add(wagon);
        }
        
    }
}
