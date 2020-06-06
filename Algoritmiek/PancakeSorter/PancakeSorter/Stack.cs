using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakeSorter
{
    public class Stack
    {
        public Pancake[] PancakeStack { get; set; }
        public Stack(int pancakeCount)
        {
            PancakeStack = new Pancake[pancakeCount];
        }
    }
}
