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
        public string JudgeName { get; set; } = "";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            JudgeName = this.textBoxName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
