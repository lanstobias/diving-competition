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
        public bool Offline { get; set; } = false;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void RadioButtonOnline_Click(object sender, EventArgs e)
        {
            radioButtonOnline.Checked = true;
            radioButtonLAN.Checked = false;
            radioButtonOffline.Checked = false;
            labelPort.Visible = true;
            textBoxPort.Visible = true;

        }

        private void RadioButtonLAN_Click(object sender, EventArgs e)
        {
            radioButtonOnline.Checked = false;
            radioButtonLAN.Checked = true;
            radioButtonOffline.Checked = false;
            labelPort.Visible = false;
            textBoxPort.Visible = false;

        }
        private void radioButtonOffline_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonOnline.Checked = false;
            radioButtonLAN.Checked = false;
            radioButtonOffline.Checked = true;
            labelPort.Visible = false;
            textBoxPort.Visible = false;
            Offline = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            LAN = radioButtonLAN.Checked;
            
            if(!String.IsNullOrEmpty(textBoxPort.Text))
            {
                Port = Convert.ToInt32(textBoxPort.Text);
            }

            this.Hide();
        }

    }
}
