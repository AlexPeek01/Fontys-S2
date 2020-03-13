using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals
{
    class Train
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

        public static void CreateTrain(int _trainId)
        {
            Train train = new Train(_trainId);
        }
    }
}
