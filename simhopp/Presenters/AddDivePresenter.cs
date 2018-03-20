using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    /// <summary>
    /// Presenter part of AddDive. Lets the user add a new dive to a contestant
    /// </summary>
    public class AddDivePresenter
    {
        #region Properties
        public AddDiveView View { get; set; }

        private ProjectMainWindow window;

        public SubContestBranch SubContest { get; set; }

        public Contestant CurrentContestant { get; set; }

        #endregion

        #region Constructor

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

        #endregion

        #region Methods

        /// <summary>
        /// Add a dive to the contestant. Validates the input data before adding it.
        /// </summary>
        public void AddDiveToContestant()
        {
            if(ValidateData())
            {
                double multiplier = double.Parse(View.TextBoxDiveMultiplier.Text, CultureInfo.InvariantCulture);

                string code = View.TextBoxDiveCode.Text;

                Dive diveTobeAdded = new Dive(new DiveCode(multiplier, code));

                SubContest.AddNewDive(CurrentContestant, diveTobeAdded);

                View.DialogResult = System.Windows.Forms.DialogResult.OK;

                View.Close();
            }
        }

        /// <summary>
        /// Validates the input data about the new dive
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            bool isCodeValid = CheckDataInput.StringCheckFormat(View.TextBoxDiveCode.Text);

            bool isMultiplierValid = double.TryParse(View.TextBoxDiveMultiplier.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double multiplier);


            if (!isCodeValid)
                View.TextBoxDiveCode.BackColor = System.Drawing.Color.Red;
            if (!isMultiplierValid)
                View.TextBoxDiveMultiplier.BackColor = System.Drawing.Color.Red;

            return isCodeValid && isMultiplierValid;
        }

        #endregion
    }
}
