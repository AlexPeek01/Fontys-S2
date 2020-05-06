using System;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmetic_Casus_CircusAnimalsUnitTests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void PlaceAnimalTestWithWagonNull()
        {
            Train train = new Train();
            Animal animal = new Animal(true, Animal.size.Large, "LC");
            animal.PlaceAnimal(train, null);
        }
    }
}
