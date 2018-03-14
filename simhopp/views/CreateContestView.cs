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
        private Label labelContestContestants;
        private Label labelContestJudges;
        private Label labelContestantsFromDB;
        private Label labelJudgesFromDB;
        private Button buttonGoBack;
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
        public event DelegateGoBack EventGoBack;

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
            this.labelJudgesFromDB = new System.Windows.Forms.Label();
            this.labelContestantsFromDB = new System.Windows.Forms.Label();
            this.labelContestJudges = new System.Windows.Forms.Label();
            this.labelContestContestants = new System.Windows.Forms.Label();
            this.buttonGoBack = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.buttonGoBack);
            this.mainPanel.Controls.Add(this.labelContestContestants);
            this.mainPanel.Controls.Add(this.labelContestJudges);
            this.mainPanel.Controls.Add(this.labelContestantsFromDB);
            this.mainPanel.Controls.Add(this.labelJudgesFromDB);
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
            this.labelContestInfo.TabIndex = 16;
            this.labelContestInfo.Text = "Tävlingsinformation";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(21, 36);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 17;
            this.labelName.Text = "Namn";
            // 
            // textBoxArena
            // 
            this.textBoxArena.Location = new System.Drawing.Point(244, 51);
            this.textBoxArena.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxArena.Name = "textBoxArena";
            this.textBoxArena.Size = new System.Drawing.Size(87, 20);
            this.textBoxArena.TabIndex = 2;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(130, 36);
            this.labelCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(29, 13);
            this.labelCity.TabIndex = 18;
            this.labelCity.Text = "Stad";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(344, 54);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(0, 13);
            this.labelStartDate.TabIndex = 19;
            // 
            // buttonSetStartDate
            // 
            this.buttonSetStartDate.Location = new System.Drawing.Point(335, 20);
            this.buttonSetStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSetStartDate.Name = "buttonSetStartDate";
            this.buttonSetStartDate.Size = new System.Drawing.Size(94, 29);
            this.buttonSetStartDate.TabIndex = 3;
            this.buttonSetStartDate.Text = "Välj startdatum";
            this.buttonSetStartDate.UseVisualStyleBackColor = true;
            this.buttonSetStartDate.Click += new System.EventHandler(this.buttonSetStartDate_Click);
            // 
            // buttonAddJudgeToContest
            // 
            this.buttonAddJudgeToContest.Location = new System.Drawing.Point(224, 102);
            this.buttonAddJudgeToContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddJudgeToContest.Name = "buttonAddJudgeToContest";
            this.buttonAddJudgeToContest.Size = new System.Drawing.Size(68, 29);
            this.buttonAddJudgeToContest.TabIndex = 7;
            this.buttonAddJudgeToContest.Text = "Lägg till domare";
            this.buttonAddJudgeToContest.UseVisualStyleBackColor = true;
            this.buttonAddJudgeToContest.Click += new System.EventHandler(this.buttonAddJudgeToContest_Click);
            // 
            // buttonRemoveJudgeFromContest
            // 
            this.buttonRemoveJudgeFromContest.Location = new System.Drawing.Point(224, 194);
            this.buttonRemoveJudgeFromContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveJudgeFromContest.Name = "buttonRemoveJudgeFromContest";
            this.buttonRemoveJudgeFromContest.Size = new System.Drawing.Size(68, 29);
            this.buttonRemoveJudgeFromContest.TabIndex = 9;
            this.buttonRemoveJudgeFromContest.Text = "Ta bort domare";
            this.buttonRemoveJudgeFromContest.UseVisualStyleBackColor = true;
            this.buttonRemoveJudgeFromContest.Click += new System.EventHandler(this.buttonRemoveJudgeFromContest_Click);
            // 
            // buttonAddNewJudgeToDB
            // 
            this.buttonAddNewJudgeToDB.Location = new System.Drawing.Point(15, 102);
            this.buttonAddNewJudgeToDB.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddNewJudgeToDB.Name = "buttonAddNewJudgeToDB";
            this.buttonAddNewJudgeToDB.Size = new System.Drawing.Size(20, 20);
            this.buttonAddNewJudgeToDB.TabIndex = 5;
            this.buttonAddNewJudgeToDB.Text = "+";
            this.buttonAddNewJudgeToDB.UseVisualStyleBackColor = true;
            this.buttonAddNewJudgeToDB.Visible = false;
            this.buttonAddNewJudgeToDB.Click += new System.EventHandler(this.ButtonAddNewJudgeToDB_Click);
            // 
            // buttonAddNewContestantToDB
            // 
            this.buttonAddNewContestantToDB.Location = new System.Drawing.Point(15, 242);
            this.buttonAddNewContestantToDB.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddNewContestantToDB.Name = "buttonAddNewContestantToDB";
            this.buttonAddNewContestantToDB.Size = new System.Drawing.Size(20, 20);
            this.buttonAddNewContestantToDB.TabIndex = 10;
            this.buttonAddNewContestantToDB.Text = "+";
            this.buttonAddNewContestantToDB.UseVisualStyleBackColor = true;
            this.buttonAddNewContestantToDB.Click += new System.EventHandler(this.buttonAddNewContestantToDB_Click);
            // 
            // buttonRemoveContestantFromContest
            // 
            this.buttonRemoveContestantFromContest.Location = new System.Drawing.Point(224, 334);
            this.buttonRemoveContestantFromContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveContestantFromContest.Name = "buttonRemoveContestantFromContest";
            this.buttonRemoveContestantFromContest.Size = new System.Drawing.Size(68, 29);
            this.buttonRemoveContestantFromContest.TabIndex = 14;
            this.buttonRemoveContestantFromContest.Text = "Ta bort deltagare";
            this.buttonRemoveContestantFromContest.UseVisualStyleBackColor = true;
            this.buttonRemoveContestantFromContest.Click += new System.EventHandler(this.buttonRemoveContestantFromContest_Click);
            // 
            // buttonAddContestantToContest
            // 
            this.buttonAddContestantToContest.Location = new System.Drawing.Point(224, 242);
            this.buttonAddContestantToContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddContestantToContest.Name = "buttonAddContestantToContest";
            this.buttonAddContestantToContest.Size = new System.Drawing.Size(68, 29);
            this.buttonAddContestantToContest.TabIndex = 12;
            this.buttonAddContestantToContest.Text = "Lägg till deltagare";
            this.buttonAddContestantToContest.UseVisualStyleBackColor = true;
            this.buttonAddContestantToContest.Click += new System.EventHandler(this.buttonAddContestantToContest_Click);
            // 
            // buttonGoToSubContest
            // 
            this.buttonGoToSubContest.Location = new System.Drawing.Point(412, 368);
            this.buttonGoToSubContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGoToSubContest.Name = "buttonGoToSubContest";
            this.buttonGoToSubContest.Size = new System.Drawing.Size(68, 22);
            this.buttonGoToSubContest.TabIndex = 15;
            this.buttonGoToSubContest.Text = "OK";
            this.buttonGoToSubContest.UseVisualStyleBackColor = true;
            this.buttonGoToSubContest.Click += new System.EventHandler(this.buttonGoToSubContest_Click);
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(133, 51);
            this.textBoxCity.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(87, 20);
            this.textBoxCity.TabIndex = 1;
            // 
            // buttonSetEndDate
            // 
            this.buttonSetEndDate.Location = new System.Drawing.Point(425, 20);
            this.buttonSetEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSetEndDate.Name = "buttonSetEndDate";
            this.buttonSetEndDate.Size = new System.Drawing.Size(86, 29);
            this.buttonSetEndDate.TabIndex = 4;
            this.buttonSetEndDate.Text = "Välj slutdatum";
            this.buttonSetEndDate.UseVisualStyleBackColor = true;
            this.buttonSetEndDate.Click += new System.EventHandler(this.buttonSetEndDate_Click);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(434, 54);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(0, 13);
            this.labelEndDate.TabIndex = 20;
            // 
            // labelArena
            // 
            this.labelArena.AutoSize = true;
            this.labelArena.Location = new System.Drawing.Point(241, 36);
            this.labelArena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelArena.Name = "labelArena";
            this.labelArena.Size = new System.Drawing.Size(40, 13);
            this.labelArena.TabIndex = 21;
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
            this.listViewGlobalJudges.TabIndex = 6;
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
            this.listViewLocalJudges.TabIndex = 8;
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
            this.listViewGlobalContestants.Location = new System.Drawing.Point(43, 242);
            this.listViewGlobalContestants.Name = "listViewGlobalContestants";
            this.listViewGlobalContestants.Size = new System.Drawing.Size(147, 121);
            this.listViewGlobalContestants.TabIndex = 11;
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
            this.listViewLocalContestants.Location = new System.Drawing.Point(333, 242);
            this.listViewLocalContestants.Name = "listViewLocalContestants";
            this.listViewLocalContestants.Size = new System.Drawing.Size(147, 121);
            this.listViewLocalContestants.TabIndex = 13;
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
            // labelJudgesFromDB
            // 
            this.labelJudgesFromDB.AutoSize = true;
            this.labelJudgesFromDB.Location = new System.Drawing.Point(40, 86);
            this.labelJudgesFromDB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelJudgesFromDB.Name = "labelJudgesFromDB";
            this.labelJudgesFromDB.Size = new System.Drawing.Size(83, 13);
            this.labelJudgesFromDB.TabIndex = 22;
            this.labelJudgesFromDB.Text = "Domare från DB";
            // 
            // labelContestantsFromDB
            // 
            this.labelContestantsFromDB.AutoSize = true;
            this.labelContestantsFromDB.Location = new System.Drawing.Point(40, 226);
            this.labelContestantsFromDB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContestantsFromDB.Name = "labelContestantsFromDB";
            this.labelContestantsFromDB.Size = new System.Drawing.Size(92, 13);
            this.labelContestantsFromDB.TabIndex = 23;
            this.labelContestantsFromDB.Text = "Deltagare från DB";
            // 
            // labelContestJudges
            // 
            this.labelContestJudges.AutoSize = true;
            this.labelContestJudges.Location = new System.Drawing.Point(330, 86);
            this.labelContestJudges.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContestJudges.Name = "labelContestJudges";
            this.labelContestJudges.Size = new System.Drawing.Size(83, 13);
            this.labelContestJudges.TabIndex = 30;
            this.labelContestJudges.Text = "Domare i tävling";
            // 
            // labelContestContestants
            // 
            this.labelContestContestants.AutoSize = true;
            this.labelContestContestants.Location = new System.Drawing.Point(330, 226);
            this.labelContestContestants.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContestContestants.Name = "labelContestContestants";
            this.labelContestContestants.Size = new System.Drawing.Size(92, 13);
            this.labelContestContestants.TabIndex = 31;
            this.labelContestContestants.Text = "Deltagare i tävling";
            // 
            // buttonGoBack
            // 
            this.buttonGoBack.Location = new System.Drawing.Point(4, 4);
            this.buttonGoBack.Name = "buttonGoBack";
            this.buttonGoBack.Size = new System.Drawing.Size(15, 21);
            this.buttonGoBack.TabIndex = 32;
            this.buttonGoBack.Text = "<";
            this.buttonGoBack.UseVisualStyleBackColor = true;
            this.buttonGoBack.Click += new System.EventHandler(this.buttonGoBack_Click);
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

        private void buttonAddNewContestantToDB_Click(object sender, EventArgs e)
        {
            this.EventAddContestantToDB?.Invoke();
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

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            this.EventGoBack?.Invoke();
        }
    }
}
