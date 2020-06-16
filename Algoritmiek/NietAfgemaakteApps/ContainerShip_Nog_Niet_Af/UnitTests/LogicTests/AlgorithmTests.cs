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
            ship = new Ship(5, 5, 5);
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
            Ship ship = new Ship(5, 5, 5);
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

            //Hier wordt een container aangemaakt en geplaatst in op de onderste laag.
            Container c1 = new Container(10000, false, true, true, false);
            containerArray[0, 0, 0] = c1;

            //Wanneer een container niet op de onderste laag geplaatst wordt en er staat wel een container onder dan geeft de methode true terug.
            Assert.IsTrue(Algorithm.NotFloating(containerArray, 0, 0, 1));
        }
        [TestMethod]
        public void WeightOnTopTests()
        {
            //----------------------------------Het schip heeft een oneven breedte.
            Ship ship = new Ship(5, 5, 5);
            //Wanneer de rechterkant van het schip zwaarder is wordt de container links geplaatst.
            Assert.AreEqual(Algorithm.CheckOptimalPosition(ship),3);

            //Wanneer de linkerkant van het schip zwaarder is wordt de container rechts geplaatst.
            ship.LeftSideWeight = 2;
            Assert.AreEqual(Algorithm.CheckOptimalPosition(ship), 5);

            //Wanneer het schip in balans is wordt de container rechts geplaatst.
            ship.RightSideWeight = 2;
            Assert.AreEqual(Algorithm.CheckOptimalPosition(ship), 5);
            //----------------------------------Het schip heeft een oneven breedte.



            //----------------------------------Het schip heeft een even breedte.
            Ship ship2 = new Ship(4, 4, 4);
            //Wanneer de rechterkant van het schip zwaarder is wordt de container links geplaatst.
            Assert.AreEqual(Algorithm.CheckOptimalPosition(ship2), 2);

            //Wanneer de linkerkant van het schip zwaarder is wordt de container rechts geplaatst.
            ship2.LeftSideWeight = 2;
            Assert.AreEqual(Algorithm.CheckOptimalPosition(ship2), 4);

            //Wanneer het schip in balans is wordt de container rechts geplaatst.
            ship2.RightSideWeight = 2;
            Assert.AreEqual(Algorithm.CheckOptimalPosition(ship2), 4);
            //----------------------------------Het schip heeft een even breedte.
        }
        [TestMethod]
        public void EmptyPositionTests()
        {
            Ship ship = new Ship(5, 5, 5);
            Container[,,] containerArray = new Container[5, 5, 5];
            Container c1 = new Container(10000, false, false, true, false);
            containerArray[0, 0, 0] = c1;
            //Wanneer er geen container staat op de te checken positie wordt er true teruggegeven.
            Assert.IsTrue(Algorithm.CheckEmptyPosition(containerArray, 0, 0, 1));

            //Wanneer er wel een container staat op de te checken positie wordt er false teruggegeven.
            Assert.IsFalse(Algorithm.CheckEmptyPosition(containerArray, 0, 0, 0));
        }
        [TestMethod]
        public void AddWeightTests()
        {
            //Container[,,] containerArray = new Container[5, 5, 5];
            //Container c1 = new Container(10000, false, false, true, false);
            //containerArray[0, 0, 0] = c1;
            //Assert.AreEqual(ship.RightSideWeight, 0);
            //Assert.AreEqual(ship.LeftSideWeight, 0);
            //Algorithm.AddWeight(3, c1, ship);
            //Assert.AreEqual(ship.RightSideWeight, 10000);
            //Assert.AreEqual(ship.LeftSideWeight, 0);
            //Algorithm.AddWeight(2, c1, ship);
            //Assert.AreEqual(ship.RightSideWeight, 10000);
            //Assert.AreEqual(ship.LeftSideWeight, 0);
            //Algorithm.AddWeight(1, c1, ship);
            //Assert.AreEqual(ship.RightSideWeight, 10000);
            //Assert.AreEqual(ship.LeftSideWeight, 10000);


            //Wanneer er wel een container staat op de te checken positie wordt er false teruggegeven.
            //Assert.IsFalse(Algorithm.CheckEmptyPosition(containerArray, 0, 0, 0));
        }
    }
}
