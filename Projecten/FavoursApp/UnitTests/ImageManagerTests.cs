using Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class ImageManagerTests
    {
        private ImageManager imagemanager;
        [TestInitialize]
        public void Initialize()
        {
            imagemanager = new ImageManager();
        }
        #region GetImageName
        [TestMethod]
        public void GetImageName_CorrectInput1()
        {
            //Arrange
            string filetype = "jpg";

            //Act
            string result = imagemanager.GetImageName(filetype);

            //Assert
            Assert.AreEqual(".jpg", result.Substring(result.Length - 4, 4));
            Assert.IsTrue(result.Length > 4);
        }
        [TestMethod]
        public void GetImageName_CorrectInput2()
        {
            //Arrange
            string filetype = "png";

            //Act
            string result = imagemanager.GetImageName(filetype);

            //Assert
            Assert.AreEqual(".png", result.Substring(result.Length - 4, 4));
            Assert.IsTrue(result.Length > 4);
        }
        [TestMethod]
        public void GetImageName_EmptyInput()
        {
            //Arrange
            string filetype = "";

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => imagemanager.GetImageName(filetype));

            //Assert
            Assert.AreEqual(ex.Message, "Imagetype can't be null or empty");
        }
        [TestMethod]
        public void GetImageName_NullInput()
        {
            //Arrange
            string filetype = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => imagemanager.GetImageName(filetype));

            //Assert
            Assert.AreEqual(ex.Message, "Imagetype can't be null or empty");
        }
        #endregion
        #region GetFilePath
        [TestMethod]
        public void GetFilePath_CorrectInput1()
        {
            //Arrange
            string path = @"Disc\Folder1\SubFolder1\";
            string filename = "Item1";

            //Act
            string result = imagemanager.GetFilePath(path, filename);

            //Assert
            Assert.AreEqual(@"Disc\Folder1\SubFolder1\uploadedimages\Item1", result);
        }
        [TestMethod]
        public void GetFilePath_CorrectInput2()
        {
            //Arrange
            string path = @"Disc\Folder2\SubFolder2\";
            string filename = "Item2";

            //Act
            string result = imagemanager.GetFilePath(path, filename);

            //Assert
            Assert.AreEqual(@"Disc\Folder2\SubFolder2\uploadedimages\Item2", result);
        }
        [TestMethod]
        public void GetFilePath_EmptyPathInput()
        {
            //Arrange
            string path = @"";
            string filename = "Item3";

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => imagemanager.GetFilePath(path, filename));

            //Assert
            Assert.AreEqual(ex.Message, "Path can't be null or empty");
        }
        [TestMethod]
        public void GetFilePath_EmptyFilenameInput()
        {
            //Arrange
            string path = @"Disc\Folder2\SubFolder2\";
            string filename = "";

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => imagemanager.GetFilePath(path, filename));

            //Assert
            Assert.AreEqual(ex.Message, "Filename can't be null or empty");
        }
        [TestMethod]
        public void GetFilePath_AllEmptyInput()
        {
            //Arrange
            string path = "";
            string filename = "";

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => imagemanager.GetFilePath(path, filename));

            //Assert
            Assert.AreEqual(ex.Message, "Path can't be null or empty");
        }
        [TestMethod]
        public void GetFilePath_PathNullInput()
        {
            //Arrange
            string path = null;
            string filename = "nulltest";

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => imagemanager.GetFilePath(path, filename));

            //Assert
            Assert.AreEqual(ex.Message, "Path can't be null or empty");
        }
        [TestMethod]
        public void GetFilePath_FilenameNullInput()
        {
            //Arrange
            string path = "FilenameNullPath";
            string filename = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => imagemanager.GetFilePath(path, filename));

            //Assert
            Assert.AreEqual(ex.Message, "Filename can't be null or empty");
        }
        [TestMethod]
        public void GetFilePath_BothNullInput()
        {
            //Arrange
            string path = null;
            string filename = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentException>(() => imagemanager.GetFilePath(path, filename));

            //Assert
            Assert.AreEqual(ex.Message, "Path can't be null or empty");
        }
        #endregion
    }
}
