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
    public partial class DatePicker : Form
    {
        public DateTime SelectedDate { get; set; }

        public bool IsDateSet { get; set; }

        public DatePicker()
        {
            InitializeComponent();
            SelectedDate = new DateTime();

            IsDateSet = false;
        }

        private void buttonSelectDate_Click(object sender, EventArgs e)
        {
            SelectedDate = calender.SelectionStart;

            IsDateSet = true;

            this.Close();
        }

        
    }
}
