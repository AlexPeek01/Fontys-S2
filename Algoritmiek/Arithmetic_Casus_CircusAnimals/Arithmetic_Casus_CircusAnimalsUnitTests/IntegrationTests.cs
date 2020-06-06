using System;
using System.Collections.Generic;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmetic_Casus_CircusAnimalsUnitTests.Logic
{
    [TestClass]
    public class WagonSafetyTests
    {
        private List<Animal> animalList;
        private Train testTrain;
        private MainLogic logic;
        [TestInitialize]
        public void Initialize()
        {
            animalList = new List<Animal>();
            Random random = new Random();
            logic = new MainLogic();
            #region CreateAnimals
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(true, Animal.size.Large, "LC");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(true, Animal.size.Medium, "MC");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(true, Animal.size.Small, "SC");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(false, Animal.size.Large, "LH");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(false, Animal.size.Medium, "MH");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(false, Animal.size.Small, "SH");
                animalList.Add(animal);
            }
            #endregion
            Algorithm run = new Algorithm();
            testTrain = run.PlaceAnimalsInTrain(animalList, new Train());
        }
        [TestMethod]
        public void CarnivoreNotWithOtherCarnivores()   //Checks if each container doesn't have too many carnivores.
        {
            foreach (Wagon testWagon in testTrain.wagonsInTrain)
            {
                int i = 0;
                foreach (Animal testAnimal in testWagon.animalsInWagon)
                {
                    if (testAnimal.carnivore)  //Counts how many carnivores are in each wagon.
                    {
                        i++;
                    }
                }
                Assert.IsTrue(i <= 1);  //If the number of carnivores in the wagon are less than or equal to 1 return true.
            }
        }
        [TestMethod]
        public void CarnivoreSmallerThanHerbivores() //Checks if all herbivores are larger than the carnivore.
        {
            
            foreach (Wagon testWagon in testTrain.wagonsInTrain)
            {
                if (testWagon.animalsInWagon[0].carnivore)
                {
                    int carnivoreSize = testWagon.animalsInWagon[0].animalSize; //Sets the carnivores size.
                    bool animalIsInDanger = false;
                    for (int i = 1; i < testWagon.animalsInWagon.Count; i++)
                    {
                        Animal testAnimal = testWagon.animalsInWagon[i];
                        if (testAnimal.animalSize <= carnivoreSize)  //Checks the herbivores size.
                        {
                            animalIsInDanger = true;
                        }
                        Assert.IsFalse(animalIsInDanger);   //If the herbivore is a safe size return true.
                    }
                }
            }
        }
        [TestMethod]
        public void AnimalLimitCheck() //Checks if the number of animals in a wagon doesn't exceed 10.
        {
            
            foreach (Wagon testWagon in testTrain.wagonsInTrain)
            {
                Assert.IsTrue(testWagon.animalsInWagon.Count <= 10);
            }
        }
        [TestMethod]
        public void WagonSpaceLimit() //Checks if the combined size of the animals doesn't exceed the wagon's spaceAvailable.
        {

            foreach (Wagon testWagon in testTrain.wagonsInTrain)
            {
                int wagonSize = 10;
                int usedSpace = 0;
                foreach(Animal testAnimal in testWagon.animalsInWagon)
                {
                    usedSpace += testAnimal.animalSize;
                }
                Assert.IsTrue(usedSpace <= wagonSize);
            }
        }
        [TestMethod]
        public void OptimalWagonUse() //Checks if the number of wagons is as small as it can be.
        {
            //Arrange sets up the animalList.
            #region Arrange
            List<Animal> animalList = new List<Animal>();
            Animal testAnimal1 = new Animal(true, Animal.size.Large, "LC");
            Animal testAnimal2 = new Animal(true, Animal.size.Medium, "MC");
            Animal testAnimal3 = new Animal(true, Animal.size.Small, "SC");
            Animal testAnimal4 = new Animal(false, Animal.size.Large, "LH");
            Animal testAnimal5 = new Animal(false, Animal.size.Medium, "MH");
            Animal testAnimal6 = new Animal(false, Animal.size.Small, "SH");
            animalList.Add(testAnimal1);
            animalList.Add(testAnimal2);
            animalList.Add(testAnimal3);
            animalList.Add(testAnimal4);
            animalList.Add(testAnimal5);
            animalList.Add(testAnimal6);
            #endregion  //Setup the animalList         //Sets up the animalList.
            Algorithm run = new Algorithm();
            testTrain = run.PlaceAnimalsInTrain(animalList, new Train());
            Assert.AreEqual(testTrain.wagonsInTrain.Count, 4); //The expected number of wagons is 4.
        }
    }
}
