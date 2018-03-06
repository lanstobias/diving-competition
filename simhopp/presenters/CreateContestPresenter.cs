using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Simhopp
{
    public class CreateContestPresenter
    {
        public CreateContestView View { get; set; }

        private ProjectMainWindow window;

        #region Properties
        public DateTime StartDate { get; set; } = new DateTime();

        public DateTime EndDate { get; set; } = new DateTime();


        // Skapas och fylls upp av databas
        public JudgeList GlobalJudgeList { get; set; } = new JudgeList();

        public JudgeList ContestJudgeList { get; set; } = new JudgeList();

        public ContestantList GlobalContestantList { get; set; } = new ContestantList();

        public ContestantList ContestContestantList { get; set; } = new ContestantList();
        #endregion

        #region Constructor
        public CreateContestPresenter(CreateContestView view, ProjectMainWindow window)
        {
            this.View = view;
            this.window = window;

            View.EventSetStartDate += SetStartDate;
            View.EventSetEndDate += SetEndDate;
            View.EventAddJudgeToDB += AddJudgeToDB;
            View.EventAddJudgeToContest += AddJudgeToContest;
            View.EventRemoveJudgeFromContest += RemoveJudgeFromContest;
            View.EventAddContestantToDB += AddContestantToDB;
            View.EventAddContestantToContest += AddContestantToContest;
            View.EventRemoveContestantFromContest += RemoveContestantFromContest;
            View.EventCreateSubContest += GoToCreateSubContest;


            FillWithData();

        } 
        #endregion

        #region Methods
        // Temporary method to initialize stuff with dummy values for easy testing
        public void FillWithData()
        {
            View.TextBoxName.Text = "Test comp";
            View.TextBoxArena.Text = "Gustavsvik";
            View.TextBoxCity.Text = "Örebro";

            StartDate = DateTime.Now;
            EndDate = DateTime.MaxValue;


            // detta ska komma från databasen
            Judge judge1 = new Judge("Karl", "Mal");
            Judge judge2 = new Judge("Laban", "Asda");
            Judge judge3 = new Judge("Leg", "Shin");
            Judge judge4 = new Judge("Handy", "Bandy");
            Judge judge5 = new Judge("Sammy", "Rol");

            JudgeList judgeList = new JudgeList();
            GlobalJudgeList.Add(judge1);
            GlobalJudgeList.Add(judge2);
            GlobalJudgeList.Add(judge3);
            GlobalJudgeList.Add(judge4);
            GlobalJudgeList.Add(judge5);

            Contestant kalle = new Contestant("kalle", "Cool");
            Contestant pelle = new Contestant("pelle", "Holm");
            Contestant lars = new Contestant("Lars", "Lerin");
            Contestant anna = new Contestant("Anna", "Annasson");

            ContestantList contestantList = new ContestantList();
            GlobalContestantList.Add(kalle);
            GlobalContestantList.Add(pelle);
            GlobalContestantList.Add(lars);
            GlobalContestantList.Add(anna);

            foreach (var judge in GlobalJudgeList)
                View.ListViewGlobalJudges.Items.Add(judge.GetFullName());

            foreach (var contestant in GlobalContestantList)
                View.ListViewGlobalContestants.Items.Add(contestant.GetFullName());

            ContestJudgeList.Add(judge1);
            ContestJudgeList.Add(judge2);
            ContestJudgeList.Add(judge3);

            ContestContestantList.Add(kalle);
            ContestContestantList.Add(pelle);

            View.LabelStartDate.Text = StartDate.ToShortDateString();
            View.LabelEndDate.Text = EndDate.ToShortDateString();

            UpdateListViews();

        }
        public void UpdateListViews()
        {
            // globala listboxes från dbn

            View.ListViewGlobalJudges.Items.Clear();

            View.ListViewGlobalContestants.Items.Clear();

            foreach(var judge in GlobalJudgeList)
            {
                ListViewItem listViewGlobalJudgesItems = new ListViewItem(judge.FirstName);
                listViewGlobalJudgesItems.SubItems.Add(judge.LastName);

                View.ListViewGlobalJudges.Items.Add(listViewGlobalJudgesItems);
            }

            foreach (var contestant in GlobalContestantList)
            {
                ListViewItem listViewGlobalContestantsItems = new ListViewItem(contestant.FirstName);
                listViewGlobalContestantsItems.SubItems.Add(contestant.LastName);

                View.ListViewGlobalContestants.Items.Add(listViewGlobalContestantsItems);
            }

            // lokala listboxes
            View.ListViewLocalContestants.Items.Clear();

            View.ListViewLocalJudges.Items.Clear();

            foreach (var judge in ContestJudgeList)
            {
                ListViewItem listViewLocalJudgesItems = new ListViewItem(judge.FirstName);
                listViewLocalJudgesItems.SubItems.Add(judge.LastName);

                View.ListViewLocalJudges.Items.Add(listViewLocalJudgesItems);

            }

            foreach (var contestant in ContestContestantList)
            {
                ListViewItem listViewLocalContestantsItems = new ListViewItem(contestant.FirstName);
                listViewLocalContestantsItems.SubItems.Add(contestant.LastName);

                View.ListViewLocalContestants.Items.Add(listViewLocalContestantsItems);

            }

        }

        public void GoToCreateSubContest()
        {
            // Kolla så att data är korrekt formatterat 
            bool stringAreValid = false;
            if (CheckDataInput.StringCheckFormat(View.TextBoxName.Text))
            {
                if (CheckDataInput.StringCheckFormat(View.TextBoxCity.Text))
                {
                    if (CheckDataInput.StringCheckFormat(View.TextBoxArena.Text))
                        stringAreValid = true;
                    else
                        MessageBox.Show("Simhallsnamn är ej giltigt.");
                }
                else
                    MessageBox.Show("Stadsnamn är ej giltigt.");
            }
            else
                MessageBox.Show("Tävlingsnamn är ej giltigt.");

            bool areDatesSet = false;
            // The dates have DateTime.MinValue if they have not been set manually 
            if (StartDate != DateTime.MinValue)
            {
                if (EndDate != DateTime.MinValue)
                    areDatesSet = true;
                else
                    MessageBox.Show("Välj slutdatum.");
            }
            else
                MessageBox.Show("Välj startdatum.");


            // check if any judges or contestans have been added to the contest
            bool areListsFilled = false;
            if (ContestJudgeList.Count > 2)
            {
                if (ContestContestantList.Count > 1)
                    areListsFilled = true;
                else
                    MessageBox.Show("Måste minst vara 2 deltagare på en tävling.");
            }
            else
                MessageBox.Show("Måste minst vara 3 domare på en tävling.");


            // if everything is okay, create the contest and move to subcontestview
            if (stringAreValid && areDatesSet && areListsFilled)
            {
                ContestInfo contestInfo = new ContestInfo(View.TextBoxName.Text, View.TextBoxCity.Text, StartDate, EndDate, View.TextBoxArena.Text);

                // Listorna byggs upp med hjälp av listboxarna.

                Contest contest = new Contest(contestInfo, ContestJudgeList, ContestContestantList);

                CreateSubContestView createSubContestView = new CreateSubContestView();

                CreateSubContestPresenter createSubContestPresenter = new CreateSubContestPresenter(createSubContestView, window, contest);

                window.ChangePanel(createSubContestView, View);
            }

        }

        public void RemoveContestantFromContest()
        {
            try
            {
                var contestantFirstName = View.ListViewLocalContestants.SelectedItems[0].SubItems[0].Text;

                var contestantLastName = View.ListViewLocalContestants.SelectedItems[0].SubItems[1].Text;

                Contestant contestantToBeRemoved = null;

                foreach (var c in ContestContestantList)
                {
                    if (String.Equals(c.FirstName, contestantFirstName) && String.Equals(c.LastName, contestantLastName))
                        contestantToBeRemoved = c;
                }

                ContestContestantList.Remove(contestantToBeRemoved);

                UpdateListViews();
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Välj en deltagare!");
            }
        }

        public void AddContestantToContest()
        {
            var contestantFirstName = View.ListViewGlobalContestants.SelectedItems[0].SubItems[0].Text;
            var contestantLastName = View.ListViewGlobalContestants.SelectedItems[0].SubItems[1].Text;

            bool isAdded = false;

            foreach (var c in ContestContestantList)
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
                foreach (var c in GlobalContestantList)
                {
                    if (String.Equals(c.FirstName, contestantFirstName) && String.Equals(c.LastName, contestantLastName))
                    {
                        contestantToBeAdded = c;
                    }
                }

                if (contestantToBeAdded != null)
                    ContestContestantList.Add(contestantToBeAdded);

                UpdateListViews();
            }

        }

        public void AddJudgeToDB()
        {
            var addPerson = new AddPersonForm();

            if (addPerson.ShowDialog() == DialogResult.OK)
            {
                Database db = new Database();
                foreach (var p in addPerson.PersonList)
                {
                    //try
                    //{
                    //    db.StorePerson(p);
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine(e.Message.ToString());
                    //}

                    GlobalJudgeList.Add((Judge)p);
                }

                UpdateListViews();
            }
        }

        public void AddContestantToDB()
        {
            var addPerson = new AddPersonForm();

            if (addPerson.ShowDialog() == DialogResult.OK)
            {
                Database db = new Database();
                foreach (var p in addPerson.PersonList)
                {
                    //try
                    //{
                    //    db.StorePerson(p);
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine(e.Message.ToString());
                    //}

                    GlobalContestantList.Add( (Contestant) p );
                }

                UpdateListViews();
            }
        }

        public void RemoveJudgeFromContest()
        {
            // Collect the chosen judge, gets the full name of the judge
            var judgeFirstName = View.ListViewLocalJudges.SelectedItems[0].SubItems[0].Text;
            var judgeLastName = View.ListViewLocalJudges.SelectedItems[0].SubItems[1].Text;

            Judge judgeToBeRemoved = null;

            // find the right Judge object
            foreach (var j in ContestJudgeList)
            {
                if (String.Equals(j.FirstName,judgeFirstName) && String.Equals(j.LastName,judgeLastName))
                    judgeToBeRemoved = j;
            }

            // remove from contestlist
            ContestJudgeList.Remove(judgeToBeRemoved);

                UpdateListViews();
        }

        public void AddJudgeToContest()
        {
            // Collect the chosen judge
            var judgeFirstName = View.ListViewGlobalJudges.SelectedItems[0].SubItems[0].Text;

            var judgeLastName = View.ListViewGlobalJudges.SelectedItems[0].SubItems[1].Text;
            bool isAdded = false;

            // Check if judge is already added to the contest
            foreach (var j in ContestJudgeList)
            {
                if (String.Equals(j.FirstName,judgeFirstName) && String.Equals(j.LastName,judgeLastName))
                {
                    isAdded = true;
                    MessageBox.Show("Domare är redan tillagd!");
                    break;
                }
            }

            // Collect the correct Judge object
            Judge judgeToBeAdded = null;

            if (!isAdded)
            {
                foreach (var j in GlobalJudgeList)
                {
                    if (String.Equals(j.FirstName, judgeFirstName) && String.Equals(j.LastName, judgeLastName))
                        judgeToBeAdded = j;
                }

                if (judgeToBeAdded != null)
                    ContestJudgeList.Add(judgeToBeAdded);
                UpdateListViews();
            }

        }

        public void SetStartDate()
        {
            var datePicker = new DatePicker();

            if (datePicker.ShowDialog() == DialogResult.OK)
            {
                StartDate = datePicker.SelectedDate;
            }

            View.LabelStartDate.Text = StartDate.ToShortDateString();
        }

        public void SetEndDate()
        {
            var datePicker = new DatePicker();

            if (datePicker.ShowDialog() == DialogResult.OK)
            {
                EndDate = datePicker.SelectedDate;
            }

            View.LabelEndDate.Text = EndDate.ToShortDateString();
        } 
        #endregion
    }
}
