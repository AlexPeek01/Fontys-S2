using Arithmetic_Casus_CircusAnimals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Casus_CircusAnimalsUnitTests.Logic
{
    [TestClass()]
    class WagonTests
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
            animalList.Add(animal1);
            animalList.Add(animal2);
            animalList.Add(animal3);
            animalList.Add(animal4);
            animalList.Add(animal5);

            //Act
            Arithmetic_Casus_CircusAnimals.Wagon.PlaceAnimalsInWagon(animalList, 0);

            //Assert
            Assert.Fail();
            Assert.IsTrue
            (Arithmetic_Casus_CircusAnimals.Wagon.wagonList[0].animalsInWagon.Contains(animal1) &&
            Arithmetic_Casus_CircusAnimals.Wagon.wagonList[1].animalsInWagon.Contains(animal2) &&
            Arithmetic_Casus_CircusAnimals.Wagon.wagonList[1].animalsInWagon.Contains(animal4) &&
            Arithmetic_Casus_CircusAnimals.Wagon.wagonList[2].animalsInWagon.Contains(animal3) &&
            Arithmetic_Casus_CircusAnimals.Wagon.wagonList[3].animalsInWagon.Contains(animal5));
        }
    }
}
