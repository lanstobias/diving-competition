﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Simhopp
{
    public class AddPersonPresenter
    {
        public AddPersonView View { get; set; }

        public PersonList Persons { get; set; }

        public AddPersonPresenter(AddPersonView view, PersonList model)
        {
            this.View = view;
            this.Persons = model;

            View.EventSaveAndNew += SaveAndNew;
            View.EventSaveAndClose += SaveAndClose;

        }

        public bool CheckDataInput()
        {
            bool stringsAreValid = false;
            bool emailIsValid = false;
            bool ageIsValid = false;
            bool genderIsSelected = false;
            int d;

            if (Simhopp.CheckDataInput.StringCheckFormat(View.TextBoxFirstName.Text))
            {
                if (Simhopp.CheckDataInput.StringCheckFormat(View.TextBoxLastName.Text))
                {
                    if (Simhopp.CheckDataInput.StringCheckFormat(View.TextBoxAddress.Text))
                        stringsAreValid = true;
                    else
                        MessageBox.Show("Adressen är ej giltigt.");
                }
                else
                    MessageBox.Show("Efternamnet är ej giltigt.");
            }
            else
                MessageBox.Show("Förnamnet är ej giltigt.");

            if (int.TryParse(View.TextBoxAge.Text, out d))
                ageIsValid = true;
            else
                MessageBox.Show("Åldern är ej giltigt.");

            if (Simhopp.CheckDataInput.EmailCheckFormat(View.TextBoxEmail.Text))
                emailIsValid = true;
            else
                MessageBox.Show("Emailadressen är ej giltigt.");

            if (View.ComboBoxGender.SelectedItem != null)
                genderIsSelected = true;
            else
                MessageBox.Show("Du måste välja ett kön.");

            if (stringsAreValid && emailIsValid && ageIsValid && genderIsSelected)
                return true;

            return false;
        }

        public void ClearInputs()
        {
            View.TextBoxFirstName.Clear();
            View.TextBoxLastName.Clear();
            View.TextBoxAge.Clear();
            View.TextBoxEmail.Clear();
            View.TextBoxAddress.Clear();
            View.TextBoxSSN.Clear();

            //View.ComboBoxGender.
        }

        private void SaveAndNew()
        {
            this.CheckDataInput();

            int ID = 1;

            Person p = new Judge(ID, View.TextBoxFirstName.Text, View.TextBoxLastName.Text, int.Parse(View.TextBoxAge.Text), View.TextBoxEmail.Text, View.ComboBoxGender.SelectedItem.ToString(), View.TextBoxAddress.Text);

            Persons.Add(p);

            ClearInputs();


        }

        private void SaveAndClose()
        {
            this.CheckDataInput();

            int ID = 1;

            //Person p = new Person()

            ClearInputs();
        }

    }
}