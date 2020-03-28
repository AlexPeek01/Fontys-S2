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
        public List<Wagon> wagonsInTrain;
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
    }
}
