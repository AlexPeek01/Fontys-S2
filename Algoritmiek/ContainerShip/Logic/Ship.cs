using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Ship
    {

        private List<Container> containerList { get ; set; }
        private int length;
        private int width;
        private int height;
        private int leftSideWeight = 0;
        private int rightSideWeight = 0;
        public List<Slice> slices;

        public Ship(int _length, int _width, int _height)
        {
            containerList = new List<Container>();
            this.length = _length;
            this.width = _width;
            this.height = _height;
            slices = new List<Slice>();
            for(int i = 0; i < _width; i++)
            {
                List<Column> columns = new List<Column>();
                for(int j = 0; j < _length; j++)
                {
                    columns.Add(new Column(j));
                }
                Slice slice = new Slice(i, columns);
                slices.Add(slice);
            }
        }
        public List<Container> ContainerList
        {
            get { return containerList; }
        }
        public int Length
        {
            get { return length; }
        }
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        public int LeftSideWeight
        {
            get { return leftSideWeight; }
            set { leftSideWeight = value; }
        }
        public int RightSideWeight
        {
            get { return rightSideWeight; }
            set { rightSideWeight = value; }
        }
    }
}
