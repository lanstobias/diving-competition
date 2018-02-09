using System;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    class DatabaseConnection
    {
        #region Fields
        private MySqlConnection connection;

        private string server;
        private string database;
        private string userID;
        private string password;
        #endregion

        #region Constructor
        public DatabaseConnection()
        {
            server = "localhost";
            database = "connectcsharptomysql";
            userID = "username";
            password = "gallian0";

            InitializeConnection();
        }
        #endregion

    }
}
