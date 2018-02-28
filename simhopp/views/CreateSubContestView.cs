using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class CreateSubContestView : PanelViewControl , ICreateSubContestView
    {
        private TextBox textBoxName;
        private ListBox listBoxSubContests;
        private Button buttonFinalizeContest;
        private Button buttonAddSubContest;
        private ListBox listBoxSubContestContestants;
        private Button buttonRemoveContestantFromSubContest;
        private Button buttonAddContestantToSubContest;
        private ListBox listBoxContestContestants;
        private Label labelContestName;
        private Button buttonCancelEdit;
        private Button buttonUpdateSubContest;
        private Label labelSubContestName;

        public event DelegateAddContestantToSubContest EventAddContestantToSubContest;
        public event DelegateRemoveContestantFromSubContest EventRemoveContestantFromSubContest;
        public event DelegateAddSubContest EventAddSubContest;
        public event DelegateFinalizeContest EventFinalizeContest;
        public event DelegateSubContestSelected EventSubContestSelected;
        public event DelegateUpdateSubContest EventUpdateSubContest;
        public event DelegateCancelEdit EventCancelEdit;

        public ListBox ListBoxSubContestContestants { get { return listBoxSubContestContestants; } set { listBoxSubContestContestants = value; } }

        public ListBox ListBoxContestContestants { get { return listBoxContestContestants; } set { listBoxContestContestants = value; } }

        public ListBox ListBoxSubContests { get { return listBoxSubContests; } set { listBoxSubContests = value; } }

        public TextBox TextBoxName { get { return textBoxName; } set { textBoxName = value; } }

        public Label LabelContestName { get { return labelContestName; } set { labelContestName = value; } }

        public Button ButtonUpdateSubContest { get { return buttonUpdateSubContest; } set { buttonUpdateSubContest = value; } }

        public Button ButtonCancelEdit { get { return buttonCancelEdit; } set { buttonCancelEdit = value; } }

        public Button ButtonAddSubContest { get { return buttonAddSubContest; } set { buttonAddSubContest = value; } }

        public CreateSubContestView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.labelSubContestName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonFinalizeContest = new System.Windows.Forms.Button();
            this.buttonAddSubContest = new System.Windows.Forms.Button();
            this.listBoxSubContestContestants = new System.Windows.Forms.ListBox();
            this.buttonRemoveContestantFromSubContest = new System.Windows.Forms.Button();
            this.buttonAddContestantToSubContest = new System.Windows.Forms.Button();
            this.listBoxContestContestants = new System.Windows.Forms.ListBox();
            this.listBoxSubContests = new System.Windows.Forms.ListBox();
            this.labelContestName = new System.Windows.Forms.Label();
            this.buttonUpdateSubContest = new System.Windows.Forms.Button();
            this.buttonCancelEdit = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.buttonCancelEdit);
            this.mainPanel.Controls.Add(this.buttonUpdateSubContest);
            this.mainPanel.Controls.Add(this.labelContestName);
            this.mainPanel.Controls.Add(this.listBoxSubContests);
            this.mainPanel.Controls.Add(this.buttonFinalizeContest);
            this.mainPanel.Controls.Add(this.buttonAddSubContest);
            this.mainPanel.Controls.Add(this.listBoxSubContestContestants);
            this.mainPanel.Controls.Add(this.buttonRemoveContestantFromSubContest);
            this.mainPanel.Controls.Add(this.buttonAddContestantToSubContest);
            this.mainPanel.Controls.Add(this.listBoxContestContestants);
            this.mainPanel.Controls.Add(this.textBoxName);
            this.mainPanel.Controls.Add(this.labelSubContestName);
            // 
            // labelSubContestName
            // 
            this.labelSubContestName.AutoSize = true;
            this.labelSubContestName.Location = new System.Drawing.Point(26, 52);
            this.labelSubContestName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelSubContestName.Name = "labelSubContestName";
            this.labelSubContestName.Size = new System.Drawing.Size(85, 13);
            this.labelSubContestName.TabIndex = 0;
            this.labelSubContestName.Text = "Deltävlingsnamn";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(29, 67);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(104, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // buttonFinalizeContest
            // 
            this.buttonFinalizeContest.Location = new System.Drawing.Point(417, 359);
            this.buttonFinalizeContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFinalizeContest.Name = "buttonFinalizeContest";
            this.buttonFinalizeContest.Size = new System.Drawing.Size(68, 29);
            this.buttonFinalizeContest.TabIndex = 26;
            this.buttonFinalizeContest.Text = "Skapa Tävling";
            this.buttonFinalizeContest.UseVisualStyleBackColor = true;
            // 
            // buttonAddSubContest
            // 
            this.buttonAddSubContest.Location = new System.Drawing.Point(316, 154);
            this.buttonAddSubContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddSubContest.Name = "buttonAddSubContest";
            this.buttonAddSubContest.Size = new System.Drawing.Size(125, 23);
            this.buttonAddSubContest.TabIndex = 25;
            this.buttonAddSubContest.Text = "Lägg till deltävling";
            this.buttonAddSubContest.UseVisualStyleBackColor = true;
            this.buttonAddSubContest.Click += new System.EventHandler(this.buttonAddSubContest_Click);
            // 
            // listBoxSubContestContestants
            // 
            this.listBoxSubContestContestants.FormattingEnabled = true;
            this.listBoxSubContestContestants.Location = new System.Drawing.Point(316, 231);
            this.listBoxSubContestContestants.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxSubContestContestants.Name = "listBoxSubContestContestants";
            this.listBoxSubContestContestants.Size = new System.Drawing.Size(125, 121);
            this.listBoxSubContestContestants.TabIndex = 24;
            // 
            // buttonRemoveContestantFromSubContest
            // 
            this.buttonRemoveContestantFromSubContest.Location = new System.Drawing.Point(157, 298);
            this.buttonRemoveContestantFromSubContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveContestantFromSubContest.Name = "buttonRemoveContestantFromSubContest";
            this.buttonRemoveContestantFromSubContest.Size = new System.Drawing.Size(68, 29);
            this.buttonRemoveContestantFromSubContest.TabIndex = 23;
            this.buttonRemoveContestantFromSubContest.Text = "Ta bort från deltävling";
            this.buttonRemoveContestantFromSubContest.UseVisualStyleBackColor = true;
            this.buttonRemoveContestantFromSubContest.Click += new System.EventHandler(this.buttonRemoveContestantFromSubContest_Click);
            // 
            // buttonAddContestantToSubContest
            // 
            this.buttonAddContestantToSubContest.Location = new System.Drawing.Point(157, 231);
            this.buttonAddContestantToSubContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddContestantToSubContest.Name = "buttonAddContestantToSubContest";
            this.buttonAddContestantToSubContest.Size = new System.Drawing.Size(68, 29);
            this.buttonAddContestantToSubContest.TabIndex = 22;
            this.buttonAddContestantToSubContest.Text = "Lägg till i deltävling";
            this.buttonAddContestantToSubContest.UseVisualStyleBackColor = true;
            this.buttonAddContestantToSubContest.Click += new System.EventHandler(this.buttonAddContestantToSubContest_Click);
            // 
            // listBoxContestContestants
            // 
            this.listBoxContestContestants.FormattingEnabled = true;
            this.listBoxContestContestants.Location = new System.Drawing.Point(29, 231);
            this.listBoxContestContestants.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxContestContestants.Name = "listBoxContestContestants";
            this.listBoxContestContestants.Size = new System.Drawing.Size(125, 121);
            this.listBoxContestContestants.TabIndex = 21;
            // 
            // listBoxSubContests
            // 
            this.listBoxSubContests.FormattingEnabled = true;
            this.listBoxSubContests.Location = new System.Drawing.Point(316, 29);
            this.listBoxSubContests.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxSubContests.Name = "listBoxSubContests";
            this.listBoxSubContests.Size = new System.Drawing.Size(125, 121);
            this.listBoxSubContests.TabIndex = 27;
            this.listBoxSubContests.SelectedIndexChanged += new System.EventHandler(this.listBoxSubContests_SelectionChanged);
            // 
            // labelContestName
            // 
            this.labelContestName.AutoSize = true;
            this.labelContestName.Location = new System.Drawing.Point(26, 10);
            this.labelContestName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelContestName.Name = "labelContestName";
            this.labelContestName.Size = new System.Drawing.Size(0, 13);
            this.labelContestName.TabIndex = 28;
            // 
            // buttonUpdateSubContest
            // 
            this.buttonUpdateSubContest.Location = new System.Drawing.Point(316, 181);
            this.buttonUpdateSubContest.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdateSubContest.Name = "buttonUpdateSubContest";
            this.buttonUpdateSubContest.Size = new System.Drawing.Size(125, 22);
            this.buttonUpdateSubContest.TabIndex = 29;
            this.buttonUpdateSubContest.Text = "Uppdatera";
            this.buttonUpdateSubContest.UseVisualStyleBackColor = true;
            this.buttonUpdateSubContest.Visible = false;
            this.buttonUpdateSubContest.Click += new System.EventHandler(this.buttonUpdateSubContest_Click);
            // 
            // buttonCancelEdit
            // 
            this.buttonCancelEdit.Location = new System.Drawing.Point(316, 207);
            this.buttonCancelEdit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancelEdit.Name = "buttonCancelEdit";
            this.buttonCancelEdit.Size = new System.Drawing.Size(125, 20);
            this.buttonCancelEdit.TabIndex = 30;
            this.buttonCancelEdit.Text = "Cancel";
            this.buttonCancelEdit.UseVisualStyleBackColor = true;
            this.buttonCancelEdit.Visible = false;
            this.buttonCancelEdit.Click += new System.EventHandler(this.buttonCancelEdit_Click);
            // 
            // CreateSubContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateSubContestView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void buttonAddContestantToSubContest_Click(object sender, EventArgs e)
        {
            this.EventAddContestantToSubContest?.Invoke();
        }

        private void buttonAddSubContest_Click(object sender, EventArgs e)
        {
            this.EventAddSubContest?.Invoke();
        }

        private void buttonRemoveContestantFromSubContest_Click(object sender, EventArgs e)
        {
            this.EventRemoveContestantFromSubContest?.Invoke();
        }

        private void listBoxSubContests_SelectionChanged(object sender, EventArgs e)
        {
            this.EventSubContestSelected?.Invoke();
        }

        private void buttonUpdateSubContest_Click(object sender, EventArgs e)
        {
            this.EventUpdateSubContest?.Invoke();
        }

        private void buttonCancelEdit_Click(object sender, EventArgs e)
        {
            this.EventCancelEdit?.Invoke();
        }
    }
}
