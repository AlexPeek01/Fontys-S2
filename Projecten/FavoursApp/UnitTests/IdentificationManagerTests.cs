using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Renci.SshNet.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class IdentificationManagerTests
    {
        private IdentificationManager identificationmanager =  new IdentificationManager();
        #region GetUniqueKey
        [TestMethod]
        public void GetUniqueKey_Expected()
        {
            //Arrange

            //Act
            string key1 = identificationmanager.GetUniqueKey();
            string key2 = identificationmanager.GetUniqueKey();

            //Assert
            Assert.AreEqual(20, key1.Length);
            Assert.AreEqual(20, key2.Length);
            Assert.AreNotEqual(key1, key2);
        }
        #endregion
        #region Encrypt
        [TestMethod]
        public void Encrypt_IdenticalStrings()
        {
            //Arrange
            string inputstring1 = "EncryptTest";
            string inputstring2 = "EncryptTest";

            //Act
            string string1 = identificationmanager.Encrypt(inputstring1);
            string string2 = identificationmanager.Encrypt(inputstring2);

            //Assert
            Assert.AreEqual(string1, string2);
        }
        [TestMethod]
        public void Encrypt_DifferentStrings()
        {
            //Arrange
            string inputstring1 = "EncryptTest1";
            string inputstring2 = "EncryptTest2";

            //Act
            string string1 = identificationmanager.Encrypt(inputstring1);
            string string2 = identificationmanager.Encrypt(inputstring2);

            //Assert
            Assert.AreNotEqual(string1, string2);
        }
        #endregion
    }
}
