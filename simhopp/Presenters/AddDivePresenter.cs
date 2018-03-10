using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class AddDivePresenter
    {
        public AddDiveView View { get; set; }

        private ProjectMainWindow window;

        public SubContestBranch SubContest { get; set; }

        public Contestant CurrentContestant { get; set; }


        public AddDivePresenter(AddDiveView view, ProjectMainWindow window, SubContestBranch subContest, Contestant contestant, Dive dive = null)
        {
            this.View = view;
            this.window = window;
            this.SubContest = subContest;
            CurrentContestant = contestant;

            if(dive != null)
            {
                View.TextBoxDiveCode.Text = dive.Code.Code;
                View.TextBoxDiveMultiplier.Text = dive.Code.Multiplier.ToString();
            }

            View.EventAddDive += AddDiveToContestant;
        }


        public void AddDiveToContestant()
        {
            if(ValidateData())
            {
                double multiplier = double.Parse(View.TextBoxDiveMultiplier.Text,CultureInfo.InvariantCulture);
                string code = View.TextBoxDiveCode.Text;

                Dive diveTobeAdded = new Dive(new DiveCode(multiplier, code));

                SubContest.AddNewDive(CurrentContestant, diveTobeAdded);

                View.DialogResult = System.Windows.Forms.DialogResult.OK;
                View.Close();
            }
        }

        private bool ValidateData()
        {
            bool isCodeValid = CheckDataInput.StringCheckFormat(View.TextBoxDiveCode.Text);

            double multiplier = 0;
            bool isMultiplierValid = double.TryParse(View.TextBoxDiveMultiplier.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out multiplier);


            if (!isCodeValid)
                View.TextBoxDiveCode.BackColor = System.Drawing.Color.Red;
            if (!isMultiplierValid)
                View.TextBoxDiveMultiplier.BackColor = System.Drawing.Color.Red;

            return isCodeValid && isMultiplierValid;
        }
    }
}
