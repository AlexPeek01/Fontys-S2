using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arithmetic_Casus_CircusAnimals;
using LogicLayer;

namespace Arithmetic_Casus_CircusAnimalsUnitTests.Logic
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Wagon
    {
        List<Animal> animalList;
        [TestInitialize]
        public void TestInitialize()
        {
            animalList = new List<Animal>();
        }
        [TestMethod()]
        public void PlaceAnimalsInWagonTest()
        {
            //Arange
            Animal animal1 = new Animal(true, 5, "LargeCarnivore");
            Animal animal2 = new Animal(true, 3, "MediumCarnivore");
            Animal animal3 = new Animal(true, 1, "SmallCarnivore");
            Animal animal4 = new Animal(false, 5, "LargeHerbivore");
            Animal animal5 = new Animal(false, 1, "SmallHerbivore");
        }
        /////
    }
}
