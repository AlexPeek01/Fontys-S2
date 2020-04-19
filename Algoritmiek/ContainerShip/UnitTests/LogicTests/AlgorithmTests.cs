using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace UnitTests.Logic
{
    [TestClass]
    public class AlgorithmTests
    {
        Ship ship;
        [TestInitialize]
        public void Initialize()
        {
            ship = new Ship(5, 5, 5, 0, 0);
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
        }
        [TestMethod]
        public void CheckValuableStateTest()
        {
            Container[,,] containerArray = new Container[5, 5, 5];
            Container c1 = new Container(10000, false, true, true, true);
            Container c2 = new Container(10000, false, true, true, false);
            containerArray[2, 0, 0] = c1;
            containerArray[2, 0, 1] = c2;
            //Wanneer de container op het uiteinde van de lengte staat moet het algoritme true teruggeven
            Assert.IsTrue(Algorithm.CheckValuableState(containerArray, 0, 0, 0));

            //Wanneer de container naast een valuableBlocked container staat moet het algoritme false teruggeven
            Assert.IsFalse(Algorithm.CheckValuableState(containerArray, 1, 0, 0));

            //Wanneer de container naast een valuable container geplaatst wordt met "valuableBlocked = false", dan geeft het algoritme true terug.
            Assert.IsTrue(Algorithm.CheckValuableState(containerArray, 1, 0, 1));

            //Wanneer de container naast een valuable container wordt geplaatst, wordt de valuableBlocked van de valuable container op true gezet
            Assert.IsTrue(c2.valuableBlocked);
        }
        [TestMethod]
        public void SpaceForValuableTest()
        {
            Ship ship = new Ship(5, 5, 5, 0, 0);
            Container[,,] containerArray = new Container[5, 5, 5];
            Container c1 = new Container(10000, false, true, true, false);
            Container c2 = new Container(10000, false, false, true, false);
            containerArray[3, 3, 0] = c2;
            containerArray[1, 3, 0] = c2;
            Assert.IsTrue(Algorithm.SpaceForValuable(containerArray, 0, 3, 0, ship));
            Assert.IsFalse(Algorithm.SpaceForValuable(containerArray, 2, 3, 0, ship));
            Assert.IsTrue(Algorithm.SpaceForValuable(containerArray, 4, 3, 0, ship));
        }
        [TestMethod]
        public void NotFloatingTest()
        {
            Container[,,] containerArray = new Container[1, 1, 2];

            //Wanneer een container op de onderste laag geplaatst wordt dan geeft de methode true terug.
            Assert.IsTrue(Algorithm.NotFloating(containerArray, 0, 0, 0));

            //Wanneer een container niet op de onderste laag geplaatst wordt en er staat geen container onder dan geeft de methode false terug.
            Assert.IsFalse(Algorithm.NotFloating(containerArray, 0, 0, 1));

            //Hier wordt een container aangemaakt en geplaatst in de container op de onderste laag.
            Container c1 = new Container(10000, false, true, true, false);
            containerArray[0, 0, 0] = c1;

            //Wanneer een container niet op de onderste laag geplaatst wordt en er staat wel een container onder dan geeft de methode true terug.
            Assert.IsTrue(Algorithm.NotFloating(containerArray, 0, 0, 1));
        }
    }
}
