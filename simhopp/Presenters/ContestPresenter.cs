using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private void DiplaySubContest()
        {
            var selectedSubContestName = View.ComboBoxSubContests.SelectedItem as string;
            SubContestBranch selectedSubContest = null;

            foreach(var sc in CurrentContest.SubContestBranches)
            {
                if (selectedSubContestName == sc.Name)
                    selectedSubContest = sc;
            }

            if(selectedSubContest != null)
            {
                View.ListBoxContestants.Items.Clear();
                foreach(var c in selectedSubContest.BranchContestants)
                {
                    View.ListBoxContestants.Items.Add(c.GetFullName());
                }
            }
        }

        private void AddDive()
        {
            AddDiveView addDiveView = new AddDiveView();
            AddDivePresenter addDivePresenter = new AddDivePresenter(addDiveView, window, CurrentContest);
            addDiveView.Show();
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

        #endregion
    }
}
