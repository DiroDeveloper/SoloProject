using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectClasses;
using System.Collections.Generic;

namespace ProjectTests
{
    [TestClass]
    public class BasketTest
    {
        Basket basket;

        public BasketTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        [TestInitialize()]
        public void TestInitialize()
        {
            basket = new Basket();
        }
        
        [TestMethod]
        public void Test_No_Item_Added_basket_returns_0_item()
        {
            //Arrange
            
            //Act
           
            //Assert
            Assert.AreEqual(0, basket.Size);
        }


        [TestMethod]
        public void Test_When_One_Item_Added_Basket_Size_Is_One()
        {
            //Arrange
            basket.Add(new Item());
            //Act

            //Assert
            Assert.AreEqual(1, basket.Size);
        }

        [TestMethod]
        public void Test_When_Two_Items_Added_Basket_Size_Is_Two()
        {
            //Arrange
            basket.Add(new Item());
            basket.Add(new Item());


            //Act

            //Assert
            Assert.AreEqual(2, basket.Size);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenNoItemAddedThenGetItemLengthIsZero()
        {
            // Arrange
            // Act
            List<Item> items = basket.GetItem();
            // Assert            
            Assert.AreEqual(0, items.Count);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenOneItemAddedThenGetItemLengthIsOne()
        {
            // Arrange
            basket.Add(new Item());
            // Act
            List<Item> items = basket.GetItem();
            // Assert            
            Assert.AreEqual(1, items.Count);
        }

        [TestMethod]
        public void TestGivenAValidBasketWhenTwoItemAddedThenGetItemLengthIsTwo()
        {
            // Arrange
            basket.Add(new Item());
            basket.Add(new Item());
          
            // Act
            List<Item> items = basket.GetItem();
            // Assert            
            Assert.AreEqual(2, items.Count);
        }
    }
}
