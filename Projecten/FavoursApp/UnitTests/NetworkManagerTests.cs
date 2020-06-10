using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class NetworkManagerTests
    {
        FavoursNetworkManager networkmanager;
        [TestInitialize]
        public void Initialize()
        {
            networkmanager = new FavoursNetworkManager("memory");
        }
        #region GetNetworkIDsByUserID
        [TestMethod]
        public void TestGetNetworkIDs_UserIDExists1()
        {
            //Arrange
            string userid = "1";

            //Act
            List<string> networkids = networkmanager.GetNetworkIDsByUserID(userid);

            //Assert
            Assert.AreEqual(networkids.Count, 3);
            Assert.AreEqual(networkids[0], "1");
            Assert.AreEqual(networkids[1], "2");
            Assert.AreEqual(networkids[2], "3");
        }
        public void TestGetNetworkIDs_UserIDExists2()
        {
            //Arrange
            string userid = "2";

            //Act
            List<string> networkids = networkmanager.GetNetworkIDsByUserID(userid);

            //Assert
            Assert.AreEqual(networkids.Count, 3);
            Assert.AreEqual(networkids[0], "9");
            Assert.AreEqual(networkids[1], "8");
            Assert.AreEqual(networkids[2], "7");
        }
        [TestMethod]
        public void TestGetNetworkIDs_UserIDDoesntExist()
        {
            //Arrange
            string userid = "-5";

            //Act
            List<string> networkids = networkmanager.GetNetworkIDsByUserID(userid);

            //Assert
            Assert.AreEqual(networkids.Count, 0);
        }
        [TestMethod]
        public void TestGetNetworkIDs_UserIDIsNull()
        {
            //Arrange
            string userid = null;

            //Act
            List<string> networkids = networkmanager.GetNetworkIDsByUserID(userid);

            //Assert
            Assert.AreEqual(networkids.Count, 0);
        }
        #endregion
        #region GetNetworkData
        [TestMethod]
        public void GetNetworkData_ExistingNetworkID1()
        {
            //Arrange
            string networkid = "networkid1";

            //Act
            Network network = networkmanager.GetNetworkData(networkid);

            //Assert
            Assert.AreEqual(network.NetworkName, "NAME_NETWORK_1");
        }
        [TestMethod]
        public void GetNetworkData_ExistingNetworkID2()
        {
            //Arrange
            string networkid = "networkid2";

            //Act
            Network network = networkmanager.GetNetworkData(networkid);

            //Assert
            Assert.AreEqual(network.NetworkName, "NAME_NETWORK_2");
        }
        [TestMethod]
        public void GetNetworkData_NonExistentNetworkID()
        {
            //Arrange
            string networkid = "-5";

            //Act
            Network network = networkmanager.GetNetworkData(networkid);

            //Assert
            Assert.AreEqual(network, null);
        }
        [TestMethod]
        public void GetNetworkData_NetworkIDIsNull()
        {
            //Arrange
            string networkid = null;

            //Act
            Network network = networkmanager.GetNetworkData(networkid);

            //Assert
            Assert.AreEqual(network, null);
        }
        #endregion
        #region CreateUserNetworkConnection
        // This method only does a single database call.
        #endregion

        #region RemoveUserNetworkCon
        // This method only does a single database call.
        #endregion
        #region GetNetworkCategories
        [TestMethod]
        public void GetNetworksCategories_ExistingNetworkID1()
        {
            //Arrange
            string networkid = "1";

            //Act
            List<string> categoryNames = networkmanager.GetNetworksCategories(networkid);

            //Assert
            Assert.AreEqual(categoryNames.Count, 4);
            Assert.AreEqual(categoryNames[0], "Naam1");
            Assert.AreEqual(categoryNames[1], "Naam2");
            Assert.AreEqual(categoryNames[2], "Naam3");
            Assert.AreEqual(categoryNames[3], "Naam4");
        }
        [TestMethod]
        public void GetNetworksCategories_ExistingNetworkID2()
        {
            //Arrange
            string networkid = "2";

            //Act
            List<string> categoryNames = networkmanager.GetNetworksCategories(networkid);

            //Assert
            Assert.AreEqual(categoryNames.Count, 4);
            Assert.AreEqual(categoryNames[0], "Naam2");
            Assert.AreEqual(categoryNames[1], "Naam4");
            Assert.AreEqual(categoryNames[2], "Naam6");
            Assert.AreEqual(categoryNames[3], "Naam8");
        }
        [TestMethod]
        public void GetNetworksCategories_NonExistingNetworkID()
        {
            //Arrange
            string networkid = "-5";

            //Act
            List<string> categoryNames = networkmanager.GetNetworksCategories(networkid);

            //Assert
            Assert.AreEqual(categoryNames.Count, 0);
        }
        [TestMethod]
        public void GetNetworksCategories_NetworkIDIsNull()
        {
            //Arrange
            string networkid = null;

            //Act
            List<string> categoryNames = networkmanager.GetNetworksCategories(networkid);

            //Assert
            Assert.AreEqual(categoryNames.Count, 0);
        }
        #endregion
    }
}
