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
        public void PlaceAnimalsInTrain_EmptyList()
        {
            //Arrange
            List<Animal> animalList = new List<Animal>();

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => algorithm.PlaceAnimalsInTrain(animalList, train));

            //Assert
            Assert.AreEqual(ex.Message, "Animal list can't be null or empty");
        }
        [TestMethod]
        public void PlaceAnimalsInTrain_ListIsNull()
        {
            //Arrange
            List<Animal> animalList = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => algorithm.PlaceAnimalsInTrain(animalList, train));

            //Assert
            Assert.AreEqual(ex.Message, "Animal list can't be null or empty");
        }
        [TestMethod]
        public void PlaceAnimalsInTrain_TrainIsNull()
        {
            //Arrange
            Train train = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => algorithm.PlaceAnimalsInTrain(animalList, train));

            //Assert
            Assert.AreEqual(ex.Message, "Train can't be null");
        }
        #endregion
    }
}
