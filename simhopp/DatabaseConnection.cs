using System;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Simhopp
{
    public class DatabaseConnection
    {
        #region Fields
        public MySqlConnection Connection { get; private set; }

        private string server;
        private string database;
        private string userID;
        private string password;
        #endregion

        #region Constructor
        public DatabaseConnection()
        {
            server = "tomat.trickip.net";
            database = "simhopp";
            userID = "root";
            password = "gallian0";

            InitializeConnection();
        }
        #endregion

        /// <summary>
        /// Initialize connection to database.
        /// </summary>
        private void InitializeConnection()
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = server;
            connectionString.UserID = userID;
            connectionString.Password = password;
            connectionString.Database = database;

            connection = new MySqlConnection(connectionString.ToString());
        }

        /// <summary>
        /// Open a connection to the databas.
        /// </summary>
        /// <returns></returns>
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                // Error codes:
                // 0: Cannot connect to server.
                // 1045: Invalid user name and/or password.
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.");
                        break;

                    case 1045:
                        MessageBox.Show("Wrong username or password.");
                        break;
                }
                return false;
            }
        }

        /// <summary>
        /// Close an opened connection to the database.
        /// </summary>
        /// <returns></returns>
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
