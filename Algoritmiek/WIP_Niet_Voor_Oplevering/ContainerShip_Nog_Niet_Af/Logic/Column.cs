using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Column
    {
        public int index;
        public List<Container> containers;
        public Column(int index)
        {
            this.index = index;
            containers = new List<Container>();
        }
    }
}
