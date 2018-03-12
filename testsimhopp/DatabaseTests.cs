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

        [TestMethod()]
        public void FetchPasswordFromEmailTest()
        {
            // Assign
            Database database = new Database();
            string givenEmail = "pelle@gmail.com";
            string notExistingEmail = "noEmail@noemail.com";
            string correctPassword = "cbfdac6008f9cab4083784cbd1874f76618d2a97";
            string incorrectPassword = "incorrectpassword";

            // Act
            string returnedPassword = database.FetchPasswordFromEmail(givenEmail);

            // Assert
            try
            {
                string shouldThrowException = database.FetchPasswordFromEmail(notExistingEmail);
                Assert.Fail();
            } catch (Exception) { }

            Assert.AreEqual(correctPassword, returnedPassword);
            Assert.AreNotEqual(incorrectPassword, returnedPassword);
        }
    }
}