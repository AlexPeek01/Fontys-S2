using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace UnitTests.Logic
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        public void PlaceContainerArrayTest()
        {
            Ship ship = new Ship(3, 2, 3, 0, 0);
            List<Container> containerList = new List<Container>();
            for (int i = 0; i < 4; i++)
            {
                Container c1 = new Container(10000 + i, true, false, false, false);
                ship.ContainerList.Add(c1);
            }
            for (int i = 0; i < 8; i++)
            {
                Container c3 = new Container(10000 + i, false, false, false, false);
                ship.ContainerList.Add(c3);
            }
            for (int i = 0; i <= 2; i++)
            {
                Container c2 = new Container(10010 + i, true, true, false, false);
                ship.ContainerList.Add(c2);
            }
            for (int i = 0; i < 4; i++)
            {
                Container c = new Container(10000 + i, false, true, false, false);
                ship.ContainerList.Add(c);
            }
            Container[,,] containerArray = Algorithm.placeContainerArray(ship);
            int j = 0;
            foreach(Container c in containerArray)
            {
                if (c != null)
                {
                    j++;
                }
            }
            Assert.AreEqual(j, 16);

        }
    }
}
