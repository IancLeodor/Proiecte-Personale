using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ACM.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            Customer customer = new Customer
            {
                FirstName = "Bilbo",
                LastName = "Baggins"
            };
            string expected = "Baggins, Bilbo";

            //-Act
            string actual = customer.FullName;

            //--Asert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            Customer customer = new Customer//variabile de obiect
            {
                LastName = "Baggins"
            };
            string expected = "Baggins";
            //--Act
            string actual = customer.FullName;

            //-Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            Customer customer = new Customer
            {
                LastName = "Bilbo"
            };
            string expected = "Bilbo";
            //--Act
            //accesam metoda pe care o testam
            string actual = customer.FullName;

            //-Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void StaticTest()
        {
            //--Arrange
            var c1 = new Customer();
            c1.FirstName = "Bilbo";
            Customer.InstanceCount += 1;

            var c2 = new Customer();
            c2.FirstName = "Frodo";
            Customer.InstanceCount += 1;

            var c3 = new Customer();
            c3.FirstName = "Rosie";
            Customer.InstanceCount += 1;

            Assert.AreEqual(3, Customer.InstanceCount);
        }


        [TestMethod]
        public void ValidateValid()
        {
            var customer = new Customer
            {
                LastName = "Baggins",
                EmailAddress = "fbaggins@hobbiton.me"
            };
            var expected = true;
            //--Act
            var actual = customer.Validate();

            Assert.AreEqual(expected, actual);

        }
        

        
    }
}
