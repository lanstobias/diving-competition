using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class Database
    {
        #region Properties
        private DatabaseConnection DBConnection = new DatabaseConnection();
        #endregion

        #region Constructors
        public Database()
        {
        }
        #endregion

        #region Public methods
        public long ExecuteQuery(string query)
        {
            if (DBConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.Connection);

                try
                {
                    var queryResult = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

                DBConnection.CloseConnection();

                return command.LastInsertedId;
            }
            else
            {
                throw new Exception("No connection");
            }
        }

        public DataTable ExecuteFetch(string query)
        {
            if (DBConnection.OpenConnection())
            {
                DataTable resultDataTable = new DataTable();

                MySqlCommand command = new MySqlCommand(query, DBConnection.Connection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                try
                {
                    dataAdapter.Fill(resultDataTable);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

                DBConnection.CloseConnection();

                return resultDataTable;
            }
            else
            {
                throw new Exception("No connection");
            }
        }

        public void PushContest(Contest contest)
        {
            long contestID = PushContestInfo(contest.Info);
            PushJudgeList(contest.Judges, contestID);
            PushSubContestBranches(contest.SubContestBranches, contestID);
        }

        public void StorePerson(Person person)
        {
            // Table info
            string table = "person";

            // Person info
            var id = person.ID;
            var firstName = person.FirstName;
            var lastName = person.LastName;
            var age = person.Age;
            var email = person.Email;
            var gender = person.Gender;
            var socialSecurityNr = person.SocialSecurityNr;
            var address = person.Address;

            // Build query
            string query = $"INSERT INTO {table} ";
            query += $"(id, firstName, lastName, age, email, gender, socialSecurityNr, address) ";
            query += $"VALUES(";
            query += $"'{id}','{firstName}','{lastName}',{age},'{email}','{gender}',{socialSecurityNr},'{address}'";
            query += $")";

            ExecuteQuery(query);
        }

        public List<Person> FetchPersons()
        {
            string query = "SELECT id, firstName, lastName, age, gender FROM person;";

            DataTable personsDataTable = ExecuteFetch(query);

            // Iterate through data table and add too person list
            List<Person> personList = new List<Person>();
            foreach (DataRow row in personsDataTable.Rows)
            {
                Person person = new Person();
                person.ID = Int32.Parse(row["id"].ToString());
                person.FirstName = row["firstName"].ToString();
                person.LastName = row["lastName"].ToString();
                person.Age = Int32.Parse(row["age"].ToString());
                person.Gender = row["gender"].ToString();

                personList.Add(person);
            }

            return personList;
        }
        #endregion

        #region Private methods
        public long PushContestInfo(ContestInfo contestInfo)
        {
            string table = "contest";

            var name = contestInfo.Name;
            var city = contestInfo.City;
            var arena = contestInfo.Arena;
            var startDate = contestInfo.StartDate;
            var endDate = contestInfo.EndDate;

            string query = $"INSERT INTO {table} ";
            query += $"(name, city, arena, startDate, endDate) ";
            query += $"VALUES(";
            query += $"'{name}','{city}','{arena}','{Helpers.SQLDateFormat(startDate)}','{Helpers.SQLDateFormat(endDate)}'";
            query += $")";

            long lastInsertedId = ExecuteQuery(query);
            return lastInsertedId;
        }

        private void PushJudgeList(JudgeList judges, long contestID)
        {
            foreach (var judge in judges)
            {
                PushJudge(judge, contestID);
            }
        }

        private void PushJudge(Judge judge, long contestID)
        {
            // Table info
            string table = "judge";

            // Contest info
            var personID = judge.ID;

            // Build query
            string query = $"INSERT INTO {table} ";
            query += $"(personID, contestID) ";
            query += $"VALUES(";
            query += $"'{personID}','{contestID}'";
            query += $")";

            ExecuteQuery(query);
        }

        private void PushSubContestBranches(SubContestBranchList branches, long contestID)
        {
            // FIXA METODER AV DETTA

            long branchID, contestantID, diveID;

            foreach (var branch in branches)
            {
                branchID = PushSubContestBranch(branch, contestID);

                foreach (var contestant in branch.BranchContestants)
                {
                    contestantID = PushContestant(contestant, branchID, contestID);

                    foreach (var diveList in contestant.DiveLists)
                    {
                        foreach (var dive in diveList)
                        {
                            diveID = PushDive(dive, branchID, contestantID);

                            foreach (var score in dive.Scores)
                            {
                                PushScore(score, diveID, contestID);
                            }
                        }
                    }
                }
            }
        }

        private long PushSubContestBranch(SubContestBranch branch, long contestID)
        {
            // Table info
            string table = "branch";

            // Contest info
            var name = branch.Name;

            // Build query
            string query = $"INSERT INTO {table} ";
            query += $"(name, contestID) ";
            query += $"VALUES(";
            query += $"'{name}','{contestID}'";
            query += $")";

            return ExecuteQuery(query);
        }

        private long PushContestant(Contestant contestant, long branchID, long contestID)
        {
            // Contestant info
            var personID = contestant.ID;

            // Build contestant query
            string query = $"INSERT INTO contestant";
            query += $"(personID, contestID) ";
            query += $"VALUES(";
            query += $"'{personID}','{contestID}'";
            query += $")";

            long contestantID = ExecuteQuery(query);

            // Build branch_contestant query
            query = $"INSERT INTO branch_contestant";
            query += $"(contestantID, branchID) ";
            query += $"VALUES(";
            query += $"'{contestantID}','{branchID}'";
            query += $")";

            ExecuteQuery(query);

            return contestantID;
        }

        private long PushDive(Dive dive, long branchID, long contestantID)
        {
            // Table info
            string table = "dive";

            // Contest info
            var name = dive.Name;
            var code = dive.Code.Code;
            var multiplier = dive.Code.Multiplier;

            // Build query
            string query = $"INSERT INTO {table} ";
            query += $"(name, code, multiplier, contestantID, branchID) ";
            query += $"VALUES(";
            query += $"'{name}','{code}', '{multiplier}', '{contestantID}', '{branchID}'";
            query += $")";

            return ExecuteQuery(query);
        }

        private void PushScore(Score score, long diveID, long contestID)
        {
            // Table info
            string table = "point";

            // Contest info
            var point = score.Value;
            var judgeID = score.Judge.ID;

            // Build query
            string query = $"INSERT INTO {table} ";
            query += $"(point, diveID, judgeID, contestID) ";
            query += $"VALUES(";
            query += $"'{point}','{diveID}', '{judgeID}', '{contestID}'";
            query += $")";

            ExecuteQuery(query);
        }
        #endregion
    }
}
