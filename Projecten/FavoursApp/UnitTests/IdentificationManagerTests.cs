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
            Assert.AreEqual(16, key1.Length);
            Assert.AreEqual(16, key2.Length);
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
        [TestMethod]
        public void Encrypt_EmptyStrings()
        {
            //Arrange
            string inputstring1 = "";

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => identificationmanager.Encrypt(inputstring1));

            //Assert
            Assert.AreEqual(ex.Message, "Input string can't be null or empty");
        }
        [TestMethod]
        public void Encrypt_NullStrings()
        {
            //Arrange
            string inputstring1 = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => identificationmanager.Encrypt(inputstring1));

            //Assert
            Assert.AreEqual(ex.Message, "Input string can't be null or empty");
        }
        #endregion
    }
}
