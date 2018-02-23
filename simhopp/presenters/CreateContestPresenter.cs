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
        public JudgeList GlobalJudgeList { get; set; }

        public JudgeList ContestJudgeList { get; set; }

        public ContestantList GlobalContestantList { get; set; }

        public ContestantList ContestContestantList { get; set; }

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
