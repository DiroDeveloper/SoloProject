using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectClasses;
using System.Collections.Generic;
using Moq;

namespace ProjectTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test_GetAllItems_Calls_Read_Database_Method_Of_DatabaseReader_When_Called()
        {
            //Arrange
            Mock<DatabaseReader> mockDB = new Mock<DatabaseReader>();
            Catalogue catalogue = new Catalogue(mockDB.Object);

            //Act
           List<Item> ListOfItems = catalogue.GetAllItems();

            //Assert
           mockDB.Verify(r => r.ReadQuantity(), Times.Once);
        }

        [TestMethod]
        public void test_GetAllItems_ReturnsListOfItemsItReceivesFromReadAllMethodOfReadItemCommand_WhenCalled()
        {
            //Arrange

            Mock<DatabaseReader> mockDB = new Mock<DatabaseReader>();
            mockDB.Setup(r => r.ReadQuantity()).Returns(new List<Item>());
            Catalogue catalogue = new Catalogue(mockDB.Object);
            //Act
            var resultList = catalogue.GetAllItems();
            //Assert
            CollectionAssert.AreEqual(resultList, new List<Item>());
        }



    }
}
