using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    class MainMenuPresenter
    {
        public IMainMenuView View { get; set; }

        private ProjectMainWindow window;

        #region Constructor
        public MainMenuPresenter(IMainMenuView view, ProjectMainWindow window)
        {
            this.View = view;
            this.window = window;
            View.EventCreateNewContest += gotoCreateContestView;
            View.EventJudgeContest += GotoJudgeContest;
        }

        private void GotoJudgeContest()
        {
            JudgeDiveView judgeView = new JudgeDiveView();
            JudgeDivePresenter presenter = new JudgeDivePresenter(judgeView, window);
            window.ChangePanel(judgeView, (PanelViewControl)View);
        }
        #endregion

        public void gotoCreateContestView()
        {
            CreateContestView newView = new CreateContestView();
            CreateContestPresenter presenter = new CreateContestPresenter(newView,window);
            window.ChangePanel(newView, (PanelViewControl)View);   // ChangePanel(ny view, cameFrom)
        }
    }
}
