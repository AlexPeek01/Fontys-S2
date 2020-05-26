using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Location
    {
        public int length;
        public int width;
        public int height;
        public Container container;
        public Location(int length, int width, int height, Container container)
        {
            this.length = length;
            this.width = width;
            this.height = height;
            this.container = container;
        }
    }
}
