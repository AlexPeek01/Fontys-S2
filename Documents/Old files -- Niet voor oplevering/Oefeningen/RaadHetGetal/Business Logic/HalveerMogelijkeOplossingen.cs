using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaadHetGetal
{
    public class HalveerMogelijkeOplossingen
    {

        public int VindHetGetal(Oplossing oplossing)
        {
            int min = oplossing.MinGetal;
            int max = oplossing.MaxGetal;

            int gokje = GetNieuwGokje(min, max);

            while (!oplossing.IsDitHetGoedeGetal(gokje))
            {
                if (oplossing.IsDitGetalHogerDanHetGoedeGetal(gokje))
                {
                    max = gokje;
                }
                else
                {
                    min = gokje;
                }

                gokje = GetNieuwGokje(min, max);
            }

            Console.WriteLine($"{this.GetType().Name} heeft het goede getal gevonden!");

            return gokje;
        }

        private int GetNieuwGokje(int min, int max)
        {
            decimal helft = (max + min) / 2;
            int gokje = (int)Math.Floor(helft);

            //Console.WriteLine($"{this.GetType().Name} probeert {gokje}");

            return gokje;
        }
    }
}
