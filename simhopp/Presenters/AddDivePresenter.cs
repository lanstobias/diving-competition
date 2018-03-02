using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class AddDivePresenter
    {
        public AddDiveView View { get; set; }

        private ProjectMainWindow window;

        public SubContestBranch SubContest { get; set; }

        public Contestant CurrentContestant { get; set; }


        public AddDivePresenter(AddDiveView view, ProjectMainWindow window, SubContestBranch subContest, Contestant contestant)
        {
            this.View = view;
            this.window = window;
            this.SubContest = subContest;
            CurrentContestant = contestant;
        }
    }
}
