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
        public void TestGivenAValidtillWhenAnEmptyBasketIsProcessedThenTotalIsZero()
        {
            // Arrange
            Till till = new Till();
            // Act
            double total = till.Process(new Basket());
            // Assert
            Assert.AreEqual(0.0, total);
        }

        [TestMethod]
        public void TestGivenAValidTillWhenBasketWithOneItemIsProcessedThenTotalIsSameAsPriceOfItem()
        {
            // Arrange
            const double PRICE = 8.00;
            Till till = new Till();
            Basket basket = new Basket();
            basket.Add(new Item() { price = PRICE });
            // Act
            double total = till.Process(basket);
            // Assert
            Assert.AreEqual(PRICE, total);
        }

        [TestMethod]
        public void TestGivenAValidTillWhenBasketWithOneItemIsProcessedThenTotalIsCalculated()
        {
            // Arrange
            const double PRICE = 8.00;
            Till till = new Till();
            Basket basket = new Basket();
            basket.Add(new Item() { price = PRICE });
            basket.Add(new Item() { price = PRICE });
            // Act
            double total = till.Process(basket);
            // Assert
            Assert.AreEqual(PRICE * 2, total);
        }

    }
}