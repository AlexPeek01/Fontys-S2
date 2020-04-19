using System;
using System.Collections.Generic;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmetic_Casus_CircusAnimalsUnitTests.Logic
{
    [TestClass]
    public class WagonSafetyTests
    {
        List<Animal> animalList;
        Train testTrain;
        [TestInitialize]
        public void Initialize()
        {
            animalList = new List<Animal>();
            Random random = new Random();
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(true, 5, "LC");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(true, 3, "MC");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(true, 1, "SC");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(false, 5, "LH");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(false, 3, "MH");
                animalList.Add(animal);
            }
            for (int i = 0; i < random.Next(0, 25); i++)
            {
                Animal animal = new Animal(false, 1, "SH");
                animalList.Add(animal);
            }
            Algoritmiek run = new Algoritmiek();
            testTrain = run.PlaceAnimalsInTrain(animalList);
        }
        [TestMethod]
        public void CarnivoreNotWithOtherCarnivores()   //Checks if each container doesn't have too many carnivores.
        {
            
            foreach (Wagon testWagon in testTrain._wagonsInTrain)
            {
                int i = 0;
                foreach (Animal testAnimal in testWagon._animalList)
                {
                    if (testAnimal._carnivore)  //Counts how many carnivores are in each wagon.
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
            
            foreach (Wagon testWagon in testTrain._wagonsInTrain)
            {
                if (testWagon._animalList[0]._carnivore)
                {
                    int carnivoreSize = testWagon._animalList[0]._size; //Sets the carnivores size.
                    bool animalIsInDanger = false;
                    for (int i = 1; i < testWagon._animalList.Count; i++)
                    {
                        Animal testAnimal = testWagon._animalList[i];
                        if (testAnimal._size <= carnivoreSize)  //Checks the herbivores size.
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
            
            foreach (Wagon testWagon in testTrain._wagonsInTrain)
            {
                Assert.IsTrue(testWagon._animalList.Count <= 10);
            }
        }
        [TestMethod]
        public void WagonSpaceLimit() //Checks if the combined size of the animals doesn't exceed the wagon's spaceAvailable.
        {

            foreach (Wagon testWagon in testTrain._wagonsInTrain)
            {
                int wagonSize = 10;
                int usedSpace = 0;
                foreach(Animal testAnimal in testWagon._animalList)
                {
                    usedSpace += testAnimal._size;
                }
                Assert.IsTrue(usedSpace <= wagonSize);
            }
        }
    }
}
