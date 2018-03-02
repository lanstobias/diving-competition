using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class Database
    {
        private DatabaseConnection DBConnection = new DatabaseConnection();

        public Database()
        {
        }

        public long ExecuteQuery(string query)
        {
            if (DBConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.Connection);
                var queryResult = command.ExecuteNonQuery();

                DBConnection.CloseConnection();

                return command.LastInsertedId;
            }
            else
            {
                throw new Exception("No connection");
            }
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
        private long PushDive(long branchID, long contestantID)
        {
            throw new NotImplementedException();
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

    }
}
