using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectClasses;
using System.Collections.Generic;

namespace ProjectTests
{
    [TestClass]
    public class BasketTest
    {
        [TestMethod]
        public void Test_additem_method_in_basket_return_Empty_list_if_no_book_added()
        {
            //Arrange
            Basket basket = new Basket();
            basket.listOfItems = new List<Item>(); 
            //Act
            var listOfItems = basket.getItemInBasket();
            //Assert
            Assert.AreEqual(0, listOfItems.Count);
        }

        [TestMethod]
        public void Test_additem_method_in_basket_return_listlengthof_one_when_one_item_added()
        {
            //Arrange
            Basket basket = new Basket();
            Item item = new Item();
            basket.listOfItems = new List<Item>();
          

           //Act
            var listOfItems = basket.additem();
            listOfItems.Add(new Item());
            

            //Assert
            Assert.AreEqual(1, listOfItems.Count);
        }

        [TestMethod]
        public void Test_additem_method_in_basket_return_listlengthof_two_when_two_items_added()
        {
            //Arrange
            Basket basket = new Basket();
            Item item = new Item();
            basket.listOfItems = new List<Item>();


            //Act
            var listOfItems = basket.additem();
            listOfItems.Add(new Item());
            listOfItems.Add(new Item());

            //Assert
            Assert.AreEqual(2, listOfItems.Count);
        }
    }
}
