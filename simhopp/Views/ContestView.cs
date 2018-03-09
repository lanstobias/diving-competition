using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class ContestView : PanelViewControl, IContestView
    {
        private System.Windows.Forms.Button buttonAddJump;
        private System.Windows.Forms.Label labelDives;
        private System.Windows.Forms.Label labelContestants;
        private System.Windows.Forms.Label labelSubContests;
        private System.Windows.Forms.ComboBox comboBoxSubContests;
        private Label labelStartDate;
        private Label labelArena;
        private Label labelCity;
        private Label labelEndDate;
        private Button buttonCloseContest;
        private Button buttonPause;
        private Button buttonCancelModify;
        private Button buttonRemoveDive;
        private Button buttonModifyDive;
        private Button buttonRequestPoints;
        private ListView listViewJudgeClients;
        private ListView listViewDives;
        private ColumnHeader columnCode;
        private ColumnHeader columnMultiplier;
        private ListView listViewContestants;
        private ColumnHeader columnFirstName;
        private ColumnHeader columnLastName;
        private System.Windows.Forms.Label labelContestName;
        private System.Windows.Forms.ColumnHeader columnJudge;
        private Button buttonCollectPoints;
        private System.Windows.Forms.ColumnHeader columnPoints;

        public event DelegateAddJump EventAddJump;
        public event DelegateSubContestSelection EventSubContestSelection;
        public event DelegateContestantSelection EventContestantSelection;
        public event DelegatePauseContest EventPauseContest;
        public event DelegateCloseContest EventCloseContest;
        public event DelegateDiveSelection EventDiveSelection;
        public event DelegateModifyDive EventModifyDive;
        public event DelegateCancelDiveEdit EventCancelDiveEdit;
        public event DelegateRemoveDive EventRemoveDive;
        public event DelegateRequestPoints EventRequestPoints;
        public event DelegateCollectPoints EventCollectPoints;

        public ComboBox ComboBoxSubContests { get { return comboBoxSubContests; } set { comboBoxSubContests = value; } }
        public ListView ListViewContestants { get { return listViewContestants; } set { listViewContestants = value; } }
        public ListView ListViewDives { get { return listViewDives; } set { listViewDives = value; } }
        public Label LabelContestName { get { return labelContestName; }set { labelContestName = value; } }
        public Label LabelCity { get { return labelCity; } set { labelCity = value; } }
        public Label LabelArena { get { return labelArena; } set { labelArena = value; } }
        public Label LabelStartDate { get { return labelStartDate; } set { labelStartDate = value; } }
        public Label LabelEndDate { get { return labelEndDate; } set { labelEndDate = value; } }

        public Button ButtonModifyDive { get { return buttonModifyDive; } set { buttonModifyDive = value; } }
        public Button ButtonRemoveDive { get { return buttonRemoveDive; } set { buttonRemoveDive = value; } }
        public Button ButtonCancelModify { get { return buttonCancelModify; } set { buttonCancelModify = value; } }
        public Button ButtonRequestPoints { get { return buttonRequestPoints; } set { buttonRequestPoints = value; } }
        public ListView ListViewJudgeClients { get { return listViewJudgeClients; } set { listViewJudgeClients = value; } }

        public ContestView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelContestName = new System.Windows.Forms.Label();
            this.comboBoxSubContests = new System.Windows.Forms.ComboBox();
            this.labelSubContests = new System.Windows.Forms.Label();
            this.labelContestants = new System.Windows.Forms.Label();
            this.labelDives = new System.Windows.Forms.Label();
            this.buttonAddJump = new System.Windows.Forms.Button();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelArena = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonCloseContest = new System.Windows.Forms.Button();
            this.buttonModifyDive = new System.Windows.Forms.Button();
            this.buttonRemoveDive = new System.Windows.Forms.Button();
            this.buttonCancelModify = new System.Windows.Forms.Button();
            this.buttonRequestPoints = new System.Windows.Forms.Button();
            this.listViewJudgeClients = new System.Windows.Forms.ListView();
            this.columnJudge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPoints = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewContestants = new System.Windows.Forms.ListView();
            this.columnFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewDives = new System.Windows.Forms.ListView();
            this.columnCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMultiplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonCollectPoints = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.buttonCollectPoints);
            this.mainPanel.Controls.Add(this.listViewJudgeClients);
            this.mainPanel.Controls.Add(this.buttonRequestPoints);
            this.mainPanel.Controls.Add(this.listViewDives);
            this.mainPanel.Controls.Add(this.listViewContestants);
            this.mainPanel.Controls.Add(this.buttonCancelModify);
            this.mainPanel.Controls.Add(this.buttonRemoveDive);
            this.mainPanel.Controls.Add(this.buttonModifyDive);
            this.mainPanel.Controls.Add(this.buttonCloseContest);
            this.mainPanel.Controls.Add(this.buttonPause);
            this.mainPanel.Controls.Add(this.labelEndDate);
            this.mainPanel.Controls.Add(this.labelStartDate);
            this.mainPanel.Controls.Add(this.labelArena);
            this.mainPanel.Controls.Add(this.labelCity);
            this.mainPanel.Controls.Add(this.buttonAddJump);
            this.mainPanel.Controls.Add(this.labelDives);
            this.mainPanel.Controls.Add(this.labelContestants);
            this.mainPanel.Controls.Add(this.labelSubContests);
            this.mainPanel.Controls.Add(this.comboBoxSubContests);
            this.mainPanel.Controls.Add(this.labelContestName);
            // 
            // labelContestName
            // 
            this.labelContestName.AutoSize = true;
            this.labelContestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelContestName.Location = new System.Drawing.Point(23, 15);
            this.labelContestName.Name = "labelContestName";
            this.labelContestName.Size = new System.Drawing.Size(113, 20);
            this.labelContestName.TabIndex = 11;
            this.labelContestName.Text = "Contest name";
            // 
            // comboBoxSubContests
            // 
            this.comboBoxSubContests.FormattingEnabled = true;
            this.comboBoxSubContests.Location = new System.Drawing.Point(27, 94);
            this.comboBoxSubContests.Name = "comboBoxSubContests";
            this.comboBoxSubContests.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSubContests.TabIndex = 0;
            this.comboBoxSubContests.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSubContests_SelectedIndexChanged);
            // 
            // labelSubContests
            // 
            this.labelSubContests.AutoSize = true;
            this.labelSubContests.Location = new System.Drawing.Point(27, 78);
            this.labelSubContests.Name = "labelSubContests";
            this.labelSubContests.Size = new System.Drawing.Size(63, 13);
            this.labelSubContests.TabIndex = 12;
            this.labelSubContests.Text = "Deltävlingar";
            // 
            // labelContestants
            // 
            this.labelContestants.AutoSize = true;
            this.labelContestants.Location = new System.Drawing.Point(27, 185);
            this.labelContestants.Name = "labelContestants";
            this.labelContestants.Size = new System.Drawing.Size(53, 13);
            this.labelContestants.TabIndex = 13;
            this.labelContestants.Text = "Deltagare";
            // 
            // labelDives
            // 
            this.labelDives.AutoSize = true;
            this.labelDives.Location = new System.Drawing.Point(154, 185);
            this.labelDives.Name = "labelDives";
            this.labelDives.Size = new System.Drawing.Size(33, 13);
            this.labelDives.TabIndex = 14;
            this.labelDives.Text = "Hopp";
            // 
            // buttonAddJump
            // 
            this.buttonAddJump.Location = new System.Drawing.Point(282, 204);
            this.buttonAddJump.Name = "buttonAddJump";
            this.buttonAddJump.Size = new System.Drawing.Size(82, 23);
            this.buttonAddJump.TabIndex = 3;
            this.buttonAddJump.Text = "Lägg till hopp";
            this.buttonAddJump.UseVisualStyleBackColor = true;
            this.buttonAddJump.Click += new System.EventHandler(this.ButtonAddJump_Click);
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(157, 20);
            this.labelCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(29, 13);
            this.labelCity.TabIndex = 15;
            this.labelCity.Text = "Stad";
            // 
            // labelArena
            // 
            this.labelArena.AutoSize = true;
            this.labelArena.Location = new System.Drawing.Point(208, 21);
            this.labelArena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelArena.Name = "labelArena";
            this.labelArena.Size = new System.Drawing.Size(40, 13);
            this.labelArena.TabIndex = 16;
            this.labelArena.Text = "Simhall";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(279, 21);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(56, 13);
            this.labelStartDate.TabIndex = 17;
            this.labelStartDate.Text = "startdatum";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(363, 21);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(52, 13);
            this.labelEndDate.TabIndex = 18;
            this.labelEndDate.Text = "slutdatum";
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(354, 54);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(95, 44);
            this.buttonPause.TabIndex = 9;
            this.buttonPause.Text = "Pausa Tävling";
            this.buttonPause.UseVisualStyleBackColor = true;
            // 
            // buttonCloseContest
            // 
            this.buttonCloseContest.Location = new System.Drawing.Point(354, 109);
            this.buttonCloseContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseContest.Name = "buttonCloseContest";
            this.buttonCloseContest.Size = new System.Drawing.Size(95, 44);
            this.buttonCloseContest.TabIndex = 10;
            this.buttonCloseContest.Text = "Avsluta";
            this.buttonCloseContest.UseVisualStyleBackColor = true;
            this.buttonCloseContest.Click += new System.EventHandler(this.buttonCloseContest_Click);
            // 
            // buttonModifyDive
            // 
            this.buttonModifyDive.Location = new System.Drawing.Point(282, 233);
            this.buttonModifyDive.Name = "buttonModifyDive";
            this.buttonModifyDive.Size = new System.Drawing.Size(82, 23);
            this.buttonModifyDive.TabIndex = 6;
            this.buttonModifyDive.Text = "Ändra";
            this.buttonModifyDive.UseVisualStyleBackColor = true;
            this.buttonModifyDive.Visible = false;
            this.buttonModifyDive.Click += new System.EventHandler(this.buttonModifyDive_Click);
            // 
            // buttonRemoveDive
            // 
            this.buttonRemoveDive.Location = new System.Drawing.Point(281, 262);
            this.buttonRemoveDive.Name = "buttonRemoveDive";
            this.buttonRemoveDive.Size = new System.Drawing.Size(82, 23);
            this.buttonRemoveDive.TabIndex = 7;
            this.buttonRemoveDive.Text = "Ta bort";
            this.buttonRemoveDive.UseVisualStyleBackColor = true;
            this.buttonRemoveDive.Visible = false;
            this.buttonRemoveDive.Click += new System.EventHandler(this.ButtonRemoveDive_Click);
            // 
            // buttonCancelModify
            // 
            this.buttonCancelModify.Location = new System.Drawing.Point(282, 291);
            this.buttonCancelModify.Name = "buttonCancelModify";
            this.buttonCancelModify.Size = new System.Drawing.Size(82, 23);
            this.buttonCancelModify.TabIndex = 8;
            this.buttonCancelModify.Text = "Cancel";
            this.buttonCancelModify.UseVisualStyleBackColor = true;
            this.buttonCancelModify.Visible = false;
            this.buttonCancelModify.Click += new System.EventHandler(this.ButtonCancelModify_Click);
            // 
            // buttonRequestPoints
            // 
            this.buttonRequestPoints.Enabled = false;
            this.buttonRequestPoints.Location = new System.Drawing.Point(369, 204);
            this.buttonRequestPoints.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRequestPoints.Name = "buttonRequestPoints";
            this.buttonRequestPoints.Size = new System.Drawing.Size(132, 22);
            this.buttonRequestPoints.TabIndex = 4;
            this.buttonRequestPoints.Text = "Begär bedömning";
            this.buttonRequestPoints.UseVisualStyleBackColor = true;
            this.buttonRequestPoints.Click += new System.EventHandler(this.buttonRequestPoints_Click);
            // 
            // listViewJudgeClients
            // 
            this.listViewJudgeClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnJudge,
            this.columnPoints});
            this.listViewJudgeClients.Location = new System.Drawing.Point(369, 230);
            this.listViewJudgeClients.Margin = new System.Windows.Forms.Padding(2);
            this.listViewJudgeClients.Name = "listViewJudgeClients";
            this.listViewJudgeClients.Size = new System.Drawing.Size(132, 95);
            this.listViewJudgeClients.TabIndex = 19;
            this.listViewJudgeClients.UseCompatibleStateImageBehavior = false;
            this.listViewJudgeClients.View = System.Windows.Forms.View.Details;
            // 
            // columnJudge
            // 
            this.columnJudge.Text = "Judge";
            // 
            // columnPoints
            // 
            this.columnPoints.Text = "Points";
            // 
            // listViewContestants
            // 
            this.listViewContestants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFirstName,
            this.columnLastName});
            this.listViewContestants.Location = new System.Drawing.Point(17, 204);
            this.listViewContestants.Margin = new System.Windows.Forms.Padding(2);
            this.listViewContestants.Name = "listViewContestants";
            this.listViewContestants.Size = new System.Drawing.Size(121, 147);
            this.listViewContestants.TabIndex = 1;
            this.listViewContestants.UseCompatibleStateImageBehavior = false;
            this.listViewContestants.View = System.Windows.Forms.View.Details;
            this.listViewContestants.SelectedIndexChanged += new System.EventHandler(this.listViewContestants_SelectedIndexChanged);
            // 
            // columnFirstName
            // 
            this.columnFirstName.Text = "Förnamn";
            this.columnFirstName.Width = 63;
            // 
            // columnLastName
            // 
            this.columnLastName.Text = "Efternamn";
            this.columnLastName.Width = 91;
            // 
            // listViewDives
            // 
            this.listViewDives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnCode,
            this.columnMultiplier});
            this.listViewDives.Location = new System.Drawing.Point(154, 204);
            this.listViewDives.Margin = new System.Windows.Forms.Padding(2);
            this.listViewDives.Name = "listViewDives";
            this.listViewDives.Size = new System.Drawing.Size(121, 147);
            this.listViewDives.TabIndex = 2;
            this.listViewDives.UseCompatibleStateImageBehavior = false;
            this.listViewDives.View = System.Windows.Forms.View.Details;
            this.listViewDives.SelectedIndexChanged += new System.EventHandler(this.listViewDives_SelectedIndexChanged);
            // 
            // columnCode
            // 
            this.columnCode.Text = "Code";
            this.columnCode.Width = 61;
            // 
            // columnMultiplier
            // 
            this.columnMultiplier.Text = "Multiplier";
            this.columnMultiplier.Width = 97;
            // 
            // buttonCollectPoints
            // 
            this.buttonCollectPoints.Location = new System.Drawing.Point(366, 329);
            this.buttonCollectPoints.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCollectPoints.Name = "buttonCollectPoints";
            this.buttonCollectPoints.Size = new System.Drawing.Size(135, 22);
            this.buttonCollectPoints.TabIndex = 5;
            this.buttonCollectPoints.Text = "Spara poäng";
            this.buttonCollectPoints.UseVisualStyleBackColor = true;
            this.buttonCollectPoints.Click += new System.EventHandler(this.buttonCollectPoints_Click);
            // 
            // ContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ContestView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        private void buttonModifyDive_Click(object sender, EventArgs e)
        {
            this.EventModifyDive?.Invoke();
        }

        private void ButtonRemoveDive_Click(object sender, EventArgs e)
        {
            this.EventRemoveDive?.Invoke();
        }

        private void ButtonCancelModify_Click(object sender, EventArgs e)
        {
            this.EventCancelDiveEdit?.Invoke();
        }

        private void ComboBoxSubContests_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventSubContestSelection?.Invoke();
        }

        private void ButtonAddJump_Click(object sender, EventArgs e)
        {
            this.EventAddJump?.Invoke();
        }

        private void listViewContestants_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventContestantSelection?.Invoke();
        }

        private void listViewDives_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventDiveSelection?.Invoke();
        }

        private void buttonRequestPoints_Click(object sender, EventArgs e)
        {
            this.EventRequestPoints?.Invoke();
        }

        private void buttonCollectPoints_Click(object sender, EventArgs e)
        {
            this.EventCollectPoints?.Invoke();
        }

        private void buttonCloseContest_Click(object sender, EventArgs e)
        {
            this.EventCloseContest?.Invoke();
        }
    }
}
