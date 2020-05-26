using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Slice
    {
        public int index;
        public List<Column> columns;
        public Slice(int index, List<Column> columns)
        {
            this.index = index;
            this.columns = columns;
        }
    }
}
