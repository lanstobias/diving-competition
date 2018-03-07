using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class ContestPresenter
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
            View.EventPauseContest += PauseContest;
            View.EventCloseContest += CloseContest;

            View.EventSubContestSelection += UpdateContestantListBox;
            View.EventContestantSelection += UpdateDivesListBox;
            View.EventDiveSelection += EnableModifyDive;
            View.EventModifyDive += ModifyDive;
            View.EventRemoveDive += RemoveDive;
            View.EventCancelDiveEdit += CancelModifyDive;

            Initialize();
        }



        #endregion

        #region Functions
        private void Initialize()
        {
            foreach (var sc in CurrentContest.SubContestBranches)
            {
                View.ComboBoxSubContests.Items.Add(sc.Name);
            }

            View.LabelContestName.Text = CurrentContest.Info.Name;
            View.LabelCity.Text = CurrentContest.Info.City;
            View.LabelArena.Text = CurrentContest.Info.Arena;
            View.LabelStartDate.Text = CurrentContest.Info.StartDate.ToShortDateString();
            View.LabelEndDate.Text = CurrentContest.Info.EndDate.ToShortDateString();

        }

        private void RequestPointsFromJudges()
        {
            Server.RequestPoints();
        }

        private void EnableModifyDive()
        {
            View.ButtonCancelModify.Visible = true;
            View.ButtonModifyDive.Visible = true;
            View.ButtonRemoveDive.Visible = true;
        }

        private void ModifyDive()
        {
            SubContestBranch subContestBranch = GetSelectedSubContest();
            Contestant contestant = GetSelectedContestant();
            Dive dive = GetSelectedDive();
            AddDiveView modifyView = new AddDiveView();
            AddDivePresenter presenter = new AddDivePresenter(modifyView, window, subContestBranch, contestant, dive);

            if (subContestBranch != null && contestant != null && dive != null)
            {
                if (modifyView.ShowDialog() == DialogResult.OK)
                {
                    subContestBranch.RemoveExistingDive(contestant, dive);
                    UpdateDivesListBox();
                }
            }

        }

        private void RemoveDive()
        {
            GetSelectedSubContest().RemoveExistingDive(GetSelectedContestant(), GetSelectedDive());
            UpdateDivesListBox();
        }

        private void CancelModifyDive()
        {
            View.ListBoxDives.ClearSelected();
            View.ButtonCancelModify.Visible = false;
            View.ButtonModifyDive.Visible = false;
            View.ButtonRemoveDive.Visible = false;
        }

        /// <summary>
        /// Is called when the selection is change in the combobox with subcontests
        /// </summary>
        private void UpdateContestantListBox()
        {
            SubContestBranch selectedSubContest = GetSelectedSubContest();

            if(selectedSubContest != null)
            {
                // Clear the listboxes
                View.ListBoxContestants.Items.Clear();
                View.ListBoxDives.Items.Clear();

                foreach(var c in selectedSubContest.BranchContestants)
                {
                    //ListViewItem contestantItem = new ListViewItem(c.FirstName);
                    //contestantItem.SubItems.Add(c.LastName);
                    //contestantItem.SubItems.Add(c.Age.ToString());

                    //View.ListViewContestants.Items.Add(contestantItem);

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
                View.ListBoxDives.Items.Clear();
                foreach (var divelist in contestant.DiveLists)
                {
                    if(divelist.SubContestBranch == GetSelectedSubContest())
                    {
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

        private Dive GetSelectedDive()
        {
            var selectedDiveIndex = View.ComboBoxSubContests.SelectedIndex;

            int i = 0;
            foreach(var diveList in GetSelectedContestant().DiveLists)
            {
                if (diveList.SubContestBranch == GetSelectedSubContest())
                {
                    foreach (var dive in diveList)
                    {
                        if (i++ == selectedDiveIndex)
                            return dive;
                    }

                }
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
