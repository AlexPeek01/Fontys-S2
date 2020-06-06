using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakeSorter
{
    public class Algorithm
    {
        public Pancake[] RunAlgorithm(Pancake[] stack)
        {
            foreach (Pancake pancake in stack)
            {
                int index = FindNextIndex(stack);
                stack = FlipTop(stack, index);
                stack = FlipAll(stack);
            }
            return stack;
        }
        public List<Pancake> CreateStack()
        {
            List<Pancake> stack = new List<Pancake>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                stack.Add(new Pancake(r.Next(0, 10), i));
            }
            return stack;
        }
        public int FindNextIndex(Pancake[] stack)
        {
            Pancake largestpc = new Pancake(0, -1);
            int index = -1;
            for (int i = 0; i < stack.Length; i++)
            {
                if (stack[i] != null && !stack[i].Sorted)
                {
                    if (stack[i].Size > largestpc.Size)
                    {
                        largestpc = stack[i];
                        index = i;
                    }
                }
            }
            stack[index].Sorted = true;
            return index;
        }
        public Pancake[] FlipTop(Pancake[] stack, int index)
        {
            Pancake[] topPortion = new Pancake[stack.Length];
            for (int i = index; i < stack.Length; i++)
            {
                topPortion[i] = stack[i];
            }
            topPortion = topPortion.Reverse().ToArray();
            for (int i = index; i < stack.Length; i++)
            {
                if (topPortion[i] != null)
                    stack[i] = topPortion[i];
            }
            return stack;
        }
        public Pancake[] FlipAll(Pancake[] stack) => stack.Reverse().ToArray();
    }
}
