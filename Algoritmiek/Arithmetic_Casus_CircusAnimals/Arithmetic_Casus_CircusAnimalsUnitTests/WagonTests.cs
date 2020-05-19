using System;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmetic_Casus_CircusAnimalsUnitTests
{
    [TestClass]
    public class WagonTests
    {
        Wagon wagon;
        [TestInitialize]
        public void Initialize()
        {
            wagon = new Wagon(0, 10);
        }
        #region ExpectedBehaviour
        [TestMethod]
        public void AddingOneLargeAnimalToWagon()
        {
            //Arrange
            Animal largeHerbivore = new Animal(false, Animal.size.Large, "LH");
            
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
            Animal largeHerbivore1 = new Animal(false, Animal.size.Large, "LH");
            Animal largeHerbivore2 = new Animal(false, Animal.size.Large, "LH");
        
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
            Animal largeHerbivore1 = new Animal(false, Animal.size.Large, "LH");
            Animal largeHerbivore2 = new Animal(false, Animal.size.Large, "LH");
            Animal largeHerbivore3 = new Animal(false, Animal.size.Large, "LH");

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
            Animal mediumHerbivore1 = new Animal(false, Animal.size.Medium, "MH");
            Animal mediumHerbivore2 = new Animal(false, Animal.size.Medium, "MH");
            Animal mediumHerbivore3 = new Animal(false, Animal.size.Medium, "MH");

            //Act
            wagon.AddAnimalToWagon(mediumHerbivore1);
            wagon.AddAnimalToWagon(mediumHerbivore2);
            wagon.AddAnimalToWagon(mediumHerbivore3);

            //Assert
            Assert.AreEqual(wagon.animalsInWagon.Count, 3);
            Assert.AreEqual(wagon.spaceAvailable, 1);
        }
        /// <summary>
        /// De eerste twee dieren moeten false teruggeven, voor het laatste dier is het niet veilig meer dus deze moet true teruggeven.
        /// </summary>
        [TestMethod]
        public void CheckLargeHerbivoreWithCarnivore()
        {
            //Arrange
            Animal smallCarnivore = new Animal(true, Animal.size.Small, "SC");
            Animal largeHerbivore = new Animal(false, Animal.size.Large, "LH");
            
            //Act
            wagon.AddAnimalToWagon(smallCarnivore);

            //Assert
            Assert.IsTrue(wagon.CanPlaceAnimalChecks(largeHerbivore));
        }
        public void CheckMediumHerbivoreWithCarnivore()
        {
            //Arrange
            Animal smallCarnivore = new Animal(true, Animal.size.Small, "SC");
            Animal mediumHerbivore = new Animal(false, Animal.size.Medium, "MH");

            //Act
            wagon.AddAnimalToWagon(smallCarnivore);

            //Assert
            Assert.IsTrue(wagon.CanPlaceAnimalChecks(mediumHerbivore));
        }
        public void CheckSmallHerbivoreWithCarnivore()
        {
            //Arrange
            Animal smallCarnivore = new Animal(true, Animal.size.Small, "SC");
            Animal smallHerbivore = new Animal(false, Animal.size.Small, "SH");
            
            //Act
            wagon.AddAnimalToWagon(smallCarnivore);
            
            //Assert
            Assert.IsTrue(wagon.CanPlaceAnimalChecks(smallHerbivore));
        }
        /// <summary>
        /// Beide dieren moeten true teruggeven aangezien ze beide geplaatst kunnen worden.
        /// </summary>
        [TestMethod]
        public void CheckSeveralAnimalsWithHerbivore()
        {
            //Arrange
            Animal largeHerbivore = new Animal(false, Animal.size.Large, "LH");
            Animal mediumHerbivore = new Animal(false, Animal.size.Medium, "MH");
            Animal smallHerbivore = new Animal(false, Animal.size.Small, "SH");

            //Act
            wagon.AddAnimalToWagon(largeHerbivore);
            wagon.AddAnimalToWagon(mediumHerbivore);

            //Assert
            Assert.IsFalse(wagon.CanPlaceAnimalChecks(mediumHerbivore));
            Assert.IsTrue(wagon.CanPlaceAnimalChecks(smallHerbivore));
        }
        #endregion
        #region UnexpectedBehaviour
        [TestMethod]
        public void AddAnimalToWagon_NullAnimal()
        {
            wagon.AddAnimalToWagon(null);
            Assert.AreEqual(wagon.animalsInWagon.Count, 0);
            Assert.AreEqual(wagon.spaceAvailable, 10);
        }
        [TestMethod]
        public void CanPlaceAnimalChecks_NullAnimal()
        {
            //Assert
            Assert.IsFalse(wagon.CanPlaceAnimalChecks(null));
        }
        #endregion
    }
}
