using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Train
    {
        public List<Wagon> wagonsInTrain { get; private set; }
        public int trainId { get; private set; }
        public Train()
        {
            wagonsInTrain = new List<Wagon>();
        }
    }
}
