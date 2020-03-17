using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arithmetic_Casus_CircusAnimals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimals.Tests
{
    [TestClass()]
    public class AnimalTests
    {
        List<Animal> animalList;
        [TestInitialize]
        public void TestInitialize()
        {
            animalList = new List<Animal>();
        }
        [TestMethod()]
        public void CreateNoAnimalTest()
        {
            Assert.AreEqual(0, animalList.Count);
        }
        [TestMethod()]
        public void CreateOneAnimalTest()
        {
            Animal animal = new Animal(true, 3, "LargeHerbivore");
            animalList.Add(animal);
            Assert.AreEqual(1, animalList.Count);
        }
        
    }
}