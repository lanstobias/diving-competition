using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    /// <summary>
    /// This is the main window of the program. Stores some information like and handles the switching of views
    /// </summary>
    public partial class ProjectMainWindow : Form
    {
        #region Properties
        private MainMenuView mainMenuView;

        private MainMenuPresenter mainMenuPresenter;

        public bool LAN { get; set; } = true;
        public int Port { get; set; }

        private SettingsForm Settings { get; set; } = new SettingsForm();
        private PanelViewControl CurrentView { get; set; }
        private PanelViewControl PreviousView { get; set; }
        
        // Holds the previous views that was presented earlier. Last in First out
        private Stack<PanelViewControl> PrevViewStack { get; set; }
        public Judge CurrentJudge { get; set; }
        public Judge HeadJudge { get; set; }
        public bool Offline { get; set; }
        #endregion

        #region Constructor
        public ProjectMainWindow()
        {
            InitializeComponent();

            PrevViewStack = new Stack<PanelViewControl>();

            LoginForm login = new LoginForm();

            if (login.ShowDialog() == DialogResult.OK)
            {
                CurrentJudge = login.Judge;

                Text = "Simhopp: " + CurrentJudge.GetFullName();

                mainMenuView = new MainMenuView();
                mainMenuPresenter = new MainMenuPresenter(mainMenuView, this);

                Controls.Add(mainMenuView);
            }
            else
                Environment.Exit(1);
                
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the changing of panels to view
        /// </summary>
        /// <param name="viewToLoad">The new view to be presented</param>
        /// <param name="cameFrom">The view from where the call to this was made</param>
        public void ChangePanel(PanelViewControl viewToLoad, PanelViewControl cameFrom)
        {
            this.Controls.Remove(cameFrom);
            this.Controls.Add(viewToLoad);
            
            PrevViewStack.Push(cameFrom);

            CurrentView = viewToLoad;
        }
        
        /// <summary>
        /// Disable the back button in the file menu
        /// </summary>
        public void DisableBackButton()
        {
            this.goBackItem.Visible = false;
        }

        /// <summary>
        /// Go back to start menu view
        /// </summary>
        public void GoBackToStartMenu()
        {
            Controls.Remove(CurrentView);
            Controls.Add(mainMenuView);

            this.goBackItem.Visible = true;
        }

        /// <summary>
        /// Go back to the previous panel that was presented. 
        /// </summary>
        public void GoBackToPreviuosPanel()
        {
            try
            {
                PreviousView = PrevViewStack.Pop();

                this.Controls.Remove(CurrentView);
                this.Controls.Add(PreviousView);

                CurrentView = PreviousView;
            }
            catch(InvalidOperationException)
            {
                GoBackToStartMenu();
            }
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResultsMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://tomat.trickip.net/simhopp/?controller=view_result&action=home");
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.IsDisposed)
                Settings = new SettingsForm();

            Settings.ShowDialog();

            LAN = Settings.LAN;
            Port = Settings.Port;
            Offline = Settings.Offline;

        }

        private void SettingsGoBackItem_Click(object sender, EventArgs e)
        {
            GoBackToPreviuosPanel();
        }

        #endregion
    }
}
