using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals
{
    class Wagon
    {
        ///////////////////////////Fields
        public static List<Wagon> wagonList = new List<Wagon>();
        public int wagonId;
        public int spaceAvailable;
        public List<Animal> animalsInWagon;

        ///////////////////////////Constructor
        public Wagon(int _wagonId, int _spaceAvailable)
        {
            this.wagonId = _wagonId;
            this.spaceAvailable = _spaceAvailable;
            animalsInWagon = new List<Animal>();
        }

        ///////////////////////////Get/Set
        public int WagonId
        {
            get { return wagonId; }
            set { wagonId = value; }
        }
        public int SpaceAvailable
        {
            get { return spaceAvailable; }
            set { spaceAvailable = value; }
        }

        ///////////////////////////Methods
        public static void AddAnimal(int i, Wagon wagon, List<Animal> list, int trainCount)
        {
            wagon.animalsInWagon.Add(list[i]);
            wagon.spaceAvailable -= list[i].Size;
            DAL.MySQLManager.MySqlQuery(wagon.wagonId, list[i].AnimalName, trainCount);
        }
        public static void AddCarnivoreToWagon(int i, Wagon wagon, List<Animal> list, int trainCount)
        {

        }
    }
}
