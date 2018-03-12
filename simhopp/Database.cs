using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    /// <summary>
    /// The main Database class.
    /// Contains all methods for pushing and fetching objects to the database.
    /// </summary>
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
        // TODO: Döp om osv..
        /// <summary>
        /// Execute a SQL-query against a open MySQL connection.
        /// </summary>
        /// <param name="query">SQL-query string.</param>
        /// <returns>Last inserted ID.</returns>
        public long ExecuteQuery(string query)
        {
            if (DBConnection.OpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, DBConnection.Connection))
                {
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
            }
            else
            {
                throw new Exception("No connection");
            }
        }

        /// <summary>
        /// Fetches rows from a MySQL database with 
        /// </summary>
        /// <param name="query">SQL-query string.</param>
        /// <returns>The fetched rows as a DataTable object.</returns>
        public DataTable ExecuteFetch(string query)
        {
            if (DBConnection.OpenConnection())
            {
                using (DataTable resultDataTable = new DataTable())
                {
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
            }
            else
            {
                throw new Exception("No connection");
            }
        }

        /// <summary>
        /// Pushes a contest object to a MySQL database.
        /// </summary>
        /// <param name="contest">A contest object.</param>
        public void PushContest(Contest contest)
        {
            long contestID = PushContestInfo(contest.Info);
            PushJudgeList(contest.Judges, contestID);
            PushSubContestBranches(contest.SubContestBranches, contestID);
        }

        /// <summary>
        /// Pushes a person object to the databse.
        /// </summary>
        /// <param name="person">Person object.</param>
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

        /// <summary>
        /// Fetch a list of persons from a MySQL database.
        /// </summary>
        /// <returns>A list of the fetched person objects.</returns>
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

        /// <summary>
        /// Check if the email belongs to one person in the database.
        /// </summary>
        /// <param name="email"></param>
        public bool MailBelongsToOnePerson(string email)
        {
            string query = $"SELECT id FROM person WHERE email=\"{email}\";";

            DataTable dataTable = new DataTable();
            dataTable = ExecuteFetch(query);

            if (dataTable.Rows.Count == 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Fetch a password that belongs to the given email address.
        /// </summary>
        /// <param name="email">The email that belongs to the password.</param>
        /// <returns>The password as a string.</returns>
        public string FetchPasswordFromEmail(string email)
        {
            if (MailBelongsToOnePerson(email))
            {
                string query = "SELECT `password` FROM `password` WHERE personID = (";
                query += "SELECT id FROM person ";
                query += $"WHERE email = \"{email}\"";
                query += ");";

                DataTable dataTable = ExecuteFetch(query);

                return dataTable.Rows[0]["password"].ToString();
            }

            throw new Exception("Email does not belong to one person.");
        }

        private DataTable FetchSpecifiedRole(string roleName)
        {
            string query = "SELECT person.id, person.firstName, person.lastName, person.age, person.gender ";
            query += "FROM person ";
            query += "INNER JOIN role_person ON person.id = role_person.personID ";
            query += $"WHERE role_person.roleID = (SELECT id FROM role WHERE `name`=\"{roleName}\");";

            return ExecuteFetch(query);
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
