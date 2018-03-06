﻿using System;
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

        public Person FetchPerson()
        {
            throw new NotImplementedException();
        }

        public Judge StoreJudgeInJudgeList()
        {
            throw new NotImplementedException();
        }

        public Contestant StoreContestantInContestantList()
        {
            throw new NotImplementedException();
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

        private long PushDive(long branchID, long contestantID)
        {
            throw new NotImplementedException();
        }

        private void PushSubContestBranches(SubContestBranchList branches, long contestID)
        {
            // FIXA METODER AV DETTA

            long branchID, contestantID, diveID;

            foreach (var branch in branches)
            {
                branchID = PushSubContestBranch(branch);

                foreach (var contestant in branch.BranchContestants)
                {
                    contestantID = PushContestant(contestant, branchID, contestID);

                    foreach (var diveList in contestant.DiveLists)
                    {
                        foreach (var dive in diveList)
                        {
                            diveID = PushDive(branchID, contestantID);

                            foreach (var score in dive.Scores)
                            {
                                PushScore(score, diveID);
                            }
                        }
                    }
                }
            }
        }

        private void PushScore(Score score, long diveID)
        {
            throw new NotImplementedException();
        }

        private long PushSubContestBranch(SubContestBranch branch)
        {
            throw new NotImplementedException();
        }

        private void PushJudgeList()
        {
            throw new NotImplementedException();
        }

        private long PushContestant(Contestant contestant, long branchID, long contestId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
