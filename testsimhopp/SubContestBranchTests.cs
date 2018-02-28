using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Simhopp;

namespace testsimhopp
{
    /// <summary>
    /// Summary description for SubContestBranchTests
    /// </summary>
    [TestClass]
    public class SubContestBranchTests
    {
        private TestContext testContext;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }


        Contest contest = new Contest();
        Contestant kalle = new Contestant("kalle", "Cool");
        Contestant pelle = new Contestant("pelle", "Holm");
        ContestantList contestantList = new ContestantList();
        SubContestBranch branch;
        

        public SubContestBranchTests()
        {
            contestantList.Add(kalle);
            contestantList.Add(pelle);
            branch = new SubContestBranch("testbranch", contest, contestantList);
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

        [TestMethod]
        public void TestAddAndRemoveNewDive()
        {


            // Tests the adding of a new dive, when it is the first dive of the diver
            Dive dive = new Dive(new DiveCode(3.1));
            branch.AddNewDive(contestantList.ElementAt(0), dive);
            Dive diveToCheck = null;

            diveToCheck = branch.BranchContestants.ElementAt(0).DiveLists.ElementAt(0).ElementAt(0);

            Assert.AreEqual(dive, diveToCheck);

            // Tests the adding of a second jump of a diver on same branch

            Dive dive2 = new Dive(new DiveCode(2));

            branch.AddNewDive(contestantList.ElementAt(0), dive2);

            diveToCheck = branch.BranchContestants.ElementAt(0).DiveLists.ElementAt(0).ElementAt(1);

            Assert.AreEqual(dive2, diveToCheck);


            // Tests adding a new dive on a new branch

            SubContestBranch branch2 = new SubContestBranch("testbranch2", contest, contestantList);

            Dive dive3 = new Dive(new DiveCode(3.0));

            branch2.AddNewDive(contestantList.ElementAt(0), dive3);

            diveToCheck = branch2.BranchContestants.ElementAt(0).DiveLists.ElementAt(1).ElementAt(0);

            Assert.AreEqual(dive3, diveToCheck);


            // Tests removing of a dive that was added by mistake?

            Assert.IsTrue(branch.RemoveExistingDive(contestantList.ElementAt(0), dive2));

            // Checks if the element we removed is still there
            // If ArgumentOutOfRangeException is triggered the test is valid
            try
            {
                contestantList.ElementAt(0).DiveLists.ElementAt(0).ElementAt(1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                
            }
            

            // Tests removing of a dive that doesnt exist

            Assert.IsFalse(branch.RemoveExistingDive(contestantList.ElementAt(1), dive2));
            
        }

        /// <summary>
        /// Test the method that generates a result of a subcontest, ordered by winner first.
        /// </summary>
        [TestMethod]
        public void TestGenerateSubContestResult()
        {
            Contest contest = new Contest();
            Contestant kalle = new Contestant("kalle", "Cool");
            Contestant pelle = new Contestant("pelle", "Holm");
            Contestant lars = new Contestant("Lars", "Lerin");

            ContestantList contestantList = new ContestantList();
            contestantList.Add(kalle);
            contestantList.Add(pelle);
            contestantList.Add(lars);

            SubContestBranch subContest = new SubContestBranch("Test", contest, contestantList);

            Dive dive = new Dive(new DiveCode(3.1));
            Dive dive2 = new Dive(new DiveCode(2.1));
            Dive dive3 = new Dive(new DiveCode(3.5));
            Dive dive4 = new Dive(new DiveCode(2.5));
            Dive dive5 = new Dive(new DiveCode(15.0));

            ScoreList scoreListDive = new ScoreList();
            scoreListDive.Add(new Score(8));
            scoreListDive.Add(new Score(8.5));
            scoreListDive.Add(new Score(6.5));
            scoreListDive.Add(new Score(7));
            scoreListDive.Add(new Score(9));
            dive.Scores = scoreListDive;
            // 72.85

            subContest.AddNewDive(kalle, dive);

            ScoreList scoreListDive2 = new ScoreList();
            scoreListDive2.Add(new Score(6));
            scoreListDive2.Add(new Score(7.5));
            scoreListDive2.Add(new Score(6.5));
            scoreListDive2.Add(new Score(7));
            scoreListDive2.Add(new Score(9));
            dive2.Scores = scoreListDive2;
            // 44.1

            subContest.AddNewDive(pelle, dive2);

            ScoreList scoreListDive3 = new ScoreList();
            scoreListDive3.Add(new Score(6));
            scoreListDive3.Add(new Score(4.5));
            scoreListDive3.Add(new Score(6.5));
            scoreListDive3.Add(new Score(5));
            scoreListDive3.Add(new Score(8));
            dive3.Scores = scoreListDive3;
            subContest.AddNewDive(kalle, dive3);
            // 61.25

            ScoreList scoreListDive4 = new ScoreList();
            scoreListDive4.Add(new Score(6));
            scoreListDive4.Add(new Score(7));
            scoreListDive4.Add(new Score(8.5));
            scoreListDive4.Add(new Score(5));
            scoreListDive4.Add(new Score(8));
            dive4.Scores = scoreListDive4;
            subContest.AddNewDive(pelle, dive4);
            //
            

            ScoreList scoreListDive5 = new ScoreList();
            scoreListDive5.Add(new Score(6));
            scoreListDive5.Add(new Score(7));
            scoreListDive5.Add(new Score(8.5));
            scoreListDive5.Add(new Score(5));
            scoreListDive5.Add(new Score(8));
            dive5.Scores = scoreListDive5;
            subContest.AddNewDive(lars, dive5);
            //

            // get the ResultDictionary containing pairs of contestant and a total score sum.
            ResultDictionary result = subContest.GenerateSubContestResult();

        

            Assert.AreEqual(3, result.Count);

            foreach (var score in result)
            {
                Console.WriteLine(score.Key.FirstName + ": " + score.Value);
            }

            Assert.AreEqual(315, result.First().Value);

            Console.WriteLine();

            // getting same data from our Contest object
            ResultDictionary r = contest.GetSubContestResultDictionary(subContest);

            Assert.AreEqual(3, r.Count);

            foreach (var score in r)
            {
                Console.WriteLine(score.Key.FirstName + ": " + score.Value);
            }

            Assert.AreEqual(315, r.First().Value);

        }
    }
}
