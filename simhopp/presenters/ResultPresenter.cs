using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class ResultPresenter
    {
        #region Members
        // Properties
        public ResultView View { get; set; }

        public Contest Model { get; set; }

        public SubContestBranch SelectedSubContest { get; set; } = null;

        // Private fields
        private ProjectMainWindow window;
        #endregion

        #region Constructors
        // Instance constructor
        public ResultPresenter(ResultView view, ProjectMainWindow window, Contest contest)
        {
            this.View = view;
            this.window = window;
            this.Model = contest;

            TestData();

            foreach (var subcontest in Model.SubContestBranches)
                View.ListViewSubContests.Items.Add(subcontest.Name);

            View.EventSubContestSelection += SubContestSelected;
        }
        #endregion

        #region Methods
        // Public Methods
        public void TestData()
        {
            ScoreList scoreList = new ScoreList();

            scoreList.Add(new Score(2.5));
            scoreList.Add(new Score(7.5));
            scoreList.Add(new Score(3));
            scoreList.Add(new Score(10));
            scoreList.Add(new Score(5.5));


            ScoreList scoreList2 = new ScoreList();

            scoreList2.Add(new Score(2.5));
            scoreList2.Add(new Score(3));
            scoreList2.Add(new Score(2));
            scoreList2.Add(new Score(8.5));
            scoreList2.Add(new Score(5.5));

            Dive dive = new Dive(new DiveCode(2.0, "10mbakåtvolt"), scoreList2);

            Dive dive2 = new Dive(new DiveCode(3.0, "10m"), scoreList);

            foreach (var sc in Model.SubContestBranches)
            {
                foreach (var c in sc.BranchContestants)
                {
                    if (c.FirstName == "pelle")
                        sc.AddNewDive(c, dive2);
                }
            }

            foreach (var sc in Model.SubContestBranches)
            {
                foreach (var c in sc.BranchContestants)
                {
                    if (c.FirstName == "kalle")
                        sc.AddNewDive(c, dive);

                }


            }

        }

        // Private Methods
        private void DisplaySubContestResult(SubContestBranch subContestBranch)
        {
            View.ListViewContestants.Items.Clear();
            int i = 1;
            foreach (var result in Model.GetSubContestResultDictionary(subContestBranch))
            {
                ListViewItem listViewResultItem = new ListViewItem(i.ToString());

                listViewResultItem.SubItems.Add(result.Key.FirstName);

                listViewResultItem.SubItems.Add(result.Key.LastName);

                listViewResultItem.SubItems.Add(result.Value.ToString());

                View.ListViewContestants.Items.Add(listViewResultItem);

                i++;

            }
        }

        private void SubContestSelected()
        {
            if (View.ListViewSubContests.SelectedItems.Count == 1)
            {
                var subContestName = View.ListViewSubContests.SelectedItems[0].Text;

                foreach (var sc in Model.SubContestBranches)
                {
                    if (sc.Name == subContestName)
                    {
                        DisplaySubContestResult(sc);
                    }

                }



            }
        } 
        #endregion
    }
}
