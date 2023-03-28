using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BLTest
{
    [TestClass]
    public class ProductRepositoryTest 
    {
        [TestMethod()]
        public void RetrieveTest()
        {
            var productRepository = new ProductRepository();
            var expected = new Product(2)
            {
                CurrentPrice = 15.96M,
                ProductDescription = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers",
                ProductName = "Sunflowers"

            };
            var actual= productRepository.Retrieve(2);
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.ProductName, actual.ProductName);
        }

        [TestMethod()]
        public void SaveTestValid()
        {
            var productRepository = new ProductRepository();
            var updateProduct = new Product(2);
            {
                CurrentPrice = 18M,
                ProductDescription="Assorted Size Set of 4 Bright Yellow Mini Sunflowers",
                ProductName="Sunflowers",
                HasChanges=true

            };
            var actual = productRepository.Save(updatedProduct);
            Assert.AreEqual(true, actual);
        }
        [TestMethod()]
        public void SaveTestMissingPrice()
        {
            var productRepository = new ProductRepository();
            var updateProduct = new ProductRepository();
            {
                CurrentPrice = null,
                ProductDescription = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers",
                ProductName = "Sunflowers",
                HasChanges = true
            };
            var actual = productRepository.Save(updatedProduct);
            Assert.AreEqual(false, actual);
        }

    }
}
