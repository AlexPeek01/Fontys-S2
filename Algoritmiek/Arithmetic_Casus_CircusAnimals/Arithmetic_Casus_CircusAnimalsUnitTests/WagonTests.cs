using System;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmetic_Casus_CircusAnimalsUnitTests
{
    [TestClass]
    public class WagonTests
    {
        private Wagon wagon;
        [TestInitialize]
        public void Initialize()
        {
            wagon = new Wagon(0, 10);
        }
        #region AddAnimalToWagon
        [TestMethod]
        public void AddingOneLargeAnimalToWagon()
        {
            //Arrange
            Animal largeHerbivore = new Animal(LogicLayer.Type.Herbivore, Size.Large, "LH");

            //Act
            wagon.AddAnimalToWagon(largeHerbivore);

            //Assert
            Assert.AreEqual(wagon.animalsInWagon.Count, 1);
            Assert.AreEqual(wagon.spaceAvailable, 5);
        }
        [TestMethod]
        public void AddingTwoLargeAnimalsToWagon()
        {
            //Arrange
            Animal largeHerbivore1 = new Animal(LogicLayer.Type.Herbivore, Size.Large, "LH");
            Animal largeHerbivore2 = new Animal(LogicLayer.Type.Herbivore, Size.Large, "LH");

            //Act
            wagon.AddAnimalToWagon(largeHerbivore1);
            wagon.AddAnimalToWagon(largeHerbivore2);

            //Assert
            Assert.AreEqual(wagon.animalsInWagon.Count, 2);
            Assert.AreEqual(wagon.spaceAvailable, 0);
        }
        [TestMethod]
        public void AddingThreeLargeAnimalsToWagon()
        {
            //Arrange
            Animal largeHerbivore1 = new Animal(LogicLayer.Type.Herbivore, Size.Large, "LH");
            Animal largeHerbivore2 = new Animal(LogicLayer.Type.Herbivore, Size.Large, "LH");
            Animal largeHerbivore3 = new Animal(LogicLayer.Type.Herbivore, Size.Large, "LH");

            //Act
            wagon.AddAnimalToWagon(largeHerbivore1);
            wagon.AddAnimalToWagon(largeHerbivore2);
            wagon.AddAnimalToWagon(largeHerbivore3);

            //Assert
            Assert.AreEqual(wagon.animalsInWagon.Count, 2);
            Assert.AreEqual(wagon.spaceAvailable, 0);
        }
        [TestMethod]
        public void AddThreeMediumAnimalsToWagon()
        {
            //Arrange
            Animal mediumHerbivore1 = new Animal(LogicLayer.Type.Herbivore, Size.Medium, "MH");
            Animal mediumHerbivore2 = new Animal(LogicLayer.Type.Herbivore, Size.Medium, "MH");
            Animal mediumHerbivore3 = new Animal(LogicLayer.Type.Herbivore, Size.Medium, "MH");

            //Act
            wagon.AddAnimalToWagon(mediumHerbivore1);
            wagon.AddAnimalToWagon(mediumHerbivore2);
            wagon.AddAnimalToWagon(mediumHerbivore3);

            //Assert
            Assert.AreEqual(wagon.animalsInWagon.Count, 3);
            Assert.AreEqual(wagon.spaceAvailable, 1);
        }
        [TestMethod]
        public void AddAnimalToWagon_NullAnimal()
        {
            //Arrange
            Animal animal = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => wagon.AddAnimalToWagon(animal));

            //Assert
            Assert.AreEqual(ex.Message, "Animal can't be null");
        }
        #endregion
        #region CanPlaceAnimalChecks
        [TestMethod]
        public void CanPlaceAnimalChecks_PossiblePlacement1()
        {
            //Arrange
            Animal smallCarnivore = new Animal(LogicLayer.Type.Carnivore, Size.Small, "SC");
            Animal largeHerbivore = new Animal(LogicLayer.Type.Herbivore, Size.Large, "LH");

            //Act
            wagon.AddAnimalToWagon(smallCarnivore);

            //Assert
            Assert.IsTrue(wagon.CanPlaceAnimalChecks(largeHerbivore));
        }
        public void CanPlaceAnimalChecks_PossiblePlacement2()
        {
            //Arrange
            Animal smallCarnivore = new Animal(LogicLayer.Type.Carnivore, Size.Small, "SC");
            Animal mediumHerbivore = new Animal(LogicLayer.Type.Herbivore, Size.Medium, "MH");

            //Act
            wagon.AddAnimalToWagon(smallCarnivore);

            //Assert
            Assert.IsTrue(wagon.CanPlaceAnimalChecks(mediumHerbivore));
        }
        public void CanPlaceAnimalChecks_DangerousPlacement()
        {
            //Arrange
            Animal smallCarnivore = new Animal(LogicLayer.Type.Carnivore, Size.Small, "SC");
            Animal smallHerbivore = new Animal(LogicLayer.Type.Herbivore, Size.Small, "SH");

            //Act
            wagon.AddAnimalToWagon(smallCarnivore);

            //Assert
            Assert.IsTrue(wagon.CanPlaceAnimalChecks(smallHerbivore));
        }
        [TestMethod]
        public void CanPlaceAnimalChecks_PossiblePlacement3()
        {
            //Arrange
            Animal largeHerbivore = new Animal(LogicLayer.Type.Herbivore, Size.Large, "LH");
            Animal mediumHerbivore = new Animal(LogicLayer.Type.Herbivore, Size.Medium, "MH");
            Animal smallHerbivore = new Animal(LogicLayer.Type.Herbivore, Size.Small, "SH");

            //Act
            wagon.AddAnimalToWagon(largeHerbivore);
            wagon.AddAnimalToWagon(mediumHerbivore);

            //Assert
            Assert.IsFalse(wagon.CanPlaceAnimalChecks(mediumHerbivore));
            Assert.IsTrue(wagon.CanPlaceAnimalChecks(smallHerbivore));
        }

        [TestMethod]
        public void CanPlaceAnimalChecks_NullAnimal()
        {
            //Assert
            Animal animal = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => wagon.CanPlaceAnimalChecks(animal));

            //Assert
            Assert.AreEqual(ex.Message, "Animal can't be null");
        }
        #endregion
    }
}
