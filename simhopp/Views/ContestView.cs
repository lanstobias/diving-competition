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
        private System.Windows.Forms.ListBox listBoxDives;
        private System.Windows.Forms.Label labelContestants;
        private System.Windows.Forms.ListBox listBoxContestants;
        private System.Windows.Forms.Label labelSubContests;
        private System.Windows.Forms.ComboBox comboBoxSubContests;
        private Label labelStartDate;
        private Label labelArena;
        private Label labelCity;
        private Label labelEndDate;
        private Button buttonCloseContest;
        private Button buttonPause;
        private Button buttonCancelModify;
        private System.Windows.Forms.Label labelContestName;

        public event DelegateAddJump EventAddJump;
        public event DelegateSubContestSelection EventSubContestSelection;
        public event DelegateContestantSelection EventContestantSelection;
        public event DelegatePauseContest EventPauseContest;
        public event DelegateCloseContest EventCloseContest;
        public event DelegateDiveSelection EventDiveSelection;
        public event DelegateModifyDive EventModifyDive;

        public ComboBox ComboBoxSubContests { get { return comboBoxSubContests; } set { comboBoxSubContests = value; } }
        public ListBox ListBoxContestants { get { return listBoxContestants; } set { listBoxContestants = value; } }
        public ListBox ListBoxDives { get { return listBoxDives; } set { listBoxDives = value; } }
        public Label LabelContestName { get { return labelContestName; }set { labelContestName = value; } }
        public Label LabelCity { get { return labelCity; } set { labelCity = value; } }
        public Label LabelArena { get { return labelArena; } set { labelArena = value; } }
        public Label LabelStartDate { get { return labelStartDate; } set { labelStartDate = value; } }
        public Label LabelEndDate { get { return labelEndDate; } set { labelEndDate = value; } }

        public Button ButtonModifyDive { get { return buttonModifyDive; } set { buttonModifyDive = value; } }
        public ContestView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelContestName = new System.Windows.Forms.Label();
            this.comboBoxSubContests = new System.Windows.Forms.ComboBox();
            this.labelSubContests = new System.Windows.Forms.Label();
            this.listBoxContestants = new System.Windows.Forms.ListBox();
            this.labelContestants = new System.Windows.Forms.Label();
            this.labelDives = new System.Windows.Forms.Label();
            this.listBoxDives = new System.Windows.Forms.ListBox();
            this.buttonAddJump = new System.Windows.Forms.Button();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelArena = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonCloseContest = new System.Windows.Forms.Button();
            this.buttonModifyDive = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.buttonModifyDive);
            this.mainPanel.Controls.Add(this.buttonCloseContest);
            this.mainPanel.Controls.Add(this.buttonPause);
            this.mainPanel.Controls.Add(this.labelEndDate);
            this.mainPanel.Controls.Add(this.labelStartDate);
            this.mainPanel.Controls.Add(this.labelArena);
            this.mainPanel.Controls.Add(this.labelCity);
            this.mainPanel.Controls.Add(this.buttonAddJump);
            this.mainPanel.Controls.Add(this.labelDives);
            this.mainPanel.Controls.Add(this.listBoxDives);
            this.mainPanel.Controls.Add(this.labelContestants);
            this.mainPanel.Controls.Add(this.listBoxContestants);
            this.mainPanel.Controls.Add(this.labelSubContests);
            this.mainPanel.Controls.Add(this.comboBoxSubContests);
            this.mainPanel.Controls.Add(this.labelContestName);
            // 
            // labelContestName
            // 
            this.labelContestName.AutoSize = true;
            this.labelContestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelContestName.Location = new System.Drawing.Point(34, 23);
            this.labelContestName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContestName.Name = "labelContestName";
            this.labelContestName.Size = new System.Drawing.Size(171, 29);
            this.labelContestName.TabIndex = 0;
            this.labelContestName.Text = "Contest name";
            // 
            // comboBoxSubContests
            // 
            this.comboBoxSubContests.FormattingEnabled = true;
            this.comboBoxSubContests.Location = new System.Drawing.Point(40, 145);
            this.comboBoxSubContests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxSubContests.Name = "comboBoxSubContests";
            this.comboBoxSubContests.Size = new System.Drawing.Size(180, 28);
            this.comboBoxSubContests.TabIndex = 1;
            this.comboBoxSubContests.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSubContests_SelectedIndexChanged);
            // 
            // labelSubContests
            // 
            this.labelSubContests.AutoSize = true;
            this.labelSubContests.Location = new System.Drawing.Point(40, 120);
            this.labelSubContests.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSubContests.Name = "labelSubContests";
            this.labelSubContests.Size = new System.Drawing.Size(92, 20);
            this.labelSubContests.TabIndex = 2;
            this.labelSubContests.Text = "Deltävlingar";
            // 
            // listBoxContestants
            // 
            this.listBoxContestants.FormattingEnabled = true;
            this.listBoxContestants.ItemHeight = 20;
            this.listBoxContestants.Location = new System.Drawing.Point(40, 314);
            this.listBoxContestants.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxContestants.Name = "listBoxContestants";
            this.listBoxContestants.Size = new System.Drawing.Size(180, 224);
            this.listBoxContestants.TabIndex = 3;
            this.listBoxContestants.SelectedIndexChanged += new EventHandler(ListBoxContestants_SelectedIndexChanged);
            // 
            // labelContestants
            // 
            this.labelContestants.AutoSize = true;
            this.labelContestants.Location = new System.Drawing.Point(40, 285);
            this.labelContestants.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContestants.Name = "labelContestants";
            this.labelContestants.Size = new System.Drawing.Size(79, 20);
            this.labelContestants.TabIndex = 4;
            this.labelContestants.Text = "Deltagare";
            // 
            // labelDives
            // 
            this.labelDives.AutoSize = true;
            this.labelDives.Location = new System.Drawing.Point(231, 285);
            this.labelDives.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDives.Name = "labelDives";
            this.labelDives.Size = new System.Drawing.Size(48, 20);
            this.labelDives.TabIndex = 6;
            this.labelDives.Text = "Hopp";
            // 
            // listBoxDives
            // 
            this.listBoxDives.FormattingEnabled = true;
            this.listBoxDives.ItemHeight = 20;
            this.listBoxDives.Location = new System.Drawing.Point(231, 314);
            this.listBoxDives.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxDives.Name = "listBoxDives";
            this.listBoxDives.Size = new System.Drawing.Size(180, 224);
            this.listBoxDives.TabIndex = 5;
            // 
            // buttonAddJump
            // 
            this.buttonAddJump.Location = new System.Drawing.Point(423, 314);
            this.buttonAddJump.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddJump.Name = "buttonAddJump";
            this.buttonAddJump.Size = new System.Drawing.Size(123, 35);
            this.buttonAddJump.TabIndex = 7;
            this.buttonAddJump.Text = "Lägg till hopp";
            this.buttonAddJump.UseVisualStyleBackColor = true;
            this.buttonAddJump.Click += new System.EventHandler(this.ButtonAddJump_Click);
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(236, 31);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(43, 20);
            this.labelCity.TabIndex = 8;
            this.labelCity.Text = "Stad";
            // 
            // labelArena
            // 
            this.labelArena.AutoSize = true;
            this.labelArena.Location = new System.Drawing.Point(312, 32);
            this.labelArena.Name = "labelArena";
            this.labelArena.Size = new System.Drawing.Size(60, 20);
            this.labelArena.TabIndex = 9;
            this.labelArena.Text = "Simhall";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(419, 32);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(86, 20);
            this.labelStartDate.TabIndex = 10;
            this.labelStartDate.Text = "startdatum";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(545, 32);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(79, 20);
            this.labelEndDate.TabIndex = 11;
            this.labelEndDate.Text = "slutdatum";
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(531, 83);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(142, 67);
            this.buttonPause.TabIndex = 12;
            this.buttonPause.Text = "Pausa Tävling";
            this.buttonPause.UseVisualStyleBackColor = true;
            // 
            // buttonCloseContest
            // 
            this.buttonCloseContest.Location = new System.Drawing.Point(531, 167);
            this.buttonCloseContest.Name = "buttonCloseContest";
            this.buttonCloseContest.Size = new System.Drawing.Size(142, 67);
            this.buttonCloseContest.TabIndex = 13;
            this.buttonCloseContest.Text = "Avsluta";
            this.buttonCloseContest.UseVisualStyleBackColor = true;
            // 
            // buttonModifyDive
            // 
            this.buttonModifyDive.Location = new System.Drawing.Point(282, 233);
            this.buttonModifyDive.Name = "buttonModifyDive";
            this.buttonModifyDive.Size = new System.Drawing.Size(82, 23);
            this.buttonModifyDive.TabIndex = 14;
            this.buttonModifyDive.Text = "Ändra";
            this.buttonModifyDive.UseVisualStyleBackColor = true;
            this.buttonModifyDive.Visible = false;
            this.buttonModifyDive.Click += new System.EventHandler(this.buttonModifyDive_Click);
            // ContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "ContestView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        private void buttonModifyDive_Click(object sender, EventArgs e)
        {
            this.EventModifyDive?.Invoke();
        }

        private void ListBoxContestants_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventContestantSelection?.Invoke();
        }

        private void ComboBoxSubContests_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventSubContestSelection?.Invoke();
        }

        private void ButtonAddJump_Click(object sender, EventArgs e)
        {
            this.EventAddJump?.Invoke();
        }
    }
}
