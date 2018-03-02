using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    class ContestPresenter
    {
        #region Properties
        public ContestView View { get; set; }

        private ProjectMainWindow window;

        public Contest CurrentContest { get; set; }

        #endregion

        #region Constructor
        public ContestPresenter(ContestView view, ProjectMainWindow window, Contest contest)
        {
            this.View = view;
            this.window = window;
            CurrentContest = contest;
            View.EventAddJump += AddDive;
            View.EventSubContestSelection += DiplaySubContest;
            View.EventPauseContest += PauseContest;
            View.EventCloseContest += CloseContest;

            View.EventSubContestSelection += UpdateContestantListBox;
            View.EventContestantSelection += UpdateDivesListBox;

            Initialize();
        }



        #endregion

        #region Functions
        private void Initialize()
        {
            foreach(var sc in CurrentContest.SubContestBranches)
            {
                View.ComboBoxSubContests.Items.Add(sc.Name);
            }

            View.LabelContestName.Text = CurrentContest.Info.Name;
            View.LabelCity.Text = CurrentContest.Info.City;
            View.LabelArena.Text = CurrentContest.Info.Arena;
            View.LabelStartDate.Text = CurrentContest.Info.StartDate.ToShortDateString();
            View.LabelEndDate.Text = CurrentContest.Info.EndDate.ToShortDateString();


        }

        private void UpdateContestantListBox()
        {
            SubContestBranch selectedSubContest = GetSelectedSubContest();

            if(selectedSubContest != null)
            {
                View.ListBoxContestants.Items.Clear();
                foreach(var c in selectedSubContest.BranchContestants)
                {
                    View.ListBoxContestants.Items.Add(c.GetFullName());
                }
            }
        }

        /// <summary>
        /// Opens up a AddDiveView form and waits for the result
        /// </summary>
        private void AddDive()
        {
            SubContestBranch subContestBranch = GetSelectedSubContest();
            Contestant contestant = GetSelectedContestant();
            
            AddDiveView addDiveView = new AddDiveView();
            AddDivePresenter addDivePresenter = new AddDivePresenter(addDiveView, window, subContestBranch, contestant);

            if(subContestBranch != null && contestant != null)
            {
                if (addDiveView.ShowDialog() == DialogResult.OK)
                {
                    UpdateDivesListBox();
                }
            }
        }

        /// <summary>
        /// Fills up ListBoxDives with the dives tied to a contestant
        /// </summary>
        /// <param name="contestant">The contestant with the dives to be presented</param>
        public void UpdateDivesListBox()
        {
            Contestant contestant = GetSelectedContestant();

            if(contestant != null)
            {
                foreach(var divelist in contestant.DiveLists)
                {
                    if(divelist.SubContestBranch == GetSelectedSubContest())
                    {
                        View.ListBoxDives.Items.Clear();
                        foreach(var dive in divelist)
                        {
                            View.ListBoxDives.Items.Add("Kod: " + dive.Code.Code + " - Multiplier: " + dive.Code.Multiplier);
                        }
                        
                    }
                }
            }
        }

        private Contestant GetSelectedContestant()
        {
            var selectedContestantName = View.ListBoxContestants.SelectedItem as string;

            foreach(var contestant in GetSelectedSubContest().BranchContestants)
            {
                if (contestant.GetFullName() == selectedContestantName)
                    return contestant;
            }

            return null;
        }

        private SubContestBranch GetSelectedSubContest()
        {
            var selectedSubContestName = View.ComboBoxSubContests.SelectedItem as string;

            foreach (var subContest in CurrentContest.SubContestBranches)
            {
                if (selectedSubContestName == subContest.Name)
                    return subContest;
            }
            return null;
        }

        private void PauseContest()
        {
            throw new NotImplementedException();
        }

        private void CloseContest()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
