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
        
        public DatePicker()
        {
            InitializeComponent();
            SelectedDate = new DateTime();
        }

        private void buttonSelectDate_Click(object sender, EventArgs e)
        {
            SelectedDate = calender.SelectionStart;
        }

        
    }
}
