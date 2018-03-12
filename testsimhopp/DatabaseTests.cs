using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhopp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp.Tests
{
    [TestClass()]
    public class DatabaseTests
    {
        [TestMethod()]
        public void MailBelongsToOnePersonTest()
        {
            // Assign
            Database database = new Database();
            string givenEmail = "pelle@gmail.com";
            string givenBadEmail = "noEmail@noemail.com";

            // Act
            bool shouldBeTrue = database.MailBelongsToOnePerson(givenEmail);
            bool shouldBeFalse = database.MailBelongsToOnePerson(givenBadEmail);

            // Assert
            Assert.IsTrue(shouldBeTrue);
            Assert.IsFalse(shouldBeFalse);
        }
    }
}