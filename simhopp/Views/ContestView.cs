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
        private Button buttonRemoveDive;
        private Button buttonModifyDive;
        private System.Windows.Forms.Label labelContestName;

        public event DelegateAddJump EventAddJump;
        public event DelegateSubContestSelection EventSubContestSelection;
        public event DelegateContestantSelection EventContestantSelection;
        public event DelegatePauseContest EventPauseContest;
        public event DelegateCloseContest EventCloseContest;
        public event DelegateDiveSelection EventDiveSelection;
        public event DelegateModifyDive EventModifyDive;
        public event DelegateCancelDiveEdit EventCancelDiveEdit;
        public event DelegateRemoveDive EventRemoveDive;

        public ComboBox ComboBoxSubContests { get { return comboBoxSubContests; } set { comboBoxSubContests = value; } }
        public ListBox ListBoxContestants { get { return listBoxContestants; } set { listBoxContestants = value; } }
        public ListBox ListBoxDives { get { return listBoxDives; } set { listBoxDives = value; } }
        public Label LabelContestName { get { return labelContestName; }set { labelContestName = value; } }
        public Label LabelCity { get { return labelCity; } set { labelCity = value; } }
        public Label LabelArena { get { return labelArena; } set { labelArena = value; } }
        public Label LabelStartDate { get { return labelStartDate; } set { labelStartDate = value; } }
        public Label LabelEndDate { get { return labelEndDate; } set { labelEndDate = value; } }

        public Button ButtonModifyDive { get { return buttonModifyDive; } set { buttonModifyDive = value; } }
        public Button ButtonRemoveDive { get { return buttonRemoveDive; } set { buttonRemoveDive = value; } }
        public Button ButtonCancelModify { get { return buttonCancelModify; } set { buttonCancelModify = value; } }

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
            this.buttonRemoveDive = new System.Windows.Forms.Button();
            this.buttonCancelModify = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
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
            this.labelContestName.Location = new System.Drawing.Point(23, 15);
            this.labelContestName.Name = "labelContestName";
            this.labelContestName.Size = new System.Drawing.Size(113, 20);
            this.labelContestName.TabIndex = 0;
            this.labelContestName.Text = "Contest name";
            // 
            // comboBoxSubContests
            // 
            this.comboBoxSubContests.FormattingEnabled = true;
            this.comboBoxSubContests.Location = new System.Drawing.Point(27, 94);
            this.comboBoxSubContests.Name = "comboBoxSubContests";
            this.comboBoxSubContests.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSubContests.TabIndex = 1;
            this.comboBoxSubContests.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSubContests_SelectedIndexChanged);
            // 
            // labelSubContests
            // 
            this.labelSubContests.AutoSize = true;
            this.labelSubContests.Location = new System.Drawing.Point(27, 78);
            this.labelSubContests.Name = "labelSubContests";
            this.labelSubContests.Size = new System.Drawing.Size(63, 13);
            this.labelSubContests.TabIndex = 2;
            this.labelSubContests.Text = "Deltävlingar";
            // 
            // listBoxContestants
            // 
            this.listBoxContestants.FormattingEnabled = true;
            this.listBoxContestants.Location = new System.Drawing.Point(27, 204);
            this.listBoxContestants.Name = "listBoxContestants";
            this.listBoxContestants.Size = new System.Drawing.Size(121, 147);
            this.listBoxContestants.TabIndex = 3;
            this.listBoxContestants.SelectedIndexChanged += new System.EventHandler(this.ListBoxContestants_SelectedIndexChanged);
            // 
            // labelContestants
            // 
            this.labelContestants.AutoSize = true;
            this.labelContestants.Location = new System.Drawing.Point(27, 185);
            this.labelContestants.Name = "labelContestants";
            this.labelContestants.Size = new System.Drawing.Size(53, 13);
            this.labelContestants.TabIndex = 4;
            this.labelContestants.Text = "Deltagare";
            // 
            // labelDives
            // 
            this.labelDives.AutoSize = true;
            this.labelDives.Location = new System.Drawing.Point(154, 185);
            this.labelDives.Name = "labelDives";
            this.labelDives.Size = new System.Drawing.Size(33, 13);
            this.labelDives.TabIndex = 6;
            this.labelDives.Text = "Hopp";
            // 
            // listBoxDives
            // 
            this.listBoxDives.FormattingEnabled = true;
            this.listBoxDives.Location = new System.Drawing.Point(154, 204);
            this.listBoxDives.Name = "listBoxDives";
            this.listBoxDives.Size = new System.Drawing.Size(121, 147);
            this.listBoxDives.TabIndex = 5;
            this.listBoxDives.SelectedIndexChanged += new System.EventHandler(this.ListBoxDives_SelectedIndexChanged);
            // 
            // buttonAddJump
            // 
            this.buttonAddJump.Location = new System.Drawing.Point(282, 204);
            this.buttonAddJump.Name = "buttonAddJump";
            this.buttonAddJump.Size = new System.Drawing.Size(82, 23);
            this.buttonAddJump.TabIndex = 7;
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
            this.labelCity.TabIndex = 8;
            this.labelCity.Text = "Stad";
            // 
            // labelArena
            // 
            this.labelArena.AutoSize = true;
            this.labelArena.Location = new System.Drawing.Point(208, 21);
            this.labelArena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelArena.Name = "labelArena";
            this.labelArena.Size = new System.Drawing.Size(40, 13);
            this.labelArena.TabIndex = 9;
            this.labelArena.Text = "Simhall";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(279, 21);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(56, 13);
            this.labelStartDate.TabIndex = 10;
            this.labelStartDate.Text = "startdatum";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(363, 21);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(52, 13);
            this.labelEndDate.TabIndex = 11;
            this.labelEndDate.Text = "slutdatum";
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(354, 54);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(95, 44);
            this.buttonPause.TabIndex = 12;
            this.buttonPause.Text = "Pausa Tävling";
            this.buttonPause.UseVisualStyleBackColor = true;
            // 
            // buttonCloseContest
            // 
            this.buttonCloseContest.Location = new System.Drawing.Point(354, 109);
            this.buttonCloseContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseContest.Name = "buttonCloseContest";
            this.buttonCloseContest.Size = new System.Drawing.Size(95, 44);
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
            // 
            // buttonRemoveDive
            // 
            this.buttonRemoveDive.Location = new System.Drawing.Point(281, 262);
            this.buttonRemoveDive.Name = "buttonRemoveDive";
            this.buttonRemoveDive.Size = new System.Drawing.Size(82, 23);
            this.buttonRemoveDive.TabIndex = 15;
            this.buttonRemoveDive.Text = "Ta bort";
            this.buttonRemoveDive.UseVisualStyleBackColor = true;
            this.buttonRemoveDive.Visible = false;
            this.buttonRemoveDive.Click += new EventHandler(ButtonRemoveDive_Click);
            // 
            // buttonCancelModify
            // 
            this.buttonCancelModify.Location = new System.Drawing.Point(282, 291);
            this.buttonCancelModify.Name = "buttonCancelModify";
            this.buttonCancelModify.Size = new System.Drawing.Size(82, 23);
            this.buttonCancelModify.TabIndex = 16;
            this.buttonCancelModify.Text = "Cancel";
            this.buttonCancelModify.UseVisualStyleBackColor = true;
            this.buttonCancelModify.Visible = false;
            this.buttonCancelModify.Click += new EventHandler(ButtonCancelModify_Click);
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

        private void ListBoxDives_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventDiveSelection?.Invoke();
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
