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

        public TCPServer Server { get; set; }

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

            View.EventSubContestSelection += UpdateContestantListView;
            View.EventContestantSelection += UpdateDivesListView;
            View.EventDiveSelection += EnableModifyDive;
            View.EventModifyDive += ModifyDive;
            View.EventRemoveDive += RemoveDive;
            View.EventCancelDiveEdit += CancelModifyDive;
            View.EventRequestPoints += RequestPointsFromJudges;

            Initialize();

            Server = new TCPServer();
            Server.TieToContest(this);
        }
        

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
            View.ButtonRequestPoints.Enabled = true;
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
                    UpdateDivesListView();
                }
            }

        }

        internal void AddToPointList(string client, string point)
        {
            bool AllPointsCollected = true;

            if(View.ListViewJudgeClients.Items.Count == CurrentContest.Judges.Count)
            {
                ScoreList scoreList = new ScoreList();
                foreach (ListViewItem clientItem in View.ListViewJudgeClients.Items)
                {
                    if(clientItem.SubItems[1].ForeColor != System.Drawing.Color.Green)
                    {
                        // någon av poängerna har inte kommit in
                        AllPointsCollected = false;
                    }
                    else
                    {
                        // Fixa: ta in rätt judge här
                        foreach(var judge in CurrentContest.Judges)
                        {
                            if(judge.GetFullName() == client)
                                scoreList.Add(new Score(Convert.ToDouble(clientItem.SubItems[1].Text), judge));
                        }
                        
                    }
                }

                if (AllPointsCollected)
                {
                    GetSelectedDive().Scores = scoreList;
                }
            }

            foreach (ListViewItem clientItem in View.ListViewJudgeClients.Items)
            {
                if (clientItem.Text == client)
                {
                    clientItem.SubItems[1].Text = point;
                    clientItem.SubItems[1].ForeColor = System.Drawing.Color.Green;
                }
            }

            
        }

        private void RemoveDive()
        {
            GetSelectedSubContest().RemoveExistingDive(GetSelectedContestant(), GetSelectedDive());
            UpdateDivesListView();
        }

        private void CancelModifyDive()
        {
            View.ListViewDives.SelectedItems.Clear();
            View.ButtonCancelModify.Visible = false;
            View.ButtonModifyDive.Visible = false;
            View.ButtonRemoveDive.Visible = false;
        }

        /// <summary>
        /// Is called when the selection is change in the combobox with subcontests
        /// </summary>
        private void UpdateContestantListView()
        {
            SubContestBranch selectedSubContest = GetSelectedSubContest();

            if(selectedSubContest != null)
            {
                // Clear the listviews

                View.ListViewContestants.Items.Clear();
                View.ListViewDives.Items.Clear();

                foreach(var c in selectedSubContest.BranchContestants)
                {
                    ListViewItem contestantItem = new ListViewItem(c.FirstName);
                    contestantItem.SubItems.Add(c.LastName);

                    View.ListViewContestants.Items.Add(contestantItem);

                }
            }
        }

        internal void AddToClientList(HandleClient client)
        {
            ListViewItem clientItem = new ListViewItem(client.ClientName);
            clientItem.SubItems.Add(client.Points.ToString());

            View.ListViewJudgeClients.Items.Add(clientItem);
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
                    UpdateDivesListView();
                }
            }
        }

        /// <summary>
        /// Fills up ListViewDives with the dives tied to a contestant
        /// </summary>
        /// <param name="contestant">The contestant with the dives to be presented</param>
        public void UpdateDivesListView()
        {
            Contestant contestant = GetSelectedContestant();

            if(contestant != null)
            {
                //View.ListBoxDives.Items.Clear();
                View.ListViewDives.Items.Clear();
                foreach (var divelist in contestant.DiveLists)
                {
                    if(divelist.SubContestBranch == GetSelectedSubContest())
                    {
                        foreach(var dive in divelist)
                        {
                            //View.ListBoxDives.Items.Add("Kod: " + dive.Code.Code + " - Multiplier: " + dive.Code.Multiplier);
                            ListViewItem DiveItems = new ListViewItem(dive.Code.Code);
                            DiveItems.SubItems.Add(dive.Code.Multiplier.ToString());

                            View.ListViewDives.Items.Add(DiveItems);
                        }
                        
                    }
                }
            }
        }

        private Contestant GetSelectedContestant()
        {
            try
            {
                if (View.ListViewContestants.SelectedItems.Count == 1)
                {
                    //var selectedContestantName = View.ListBoxContestants.SelectedItem as string;
                    var selectedContestantFirstName = View.ListViewContestants.SelectedItems[0].SubItems[0].Text;
                    var selectedContestantLastName = View.ListViewContestants.SelectedItems[0].SubItems[1].Text;

                    foreach (var contestant in GetSelectedSubContest().BranchContestants)
                    {
                        if (String.Equals(contestant.FirstName, selectedContestantFirstName) && String.Equals(contestant.LastName, selectedContestantLastName))
                            return contestant;
                    }
                }

            }

            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Välj en deltagare!");
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
