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
            Animal carnivore = new Animal(true, Animal.size.Large, "LC");
            
            //Assert
            Assert.AreEqual(train.FindOptimalWagon(carnivore), null);
        }
        [TestMethod]
        public void FindingWagonForHerbivore()
        {
            //Arrange
            Animal carnivore = new Animal(true, Animal.size.Small, "SC");
            Animal herbivore = new Animal(false, Animal.size.Large, "LH");

            //Act
            wagon.animalsInWagon.Add(carnivore);
            
            //Assert
            Assert.AreEqual(train.FindOptimalWagon(herbivore), train.wagonsInTrain[0]);
        }
        [TestMethod]
        public void FindingWagonForNull()
        {
            //Arrange
            Animal carnivore = new Animal(true, Animal.size.Small, "SC");
            
            //Act
            wagon.AddAnimalToWagon(carnivore);
            
            //Assert
            Assert.AreEqual(train.FindOptimalWagon(null), null);
        }
        #endregion
    }
}
