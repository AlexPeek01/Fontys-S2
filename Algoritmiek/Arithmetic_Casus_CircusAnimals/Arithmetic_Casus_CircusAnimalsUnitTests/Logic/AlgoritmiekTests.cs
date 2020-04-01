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
            animalTestList = new List<Animal>();
            animalTestList.Add(animal1 = new Animal(true, 3, "Medium Carnivore"));
            animalTestList.Add(animal2 = new Animal(true, 5, "Large Carnivore"));
            animalTestList.Add(animal3 = new Animal(true, 1, "Small Carnivore"));
            animalTestList.Add(animal4 = new Animal(true, 3, "Medium Carnivore"));
            animalTestList.Add(animal5 = new Animal(true, 5, "Large Carnivore"));
            animalTestList.Add(carnivore = new Animal(true, 3, "Medium Carnivore"));
            animalTestList.Add(animal6 = new Animal(false, 1, "Small Herbivore"));
            animalTestList.Add(animal7 = new Animal(false, 3, "Medium Herbivore"));
            animalTestList.Add(animal8 = new Animal(false, 5, "Large Herbivore"));
            animalTestList.Add(animal9 = new Animal(false, 1, "Small Herbivore"));
            animalTestList.Add(herbivore = new Animal(false, 3, "Medium Herbivore"));
            wagon = new Wagon(0, 10);
            wagonNotFound = true;
        }
        [TestMethod]
        public void CheckCarnivoreInput()
        {
            //Checks if the method works if the first animal in the wagon is a carnivore
            wagon._animalList.Add(carnivore);
            wagonNotFound = Algoritmiek.CheckWagon(animal1, wagon);
            Assert.IsTrue(wagonNotFound);
            wagonNotFound = Algoritmiek.CheckWagon(animal2, wagon);
            Assert.IsFalse(wagonNotFound);
            wagonNotFound = Algoritmiek.CheckWagon(animal3, wagon);
            Assert.IsTrue(wagonNotFound);
        }
        [TestMethod]
        public void CheckHerbivoreInput()
        {
            //Checks if the method works if the first animal in the wagon is a herbivore
            wagon._animalList.Add(herbivore);
            wagonNotFound = Algoritmiek.CheckWagon(animal1, wagon);
            Assert.IsFalse(wagonNotFound);
            wagonNotFound = Algoritmiek.CheckWagon(animal2, wagon);
            Assert.IsFalse(wagonNotFound);
            wagonNotFound = Algoritmiek.CheckWagon(animal3, wagon);
            Assert.IsFalse(wagonNotFound);
        }
        [TestMethod]
        public void CheckAnimalPlacement()
        {
            //Checks if the number of wagons is correct and if each wagon contains the correct amount of animals
            Train train = Algoritmiek.PlaceAnimalsInTrain(animalTestList);
            Assert.AreEqual(train._wagonsInTrain.Count, 7);
            Assert.AreEqual(train._wagonsInTrain[0]._animalList.Count, 2);
            Assert.AreEqual(train._wagonsInTrain[1]._animalList.Count, 1);
            Assert.AreEqual(train._wagonsInTrain[2]._animalList.Count, 3);
            Assert.AreEqual(train._wagonsInTrain[3]._animalList.Count, 1);
            Assert.AreEqual(train._wagonsInTrain[4]._animalList.Count, 1);
            Assert.AreEqual(train._wagonsInTrain[5]._animalList.Count, 1);
            Assert.AreEqual(train._wagonsInTrain[6]._animalList.Count, 2);
        }
    }
}
