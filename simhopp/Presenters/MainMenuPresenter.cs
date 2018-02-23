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

        private MainMenu window;

        #region Constructor
        public MainMenuPresenter(IMainMenuView view, MainMenu window)
        {
            this.View = view;
            this.window = window;
            View.EventCreateNewContest += gotoCreateContestView;
        }
        #endregion
        
        public void gotoCreateContestView()
        {
            //CreateContestView view = new CreateContestView();
            //CreateContestPresenter presenter = new CreateContestPresenter();
            //window.ChangePanel(view, this);   // ChangePanel(ny view, cameFrom)
        }
    }
}
