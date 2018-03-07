using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhopp;
using System.Linq;

namespace testsimhopp
{
    /// <summary>
    /// Summary description for CheckDataInputTest
    /// </summary>
    [TestClass]
    public class CheckDataInputTest
    {
        public CheckDataInputTest()
        {


        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Metod som testar ifall en sträng giltig. Ogiltiga tecken är alla specialtecken som #¤%&$£€.
        /// Siffror och mellanslag är också giltiga.
        /// </summary>
        [TestMethod]
        public void TestStringCheckFormat()
        {
            String Valid = "hello world";

            String Invalid = "Hello%World";

            String Valid2 = "Örebro";

            String Valid3 = "Lars Larsson";

            String Invalid2 = "Lar$ Lar$$on";

            String Valid4 = "10m frihopp"; //

            Assert.AreEqual(true, CheckDataInput.StringCheckFormat(Valid));

            Assert.AreEqual(false, CheckDataInput.StringCheckFormat(Invalid));

            Assert.AreEqual(true, CheckDataInput.StringCheckFormat(Valid2));

            Assert.AreEqual(true, CheckDataInput.StringCheckFormat(Valid3));

            Assert.AreEqual(false, CheckDataInput.StringCheckFormat(Invalid2));

            Assert.AreEqual(true, CheckDataInput.StringCheckFormat(Valid4));
        }

        /// <summary>
        /// Metod som kollar ifall en emailadress är giltig.
        /// Adressen får endast innehålla 1 @ tecken. Några tecken både innan och efter @ måste också förekomma.
        /// </summary>
        [TestMethod]
        public void TestEmailCheckFormat()
        {
            List<String> InvalidEmails = new List<String>();

            List<String> ValidEmails = new List<String>();

            InvalidEmails.Add("LarssnabelA.com"); // strängen måste innehålla @.
            InvalidEmails.Add("Lars@gmailpunktse"); // Saknar .
            InvalidEmails.Add("Lars@gmail.c"); // minst 2 tecken måste komma efter punkten.
            InvalidEmails.Add(".Lars@gmail.com"); // ingen punkt i början.
            InvalidEmails.Add("Lars[at]geemail.com"); // @@@@@@@
            InvalidEmails.Add("Lars..Larsson@gmail.com"); // 2 punkter
            InvalidEmails.Add("Lars.@gmail.com"); // punkt innan @ får man inte ha.
            InvalidEmails.Add("Lars@gmail.com."); // punkt i slutet får man inte heller ha.

            ValidEmails.Add("Lars@hotmail.se");
            ValidEmails.Add("Lars@home.kr");
            ValidEmails.Add("Lars_Larsson94@yahoo.se");
            ValidEmails.Add("L@abc.org");
            ValidEmails.Add("Lars@192.168.0.1");
            ValidEmails.Add("Lars@10.10.100.1");
            ValidEmails.Add("Lars&Karl@punkt.se");


            foreach (var invalid in InvalidEmails)
            {
                Assert.AreEqual(false, CheckDataInput.EmailCheckFormat(invalid));
            }

            foreach (var valid in ValidEmails)
            {
                Assert.AreEqual(true, CheckDataInput.EmailCheckFormat(valid));
            }
        }
        /// <summary>
        /// Test av Personnummer.
        /// Giltiga format är:
        /// YYYYMMDD-NNNN
        /// YYMMDD-NNNN
        /// YYYYMMDDNNNN
        /// YYMMDDNNNN
        /// </summary>
        [TestMethod]
        public void TestSSNCheckFormat()
        {
            List<String> ValidSSN = new List<String>();

            List<String> InvalidSSN = new List<String>();

            ValidSSN.Add("19830709-0327");
            ValidSSN.Add("830709-0327");
            ValidSSN.Add("198307090327");
            ValidSSN.Add("8307090327");

            InvalidSSN.Add("119830709-0327"); // Inte ett giltigt format.
            InvalidSSN.Add("19830709-03270"); // - || -
            InvalidSSN.Add("19830709--0327");// - || -
            InvalidSSN.Add("1983O7O9-O327"); // bokstav

            foreach (var valid in ValidSSN)
            {
                Assert.AreEqual(true, CheckDataInput.SSNCheckFormat(valid));
            }

            foreach (var invalid in InvalidSSN)
            {
                Assert.AreEqual(false, CheckDataInput.SSNCheckFormat(invalid));
            }
        }
    }
}