using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public class CreateContestView : PanelViewControl, ICreateContestView
    {
        private System.Windows.Forms.Button buttonGoToSubContest;
        private System.Windows.Forms.Button buttonAddNewContestantToDB;
        private System.Windows.Forms.ListBox listBoxLocalContestants;
        private System.Windows.Forms.Button buttonRemoveContestantFromContest;
        private System.Windows.Forms.Button buttonAddContestantToContest;
        private ListBox listBoxGlobalContestants;
        private System.Windows.Forms.Button buttonAddNewJudgeToDB;
        private System.Windows.Forms.ListBox listBoxLocalJudges;
        private System.Windows.Forms.Button buttonRemoveJudgeFromContest;
        private System.Windows.Forms.Button buttonAddJudgeToContest;
        private System.Windows.Forms.ListBox listBoxGlobalJudges;
        private System.Windows.Forms.Button buttonSetStartDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxArena;
        private Label labelName;
        private System.Windows.Forms.Label labelContestInfo;
        private System.Windows.Forms.TextBox textBoxCity;
        private Label labelEndDate;
        private Button buttonSetEndDate;
        private Label labelArena;
        private System.Windows.Forms.TextBox textBoxName;

        public event DelegateSetStartDate EventSetStartDate;
        public event DelegateSetEndDate EventSetEndDate;
        public event DelegateAddJudgeToDB EventAddJudgeToDB;
        public event DelegateAddJudgeToContest EventAddJudgeToContest;
        public event DelegateRemoveJudgeFromContest EventRemoveJudgeFromContest;
        public event DelegateAddContestantToDB EventAddContestantToDB;
        public event DelegateAddContestantToContest EventAddContestantToContest;
        public event DelegateRemoveContestantFromContest EventRemoveContestantFromContest;
        public event DelegateCreateSubContest EventCreateSubContest;


        public TextBox TextBoxName { get { return textBoxName; } set { textBoxName = value; } }
        public TextBox TextBoxCity { get { return textBoxCity; } set { textBoxCity = value; } }
        public TextBox TextBoxArena { get { return textBoxArena; } set { textBoxArena = value; } }
        public ListBox ListBoxGlobalJudges { get { return listBoxGlobalJudges; } set { listBoxGlobalJudges = value; } }
        public ListBox ListBoxLocalJudges { get { return listBoxLocalJudges; } set { listBoxLocalJudges = value; } }
        public ListBox ListBoxGlobalContestants { get { return listBoxGlobalContestants; } set { listBoxGlobalJudges = value; } }
        public ListBox ListBoxLocalContestants { get { return listBoxLocalContestants; } set { listBoxLocalContestants = value; } }
        public Label LabelStartDate { get { return labelStartDate; } set { labelStartDate = value; } }
        public Label LabelEndDate { get { return labelEndDate; } set { labelEndDate = value; } }

        public CreateContestView()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelContestInfo = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxArena = new System.Windows.Forms.TextBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.buttonSetStartDate = new System.Windows.Forms.Button();
            this.listBoxGlobalJudges = new System.Windows.Forms.ListBox();
            this.buttonAddJudgeToContest = new System.Windows.Forms.Button();
            this.buttonRemoveJudgeFromContest = new System.Windows.Forms.Button();
            this.listBoxLocalJudges = new System.Windows.Forms.ListBox();
            this.buttonAddNewJudgeToDB = new System.Windows.Forms.Button();
            this.buttonAddNewContestantToDB = new System.Windows.Forms.Button();
            this.listBoxLocalContestants = new System.Windows.Forms.ListBox();
            this.buttonRemoveContestantFromContest = new System.Windows.Forms.Button();
            this.buttonAddContestantToContest = new System.Windows.Forms.Button();
            this.listBoxGlobalContestants = new System.Windows.Forms.ListBox();
            this.buttonGoToSubContest = new System.Windows.Forms.Button();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.buttonSetEndDate = new System.Windows.Forms.Button();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelArena = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.labelArena);
            this.mainPanel.Controls.Add(this.labelEndDate);
            this.mainPanel.Controls.Add(this.buttonSetEndDate);
            this.mainPanel.Controls.Add(this.textBoxCity);
            this.mainPanel.Controls.Add(this.buttonGoToSubContest);
            this.mainPanel.Controls.Add(this.buttonAddNewContestantToDB);
            this.mainPanel.Controls.Add(this.listBoxLocalContestants);
            this.mainPanel.Controls.Add(this.buttonRemoveContestantFromContest);
            this.mainPanel.Controls.Add(this.buttonAddContestantToContest);
            this.mainPanel.Controls.Add(this.listBoxGlobalContestants);
            this.mainPanel.Controls.Add(this.buttonAddNewJudgeToDB);
            this.mainPanel.Controls.Add(this.listBoxLocalJudges);
            this.mainPanel.Controls.Add(this.buttonRemoveJudgeFromContest);
            this.mainPanel.Controls.Add(this.buttonAddJudgeToContest);
            this.mainPanel.Controls.Add(this.listBoxGlobalJudges);
            this.mainPanel.Controls.Add(this.buttonSetStartDate);
            this.mainPanel.Controls.Add(this.labelStartDate);
            this.mainPanel.Controls.Add(this.labelCity);
            this.mainPanel.Controls.Add(this.textBoxArena);
            this.mainPanel.Controls.Add(this.labelName);
            this.mainPanel.Controls.Add(this.labelContestInfo);
            this.mainPanel.Controls.Add(this.textBoxName);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(24, 51);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(87, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // labelContestInfo
            // 
            this.labelContestInfo.AutoSize = true;
            this.labelContestInfo.Location = new System.Drawing.Point(35, 12);
            this.labelContestInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContestInfo.Name = "labelContestInfo";
            this.labelContestInfo.Size = new System.Drawing.Size(98, 13);
            this.labelContestInfo.TabIndex = 1;
            this.labelContestInfo.Text = "Tävlingsinformation";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(21, 36);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Namn";
            // 
            // textBoxArena
            // 
            this.textBoxArena.Location = new System.Drawing.Point(133, 51);
            this.textBoxArena.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxArena.Name = "textBoxArena";
            this.textBoxArena.Size = new System.Drawing.Size(87, 20);
            this.textBoxArena.TabIndex = 3;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(130, 36);
            this.labelCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(29, 13);
            this.labelCity.TabIndex = 6;
            this.labelCity.Text = "Stad";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(332, 31);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(35, 13);
            this.labelStartDate.TabIndex = 7;
            this.labelStartDate.Text = "";
            // 
            // buttonSetStartDate
            // 
            this.buttonSetStartDate.Location = new System.Drawing.Point(335, 46);
            this.buttonSetStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSetStartDate.Name = "buttonSetStartDate";
            this.buttonSetStartDate.Size = new System.Drawing.Size(94, 29);
            this.buttonSetStartDate.TabIndex = 9;
            this.buttonSetStartDate.Text = "Välj startdatum";
            this.buttonSetStartDate.UseVisualStyleBackColor = true;
            this.buttonSetStartDate.Click += new System.EventHandler(this.buttonSetStartDate_Click);
            // 
            // listBoxGlobalJudges
            // 
            this.listBoxGlobalJudges.FormattingEnabled = true;
            this.listBoxGlobalJudges.Location = new System.Drawing.Point(43, 102);
            this.listBoxGlobalJudges.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxGlobalJudges.Name = "listBoxGlobalJudges";
            this.listBoxGlobalJudges.Size = new System.Drawing.Size(125, 121);
            this.listBoxGlobalJudges.TabIndex = 10;
            // 
            // buttonAddJudgeToContest
            // 
            this.buttonAddJudgeToContest.Location = new System.Drawing.Point(171, 102);
            this.buttonAddJudgeToContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddJudgeToContest.Name = "buttonAddJudgeToContest";
            this.buttonAddJudgeToContest.Size = new System.Drawing.Size(68, 29);
            this.buttonAddJudgeToContest.TabIndex = 11;
            this.buttonAddJudgeToContest.Text = "Lägg till domare";
            this.buttonAddJudgeToContest.UseVisualStyleBackColor = true;
            this.buttonAddJudgeToContest.Click += new System.EventHandler(this.buttonAddJudgeToContest_Click);
            // 
            // buttonRemoveJudgeFromContest
            // 
            this.buttonRemoveJudgeFromContest.Location = new System.Drawing.Point(171, 170);
            this.buttonRemoveJudgeFromContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveJudgeFromContest.Name = "buttonRemoveJudgeFromContest";
            this.buttonRemoveJudgeFromContest.Size = new System.Drawing.Size(68, 29);
            this.buttonRemoveJudgeFromContest.TabIndex = 12;
            this.buttonRemoveJudgeFromContest.Text = "Ta bort domare";
            this.buttonRemoveJudgeFromContest.UseVisualStyleBackColor = true;
            this.buttonRemoveJudgeFromContest.Click += new System.EventHandler(this.buttonRemoveJudgeFromContest_Click);
            // 
            // listBoxLocalJudges
            // 
            this.listBoxLocalJudges.FormattingEnabled = true;
            this.listBoxLocalJudges.Location = new System.Drawing.Point(331, 102);
            this.listBoxLocalJudges.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxLocalJudges.Name = "listBoxLocalJudges";
            this.listBoxLocalJudges.Size = new System.Drawing.Size(125, 121);
            this.listBoxLocalJudges.TabIndex = 13;
            // 
            // buttonAddNewJudgeToDB
            // 
            this.buttonAddNewJudgeToDB.Location = new System.Drawing.Point(5, 102);
            this.buttonAddNewJudgeToDB.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddNewJudgeToDB.Name = "buttonAddNewJudgeToDB";
            this.buttonAddNewJudgeToDB.Size = new System.Drawing.Size(34, 23);
            this.buttonAddNewJudgeToDB.TabIndex = 14;
            this.buttonAddNewJudgeToDB.Text = "Skapa domare";
            this.buttonAddNewJudgeToDB.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewContestantToDB
            // 
            this.buttonAddNewContestantToDB.Location = new System.Drawing.Point(5, 234);
            this.buttonAddNewContestantToDB.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddNewContestantToDB.Name = "buttonAddNewContestantToDB";
            this.buttonAddNewContestantToDB.Size = new System.Drawing.Size(34, 23);
            this.buttonAddNewContestantToDB.TabIndex = 19;
            this.buttonAddNewContestantToDB.Text = "Skapa deltagare";
            this.buttonAddNewContestantToDB.UseVisualStyleBackColor = true;
            // 
            // listBoxLocalContestants
            // 
            this.listBoxLocalContestants.FormattingEnabled = true;
            this.listBoxLocalContestants.Location = new System.Drawing.Point(331, 234);
            this.listBoxLocalContestants.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxLocalContestants.Name = "listBoxLocalContestants";
            this.listBoxLocalContestants.Size = new System.Drawing.Size(125, 121);
            this.listBoxLocalContestants.TabIndex = 18;
            // 
            // buttonRemoveContestantFromContest
            // 
            this.buttonRemoveContestantFromContest.Location = new System.Drawing.Point(171, 302);
            this.buttonRemoveContestantFromContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveContestantFromContest.Name = "buttonRemoveContestantFromContest";
            this.buttonRemoveContestantFromContest.Size = new System.Drawing.Size(68, 29);
            this.buttonRemoveContestantFromContest.TabIndex = 17;
            this.buttonRemoveContestantFromContest.Text = "Ta bort deltagare";
            this.buttonRemoveContestantFromContest.UseVisualStyleBackColor = true;
            this.buttonRemoveContestantFromContest.Click += new System.EventHandler(this.buttonRemoveContestantFromContest_Click);
            // 
            // buttonAddContestantToContest
            // 
            this.buttonAddContestantToContest.Location = new System.Drawing.Point(171, 234);
            this.buttonAddContestantToContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddContestantToContest.Name = "buttonAddContestantToContest";
            this.buttonAddContestantToContest.Size = new System.Drawing.Size(68, 29);
            this.buttonAddContestantToContest.TabIndex = 16;
            this.buttonAddContestantToContest.Text = "Lägg till deltagare";
            this.buttonAddContestantToContest.UseVisualStyleBackColor = true;
            this.buttonAddContestantToContest.Click += new System.EventHandler(this.buttonAddContestantToContest_Click);
            // 
            // listBoxGlobalContestants
            // 
            this.listBoxGlobalContestants.FormattingEnabled = true;
            this.listBoxGlobalContestants.Location = new System.Drawing.Point(43, 234);
            this.listBoxGlobalContestants.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxGlobalContestants.Name = "listBoxGlobalContestants";
            this.listBoxGlobalContestants.Size = new System.Drawing.Size(125, 121);
            this.listBoxGlobalContestants.TabIndex = 15;
            // 
            // buttonGoToSubContest
            // 
            this.buttonGoToSubContest.Location = new System.Drawing.Point(412, 357);
            this.buttonGoToSubContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGoToSubContest.Name = "buttonGoToSubContest";
            this.buttonGoToSubContest.Size = new System.Drawing.Size(68, 29);
            this.buttonGoToSubContest.TabIndex = 20;
            this.buttonGoToSubContest.Text = "OK";
            this.buttonGoToSubContest.UseVisualStyleBackColor = true;
            this.buttonGoToSubContest.Click += new System.EventHandler(this.buttonGoToSubContest_Click);
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(244, 51);
            this.textBoxCity.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(87, 20);
            this.textBoxCity.TabIndex = 21;
            // 
            // buttonSetEndDate
            // 
            this.buttonSetEndDate.Location = new System.Drawing.Point(425, 46);
            this.buttonSetEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSetEndDate.Name = "buttonSetEndDate";
            this.buttonSetEndDate.Size = new System.Drawing.Size(86, 29);
            this.buttonSetEndDate.TabIndex = 22;
            this.buttonSetEndDate.Text = "Välj slutdatum";
            this.buttonSetEndDate.UseVisualStyleBackColor = true;
            this.buttonSetEndDate.Click += new System.EventHandler(this.buttonSetEndDate_Click);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(422, 31);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(35, 13);
            this.labelEndDate.TabIndex = 23;
            this.labelEndDate.Text = "";
            // 
            // labelArena
            // 
            this.labelArena.AutoSize = true;
            this.labelArena.Location = new System.Drawing.Point(241, 36);
            this.labelArena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelArena.Name = "labelArena";
            this.labelArena.Size = new System.Drawing.Size(35, 13);
            this.labelArena.TabIndex = 24;
            this.labelArena.Text = "Arena";
            // 
            // CreateContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateContestView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void buttonSetStartDate_Click(object sender, EventArgs e)
        {
            this.EventSetStartDate?.Invoke();
        }
        private void buttonSetEndDate_Click(object sender, EventArgs e)
        {
            this.EventSetEndDate?.Invoke();
        }

        private void buttonGoToSubContest_Click(object sender, EventArgs e)
        {
            
            this.EventCreateSubContest?.Invoke();
        }

        private void buttonAddJudgeToContest_Click(object sender, EventArgs e)
        {
            this.EventAddJudgeToContest?.Invoke();
        }

        private void buttonAddContestantToContest_Click(object sender, EventArgs e)
        {
            this.EventAddContestantToContest?.Invoke();
        }

        private void buttonRemoveContestantFromContest_Click(object sender, EventArgs e)
        {
            this.EventRemoveContestantFromContest?.Invoke();
        }

        private void buttonRemoveJudgeFromContest_Click(object sender, EventArgs e)
        {
            this.EventRemoveJudgeFromContest?.Invoke();
        }


    }
}
