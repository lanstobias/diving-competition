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

        public Contest CurrentContest { get; set; }

        public AddDivePresenter(AddDiveView view, ProjectMainWindow window, Contest contest)
        {
            this.View = view;
            this.window = window;
            CurrentContest = contest;
        }
    }
}
