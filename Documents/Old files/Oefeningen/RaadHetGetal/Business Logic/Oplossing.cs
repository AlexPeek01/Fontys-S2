using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaadHetGetal
{
    public class Oplossing
    {
        private int defaultMinGetal=1;
        private int defaultMaxGetal=10;
        private int mijnMooieGetal;

        public int MinGetal { get; private set; }

        public int MaxGetal { get; private set; }

        public Oplossing(int minGetal, int maxGetal)
        {
            SetMinNumber(minGetal);
            SetMaxNumber(minGetal, maxGetal);
            SetRandomNumber(minGetal, maxGetal);
        }
        public void SetMinNumber(int minGetal)
        {
            if (minGetal <= 0) minGetal = this.defaultMinGetal;
            this.MinGetal = minGetal;
        }
        public void SetMaxNumber(int minGetal, int maxGetal)
        {
            if (maxGetal <= 0) maxGetal = this.defaultMaxGetal;
            if (maxGetal <= minGetal) maxGetal = minGetal + defaultMaxGetal;
            this.MaxGetal = maxGetal;
        }
        public void SetRandomNumber(int minGetal, int maxGetal)
        {
            this.mijnMooieGetal = new Random().Next(minGetal, maxGetal + 1);
        }
        public bool IsDitHetGoedeGetal(int gokje)
        {
            return gokje == this.mijnMooieGetal;
        }

        public bool IsDitGetalHogerDanHetGoedeGetal(int gokje)
        {
            return gokje > this.mijnMooieGetal;
        }
    }
}
