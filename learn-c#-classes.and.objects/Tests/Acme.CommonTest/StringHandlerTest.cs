using Acme.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Acme.CommonTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacesTestValid()
        {
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";
            //var handler = new StringHandler();

            var actual = source.InsertSpaces();
            
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void InsertSpacesTestWithExistingSpace()
        {
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";
            //var handler = new StringHandler();

            var actual = source.InsertSpaces();
            Assert.AreEqual(expected, actual);

        }

    }
}
