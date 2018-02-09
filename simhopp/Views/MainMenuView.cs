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
        
        
        private Label label1;
        

        public MainMenuView()
        {

            this.createContestButton = new Button();
            this.label1 = new Label();
            this.loadContestButton = new Button();
            this.judgeContestButton = new Button();
            this.exitButton = new Button();

            // 
            // this
            // 
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.judgeContestButton);
            this.Controls.Add(this.loadContestButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createContestButton);
            this.Name = "mainMenuPanel";
            // 
            // button1
            // 
            this.createContestButton.Location = new System.Drawing.Point(212, 142);
            this.createContestButton.Name = "createContestButton";
            this.createContestButton.Size = new System.Drawing.Size(75, 23);
            this.createContestButton.TabIndex = 0;
            this.createContestButton.Text = "Ny tävling";
            this.createContestButton.UseVisualStyleBackColor = true;
            this.Click += new EventHandler(this.CreateContestButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button2
            // 
            this.loadContestButton.Location = new System.Drawing.Point(212, 171);
            this.loadContestButton.Name = "loadContestButton";
            this.loadContestButton.Size = new System.Drawing.Size(75, 23);
            this.loadContestButton.TabIndex = 2;
            this.loadContestButton.Text = "Ladda pågående tävling";
            this.loadContestButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.judgeContestButton.Location = new System.Drawing.Point(212, 200);
            this.judgeContestButton.Name = "judgeContestButton";
            this.judgeContestButton.Size = new System.Drawing.Size(75, 23);
            this.judgeContestButton.TabIndex = 3;
            this.judgeContestButton.Text = "Bedöm tävling";
            this.judgeContestButton.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.exitButton.Location = new System.Drawing.Point(212, 229);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Stäng";
            this.exitButton.UseVisualStyleBackColor = true;
        }

        public event DelegateCreateNewContest EventCreateNewContest;

        private void CreateContestButton_Click(object sender, EventArgs e)
        {
            this.EventCreateNewContest.Invoke();
        }
    }
}
