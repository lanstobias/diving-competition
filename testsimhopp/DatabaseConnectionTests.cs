using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Simhopp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp.Tests
{
    [TestClass()]
    public class DatabaseConnectionTests
    {
        private MySqlConnection connection;

        [TestMethod()]
        public void TestDatabaseConnection()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "tomat.trickip.net";
            connectionString.UserID = "root";
            connectionString.Password = "gallian0";
            connectionString.Database = "simhopp";

            connection = new MySqlConnection(connectionString.ToString());

            // If a connection can not open, an exception will be thrown
            // and the test will fail.
            connection.Open();
        }
    }
}