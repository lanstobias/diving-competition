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
        #region Properties
        public IMainMenuView View { get; set; }

        private ProjectMainWindow window;
        #endregion

        #region Constructor
        public MainMenuPresenter(IMainMenuView view, ProjectMainWindow window)
        {
            this.View = view;
            this.window = window;
            View.EventCreateNewContest += gotoCreateContestView;
            View.EventJudgeContest += GotoJudgeContest;
        }
        #endregion

        #region Methods
        public void gotoCreateContestView()
        {
            CreateContestView newView = new CreateContestView();
            CreateContestPresenter presenter = new CreateContestPresenter(newView,window);
            window.ChangePanel(newView, (PanelViewControl)View);   // ChangePanel(ny view, cameFrom)
        }

        private void GotoJudgeContest()
        {
            ServerBrowser serverBrowser = new ServerBrowser();

            if(serverBrowser.ShowDialog() == DialogResult.OK)
            {
                JudgeDiveView judgeView = new JudgeDiveView();
                JudgeDivePresenter presenter = new JudgeDivePresenter(judgeView, window, serverBrowser.ChosenIp);
                window.ChangePanel(judgeView, (PanelViewControl)View);
            }
        }
        #endregion
    }
}
