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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxArena;
        private Label labelName;
        private System.Windows.Forms.Label labelContestInfo;
        private System.Windows.Forms.TextBox textBoxCity;
        private Label labelEndDate;
        private Button buttonSetEndDate;
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
            this.label1 = new System.Windows.Forms.Label();
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
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
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
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.textBoxArena);
            this.mainPanel.Controls.Add(this.labelName);
            this.mainPanel.Controls.Add(this.labelContestInfo);
            this.mainPanel.Controls.Add(this.textBoxName);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(68, 56);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(129, 26);
            this.textBoxName.TabIndex = 0;
            // 
            // labelContestInfo
            // 
            this.labelContestInfo.AutoSize = true;
            this.labelContestInfo.Location = new System.Drawing.Point(52, 19);
            this.labelContestInfo.Name = "labelContestInfo";
            this.labelContestInfo.Size = new System.Drawing.Size(145, 20);
            this.labelContestInfo.TabIndex = 1;
            this.labelContestInfo.Text = "Tävlingsinformation";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 56);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(51, 20);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "label1";
            // 
            // textBoxArena
            // 
            this.textBoxArena.Location = new System.Drawing.Point(257, 56);
            this.textBoxArena.Name = "textBoxArena";
            this.textBoxArena.Size = new System.Drawing.Size(129, 26);
            this.textBoxArena.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(546, 104);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(51, 20);
            this.labelStartDate.TabIndex = 7;
            this.labelStartDate.Text = "label1";
            // 
            // buttonSetStartDate
            // 
            this.buttonSetStartDate.Location = new System.Drawing.Point(550, 56);
            this.buttonSetStartDate.Name = "buttonSetStartDate";
            this.buttonSetStartDate.Size = new System.Drawing.Size(102, 45);
            this.buttonSetStartDate.TabIndex = 9;
            this.buttonSetStartDate.Text = "Välj startdatum";
            this.buttonSetStartDate.UseVisualStyleBackColor = true;
            this.buttonSetStartDate.Click += new System.EventHandler(this.buttonSetStartDate_Click);
            // 
            // listBoxGlobalJudges
            // 
            this.listBoxGlobalJudges.FormattingEnabled = true;
            this.listBoxGlobalJudges.ItemHeight = 20;
            this.listBoxGlobalJudges.Location = new System.Drawing.Point(65, 157);
            this.listBoxGlobalJudges.Name = "listBoxGlobalJudges";
            this.listBoxGlobalJudges.Size = new System.Drawing.Size(186, 184);
            this.listBoxGlobalJudges.TabIndex = 10;
            // 
            // buttonAddJudgeToContest
            // 
            this.buttonAddJudgeToContest.Location = new System.Drawing.Point(257, 157);
            this.buttonAddJudgeToContest.Name = "buttonAddJudgeToContest";
            this.buttonAddJudgeToContest.Size = new System.Drawing.Size(102, 45);
            this.buttonAddJudgeToContest.TabIndex = 11;
            this.buttonAddJudgeToContest.Text = "Lägg till domare";
            this.buttonAddJudgeToContest.UseVisualStyleBackColor = true;
            this.buttonAddJudgeToContest.Click += new System.EventHandler(this.buttonAddJudgeToContest_Click);
            // 
            // buttonRemoveJudgeFromContest
            // 
            this.buttonRemoveJudgeFromContest.Location = new System.Drawing.Point(257, 261);
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
            this.buttonAddNewJudgeToDB.Location = new System.Drawing.Point(7, 157);
            this.buttonAddNewJudgeToDB.Name = "buttonAddNewJudgeToDB";
            this.buttonAddNewJudgeToDB.Size = new System.Drawing.Size(51, 35);
            this.buttonAddNewJudgeToDB.TabIndex = 14;
            this.buttonAddNewJudgeToDB.Text = "Skapa domare";
            this.buttonAddNewJudgeToDB.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewContestantToDB
            // 
            this.buttonAddNewContestantToDB.Location = new System.Drawing.Point(7, 360);
            this.buttonAddNewContestantToDB.Name = "buttonAddNewContestantToDB";
            this.buttonAddNewContestantToDB.Size = new System.Drawing.Size(51, 35);
            this.buttonAddNewContestantToDB.TabIndex = 19;
            this.buttonAddNewContestantToDB.Text = "Skapa deltagare";
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
            this.buttonRemoveContestantFromContest.Location = new System.Drawing.Point(257, 464);
            this.buttonRemoveContestantFromContest.Name = "buttonRemoveContestantFromContest";
            this.buttonRemoveContestantFromContest.Size = new System.Drawing.Size(102, 45);
            this.buttonRemoveContestantFromContest.TabIndex = 17;
            this.buttonRemoveContestantFromContest.Text = "Ta bort deltagare";
            this.buttonRemoveContestantFromContest.UseVisualStyleBackColor = true;
            this.buttonRemoveContestantFromContest.Click += new System.EventHandler(this.buttonRemoveContestantFromContest_Click);
            // 
            // buttonAddContestantToContest
            // 
            this.buttonAddContestantToContest.Location = new System.Drawing.Point(257, 360);
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
            this.listBoxGlobalContestants.Location = new System.Drawing.Point(65, 360);
            this.listBoxGlobalContestants.Name = "listBoxGlobalContestants";
            this.listBoxGlobalContestants.Size = new System.Drawing.Size(186, 184);
            this.listBoxGlobalContestants.TabIndex = 15;
            // 
            // buttonGoToSubContest
            // 
            this.buttonGoToSubContest.Location = new System.Drawing.Point(618, 550);
            this.buttonGoToSubContest.Name = "buttonGoToSubContest";
            this.buttonGoToSubContest.Size = new System.Drawing.Size(102, 45);
            this.buttonGoToSubContest.TabIndex = 20;
            this.buttonGoToSubContest.Text = "OK";
            this.buttonGoToSubContest.UseVisualStyleBackColor = true;
            this.buttonGoToSubContest.Click += new System.EventHandler(this.buttonGoToSubContest_Click);
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(415, 56);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(129, 26);
            this.textBoxCity.TabIndex = 21;
            // 
            // buttonSetEndDate
            // 
            this.buttonSetEndDate.Location = new System.Drawing.Point(658, 56);
            this.buttonSetEndDate.Name = "buttonSetEndDate";
            this.buttonSetEndDate.Size = new System.Drawing.Size(102, 45);
            this.buttonSetEndDate.TabIndex = 22;
            this.buttonSetEndDate.Text = "Välj startdatum";
            this.buttonSetEndDate.UseVisualStyleBackColor = true;
            this.buttonSetEndDate.Click += new System.EventHandler(this.buttonSetEndDate_Click);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(669, 104);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(51, 20);
            this.labelEndDate.TabIndex = 23;
            this.labelEndDate.Text = "label1";
            // 
            // CreateContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.Location = new System.Drawing.Point(0, 0);
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
