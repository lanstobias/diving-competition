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
        public void TestAddNewDive()
        {
            Contest contest = new Contest();
            Contestant kalle = new Contestant("kalle");
            Contestant pelle = new Contestant("pelle");
            ContestantList contestantList = new ContestantList();
            contestantList.Add(kalle);
            contestantList.Add(pelle);

            // Tests the adding of a new dive, when it is the first dive of the diver
            SubContestBranch branch = new SubContestBranch("testbranch", contest, contestantList);
            
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

        }
    }
}
