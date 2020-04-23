using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaadHetGetal
{
    public class GokRandomMaarNietDubbel
    {
        private Oplossing Oplossing { get; set; }
        private Random random = new Random(2);
        private List<int> vorigePogingen = new List<int>();

        public GokRandomMaarNietDubbel(Oplossing oplossing)
        {
            this.Oplossing = oplossing;
        }

        public int VindHetGetal()
        {
            int gokje = -1;

            while (!this.Oplossing.IsDitHetGoedeGetal(gokje))
            {
                do
                {
                    gokje = random.Next(this.Oplossing.MinGetal, this.Oplossing.MaxGetal + 1);

                } while (vorigePogingen.Contains(gokje));

                //Console.WriteLine($"{this.GetType().Name} probeert {gokje}");
                vorigePogingen.Add(gokje);

            }

            //Console.WriteLine($"{this.GetType().Name} heeft het goede getal gevonden!");

            return gokje;
        }
    }
}
