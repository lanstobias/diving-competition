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

    public partial class InputDialog : Form
    {
        public InputDialog()
        {
            InitializeComponent();
        }

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
