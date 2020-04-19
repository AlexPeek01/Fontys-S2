using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetic_Casus_CircusAnimals.DataAccess;

namespace LogicLayer
{
    public class Train
    {
        private List<Wagon> wagonsInTrain;
        private int trainId { get; set; }
        public Train(int _trainId)
        {
            wagonsInTrain = new List<Wagon>();
            this.trainId = _trainId;
        }
        public int _trainId
        {
            get { return trainId; }
            set { trainId = value; }
        }
        public List<Wagon> _wagonsInTrain
        {
            get { return wagonsInTrain; }
        }
        public void SaveTrainToDb(Train train)
        {
            foreach(Wagon w in train.wagonsInTrain)
            {
                foreach(Animal a in w._animalList)
                {
                    MySQLManager.MySqlQuery(w._wagonId, a._animalName, train.trainId);
                }
            }
        }
        public static int GetTrainCount()
        {
            return MySQLManager.GetTrainCount();
        }
        public void CreateWagon(Animal animal, Train train)
        {
            Wagon wagon = new Wagon(train._wagonsInTrain.Count, 10);
            wagon.AddAnimalToWagon(animal, wagon);
            train._wagonsInTrain.Add(wagon);
        }
    }
}
