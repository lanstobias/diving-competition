﻿using System;
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
    public partial class ProjectMainWindow : Form
    {
        #region Properties
        MainMenuView mainMenuView;
        MainMenuPresenter mainMenuPresenter;
        private PanelViewControl CurrentView { get; set; }

        // Holds the previous view that was presented.
        private PanelViewControl PreviousView { get; set; }

        public Judge CurrentJudge { get; set; }
        #endregion

        public ProjectMainWindow()
        {
            InitializeComponent();

            LoginForm login = new LoginForm();

            if (login.ShowDialog() == DialogResult.OK)
            {
                CurrentJudge = login.Judge;
                this.Text = "Simhopp: " + CurrentJudge.GetFullName();
                mainMenuView = new MainMenuView();
                mainMenuPresenter = new MainMenuPresenter(mainMenuView, this);

                this.Controls.Add(mainMenuView);
            }
            else
                Environment.Exit(1);
                

        }

        public void GoBackToStartMenu()
        {
            this.Controls.Remove(CurrentView);
            this.Controls.Add(mainMenuView);
        }

        /// <summary>
        /// Handles the changing of panels to view
        /// </summary>
        /// <param name="viewToLoad">The new view to be presented</param>
        /// <param name="cameFrom">The view from where the call to this was made</param>
        public void ChangePanel(PanelViewControl viewToLoad, PanelViewControl cameFrom)
        {
            this.Controls.Remove(cameFrom);
            this.Controls.Add(viewToLoad);

            PreviousView = cameFrom;
            CurrentView = viewToLoad;
        }

        public void GoBackToPreviuosPanel()
        {
            if(PreviousView != null)
            {
                this.Controls.Remove(CurrentView);
                this.Controls.Add(PreviousView);

                PreviousView = null;
                CurrentView = PreviousView;
            } 
        }
        
    }
}
