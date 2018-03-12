using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using Simhopp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Simhopp.Tests
{
    [TestClass()]
    public class AuthTests
    {
        [TestMethod()]
        public void PasswordsMatchTest()
        {
            string inputPassword = "these pretzels are making me thirsty";
            string expectedHash = "f98c73c790e7b4e571b413f39330b506748823ae";

            string hashedInputPassword = Helpers.SHA1Hash(inputPassword);

            Auth auth = new Auth();
            Assert.IsTrue(auth.PasswordsMatch(expectedHash, hashedInputPassword));
        }
    }
}