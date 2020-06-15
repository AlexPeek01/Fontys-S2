using System;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmetic_Casus_CircusAnimalsUnitTests
{
    [TestClass]
    public class TrainTests
    {
        private Train train;
        private Wagon wagon;
        [TestInitialize]
        public void Initialize()
        {
            train = new Train();
            wagon = new Wagon(0, 10);
            train.wagonsInTrain.Add(wagon);
        }
        [TestMethod]
        public void CreatingAWagon()
        {
            //Arrange

            //Act
            train.CreateWagon(); 
            
            //Assert
            Assert.AreEqual(2, train.wagonsInTrain.Count); // When a train is created it creates one wagon by default.
        }
        #region FindOptimalWagon
        [TestMethod]
        public void FindingWagonForCarnivore()
        {
            //Arrange
            Animal carnivore = new Animal(LogicLayer.Type.Carnivore, Size.Large, "LC");
            
            //Assert
            Assert.AreEqual(train.FindOptimalWagon(carnivore), null);
        }
        [TestMethod]
        public void FindingWagonForHerbivore()
        {
            //Arrange
            Animal carnivore = new Animal(LogicLayer.Type.Carnivore, Size.Small, "SC");
            Animal herbivore = new Animal(LogicLayer.Type.Herbivore, Size.Large, "LH");

            //Act
            wagon.animalsInWagon.Add(carnivore);
            
            //Assert
            Assert.AreEqual(train.FindOptimalWagon(herbivore), train.wagonsInTrain[0]);
        }
        [TestMethod]
        public void FindingWagonForNull()
        {
            //Arrange
            Animal animal = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => train.FindOptimalWagon(animal));

            //Assert
            Assert.AreEqual(ex.Message, "Animal can't be null");
        }
        #endregion
    }
}
