using System;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arithmetic_Casus_CircusAnimalsUnitTests
{
    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void CreatingAWagon()
        {
            Train train = new Train();
            train.CreateWagon();
            Assert.AreEqual(train.wagonsInTrain.Count, 1);
        }
    }
}
