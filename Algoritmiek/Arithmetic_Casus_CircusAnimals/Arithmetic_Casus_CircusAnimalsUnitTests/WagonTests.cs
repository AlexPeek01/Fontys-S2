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
        #region AddAnimalToWagon()
        [TestMethod]
        public void AddOneLargeAnimal()
        {
            Animal largeHerbivore = new Animal(false, Animal.size.Large, "LH");
            wagon.AddAnimalToWagon(largeHerbivore);
            Assert.AreEqual(wagon.animalsInWagon.Count, 1);
            Assert.AreEqual(wagon.spaceAvailable, 5);
        }
        [TestMethod]
        public void AddTwoLargeAnimals()
        {
            Animal largeHerbivore1 = new Animal(false, Animal.size.Large, "LH");
            Animal largeHerbivore2 = new Animal(false, Animal.size.Large, "LH");
            wagon.AddAnimalToWagon(largeHerbivore1);
            wagon.AddAnimalToWagon(largeHerbivore2);
            Assert.AreEqual(wagon.animalsInWagon.Count, 2);
            Assert.AreEqual(wagon.spaceAvailable, 0);
        }
        [TestMethod]
        public void AddThreeMediumAnimals()
        {
            Animal mediumHerbivore1 = new Animal(false, Animal.size.Medium, "MH");
            Animal mediumHerbivore2 = new Animal(false, Animal.size.Medium, "MH");
            Animal mediumHerbivore3 = new Animal(false, Animal.size.Medium, "MH");
            wagon.AddAnimalToWagon(mediumHerbivore1);
            wagon.AddAnimalToWagon(mediumHerbivore2);
            wagon.AddAnimalToWagon(mediumHerbivore3);
            Assert.AreEqual(wagon.animalsInWagon.Count, 3);
            Assert.AreEqual(wagon.spaceAvailable, 1);
        }
        #endregion
        #region CheckWagon()
        /// <summary>
        /// De eerste twee dieren moeten false teruggeven, voor het laatste dier is het niet veilig meer dus deze moet true teruggeven.
        /// </summary>
        [TestMethod]
        public void CheckSeveralAnimalsWithCarnivore()
        {
            Animal smallCarnivore = new Animal(true, Animal.size.Small, "SC");
            Animal largeHerbivore = new Animal(false, Animal.size.Large, "LH");
            Animal mediumHerbivore = new Animal(false, Animal.size.Medium, "MH");
            Animal smallHerbivore = new Animal(false, Animal.size.Small, "SH");
            wagon.AddAnimalToWagon(smallCarnivore);
            Assert.IsFalse(wagon.CheckWagon(largeHerbivore));
            wagon.AddAnimalToWagon(largeHerbivore);
            Assert.IsFalse(wagon.CheckWagon(mediumHerbivore));
            wagon.AddAnimalToWagon(mediumHerbivore);
            Assert.IsTrue(wagon.CheckWagon(smallHerbivore));
        }
        /// <summary>
        /// Beide dieren moeten false teruggeven aangezien ze beide geplaatst kunnen worden.
        /// </summary>
        [TestMethod]
        public void CheckSeveralAnimalsWithHerbivore()
        {
            Animal largeHerbivore = new Animal(false, Animal.size.Large, "LH");
            Animal mediumHerbivore = new Animal(false, Animal.size.Medium, "MH");
            Animal smallHerbivore = new Animal(false, Animal.size.Small, "SH");
            wagon.AddAnimalToWagon(largeHerbivore);
            Assert.IsFalse(wagon.CheckWagon(mediumHerbivore));
            wagon.AddAnimalToWagon(mediumHerbivore);
            Assert.IsFalse(wagon.CheckWagon(smallHerbivore));
        }
        #endregion
    }
}
