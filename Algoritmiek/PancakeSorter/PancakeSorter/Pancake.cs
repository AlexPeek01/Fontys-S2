using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakeSorter
{
    public class Pancake
    {
        public int Size { get; private set; }
        public bool Sorted { get; set; }
        public int Index { get; set; }
        public Pancake(int size, int index)
        {
            this.Size = size;
            this.Index = index;
        }
    }
}
