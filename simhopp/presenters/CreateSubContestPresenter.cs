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

        public ContestantList SubContestContestants { get; set; } = new ContestantList();

        public SubContestBranchList SubContests { get; set; } = new SubContestBranchList();

        public CreateSubContestPresenter(CreateSubContestView view, ProjectMainWindow window, Contest contest)
        {
            this.View = view;
            this.window = window;

            CurrentContest = contest;

            //Fyller på contestants från contest
            foreach(var contestant in contest.Contestants)
            {
                View.ListBoxContestContestants.Items.Add(contestant.FirstName);
                SubContestContestants.Add(contestant);
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
            SubContestBranch subContestBranch = new SubContestBranch(View.TextBoxName.Text, CurrentContest, SubContestContestants);

            //Uppdatera SubContestListBox

            View.ListBoxSubContests.Items.Add(subContestBranch.Name);

        }

        private void RemoveContestantFromSubContest()
        {
            throw new NotImplementedException();
        }

        private void AddContestantToSubContest()
        {
            var contestant = View.ListBoxContestContestants.SelectedItem;
            bool isAdded = false;

            foreach (var c in SubContestContestants)
            {
                if (c.GetFullName() == (string)contestant)
                {
                    isAdded = true;
                    MessageBox.Show("Deltagare är redan tillagd!");
                    break;
                }
            }

            Contestant contestantToBeAdded = null;

            if (!isAdded)
            {
                foreach (var c in CurrentContest.Contestants)
                {

                    if (c.GetFullName() == (string)contestant)
                    {
                        contestantToBeAdded = c;
                    }
                }

                if (contestantToBeAdded != null)
                {
                    SubContestContestants.Add(contestantToBeAdded);
                    View.ListBoxContestContestants.Items.Add(contestantToBeAdded.GetFullName());
                }
       

            }
        }
    }
}
