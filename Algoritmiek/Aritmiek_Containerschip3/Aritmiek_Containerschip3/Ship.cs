using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aritmiek_Containerschip3
{
    class Ship
    {
        public List<Container> unsortedContainerList;
        private Container[,,] containerArray;
        private double minWeight { get; set; }
        private int length { get; set; }
        private int width { get; set; }
        private int height { get; set; }
        public Ship(int _length, int _width, int _height)
        {
            unsortedContainerList = new List<Container>();
            containerArray = new Container[_length, _width, _height];
            this.minWeight = CalculateMinWeight(_length, _width, _height);
            this.length = _length;
            this.width = _width;
            this.height = _height;
        }
        private double CalculateMinWeight(int length, int width, int height)
        {
            return (length * width * height * 30000) * 0.5;
        }
        public static List<Container> SortContainerList(List<Container> _unsortedContainerList)
        {
            var containerList = _unsortedContainerList.OrderByDescending(s => s._cooled).ThenByDescending(s => s._weight);
            return containerList.ToList<Container>();
        }
    }
}
