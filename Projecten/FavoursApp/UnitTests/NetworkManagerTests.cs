using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class NetworkManagerTests
    {
        [TestMethod]
        public void GettingCategoryIDs_ExistingUserID1()
        {
            //Arrange
            FavoursNetworkManager nm = new FavoursNetworkManager();

            //Act
            nm.GetNetworksCategories("1");

            //Assert
            Assert.AreNotEqual(nm, null);
        }
    }
}
