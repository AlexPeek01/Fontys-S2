using System;
using System.Collections.Generic;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmetic_Casus_CircusAnimalsUnitTests
{
    [TestClass]
    public class AlgorithmTests
    {
        List<Animal> animalList;
        Train train;
        Algorithm algorithm;
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
        #region ExpectedBehaviour
        [TestMethod]
        public void PlaceAnimalsInTrain_OneOfEachAnimal()
        {
            //Arrange (Initialize)
            
            //Act
            train = algorithm.PlaceAnimalsInTrain(animalList, train);

            //Assert
            Assert.AreEqual(4, train.wagonsInTrain.Count);
            Assert.IsTrue(train.wagonsInTrain[0].animalsInWagon[0].carnivore);
            Assert.IsFalse(train.wagonsInTrain[0].animalsInWagon[1].carnivore);
            Assert.IsFalse(train.wagonsInTrain[0].animalsInWagon[2].carnivore);
            Assert.IsTrue(train.wagonsInTrain[1].animalsInWagon[0].carnivore);
            Assert.IsTrue(train.wagonsInTrain[2].animalsInWagon[0].carnivore);
            Assert.IsFalse(train.wagonsInTrain[3].animalsInWagon[0].carnivore);
        }
        #endregion
        #region UnexpectedBehaviour
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlaceAnimalsInTrain_NullList()
        {
            //Act
            train = algorithm.PlaceAnimalsInTrain(null, train);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlaceAnimalsInTrain_NullTrain()
        {
            //Act
            train = algorithm.PlaceAnimalsInTrain(animalList, null);
        }
        #endregion
    }
}
