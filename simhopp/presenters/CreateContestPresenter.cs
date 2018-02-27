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

        public DateTime StartDate { get; set; } = new DateTime();

        public DateTime EndDate { get; set; } = new DateTime();


        // Skapas och fylls upp av databas
        public JudgeList GlobalJudgeList { get; set; } = new JudgeList();

        public JudgeList ContestJudgeList { get; set; } = new JudgeList();

        public ContestantList GlobalContestantList { get; set; } = new ContestantList();

        public ContestantList ContestContestantList { get; set; } = new ContestantList();

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


            // detta ska komma från databasen
            Judge judge1 = new Judge("Karl", "Mal");
            Judge judge2 = new Judge("LAban", "Asda");
            Judge judge3 = new Judge("Leg", "Shin");
            Judge judge4 = new Judge("Handy", "Bandy");
            Judge judge5 = new Judge("Sammy", "Rol");

            JudgeList judgeList = new JudgeList();
            GlobalJudgeList.Add(judge1);
            GlobalJudgeList.Add(judge2);
            GlobalJudgeList.Add(judge3);
            GlobalJudgeList.Add(judge4);
            GlobalJudgeList.Add(judge5);

            Contestant kalle = new Contestant("kalle");
            Contestant pelle = new Contestant("pelle");
            Contestant lars = new Contestant("Lars");
            Contestant anna = new Contestant("Anna");

            ContestantList contestantList = new ContestantList();
            GlobalContestantList.Add(kalle);
            GlobalContestantList.Add(pelle);
            GlobalContestantList.Add(lars);
            GlobalContestantList.Add(anna);

            foreach(var judge in GlobalJudgeList)
                View.ListBoxGlobalJudges.Items.Add(judge.FirstName + " " + judge.LastName);

            foreach (var contestant in GlobalContestantList)
                View.ListBoxGlobalContestants.Items.Add(contestant.FirstName + " " + contestant.LastName);

        }

        public void UpdateListBoxes()
        {
            View.ListBoxLocalJudges.Items.Clear();
            //View.ListBoxLocalContestants.Items.Clear();

            foreach (var judge in ContestJudgeList)
                View.ListBoxLocalJudges.Items.Add(judge.FirstName + " " + judge.LastName);
        }

        public void GoToCreateSubContest()
        {
            // TODO:
            // Kolla så att data är korrekt formatterat 

            ContestInfo contestInfo = new ContestInfo(View.TextBoxName.Text, View.TextBoxCity.Text, StartDate, EndDate, View.TextBoxArena.Text);

            // Listorna byggs upp med hjälp av listboxarna.
            
            Contest contest = new Contest(contestInfo, ContestJudgeList, ContestContestantList);

            CreateSubContestView createSubContestView = new CreateSubContestView();

            CreateSubContestPresenter createSubContestPresenter = new CreateSubContestPresenter(createSubContestView, window, contest);

            window.ChangePanel(createSubContestView, View);
        }

        public void RemoveContestantFromContest()
        {
            throw new NotImplementedException();
        }

        public void AddContestantToContest()
        {
            throw new NotImplementedException();
        }

        public void AddContestantToDB()
        {
            throw new NotImplementedException();
        }

        public void RemoveJudgeFromContest()
        {
            throw new NotImplementedException();
        }

        public void AddJudgeToContest()
        {
            throw new NotImplementedException();
        }

        public void AddJudgeToDB()
        {
            throw new NotImplementedException();
        }

        public void SetStartDate()
        {
            var datePicker = new DatePicker();

            if (datePicker.ShowDialog() == DialogResult.OK)
            { 
                StartDate = datePicker.SelectedDate;
            }
        }

        public void SetEndDate()
        {
            var datePicker = new DatePicker();

            if (datePicker.ShowDialog() == DialogResult.OK)
            {
                EndDate = datePicker.SelectedDate;
            }
        }
    }
}
