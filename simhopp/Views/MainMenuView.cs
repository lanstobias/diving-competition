using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    class MainMenuView : PanelView, IMainMenuView
    {
        private Button createContestButton;
        private Button loadContestButton;
        private Button judgeContestButton;
        private Button exitButton;
        
        
        private Label title;
        

        public MainMenuView()
        {

            this.createContestButton = new Button();
            this.title = new Label();
            this.loadContestButton = new Button();
            this.judgeContestButton = new Button();
            this.exitButton = new Button();

            // 
            // this
            // 
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.judgeContestButton);
            this.Controls.Add(this.loadContestButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.createContestButton);
            this.Name = "mainMenuPanel";
            // 
            // createContestButton
            // 
            this.createContestButton.Location = new System.Drawing.Point(212, 142);
            this.createContestButton.Name = "createContestButton";
            this.createContestButton.Size = new System.Drawing.Size(75, 23);
            this.createContestButton.TabIndex = 0;
            this.createContestButton.Text = "Ny tävling";
            this.createContestButton.UseVisualStyleBackColor = true;
            this.Click += new EventHandler(this.CreateContestButton_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(233, 81);
            this.title.Name = "label1";
            this.title.Size = new System.Drawing.Size(35, 13);
            this.title.TabIndex = 1;
            this.title.Text = "label1";
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
        }

        public event DelegateCreateNewContest EventCreateNewContest;

        private void CreateContestButton_Click(object sender, EventArgs e)
        {
            this.EventCreateNewContest.Invoke();
        }
    }
}
