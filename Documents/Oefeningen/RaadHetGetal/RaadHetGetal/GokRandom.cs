using System;

namespace RaadHetGetal
{
    class GokRandom
    {
        private Random random = new Random(3);

        public int VindHetGetal(Oplossing oplossing)
        {
            int gokje = -1;

            while (!oplossing.IsDitHetGoedeGetal(gokje))
            {
                gokje = random.Next(oplossing.MinGetal, oplossing.MaxGetal + 1);
            }

            return gokje;
        }
    }
}
