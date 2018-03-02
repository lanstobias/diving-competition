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
            this.textBoxName.Location = new System.Drawing.Point(36, 78);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(128, 26);
            this.textBoxName.TabIndex = 0;
            // 
            // labelContestInfo
            // 
            this.labelContestInfo.AutoSize = true;
            this.labelContestInfo.Location = new System.Drawing.Point(52, 18);
            this.labelContestInfo.Name = "labelContestInfo";
            this.labelContestInfo.Size = new System.Drawing.Size(145, 20);
            this.labelContestInfo.TabIndex = 1;
            this.labelContestInfo.Text = "Tävlingsinformation";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(32, 55);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(51, 20);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Namn";
            // 
            // textBoxArena
            // 
            this.textBoxArena.Location = new System.Drawing.Point(200, 78);
            this.textBoxArena.Name = "textBoxArena";
            this.textBoxArena.Size = new System.Drawing.Size(128, 26);
            this.textBoxArena.TabIndex = 3;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(195, 55);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(43, 20);
            this.labelCity.TabIndex = 6;
            this.labelCity.Text = "Stad";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(498, 48);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(0, 20);
            this.labelStartDate.TabIndex = 7;
            // 
            // buttonSetStartDate
            // 
            this.buttonSetStartDate.Location = new System.Drawing.Point(502, 71);
            this.buttonSetStartDate.Name = "buttonSetStartDate";
            this.buttonSetStartDate.Size = new System.Drawing.Size(141, 45);
            this.buttonSetStartDate.TabIndex = 9;
            this.buttonSetStartDate.Text = "Välj startdatum";
            this.buttonSetStartDate.UseVisualStyleBackColor = true;
            this.buttonSetStartDate.Click += new System.EventHandler(this.buttonSetStartDate_Click);
            // 
            // listBoxGlobalJudges
            // 
            this.listBoxGlobalJudges.FormattingEnabled = true;
            this.listBoxGlobalJudges.ItemHeight = 20;
            this.listBoxGlobalJudges.Location = new System.Drawing.Point(64, 157);
            this.listBoxGlobalJudges.Name = "listBoxGlobalJudges";
            this.listBoxGlobalJudges.Size = new System.Drawing.Size(186, 184);
            this.listBoxGlobalJudges.TabIndex = 10;
            // 
            // buttonAddJudgeToContest
            // 
            this.buttonAddJudgeToContest.Location = new System.Drawing.Point(256, 157);
            this.buttonAddJudgeToContest.Name = "buttonAddJudgeToContest";
            this.buttonAddJudgeToContest.Size = new System.Drawing.Size(102, 45);
            this.buttonAddJudgeToContest.TabIndex = 11;
            this.buttonAddJudgeToContest.Text = "Lägg till domare";
            this.buttonAddJudgeToContest.UseVisualStyleBackColor = true;
            this.buttonAddJudgeToContest.Click += new System.EventHandler(this.buttonAddJudgeToContest_Click);
            // 
            // buttonRemoveJudgeFromContest
            // 
            this.buttonRemoveJudgeFromContest.Location = new System.Drawing.Point(256, 262);
            this.buttonRemoveJudgeFromContest.Name = "buttonRemoveJudgeFromContest";
            this.buttonRemoveJudgeFromContest.Size = new System.Drawing.Size(102, 45);
            this.buttonRemoveJudgeFromContest.TabIndex = 12;
            this.buttonRemoveJudgeFromContest.Text = "Ta bort domare";
            this.buttonRemoveJudgeFromContest.UseVisualStyleBackColor = true;
            this.buttonRemoveJudgeFromContest.Click += new System.EventHandler(this.buttonRemoveJudgeFromContest_Click);
            // 
            // listBoxLocalJudges
            // 
            this.listBoxLocalJudges.FormattingEnabled = true;
            this.listBoxLocalJudges.ItemHeight = 20;
            this.listBoxLocalJudges.Location = new System.Drawing.Point(496, 157);
            this.listBoxLocalJudges.Name = "listBoxLocalJudges";
            this.listBoxLocalJudges.Size = new System.Drawing.Size(186, 184);
            this.listBoxLocalJudges.TabIndex = 13;
            // 
            // buttonAddNewJudgeToDB
            // 
            this.buttonAddNewJudgeToDB.Location = new System.Drawing.Point(22, 157);
            this.buttonAddNewJudgeToDB.Name = "buttonAddNewJudgeToDB";
            this.buttonAddNewJudgeToDB.Size = new System.Drawing.Size(30, 31);
            this.buttonAddNewJudgeToDB.TabIndex = 14;
            this.buttonAddNewJudgeToDB.Text = "+";
            this.buttonAddNewJudgeToDB.UseVisualStyleBackColor = true;
            this.buttonAddNewJudgeToDB.Click += new System.EventHandler(this.ButtonAddNewJudgeToDB_Click);
            // 
            // buttonAddNewContestantToDB
            // 
            this.buttonAddNewContestantToDB.Location = new System.Drawing.Point(22, 360);
            this.buttonAddNewContestantToDB.Name = "buttonAddNewContestantToDB";
            this.buttonAddNewContestantToDB.Size = new System.Drawing.Size(30, 31);
            this.buttonAddNewContestantToDB.TabIndex = 19;
            this.buttonAddNewContestantToDB.Text = "+";
            this.buttonAddNewContestantToDB.UseVisualStyleBackColor = true;
            // 
            // listBoxLocalContestants
            // 
            this.listBoxLocalContestants.FormattingEnabled = true;
            this.listBoxLocalContestants.ItemHeight = 20;
            this.listBoxLocalContestants.Location = new System.Drawing.Point(496, 360);
            this.listBoxLocalContestants.Name = "listBoxLocalContestants";
            this.listBoxLocalContestants.Size = new System.Drawing.Size(186, 184);
            this.listBoxLocalContestants.TabIndex = 18;
            // 
            // buttonRemoveContestantFromContest
            // 
            this.buttonRemoveContestantFromContest.Location = new System.Drawing.Point(256, 465);
            this.buttonRemoveContestantFromContest.Name = "buttonRemoveContestantFromContest";
            this.buttonRemoveContestantFromContest.Size = new System.Drawing.Size(102, 45);
            this.buttonRemoveContestantFromContest.TabIndex = 17;
            this.buttonRemoveContestantFromContest.Text = "Ta bort deltagare";
            this.buttonRemoveContestantFromContest.UseVisualStyleBackColor = true;
            this.buttonRemoveContestantFromContest.Click += new System.EventHandler(this.buttonRemoveContestantFromContest_Click);
            // 
            // buttonAddContestantToContest
            // 
            this.buttonAddContestantToContest.Location = new System.Drawing.Point(256, 360);
            this.buttonAddContestantToContest.Name = "buttonAddContestantToContest";
            this.buttonAddContestantToContest.Size = new System.Drawing.Size(102, 45);
            this.buttonAddContestantToContest.TabIndex = 16;
            this.buttonAddContestantToContest.Text = "Lägg till deltagare";
            this.buttonAddContestantToContest.UseVisualStyleBackColor = true;
            this.buttonAddContestantToContest.Click += new System.EventHandler(this.buttonAddContestantToContest_Click);
            // 
            // listBoxGlobalContestants
            // 
            this.listBoxGlobalContestants.FormattingEnabled = true;
            this.listBoxGlobalContestants.ItemHeight = 20;
            this.listBoxGlobalContestants.Location = new System.Drawing.Point(64, 360);
            this.listBoxGlobalContestants.Name = "listBoxGlobalContestants";
            this.listBoxGlobalContestants.Size = new System.Drawing.Size(186, 184);
            this.listBoxGlobalContestants.TabIndex = 15;
            // 
            // buttonGoToSubContest
            // 
            this.buttonGoToSubContest.Location = new System.Drawing.Point(618, 549);
            this.buttonGoToSubContest.Name = "buttonGoToSubContest";
            this.buttonGoToSubContest.Size = new System.Drawing.Size(102, 45);
            this.buttonGoToSubContest.TabIndex = 20;
            this.buttonGoToSubContest.Text = "OK";
            this.buttonGoToSubContest.UseVisualStyleBackColor = true;
            this.buttonGoToSubContest.Click += new System.EventHandler(this.buttonGoToSubContest_Click);
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(366, 78);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(128, 26);
            this.textBoxCity.TabIndex = 21;
            // 
            // buttonSetEndDate
            // 
            this.buttonSetEndDate.Location = new System.Drawing.Point(638, 71);
            this.buttonSetEndDate.Name = "buttonSetEndDate";
            this.buttonSetEndDate.Size = new System.Drawing.Size(129, 45);
            this.buttonSetEndDate.TabIndex = 22;
            this.buttonSetEndDate.Text = "Välj slutdatum";
            this.buttonSetEndDate.UseVisualStyleBackColor = true;
            this.buttonSetEndDate.Click += new System.EventHandler(this.buttonSetEndDate_Click);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(633, 48);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(0, 20);
            this.labelEndDate.TabIndex = 23;
            // 
            // labelArena
            // 
            this.labelArena.AutoSize = true;
            this.labelArena.Location = new System.Drawing.Point(362, 55);
            this.labelArena.Name = "labelArena";
            this.labelArena.Size = new System.Drawing.Size(60, 20);
            this.labelArena.TabIndex = 24;
            this.labelArena.Text = "Simhall";
            // 
            // CreateContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "CreateContestView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void ButtonAddNewJudgeToDB_Click(object sender, EventArgs e)
        {
            this.EventAddJudgeToDB?.Invoke();
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
