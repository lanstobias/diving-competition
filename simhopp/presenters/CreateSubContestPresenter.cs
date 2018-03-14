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

            SubContests = CurrentContest.SubContestBranches;

            this.View.LabelContestName.Text = CurrentContest.Info.Name;

            //Fyller på contestants från contest
            foreach (var contestant in contest.Contestants)
            {
                ListViewItem listViewContestContestantsItem = new ListViewItem(contestant.FirstName);
                listViewContestContestantsItem.SubItems.Add(contestant.LastName);

                View.ListViewContestContestants.Items.Add(listViewContestContestantsItem);

            }

            View.EventAddContestantToSubContest += AddContestantToSubContest;
            View.EventRemoveContestantFromSubContest += RemoveContestantFromSubContest;
            View.EventAddSubContest += AddSubContest;
            View.EventFinalizeContest += FinalizeContest;

            View.EventSubContestSelected += SubContestSelected;
            View.EventUpdateSubContest += UpdateSubContest;
            View.EventCancelEdit += CancelEditOfSubContest;
            View.EventRemoveSubContest += RemoveSubContest;


            // temp 
            //FillWithData();
        }



        #endregion

        #region Methods

        /// <summary>
        /// Temporär metod som lägger till en färdig deltävling
        /// </summary>
        private void FillWithData()
        {
            SubContestBranch testSubContest = new SubContestBranch("Deltävling1", CurrentContest, CurrentContest.Contestants);

            SubContests.Add(testSubContest);
            //View.ListBoxSubContests.Items.Add(testSubContest.Name);

            View.ListViewSubContests.Items.Add(testSubContest.Name);

            // clear the inputs
            SubContestContestants.Clear();
            ClearInputs();

        }

        /// <summary>
        /// Clears the various data that the user has entered
        /// </summary>
        private void ClearInputs()
        {
            View.TextBoxName.Clear();
            View.ListViewSubContestContestants.Items.Clear();
            View.ListViewContestContestants.SelectedItems.Clear();
            View.ListViewSubContests.SelectedItems.Clear();


            SubContestContestants.Clear();


            SelectedSubContest = null;

            ToggleButtons(false);
        }

        private void CancelEditOfSubContest()
        {
            SubContestContestants.Clear();
            ClearInputs();
        }

        /// <summary>
        /// Toggles various buttons on/off
        /// </summary>
        private void ToggleButtons(bool toggle)
        {
            View.ButtonUpdateSubContest.Visible = toggle;
            View.ButtonCancelEdit.Visible = toggle;
            View.ButtonRemoveSubContest.Visible = toggle;
            View.ButtonAddSubContest.Enabled = !toggle;
        }

        /// <summary>
        /// Removes a selected subcontest
        /// </summary>
        private void RemoveSubContest()
        {
            if (SelectedSubContest != null)
            {
                SubContests.Remove(SelectedSubContest);

                View.ListViewSubContests.Items.Remove(View.ListViewSubContests.SelectedItems[0]);
            }

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


                SubContestContestants.Clear();
                View.ListViewSubContests.Items.Clear();

                foreach (var sc in SubContests)
                {
                    ListViewItem listViewSubContestsItems = new ListViewItem(sc.Name);

                    View.ListViewSubContests.Items.Add(listViewSubContestsItems);
                }

                ClearInputs();
            }

        }

        /// <summary>
        /// Is triggered when a created subcontest is selected. Opens it up for editing
        /// </summary> 
        // FIXA DETTA
        private void SubContestSelected()
        {

            if (View.ListViewSubContests.SelectedItems.Count == 1)
            {
                var subContestName = View.ListViewSubContests.SelectedItems[0].Text;
                foreach (var sc in SubContests)
                {
                    if (sc.Name == subContestName)
                    {
                        SelectedSubContest = sc;

                        View.TextBoxName.Text = SelectedSubContest.Name;

                        SubContestContestants.Clear();

                        View.ListViewSubContestContestants.Items.Clear();

                        SubContestContestants = SelectedSubContest.BranchContestants.DeepCopy();

                        foreach (var c in SelectedSubContest.BranchContestants)
                        {
                       
                            ListViewItem listViewSubContestContestantsItems = new ListViewItem(c.FirstName);
                            listViewSubContestContestantsItems.SubItems.Add(c.LastName);

                            View.ListViewSubContestContestants.Items.Add(listViewSubContestContestantsItems);
                        }
                        
                        // open up the edit buttons.
                        ToggleButtons(true);
                    }
                }

                if (SelectedSubContest == null)
                {

                }

            }

        }

        /// <summary>
        /// Move on to the ContestView
        /// </summary>
        private void FinalizeContest()
        {
            ContestView contestView = new ContestView();
            ContestPresenter contestPresenter = new ContestPresenter(contestView, window, CurrentContest);
            window.ChangePanel(contestView, View);
        }

        /// <summary>
        /// Add a new subcontest to the contest
        /// </summary>
        private void AddSubContest()
        {
            bool isDataValid = false;

            if (CheckDataInput.StringCheckFormat(View.TextBoxName.Text))
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
                // Make a copy of the gathered SubContestants
                List<Contestant> list = SubContestContestants.ToList();
                ContestantList contestantList = new ContestantList();
                foreach (var c in list)
                    contestantList.Add(c);

                // Create the subcontest
                SubContestBranch subContestBranch = new SubContestBranch(View.TextBoxName.Text, CurrentContest, contestantList);
           
                SubContests.Add(subContestBranch);
                View.ListViewSubContests.Items.Add(subContestBranch.Name);

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
            try
            {
                var contestantFirstName = View.ListViewSubContestContestants.SelectedItems[0].SubItems[0].Text;
                var contestantLastName = View.ListViewSubContestContestants.SelectedItems[0].SubItems[1].Text;

                Contestant contestantToBeRemoved = null;

                foreach (var c in SubContestContestants)
                {
                    if (String.Equals(c.FirstName, contestantFirstName) && String.Equals(c.LastName, contestantLastName))
                    {
                        contestantToBeRemoved = c;
                    }
                }


                SubContestContestants.Remove(contestantToBeRemoved);

                View.ListViewSubContestContestants.Items.Remove(View.ListViewSubContestContestants.SelectedItems[0]);

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Välj en deltagare!");
            }
        }

        /// <summary>
        /// Add a contestant to the new SubContest that is being created
        /// </summary>
        private void AddContestantToSubContest()
        {
            try
            {
                var contestantFirstName = View.ListViewContestContestants.SelectedItems[0].SubItems[0].Text;
                var contestantLastName = View.ListViewContestContestants.SelectedItems[0].SubItems[1].Text;

                bool isAdded = false;

                foreach (var c in SubContestContestants)
                {
                    if (String.Equals(c.FirstName, contestantFirstName) && String.Equals(c.LastName, contestantLastName))
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
                        if (String.Equals(c.FirstName, contestantFirstName) && String.Equals(c.LastName, contestantLastName))
                        {
                            contestantToBeAdded = c;
                        }
                    }

                    if (contestantToBeAdded != null)
                    {
                        SubContestContestants.Add(contestantToBeAdded);

                        ListViewItem listViewSubContestContestantsItem = new ListViewItem(contestantToBeAdded.FirstName);
                        listViewSubContestContestantsItem.SubItems.Add(contestantToBeAdded.LastName);

                        View.ListViewSubContestContestants.Items.Add(listViewSubContestContestantsItem);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Välj en deltagare!");
            }
            }
            
        } 
        #endregion
    }
