using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaadHetGetal
{
    public class DoorloopMogelijkeOplossingen
    {
        private Oplossing Oplossing { get; set; }

        public DoorloopMogelijkeOplossingen(Oplossing oplossing)
        {
            this.Oplossing = oplossing;
        }

        public int VindHetGetal()
        {
            int hetGoedeGetal = -1;

            for (int i = this.Oplossing.MinGetal; i <= this.Oplossing.MaxGetal; i++)
            {
                //Console.WriteLine($"{this.GetType().Name} probeert {i}");
                if (this.Oplossing.IsDitHetGoedeGetal(i))
                {
                    hetGoedeGetal = i;
                    //Console.WriteLine($"{this.GetType().Name} heeft het goede getal gevonden!");
                    break;
                }
            }

            return hetGoedeGetal;
        }
    }
}
