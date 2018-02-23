using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    class MainMenuView : PanelViewControl, IMainMenuView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        private Button createContestButton;
        private Button loadContestButton;
        private Button judgeContestButton;
        private Button exitButton;
        private Button button1;
        

        public MainMenuView()
        {

            InitializeComponent();

            
        }

        public event DelegateCreateNewContest EventCreateNewContest;

        private void CreateContestButton_Click(object sender, EventArgs e)
        {
            this.EventCreateNewContest.Invoke();
        }

        private void InitializeComponent()
        {
            this.createContestButton = new System.Windows.Forms.Button();
            this.loadContestButton = new System.Windows.Forms.Button();
            this.judgeContestButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.exitButton);
            this.mainPanel.Controls.Add(this.judgeContestButton);
            this.mainPanel.Controls.Add(this.loadContestButton);
            this.mainPanel.Controls.Add(this.createContestButton);
            // 
            // createContestButton
            // 
            this.createContestButton.ForeColor = System.Drawing.Color.Black;
            this.createContestButton.Location = new System.Drawing.Point(212, 142);
            this.createContestButton.Name = "createContestButton";
            this.createContestButton.Size = new System.Drawing.Size(75, 23);
            this.createContestButton.TabIndex = 0;
            this.createContestButton.Text = "Ny tävling";
            this.createContestButton.UseVisualStyleBackColor = true;
            this.createContestButton.Click += new System.EventHandler(this.CreateContestButton_Click);
            // 
            // loadContestButton
            // 
            this.loadContestButton.Location = new System.Drawing.Point(212, 171);
            this.loadContestButton.Name = "loadContestButton";
            this.loadContestButton.Size = new System.Drawing.Size(75, 23);
            this.loadContestButton.TabIndex = 2;
            this.loadContestButton.Text = "Ladda pågående tävling";
            this.loadContestButton.UseVisualStyleBackColor = true;
            // 
            // judgeContestButton
            // 
            this.judgeContestButton.Location = new System.Drawing.Point(212, 200);
            this.judgeContestButton.Name = "judgeContestButton";
            this.judgeContestButton.Size = new System.Drawing.Size(75, 23);
            this.judgeContestButton.TabIndex = 3;
            this.judgeContestButton.Text = "Bedöm tävling";
            this.judgeContestButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(212, 229);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Avsluta";
            this.exitButton.UseVisualStyleBackColor = true;
            
            
            // 
            // MainMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MainMenuView";
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    }
}
