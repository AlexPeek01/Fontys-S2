using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using System.Collections.Generic;

namespace Arithmetic_Casus_CircusAnimalsUnitTests.Logic
{
    [TestClass]
    public class AlgoritmiekTests
    {
        Animal animal1;
        Animal animal2;
        Animal animal3;
        Animal animal4;
        Animal animal5;
        Animal animal6;
        Animal animal7;
        Animal animal8;
        Animal animal9;
        Animal carnivore;
        Animal herbivore;
        Wagon wagon;
        bool wagonNotFound;
        List<Animal> animalTestList;


        [TestInitialize]
        public void TestInitialize()
        {
            
        }
        [TestMethod]
        public void CheckCarnivoreInput()
        {
            //Checks if the method works if the first animal in the wagon is a carnivore
            
        }
        [TestMethod]
        public void CheckHerbivoreInput()
        {
            //Checks if the method works if the first animal in the wagon is a herbivore
            
        }
        [TestMethod]
        public void CheckAnimalPlacement()
        {
            //Checks if the number of wagons is correct and if each wagon contains the correct amount of animals
            
        }
    }
}
