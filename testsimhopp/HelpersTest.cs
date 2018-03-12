using System;
using Simhopp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testsimhopp
{
    [TestClass]
    public class HelpersTest
    {
        [TestMethod]
        public void SHA1HashTest()
        {
            // Arrange
            string firstInputPassword = $"password123 _=?*/'´+ åäö";
            string firstExpectedHash = "e2e8fad5d9b7d8530194eec82ef407a8121df09f";

            string secondInputPassword = "these pretzels are making me thirsty";
            string secondExpectedHash = "f98c73c790e7b4e571b413f39330b506748823ae";

            // Act
            var firstReturnedHash = Helpers.SHA1Hash(firstInputPassword);
            var secondReturnedHash = Helpers.SHA1Hash(secondInputPassword);

            // Assert
            Assert.AreEqual(firstExpectedHash, firstReturnedHash);
            Assert.AreEqual(secondExpectedHash, secondReturnedHash);
        }
    }
}
