using System;
using System.Collections.Generic;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmetic_Casus_CircusAnimalsUnitTests
{
    [TestClass]
    public class AlgorithmTests
    {
        private List<Animal> animalList;
        private Train train;
        private Algorithm algorithm;
        [TestInitialize]
        public void Initialize()
        {
            train = new Train();
            algorithm = new Algorithm();
            animalList = new List<Animal>();
            animalList.Add(new Animal(true, Animal.size.Small, "SC"));
            animalList.Add(new Animal(true, Animal.size.Medium, "MC"));
            animalList.Add(new Animal(true, Animal.size.Large, "LC"));
            animalList.Add(new Animal(false, Animal.size.Small, "SH"));
            animalList.Add(new Animal(false, Animal.size.Medium, "MH"));
            animalList.Add(new Animal(false, Animal.size.Large, "LH"));
        }
        #region PlaceAnimalsInTrain
        [TestMethod]
        public void PlaceAnimalsInTrain_CorrectInput()
        {
            //Arrange (Initialize)
            int placedAnimalCount = 0;

            //Act
            train = algorithm.PlaceAnimalsInTrain(animalList, train);
            foreach (Wagon wagon in train.wagonsInTrain)
                foreach (Animal animal in wagon.animalsInWagon)
                    placedAnimalCount++;

            //Assert
            Assert.AreEqual(4, train.wagonsInTrain.Count);
            Assert.AreEqual(6, placedAnimalCount);

        }
        [TestMethod]
        public void PlaceAnimalsInTrain_ListIsNull()
        {
            //Arrange
            animalList = null;

            //Act
            train = algorithm.PlaceAnimalsInTrain(animalList, train);

            //Assert
            Assert.AreEqual(0, train.wagonsInTrain.Count);
        }
        [TestMethod]
        public void PlaceAnimalsInTrain_TrainIsNull()
        {
            //Arrange
            train = null;

            //Act
            train = algorithm.PlaceAnimalsInTrain(animalList, train);

            //Assert
            Assert.AreEqual(0, train.wagonsInTrain.Count);
        }
        #endregion
    }
}
