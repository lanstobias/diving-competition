using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class CreateSubContestPresenter
    {
        CreateSubContestView View { get; set; }

        private ProjectMainWindow window;

        public Contest CurrentContest { get; set; }

        public ContestantList SubContestContestants { get; set; }

        public SubContestBranchList SubContests { get; set; }

        public CreateSubContestPresenter(CreateSubContestView view, ProjectMainWindow window, Contest contest)
        {
            this.View = view;
            this.window = window;

            CurrentContest = contest;

            //Fyller på contestants från contest
            foreach(var contestant in contest.Contestants)
            {
                View.ListBoxContestContestants.Items.Add(contestant.FirstName);
            }

            View.EventAddContestantToSubContest += AddContestantToSubContest;
            View.EventRemoveContestantFromSubContest += RemoveContestantFromSubContest;
            View.EventAddSubContest += AddSubContest;
            View.EventFinalizeContest += FinalizeContest;
        }

        private void FinalizeContest()
        {
            throw new NotImplementedException();
        }

        private void AddSubContest()
        {
            //TODO kolla så korrekt data
            bool isDataValid = false;

            if(window.StringCheckFormat(View.TextBoxName.Text))
            {
                if (SubContestContestants.Count != 0)
                    isDataValid = true;
                else
                    MessageBox.Show("En deltävling behöver minst en deltagare.");
            }
            else
                MessageBox.Show("Tävlingsnamn ej korrekt. Får ej innehålla specialtecken, förutom _ och -");

            if(isDataValid)
            {
                SubContestBranch subContestBranch = new SubContestBranch(View.TextBoxName.Text, CurrentContest, SubContestContestants);
           
                SubContests.Add(subContestBranch);
                View.ListBoxSubContests.Items.Add(subContestBranch.Name);
            }
        }

        private void RemoveContestantFromSubContest()
        {
            throw new NotImplementedException();
        }

        private void AddContestantToSubContest()
        {
            throw new NotImplementedException();
        }
    }
}
