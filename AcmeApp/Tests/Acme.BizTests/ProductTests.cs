﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    //Ways to initialize objects
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.ProductDescription = "15-inch steel blade hand saw";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";
            //Act
            var actual = currentProduct.SayHello();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHelloTest_ParameterizedConstructor()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");
            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";
            //Act
            var actual = currentProduct.SayHello();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHelloTest_ObjectInitializer()
        {
            //Arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                ProductDescription = "15-inch steel blade hand saw"
            };

            var expected = "Hello Saw (1): 15-inch steel blade hand saw" + " Available on: ";
            //Act
            var actual = currentProduct.SayHello();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            //must have a left side operator in order to use the null check
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;
            //Act
            var actual = companyName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertMetersToInchesTest()
        {
            //Arrange
            var expected = 78.74;

            //Act
            var actual = 2 * Product.InchesPerMeter;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinimumPrice_Default()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = .96m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinimumPrice_Bulk()
        {
            //Arrange
            var currentProduct = new Product(1, "Bulk tools", "");
            var expected = 9.99m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductName_Format()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "    Steel Hammer   ";
            var expected = "Steel Hammer";

            //Act
            var actual = currentProduct.ProductName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductName_TooShort()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";

            string expected = null;
            string expectedMessage = "Product name must be at least 3 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ProductName_TooLong()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "This is to long of a product name I think";

            string expected = null;
            string expectedMessage = "Product name must be less then 20 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ProductName_SetsValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Hammer";

            string expected = "Hammer";
            string expectedMessage = null;

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void Category_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = "Tools";

            //Act
            var actual = currentProduct.Category;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Category_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.Category = "Garden";
            var expected = "Garden";

            //Act
            var actual = currentProduct.Category;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sequence_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = 1;

            //Act
            var actual = currentProduct.SequenceNumber;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sequence_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 5;
            var expected = 5;

            //Act
            var actual = currentProduct.SequenceNumber;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCode_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = "Tools-1";

            //Act
            var actual = currentProduct.ProductCode;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}