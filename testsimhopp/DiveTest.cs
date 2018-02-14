using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhopp;

namespace testsimhopp
{
    /// <summary>
    /// Summary description for DiveTest
    /// </summary>
    [TestClass]
    public class DiveTest
    {

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
        [TestMethod]
        public void TestGenerateScoresWithoutFirstAndLast()
        {
            Dive dive = new Dive(new DiveCode(3.1));
            ScoreList scoreList = new ScoreList
            {
                new Score(7),
                new Score(8),
                new Score(5),
                new Score(10)
            };


            dive.Scores = scoreList;

            ScoreList list = dive.generateScoresWithoutFirstAndLastScore();

            //ScoreList winList = new ScoreList
            //{
            //    new Score(7),
            //    new Score(8)
            //};
            ScoreList winList = new ScoreList();
            Score score = new Score(7);
            Score score2 = new Score(8);
            winList.Add(score);
            winList.Add(score2);


            double sum1 = 0, sum2 = 0;
            foreach (var s in winList)
                sum1 += s.Value;

            foreach (var s in list)
                sum2 += s.Value;

            //Assert.IsTrue(sum1 == 15);
            Assert.AreEqual(15, sum1);
            Assert.AreEqual(15, sum2);

        }

        [TestMethod]
        public void TestGenerateFinalScore()
        {
            Dive dive = new Dive(new DiveCode(3.1));
            ScoreList scoreList = new ScoreList
            {
                new Score(7),
                new Score(8),
                new Score(5),
                new Score(10)
            };
            dive.Scores = scoreList;

            double result = dive.generateFinalizedScore();

            Assert.AreEqual(46.5, result);
        }

        [TestMethod]
        public void TestGenerateRawScore()
        {
            Dive dive = new Dive(new DiveCode(3.1));
            ScoreList scoreList = new ScoreList
            {
                new Score(7),
                new Score(8),
                new Score(5),
                new Score(10)
            };
            dive.Scores = scoreList;

            double result = dive.generateRawScore();

            Assert.AreEqual(93, result);
        }
    }
}
