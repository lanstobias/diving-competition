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

        private Form window;

        #region Constructor
        public MainMenuPresenter(IMainMenuView view, Form window)
        {
            this.View = view;
            this.window = window;
            View.EventCreateNewContest += gotoCreateContestView;
        }
        #endregion
        
        public void gotoCreateContestView()
        {
            //CreateContestView view = new Crateasdfasfd
            //CreateContestPresenter presenter = new asdfasdf
            //window.ChangePanel(view, this)   // ChangePanel(ny view, cameFrom)
        }
    }
}
