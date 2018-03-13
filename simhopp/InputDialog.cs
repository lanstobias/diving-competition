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
    /// <summary>
    /// Simple formdialog to handle string input from the user.
    /// Since OpenDialog methods are static, usage is very simple.
    /// Example usage:
    /// string input = InputDialog.OpenDialog("Enter your name");
    /// </summary>
    public partial class InputDialog : Form
    {
        public InputDialog()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Open a dialog without a message
        /// </summary>
        /// <returns>A string with the users input</returns>
        public static string OpenDialog()
        {
            var inputDialog = new InputDialog();

            inputDialog.Show();

            inputDialog.ShowDialog();

            if (inputDialog.DialogResult == DialogResult.OK)
                return inputDialog.textBoxInput.Text;

            else if (inputDialog.DialogResult == DialogResult.Cancel)
                inputDialog.Close();

            return "";
        }

        /// <summary>
        /// Open a dialog with a message
        /// </summary>
        /// <param name="message">Message for user</param>
        /// <returns>A string with the users input</returns>
        public static string OpenDialog(string message)
        {
            using (var inputDialog = new InputDialog())
            {
                inputDialog.labelMsg.Text = message;

                inputDialog.ShowDialog();

                if (inputDialog.DialogResult == DialogResult.OK)
                    return inputDialog.textBoxInput.Text;
                
                else if (inputDialog.DialogResult == DialogResult.Cancel)
                    inputDialog.Close();

                return "";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
