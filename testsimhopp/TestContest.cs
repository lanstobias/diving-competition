using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhopp;
using System.Linq;

namespace testsimhopp
{
    /// <summary>
    /// Summary description for TestContest
    /// </summary>
    [TestClass]
    public class TestContest
    {
        public TestContest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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
        public void TestFullContest()
        {
            DateTime endDate = new DateTime(2018, 2, 22);

            ContestInfo contestInfo = new ContestInfo("Svedala simhopps tävling", "Örebro", DateTime.Now, endDate, "Gustavsvik");

            Judge judge1 = new Judge("Karl", "Mal");
            Judge judge2 = new Judge("LAban", "Asda");
            Judge judge3 = new Judge("Leg", "Shin");
            Judge judge4 = new Judge("Handy", "Bandy");
            Judge judge5 = new Judge("Sammy", "Rol");

            JudgeList judgeList = new JudgeList();
            judgeList.Add(judge1);
            judgeList.Add(judge2);
            judgeList.Add(judge3);
            judgeList.Add(judge4);
            judgeList.Add(judge5);

            Contestant kalle = new Contestant("kalle", "Cool");
            Contestant pelle = new Contestant("pelle", "Holm");
            Contestant lars = new Contestant("Lars", "Lerin");
            Contestant anna = new Contestant("Anna", "Annasson");

            ContestantList contestantList = new ContestantList();
            contestantList.Add(kalle);
            contestantList.Add(pelle);
            contestantList.Add(lars);
            contestantList.Add(anna);

            // create the new Contest object
            Contest contest = new Contest(contestInfo, judgeList, contestantList);


            // create ContestantLists for a subcontest
            ContestantList branch1_Contestants = new ContestantList();
            branch1_Contestants.Add(kalle);
            branch1_Contestants.Add(pelle);
            branch1_Contestants.Add(lars);

            SubContestBranch branch1 = new SubContestBranch("Deltävling 1", contest, branch1_Contestants);


            // create second subcontest
            ContestantList branch2_Contestants = new ContestantList();
            branch2_Contestants.Add(kalle);
            branch2_Contestants.Add(pelle);
            branch2_Contestants.Add(anna);

            SubContestBranch branch2 = new SubContestBranch("Deltävling 2", contest, branch2_Contestants);

            // add the newly created subcontests to the contest
            contest.SubContestBranches.Add(branch1);
            contest.SubContestBranches.Add(branch2);


            // first dive of the subcontest
            Dive dive1Kalle = new Dive(new DiveCode(3.1));

            // Scores come in from all the judges and is built into a full ScoreList
            ScoreList scoreListDive1Kalle = new ScoreList();

            scoreListDive1Kalle.Add(new Score(8, judge1));
            scoreListDive1Kalle.Add(new Score(5, judge2));
            scoreListDive1Kalle.Add(new Score(8.5, judge3));
            scoreListDive1Kalle.Add(new Score(7, judge4));
            scoreListDive1Kalle.Add(new Score(9, judge5));

            dive1Kalle.Scores = scoreListDive1Kalle;

            branch1.AddNewDive(kalle, dive1Kalle);


            // second dive
            Dive dive1Pelle = new Dive(new DiveCode(3.1));

            // Scores come in from all the judges and is built into a full ScoreList
            ScoreList scoreListDive1Pelle = new ScoreList();

            scoreListDive1Pelle.Add(new Score(8, judge1));
            scoreListDive1Pelle.Add(new Score(5, judge2));
            scoreListDive1Pelle.Add(new Score(8.5, judge3));
            scoreListDive1Pelle.Add(new Score(7, judge4));
            scoreListDive1Pelle.Add(new Score(6.5, judge5));

            dive1Pelle.Scores = scoreListDive1Pelle;

            branch1.AddNewDive(pelle, dive1Pelle);


            // third dive
            Dive dive1Lars = new Dive(new DiveCode(3.1));

            // Scores come in from all the judges and is built into a full ScoreList
            ScoreList scoreListDive1Lars = new ScoreList();

            scoreListDive1Lars.Add(new Score(7.5, judge1));
            scoreListDive1Lars.Add(new Score(9, judge2));
            scoreListDive1Lars.Add(new Score(8.5, judge3));
            scoreListDive1Lars.Add(new Score(7, judge4));
            scoreListDive1Lars.Add(new Score(6.5, judge5));

            dive1Lars.Scores = scoreListDive1Lars;

            branch1.AddNewDive(lars, dive1Lars);


            // first dive of second subcontest
            Dive dive2Kalle = new Dive(new DiveCode(2.8));

            // Scores come in from all the judges and is built into a full ScoreList
            ScoreList scoreListDive2Kalle = new ScoreList();

            scoreListDive2Kalle.Add(new Score(8, judge1));
            scoreListDive2Kalle.Add(new Score(5, judge2));
            scoreListDive2Kalle.Add(new Score(8.5, judge3));
            scoreListDive2Kalle.Add(new Score(7, judge4));
            scoreListDive2Kalle.Add(new Score(9, judge5));

            dive2Kalle.Scores = scoreListDive1Kalle;

            branch2.AddNewDive(kalle, dive2Kalle);


            // second dive
            Dive dive2Pelle = new Dive(new DiveCode(2.9));

            // Scores come in from all the judges and is built into a full ScoreList
            ScoreList scoreListDive2Pelle = new ScoreList();

            scoreListDive2Pelle.Add(new Score(8, judge1));
            scoreListDive2Pelle.Add(new Score(5, judge2));
            scoreListDive2Pelle.Add(new Score(8, judge3));
            scoreListDive2Pelle.Add(new Score(7, judge4));
            scoreListDive2Pelle.Add(new Score(6.5, judge5));

            dive2Pelle.Scores = scoreListDive1Pelle;

            branch2.AddNewDive(pelle, dive2Pelle);


            // third dive
            Dive dive1Anna = new Dive(new DiveCode(3.0));

            // Scores come in from all the judges and is built into a full ScoreList
            ScoreList scoreListDive1Anna = new ScoreList();

            scoreListDive1Anna.Add(new Score(7.5, judge1));
            scoreListDive1Anna.Add(new Score(9, judge2));
            scoreListDive1Anna.Add(new Score(8.5, judge3));
            scoreListDive1Anna.Add(new Score(7, judge4));
            scoreListDive1Anna.Add(new Score(6.5, judge5));

            dive1Anna.Scores = scoreListDive1Anna;

            branch2.AddNewDive(anna, dive1Anna);

            Console.WriteLine("HEJ");

            foreach(var subContest in contest.SubContestBranches)
            {
                int i = 1;
                foreach(var result in subContest.GenerateSubContestResult())
                {
                    Console.WriteLine(i + ". " + result.Key.FirstName + " Score: " + result.Value);
                    i++;
                }
            }
        }
    }
}
