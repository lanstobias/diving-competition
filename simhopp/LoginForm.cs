using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public partial class LoginForm : Form
    {
        public string Email { get; set; } = "";

        public Judge Judge { get; set; }
        
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        /// <summary>
        /// Try to login
        /// </summary>
        private void Login()
        {
            if (CheckDataInput.EmailCheckFormat(this.tbUserName.Text))
            {
                if (TryCredentials())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    if (MessageBox.Show("Inlogg misslyckades, vill du försöka igen?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                }
            }
            else
            {
                tbUserName.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Checks the given email and password against the database
        /// </summary>
        /// <returns>true if login is succesful</returns>
        private bool TryCredentials()
        {
            tbUserName.BackColor = Color.White;

            Email = tbUserName.Text;

            Auth auth = new Auth();
            Database db = new Database();

            if (db.MailBelongsToOnePerson(Email))
            {
                string hashedPass = Helpers.SHA1Hash(tbPassword.Text);

                string password = db.FetchPasswordFromEmail(Email);

                if (auth.PasswordsMatch(hashedPass, password))
                {
                    foreach(var j in db.FetchJudges())
                    {
                        if (j.Email == Email)
                        {
                            Judge = j;
                            break;
                        }
                    }
                    return true;
                }
                else
                    tbPassword.BackColor = Color.Red;
                        
            }
            else
            {
                tbUserName.BackColor = Color.Red;
                Email = "";
            }

            return false;
        }

        private void TbUserName_Click(object sender, EventArgs e)
        {
            tbUserName.BackColor = Color.White;
        }

        private void TbPassword_Click(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.White;
        }
    }
}
