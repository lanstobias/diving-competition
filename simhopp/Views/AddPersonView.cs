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
    /// Simple form for gathering information about a Person
    /// </summary>
    public partial class AddPersonView : Form
    {
        public List<Person> PersonList { get; set; }

        public AddPersonView()
        {
            // Define the border style of the form to a dialog box (no resize).
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            PersonList = new List<Person>();

            InitializeComponent();
        }

        private void buttonSaveAndNew_Click(object sender, EventArgs e)
        {
            //Todo:
            // kolla så all data är korrekt (Program.StringFormatChecker(string)) och samla ihop det till ett nytt Person objekt.
            // lägg till i PersonList och resetta fälten för ny inmatning
            EventSaveAndNew?.Invoke();
        }

        private void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            //Todo:
            // kolla så all data är korrekt (Program.StringFormatChecker(string)) och samla ihop det till ett nytt Person objekt.
            EventSaveAndClose?.Invoke();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
