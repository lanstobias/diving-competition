using System;
using Simhopp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSpikes
{
    public class DatabaseContest
    {
        public DatabaseContest()
        {

        }

        public Contest createTestContest()
        {
            DateTime endDate = new DateTime(2018, 2, 22);

            ContestInfo contestInfo = new ContestInfo("Svedala simhoppstävling", "Örebro", DateTime.Now, endDate, "Gustavsvik");

            Judge judge1 = new Judge(1, "Karl", "Mal", 22, "karl@gmail.com", "male", "891017-6653", "Pappersvägen 3");
            Judge judge2 = new Judge(2, "Laban", "Asda", 45, "laban@hotmail.com", "male", "651011-6423", "Venavägen 8");
            Judge judge3 = new Judge(3, "Leg", "Shin", 33, "leg@yahoo.com", "male", "821201-5434", "Storgatan 1");
            Judge judge4 = new Judge(4, "Anna", "Pann", 29, "handy@spray.com", "female", "910413-4594", "Järnvägsgatan 33");
            Judge judge5 = new Judge(5, "Sammy", "Rol", 38, "sammy@gmail.com", "female", "880623-5921", "Skolgatan 28");

            JudgeList judgeList = new JudgeList();
            judgeList.Add(judge1);
            judgeList.Add(judge2);
            judgeList.Add(judge3);
            judgeList.Add(judge4);
            judgeList.Add(judge5);

            Contestant kalle = new Contestant(6, "Kalle", "Cool", 35, "Kalle.Erikson@gmail.com", "male", "78345345-435", "Storgatan 3");
            Contestant pelle = new Contestant(7, "Pelle", "Holm", 14, "reapermain2004@hotmail.com", "male", "04546387-1104", "Småttmisnöjdmedtillvaro gatan 25");
            Contestant lars = new Contestant(8, "Lars", "Lerin", 50, "finansierbaragrabben@yahoo.com", "male", "68345435-4352", "Brittmarie-gatan 89");
            Contestant anna = new Contestant(9, "Anna", "Annasson", 28, "Shasmine@live.com", "female", "88376534534-3455", "Lokalgatan 8");

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

            return contest;
        }

        public void AddContestInfo()
        {
            DateTime endDate = new DateTime(2018, 03, 05);
            ContestInfo contestInto = new ContestInfo("Bra simhoppstävling", "Örebro", DateTime.Now, endDate, "Gustavsvik");

            Database database = new Database();

            try
            {
                database.PushContestInfo(contestInto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        public void AddContest()
        {
            Database database = new Database();

            Contest testContest = createTestContest();

            try
            {
                database.PushContest(testContest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
