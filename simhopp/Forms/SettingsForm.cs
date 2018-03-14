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
    public partial class SettingsForm : Form
    {
        public bool LAN { get; set; } = true;

        public int Port { get; set; } = 9058;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void radioButtonOnline_Click(object sender, EventArgs e)
        {
            radioButtonLAN.Checked = false;
            radioButtonOnline.Checked = true;
            labelPort.Visible = true;
            textBoxPort.Visible = true;

        }

        private void radioButtonLAN_Click(object sender, EventArgs e)
        {
            radioButtonOnline.Checked = false;
            radioButtonLAN.Checked = true;
            labelPort.Visible = false;
            textBoxPort.Visible = false;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            LAN = radioButtonLAN.Checked;
            
            if(!String.IsNullOrEmpty(textBoxPort.Text))
            {
                Port = Convert.ToInt32(textBoxPort.Text);
            }

            this.Close();
        }
    }
}
