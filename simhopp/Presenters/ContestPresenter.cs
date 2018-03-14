using System;
using System.Collections.Generic;
using System.Globalization;
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

        public ProjectMainWindow window;

        public Contest CurrentContest { get; set; }

        public TCPServer Server { get; set; }

        public double HeadJudgePoints { get; set; }

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
            View.EventCollectPoints += CollectPoints;
            View.EventManualJudging += OpenManualJudging;

            window.FormClosing += ParentForm_FormClosing;

            Initialize();

            Server = new TCPServer(this);
            View.LabelServerIp.Text = "Server: " + Server.HostInfo;
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

        /// <summary>
        /// Is called the the mainwindow is closed
        /// </summary>
        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server?.Kill();
        }

        /// <summary>
        /// Call RequestPoints() in the Server.
        /// This sends out a message to every client that the head Judge wants to collect scores
        /// </summary>
        private void RequestPointsFromJudges()
        {
            Dive dive = GetSelectedDive();
            if(dive != null)
            {
                Server?.RequestPoints(GetSelectedDive());

                double point = -1;
                while (true)
                {
                    string input = InputDialog.OpenDialog("Ge dina poäng");
                    if (double.TryParse(input, out point))
                    {
                        HeadJudgePoints = point;
                        View.LabelHeadPoints.Text = point.ToString();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// If the program is in offline mode, open up manual scoring by the headjudge
        /// </summary>
        private void OpenManualJudging()
        {
            if(GetSelectedDive() != null)
            {
                ManualJudging judgingWindow = new ManualJudging(GetSelectedDive(), CurrentContest.Judges);
                if(judgingWindow.ShowDialog() == DialogResult.OK)
                {
                    ResetPoints();
                }
            }
            
        }

        /// <summary>
        /// Open up a dive for editing
        /// </summary>
        private void EnableModifyDive()
        {
            View.ButtonCancelModify.Visible = true;
            View.ButtonModifyDive.Visible = true;
            View.ButtonRemoveDive.Visible = true;
            View.ButtonRequestPoints.Enabled = true;
            ResetPoints();
        }

        /// <summary>
        /// Close a dive for editing
        /// </summary>
        private void CancelModifyDive()
        {
            View.ButtonCancelModify.Visible = false;
            View.ButtonModifyDive.Visible = false;
            View.ButtonRemoveDive.Visible = false;
            View.ButtonRequestPoints.Enabled = false;
            ResetPoints();
        }

        /// <summary>
        /// Updates a existing dive with new information
        /// </summary>
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

        /// <summary>
        /// Ties a score to a specific judgeClient
        /// </summary>
        /// <param name="client"></param>
        /// <param name="score"></param>
        internal void AddToPointList(string client, string score)
        {
            foreach (ListViewItem clientItem in View.ListViewJudgeClients.Items)
            {
                if (clientItem.Text == client)
                {
                    clientItem.SubItems[1].Text = score;
                }
            }
        }

        /// <summary>
        /// Gathers up the scores that have come in from the various judges
        /// However it will only create and store the ScoreList if all the scores have come in.
        /// </summary>
        public void CollectPoints()
        {
            bool AllPointsCollected = true;

            if (View.ListViewJudgeClients.Items.Count + 1 == CurrentContest.Judges.Count)
            {
                ScoreList scoreList = new ScoreList();
                foreach (ListViewItem clientItem in View.ListViewJudgeClients.Items)
                {
                    if (clientItem.SubItems[1].Text == "-1")
                    {
                        // One of the scores have not come in
                        AllPointsCollected = false;
                        break;
                    }
                    else
                    {
                        // Find the right Judge 
                        foreach (var judge in CurrentContest.Judges)
                        {
                            if (judge.GetFullName() == clientItem.SubItems[0].Text)
                            {
                                double score = double.Parse(clientItem.SubItems[1].Text, CultureInfo.InvariantCulture);
                                scoreList.Add(new Score(score, judge));
                                break;
                            }

                        }
                        scoreList.Add(new Score(HeadJudgePoints, window.CurrentJudge));
                    }
                }

                // All scores are in, go ahead and add the new ScoreList
                if (AllPointsCollected)
                {
                    GetSelectedDive().Scores = scoreList;

                    CancelModifyDive();
                    ResetPoints();
                }
                else
                    MessageBox.Show("Väntar fortfarande på poäng från domare!");

            }
        }

        /// <summary>
        /// This resets old scores that are still in the ListView, will not delete any stored scores
        /// </summary>
        public void ResetPoints()
        {

            if (Server != null)
            {
                foreach (var client in Server.ClientList)
                {
                    client.Points = "-1";
                }

                RefreshClientListView();


                foreach (var client in Server.ClientList)
                {
                    foreach (ListViewItem clientItem in View.ListViewJudgeClients.Items)
                    {
                        if (client.ClientName == clientItem.Text)
                        {
                            Dive dive = GetSelectedDive();
                            if (dive?.Scores != null)
                            {
                                int i = 0;
                                foreach (var score in GetSelectedDive().Scores)
                                {
                                    if (score.Judge.GetFullName() == clientItem.Text)
                                    {
                                        clientItem.SubItems[1].Text = score.Value.ToString();
                                        break;
                                    }
                                    else if (score.Judge == window.CurrentJudge)
                                        View.LabelHeadPoints.Text = score.Value.ToString();
                                }
                                break;
                            }
                            else
                            {
                                clientItem.SubItems[1].Text = "-1";
                                View.LabelHeadPoints.Text = "-1";
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var judge in CurrentContest.Judges)
                {
                    foreach (ListViewItem clientItem in View.ListViewJudgeClients.Items)
                    {
                        if (judge.GetFullName() == clientItem.Text)
                        {
                            Dive dive = GetSelectedDive();
                            if (dive?.Scores != null)
                            {
                                foreach (var score in GetSelectedDive().Scores)
                                {
                                    if (score.Judge.GetFullName() == clientItem.Text)
                                    {
                                        clientItem.SubItems[1].Text = score.Value.ToString();
                                        break;
                                    }
                                }
                                break;
                            }
                            else
                            {
                                clientItem.SubItems[1].Text = "-1";
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// FIXA
        /// </summary>
        private void RemoveDive()
        {
            // funkar ej 
            GetSelectedSubContest().RemoveExistingDive(GetSelectedContestant(), GetSelectedDive());
            UpdateDivesListView();
        }

        /// <summary>
        /// Is called when the selection is change in the combobox with subcontests
        /// </summary>
        private void UpdateContestantListView()
        {
            CancelModifyDive();

            SubContestBranch selectedSubContest = GetSelectedSubContest();

            if (selectedSubContest != null)
            {
                // Clear the listviews
                View.ListViewContestants.Items.Clear();
                View.ListViewDives.Items.Clear();

                foreach (var c in selectedSubContest.BranchContestants)
                {
                    ListViewItem contestantItem = new ListViewItem(c.FirstName);
                    contestantItem.SubItems.Add(c.LastName);

                    View.ListViewContestants.Items.Add(contestantItem);

                }
            }

        }

        internal void ManualJudging()
        {
            View.LabelServerIp.Text = "Server: Offline";
            Server = null;
            View.ButtonManualJudging.Visible = true;
            View.ButtonRequestPoints.Visible = false;
            RefreshClientListView();
        }

        /// <summary>
        /// Adds a client to the ListView holding Judge clients
        /// </summary>
        /// <param name="client"></param>
        internal void AddToClientListView(HandleClient client)
        {
            ListViewItem clientItem = new ListViewItem(client.ClientName);
            clientItem.SubItems.Add(client.Points.ToString());

            View.ListViewJudgeClients.Items.Add(clientItem);
        }

        /// <summary>
        /// Refreshes the listview containing Judge clients
        /// </summary>
        internal void RefreshClientListView()
        {
            View.ListViewJudgeClients?.Items.Clear();

            if (Server != null)
            {
                foreach (var client in Server.ClientList)
                {
                    ListViewItem clientItem = new ListViewItem(client.ClientName);
                    clientItem.SubItems.Add(client.Points.ToString());

                    View.ListViewJudgeClients.Items.Add(clientItem);
                }
            }
            else
            {
                foreach (var judge in CurrentContest.Judges)
                {
                    ListViewItem judgeItem = new ListViewItem(judge.GetFullName());
                    judgeItem.SubItems.Add("-1");

                    View.ListViewJudgeClients.Items.Add(judgeItem);
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

            if (subContestBranch != null && contestant != null)
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
            CancelModifyDive();

            Contestant contestant = GetSelectedContestant();

            if (contestant != null)
            {
                //View.ListBoxDives.Items.Clear();
                View.ListViewDives.Items.Clear();
                foreach (var divelist in contestant.DiveLists)
                {
                    SubContestBranch subContest = GetSelectedSubContest();
                    if (subContest != null && divelist.SubContestBranch == subContest)
                    {
                        foreach (var dive in divelist)
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

        /// <summary>
        /// Get the selected contestant in ListViewContestants
        /// </summary>
        /// <returns>Contestant object or null if nothing is chosen</returns>
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

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Välj en deltagare!");
            }

            return null;
        }

        /// <summary>
        /// Get the selected SubContest in ComboBoxSubContests
        /// </summary>
        /// <returns>SubContestBranch object or null</returns>
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

        /// <summary>
        /// Get the selected Dive in ListViewDives
        /// </summary>
        /// <returns>Dive object or null if nothing is chosen</returns>
        private Dive GetSelectedDive()
        {
            if (View.ListViewDives.SelectedIndices.Count != 0)
            {
                var selectedDiveIndex = View.ListViewDives.SelectedIndices[0];

                int i = 0;
                Contestant contestant = GetSelectedContestant();

                if (contestant != null)
                {
                    foreach (var diveList in contestant.DiveLists)
                    {
                        SubContestBranch subContest = GetSelectedSubContest();
                        if (subContest != null)
                        {
                            if (diveList.SubContestBranch == subContest)
                            {
                                foreach (var dive in diveList)
                                {
                                    if (i++ == selectedDiveIndex)
                                        return dive;
                                }

                            }
                        }
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
            Database db = new Database();
            try
            {
                db.PushContest(CurrentContest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Server?.Kill();

            ResultView resultView = new ResultView();

            ResultPresenter resultPresenter = new ResultPresenter(resultView, window, CurrentContest);

            window.ChangePanel(resultView, View);

        }
        #endregion
    }
}
