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
        public string Role { get; set; }

        public AddPersonView(string role)
        {
            // Define the border style of the form to a dialog box (no resize).
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            PersonList = new List<Person>();

            this.Role = role;

            InitializeComponent();
        }
        public TextBox TextBoxFirstName { get { return textBoxFirstName; } }
        public TextBox TextBoxLastName { get { return textBoxLastName; } }
        public TextBox TextBoxAge { get { return textBoxAge; } }
        public TextBox TextBoxEmail { get { return textBoxEmail; } }
        public ComboBox ComboBoxGender { get { return comboBoxGender; } }
        public TextBox TextBoxSSN { get { return textBoxSSN; } }
        public TextBox TextBoxAddress { get { return textBoxAddress; } }

        public bool CheckDataInput()
        {
            bool stringsAreValid = false;
            bool emailIsValid = false;
            bool ageIsValid = false;
            bool genderIsSelected = false;
            bool SSNIsValid = false;
            int d;

            if (Simhopp.CheckDataInput.StringCheckFormat(TextBoxFirstName.Text))
            {
                if (Simhopp.CheckDataInput.StringCheckFormat(TextBoxLastName.Text))
                {
                    if (Simhopp.CheckDataInput.StringCheckFormat(TextBoxAddress.Text))
                        stringsAreValid = true;
                    else
                        MessageBox.Show("Adressen är ej giltigt.");
                }
                else
                    MessageBox.Show("Efternamnet är ej giltigt.");
            }
            else
                MessageBox.Show("Förnamnet är ej giltigt.");

            if (int.TryParse(TextBoxAge.Text, out d))
                ageIsValid = true;
            else
                MessageBox.Show("Åldern är ej giltigt.");

            if (Simhopp.CheckDataInput.EmailCheckFormat(TextBoxEmail.Text))
                emailIsValid = true;
            else
                MessageBox.Show("Emailadressen är ej giltigt.");

            if (ComboBoxGender.SelectedItem != null)
                genderIsSelected = true;
            else
                MessageBox.Show("Du måste välja ett kön.");

            if (Simhopp.CheckDataInput.SSNCheckFormat(TextBoxSSN.Text))
                SSNIsValid = true;
            else
                MessageBox.Show("Personnumret är ej giltigt.");

            if (stringsAreValid && emailIsValid && ageIsValid && genderIsSelected && SSNIsValid)
                return true;

            return false;
        }
        
        public void CreatePerson()
        {
            
            if (CheckDataInput() == true)
            {
                int ID = 1;
                Person p = null;

                if (Role == "judge")
                {
                    p = new Judge(ID, TextBoxFirstName.Text, TextBoxLastName.Text, int.Parse(TextBoxAge.Text), TextBoxEmail.Text, ComboBoxGender.SelectedItem.ToString(),TextBoxSSN.Text, TextBoxAddress.Text);

                }
                else
                {
                    p = new Contestant(ID, TextBoxFirstName.Text, TextBoxLastName.Text, int.Parse(TextBoxAge.Text), TextBoxEmail.Text, ComboBoxGender.SelectedItem.ToString(), TextBoxSSN.Text, TextBoxAddress.Text);
                }

                PersonList.Add(p);

                ClearInputs();

                MessageBox.Show("En ny person har skapats!");
            }
        }

        public void ClearInputs()
        {
            TextBoxFirstName.Clear();
            TextBoxLastName.Clear();
            TextBoxAge.Clear();
            TextBoxEmail.Clear();
            TextBoxAddress.Clear();
            TextBoxSSN.Clear();

            ComboBoxGender.SelectedIndex = -1;
        }

        private void buttonSaveAndNew_Click(object sender, EventArgs e)
        {
            //Todo:
            // kolla så all data är korrekt (Program.StringFormatChecker(string)) och samla ihop det till ett nytt Person objekt.
            // lägg till i PersonList och resetta fälten för ny inmatning
            CreatePerson();
        }

        private void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            //Todo:
            // kolla så all data är korrekt (Program.StringFormatChecker(string)) och samla ihop det till ett nytt Person objekt.

            CreatePerson();

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
