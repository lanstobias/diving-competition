using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class JudgeDivePresenter
    {
        public JudgeDiveView View { get; set; }

        private ProjectMainWindow window;

        public JudgeDivePresenter(JudgeDiveView view, ProjectMainWindow window)
        {
            this.View = view;
            this.window = window;

            View.EventGiveScore += GiveScore;
        }
        private void GiveScore()
        {
            throw new NotImplementedException();
        }
    }
}
