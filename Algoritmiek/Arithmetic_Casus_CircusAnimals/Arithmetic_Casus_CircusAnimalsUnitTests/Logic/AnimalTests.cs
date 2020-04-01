using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arithmetic_Casus_CircusAnimals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;

namespace Arithmetic_Casus_CircusAnimals.Tests
{
    [TestClass()]
    public class AnimalTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Animal.oldAnimalList.Clear();
        }
        [TestMethod()]
        public void CreateNoAnimalTest()
        {
            Assert.AreEqual(0, Animal.oldAnimalList.Count);
        }
        [TestMethod()]
        public void CreateAnimalTest()
        {
            Animal.CreateAnimal(true, 2, "MediumCarnivore");
            Assert.AreEqual(Animal.oldAnimalList.Count, 1);
        }
    }
}