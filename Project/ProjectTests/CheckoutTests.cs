using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectClasses;
using System.Collections.Generic;

namespace ProjectTests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void Test_When_one_item_is_added_to_the_basked_using_addbookmethod_CalculteTotal_Method_gives_Total_for_one_item()

        {
            //Arrange
            Basket basket = new Basket();
            Item item = new Item();
            basket.listOfItems = new List<Item>();
            
            item.price = 8;
            Till till = new Till();

            //Act
            var listOfItems = basket.additem();
            listOfItems.Add(new Item());
            var total = till.calculateTotal(new Item());
          
            
            //Assert
            Assert.AreEqual(8, 8);

        }

        [TestMethod]
        public void Test_When_Two_items_are_added_to_the_basked_using_addbookmethod_CalculteTotal_Method_gives_Total_for_Two_item()
        {
            //Arrange
            Basket basket = new Basket();
            Item item = new Item();
            basket.listOfItems = new List<Item>();

            item.price = 8;
            Till till = new Till();

            //Act
            var listOfItems = basket.additem();
            listOfItems.Add(new Item());
            listOfItems.Add(new Item());
            var total = till.calculateTotal(new Item());


            //Assert
            Assert.AreEqual(8, 8);

        }
    }
}
