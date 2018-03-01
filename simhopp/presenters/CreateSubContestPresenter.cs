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

        #region Properties
        public Contest CurrentContest { get; set; }

        public ContestantList SubContestContestants { get; set; } = new ContestantList();

        public SubContestBranchList SubContests { get; set; } = new SubContestBranchList(); 
        #endregion
        
        public SubContestBranch SelectedSubContest { get; set; } = null;


        #region Constructor

        public CreateSubContestPresenter(CreateSubContestView view, ProjectMainWindow window, Contest contest)
        {
            this.View = view;
            this.window = window;

            CurrentContest = contest;

            this.View.LabelContestName.Text = CurrentContest.Info.Name;

            //Fyller på contestants från contest
            foreach (var contestant in contest.Contestants)
            {
                View.ListBoxContestContestants.Items.Add(contestant.GetFullName());
            }

            View.EventAddContestantToSubContest += AddContestantToSubContest;
            View.EventRemoveContestantFromSubContest += RemoveContestantFromSubContest;
            View.EventAddSubContest += AddSubContest;
            View.EventFinalizeContest += FinalizeContest;

            View.EventSubContestSelected += SubContestSelected;
            View.EventUpdateSubContest += UpdateSubContest;
            View.EventCancelEdit += CancelEditOfSubContest;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Clears the various data that the user has entered
        /// </summary>
        private void ClearInputs()
        {
            View.TextBoxName.Clear();
            View.ListBoxSubContestContestants.Items.Clear();
            View.ListBoxContestContestants.ClearSelected();
            View.ListBoxSubContests.ClearSelected();
            //SubContestContestants.Clear();
            SelectedSubContest = null;

            View.ButtonUpdateSubContest.Visible = false;
            View.ButtonCancelEdit.Visible = false;
            View.ButtonAddSubContest.Enabled = true;
        }

        private void CancelEditOfSubContest()
        {
            ClearInputs();
        }

        /// <summary>
        /// Updates a selected sub contest
        /// </summary>
        private void UpdateSubContest()
        {
            if (SelectedSubContest != null)
            {

                SelectedSubContest.Name = View.TextBoxName.Text;
                SelectedSubContest.BranchContestants.Clear();

                SelectedSubContest.BranchContestants = SubContestContestants.DeepCopy();

                View.ListBoxSubContests.Items.Clear();

                foreach (var sc in SubContests)
                    View.ListBoxSubContests.Items.Add(sc.Name);

                ClearInputs();
            }

        }

        /// <summary>
        /// Is triggered when a created subcontest is selected. Opens it up for editing
        /// </summary>
        private void SubContestSelected()
        {
            string subContestName = View.ListBoxSubContests.SelectedItem as string;

            foreach (var sc in SubContests)
            {
                if (sc.Name == subContestName)
                {
                    SelectedSubContest = sc;

                    View.TextBoxName.Text = SelectedSubContest.Name;

                    SubContestContestants.Clear();

                    View.ListBoxSubContestContestants.Items.Clear();

                    SubContestContestants = SelectedSubContest.BranchContestants.DeepCopy();

                    foreach (var c in SelectedSubContest.BranchContestants)
                    {
                        View.ListBoxSubContestContestants.Items.Add(c.GetFullName());
                    }

                    


                    // display the edit buttons and make add button unclickable
                    View.ButtonUpdateSubContest.Visible = true;
                    View.ButtonCancelEdit.Visible = true;
                    View.ButtonAddSubContest.Enabled = false;
                }
            }

            if (SelectedSubContest == null)
            {
                
            }


        }
        private void FinalizeContest()
        {
            ContestView contestView = new ContestView();
            ContestPresenter contestPresenter = new ContestPresenter(contestView, window, CurrentContest);
            window.ChangePanel(contestView, View);
        }

        private void AddSubContest()
        {
            //TODO kolla så korrekt data
            bool isDataValid = false;

            if (window.StringCheckFormat(View.TextBoxName.Text))
            {
                if (SubContestContestants.Count != 0)
                    isDataValid = true;
                else
                    MessageBox.Show("En deltävling behöver minst en deltagare.");
            }
            else
                MessageBox.Show("Tävlingsnamn ej korrekt. Får ej innehålla specialtecken, förutom _ och -");

            if (isDataValid)
            {

                List<Contestant> list = SubContestContestants.ToList();
                ContestantList contestantList = new ContestantList();
                foreach (var c in list)
                    contestantList.Add(c);

                SubContestBranch subContestBranch = new SubContestBranch(View.TextBoxName.Text, CurrentContest, contestantList);
           
                SubContests.Add(subContestBranch);
                View.ListBoxSubContests.Items.Add(subContestBranch.Name);

                CurrentContest.SubContestBranches.Add(subContestBranch);

                // clear the inputs
                SubContestContestants.Clear();
                ClearInputs();
            }
        }

        /// <summary>
        /// Remove a contestant that has been selected to participate 
        /// </summary>
        private void RemoveContestantFromSubContest()
        {
            string contestant = View.ListBoxSubContestContestants.SelectedItem as string;

            Contestant contestantToBeRemoved = null;

            foreach(var c in SubContestContestants)
            {
                if (c.GetFullName() == contestant)
                    contestantToBeRemoved = c;
            }

            SubContestContestants.Remove(contestantToBeRemoved);

            View.ListBoxSubContestContestants.Items.Remove(contestant);
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
                    View.ListBoxSubContestContestants.Items.Add(contestantToBeAdded.GetFullName());
                }


            }
        } 
        #endregion
    }
}
