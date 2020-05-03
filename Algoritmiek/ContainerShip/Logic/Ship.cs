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
        public int centerWeight = 0;

        public Ship(int _length, int _width, int _height, int _leftSideWeight, int _rightSideWeight)
        {
            containerList = new List<Container>();
            this.length = _length;
            this.width = _width;
            this.height = _height;
            this.leftSideWeight = _leftSideWeight;
            this.rightSideWeight = _rightSideWeight;

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
