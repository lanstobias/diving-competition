using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Denna klass är en Gren, vi valde namnet SubContestBranch eftersom namnet Event eller DiveEvent skulle kunna skapa förviring. Detta namn förvirar kanske också, men inte lika mycket ansåg vi.
namespace Simhopp
{
    public class SubContestBranch
    {

        public SubContestBranch()
        {
            Name = "-";
            ParentContest = null;
            BranchContestants = new ContestantList();
        }

        public SubContestBranch(string name, Contest parentContest, ContestantList branchContestants)
        {
            this.Name = name;
            this.ParentContest = parentContest;
            this.BranchContestants = branchContestants;
        }

        public string Name { get; set; }
        public Contest ParentContest { get; set; }

        public ContestantList BranchContestants { get; set; }

        #region Methods

        /// <summary>
        /// Add a new dive to a divers divelist
        /// </summary>
        /// <param name="Diver"></param>
        /// <param name="DiveToBeAdded"></param>
        public void AddNewDive(Contestant Diver, Dive DiveToBeAdded)
        {
            if (this.BranchContestants.Contains(Diver))
            {
                foreach (var list in Diver.DiveLists)
                {
                    if (list.SubContestBranch == this)
                    {
                        list.Add(DiveToBeAdded);
                    }
                }
            }
            
        }
        #endregion
    }
}
