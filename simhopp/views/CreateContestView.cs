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
        private System.Windows.Forms.Button buttonRemoveContestantFromContest;
        private System.Windows.Forms.Button buttonAddContestantToContest;
        private System.Windows.Forms.Button buttonAddNewJudgeToDB;
        private System.Windows.Forms.Button buttonRemoveJudgeFromContest;
        private System.Windows.Forms.Button buttonAddJudgeToContest;
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
        private ListView listViewGlobalJudges;
        private ColumnHeader columnFirstName;
        private ColumnHeader columnLastName;
        private ListView listViewLocalJudges;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ListView listViewLocalContestants;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ListView listViewGlobalContestants;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
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
        public Label LabelStartDate { get { return labelStartDate; } set { labelStartDate = value; } }
        public Label LabelEndDate { get { return labelEndDate; } set { labelEndDate = value; } }
        public ListView ListViewGlobalJudges { get { return listViewGlobalJudges; } set { listViewGlobalJudges = value; } }
        public ListView ListViewLocalJudges { get { return listViewLocalJudges; } set { listViewLocalJudges = value; } }
        public ListView ListViewGlobalContestants { get { return listViewGlobalContestants; } set { listViewGlobalContestants = value; } }
        public ListView ListViewLocalContestants { get { return listViewLocalContestants; }set { listViewLocalContestants = value; } } 
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
            this.buttonAddJudgeToContest = new System.Windows.Forms.Button();
            this.buttonRemoveJudgeFromContest = new System.Windows.Forms.Button();
            this.buttonAddNewJudgeToDB = new System.Windows.Forms.Button();
            this.buttonAddNewContestantToDB = new System.Windows.Forms.Button();
            this.buttonRemoveContestantFromContest = new System.Windows.Forms.Button();
            this.buttonAddContestantToContest = new System.Windows.Forms.Button();
            this.buttonGoToSubContest = new System.Windows.Forms.Button();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.buttonSetEndDate = new System.Windows.Forms.Button();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelArena = new System.Windows.Forms.Label();
            this.listViewGlobalJudges = new System.Windows.Forms.ListView();
            this.columnFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewLocalJudges = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewGlobalContestants = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewLocalContestants = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.listViewLocalContestants);
            this.mainPanel.Controls.Add(this.listViewGlobalContestants);
            this.mainPanel.Controls.Add(this.listViewLocalJudges);
            this.mainPanel.Controls.Add(this.listViewGlobalJudges);
            this.mainPanel.Controls.Add(this.labelArena);
            this.mainPanel.Controls.Add(this.labelEndDate);
            this.mainPanel.Controls.Add(this.buttonSetEndDate);
            this.mainPanel.Controls.Add(this.textBoxCity);
            this.mainPanel.Controls.Add(this.buttonGoToSubContest);
            this.mainPanel.Controls.Add(this.buttonAddNewContestantToDB);
            this.mainPanel.Controls.Add(this.buttonRemoveContestantFromContest);
            this.mainPanel.Controls.Add(this.buttonAddContestantToContest);
            this.mainPanel.Controls.Add(this.buttonAddNewJudgeToDB);
            this.mainPanel.Controls.Add(this.buttonRemoveJudgeFromContest);
            this.mainPanel.Controls.Add(this.buttonAddJudgeToContest);
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
            // listViewGlobalJudges
            // 
            this.listViewGlobalJudges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFirstName,
            this.columnLastName});
            this.listViewGlobalJudges.Location = new System.Drawing.Point(43, 102);
            this.listViewGlobalJudges.Name = "listViewGlobalJudges";
            this.listViewGlobalJudges.Size = new System.Drawing.Size(147, 121);
            this.listViewGlobalJudges.TabIndex = 25;
            this.listViewGlobalJudges.UseCompatibleStateImageBehavior = false;
            this.listViewGlobalJudges.View = System.Windows.Forms.View.Details;
            // 
            // columnFirstName
            // 
            this.columnFirstName.Text = "Förnamn";
            // 
            // columnLastName
            // 
            this.columnLastName.Text = "Efternamn";
            // 
            // listViewLocalJudges
            // 
            this.listViewLocalJudges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewLocalJudges.Location = new System.Drawing.Point(333, 102);
            this.listViewLocalJudges.Name = "listViewLocalJudges";
            this.listViewLocalJudges.Size = new System.Drawing.Size(147, 121);
            this.listViewLocalJudges.TabIndex = 26;
            this.listViewLocalJudges.UseCompatibleStateImageBehavior = false;
            this.listViewLocalJudges.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Förnamn";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Efternamn";
            // 
            // listViewGlobalContestants
            // 
            this.listViewGlobalContestants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewGlobalContestants.Location = new System.Drawing.Point(43, 234);
            this.listViewGlobalContestants.Name = "listViewGlobalContestants";
            this.listViewGlobalContestants.Size = new System.Drawing.Size(147, 121);
            this.listViewGlobalContestants.TabIndex = 27;
            this.listViewGlobalContestants.UseCompatibleStateImageBehavior = false;
            this.listViewGlobalContestants.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Förnamn";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Efternamn";
            // 
            // listViewLocalContestants
            // 
            this.listViewLocalContestants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listViewLocalContestants.Location = new System.Drawing.Point(333, 234);
            this.listViewLocalContestants.Name = "listViewLocalContestants";
            this.listViewLocalContestants.Size = new System.Drawing.Size(147, 121);
            this.listViewLocalContestants.TabIndex = 28;
            this.listViewLocalContestants.UseCompatibleStateImageBehavior = false;
            this.listViewLocalContestants.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Förnamn";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Efternamn";
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
