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
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ListBox listBoxSubContests;
        private System.Windows.Forms.Button buttonFinalizeContest;
        private System.Windows.Forms.Button buttonAddSubContest;
        private System.Windows.Forms.ListBox listBoxSubContestContestants;
        private System.Windows.Forms.Button buttonRemoveContestantFromSubContest;
        private System.Windows.Forms.Button buttonAddContestantToSubContest;
        private System.Windows.Forms.ListBox listBoxContestContestants;
        private System.Windows.Forms.Label label1;

        public event DelegateAddContestantToSubContest EventAddContestantToSubContest;
        public event DelegateRemoveContestantFromSubContest EventRemoveContestantFromSubContest;
        public event DelegateAddSubContest EventAddSubContest;
        public event DelegateFinalizeContest EventFinalizeContest;

        public ListBox ListBoxContestContestants { get { return listBoxContestContestants; } set { listBoxContestContestants = value; } }

        public ListBox ListBoxSubContests { get { return listBoxSubContests; } set { listBoxSubContests = value; } }

        public TextBox TextBoxName { get { return textBoxName; } set { textBoxName = value; } }

        public CreateSubContestView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonFinalizeContest = new System.Windows.Forms.Button();
            this.buttonAddSubContest = new System.Windows.Forms.Button();
            this.listBoxSubContestContestants = new System.Windows.Forms.ListBox();
            this.buttonRemoveContestantFromSubContest = new System.Windows.Forms.Button();
            this.buttonAddContestantToSubContest = new System.Windows.Forms.Button();
            this.listBoxContestContestants = new System.Windows.Forms.ListBox();
            this.listBoxSubContests = new System.Windows.Forms.ListBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.listBoxSubContests);
            this.mainPanel.Controls.Add(this.buttonFinalizeContest);
            this.mainPanel.Controls.Add(this.buttonAddSubContest);
            this.mainPanel.Controls.Add(this.listBoxSubContestContestants);
            this.mainPanel.Controls.Add(this.buttonRemoveContestantFromSubContest);
            this.mainPanel.Controls.Add(this.buttonAddContestantToSubContest);
            this.mainPanel.Controls.Add(this.listBoxContestContestants);
            this.mainPanel.Controls.Add(this.textBoxName);
            this.mainPanel.Controls.Add(this.label1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deltävling";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(171, 74);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 26);
            this.textBoxName.TabIndex = 1;
            // 
            // buttonFinalizeContest
            // 
            this.buttonFinalizeContest.Location = new System.Drawing.Point(616, 514);
            this.buttonFinalizeContest.Name = "buttonFinalizeContest";
            this.buttonFinalizeContest.Size = new System.Drawing.Size(102, 45);
            this.buttonFinalizeContest.TabIndex = 26;
            this.buttonFinalizeContest.Text = "Skapa Tävling";
            this.buttonFinalizeContest.UseVisualStyleBackColor = true;
            // 
            // buttonAddSubContest
            // 
            this.buttonAddSubContest.Location = new System.Drawing.Point(494, 514);
            this.buttonAddSubContest.Name = "buttonAddSubContest";
            this.buttonAddSubContest.Size = new System.Drawing.Size(51, 35);
            this.buttonAddSubContest.TabIndex = 25;
            this.buttonAddSubContest.Text = "Lägg till deltävling";
            this.buttonAddSubContest.UseVisualStyleBackColor = true;
            // 
            // listBoxSubContestContestants
            // 
            this.listBoxSubContestContestants.FormattingEnabled = true;
            this.listBoxSubContestContestants.ItemHeight = 20;
            this.listBoxSubContestContestants.Location = new System.Drawing.Point(494, 324);
            this.listBoxSubContestContestants.Name = "listBoxSubContestContestants";
            this.listBoxSubContestContestants.Size = new System.Drawing.Size(186, 184);
            this.listBoxSubContestContestants.TabIndex = 24;
            // 
            // buttonRemoveContestantFromSubContest
            // 
            this.buttonRemoveContestantFromSubContest.Location = new System.Drawing.Point(255, 428);
            this.buttonRemoveContestantFromSubContest.Name = "buttonRemoveContestantFromSubContest";
            this.buttonRemoveContestantFromSubContest.Size = new System.Drawing.Size(102, 45);
            this.buttonRemoveContestantFromSubContest.TabIndex = 23;
            this.buttonRemoveContestantFromSubContest.Text = "Ta bort från deltävling";
            this.buttonRemoveContestantFromSubContest.UseVisualStyleBackColor = true;
            // 
            // buttonAddContestantToSubContest
            // 
            this.buttonAddContestantToSubContest.Location = new System.Drawing.Point(255, 324);
            this.buttonAddContestantToSubContest.Name = "buttonAddContestantToSubContest";
            this.buttonAddContestantToSubContest.Size = new System.Drawing.Size(102, 45);
            this.buttonAddContestantToSubContest.TabIndex = 22;
            this.buttonAddContestantToSubContest.Text = "Lägg till i deltävling";
            this.buttonAddContestantToSubContest.UseVisualStyleBackColor = true;
            this.buttonAddContestantToSubContest.Click += new System.EventHandler(this.buttonAddContestantToSubContest_Click);
            // 
            // listBoxContestContestants
            // 
            this.listBoxContestContestants.FormattingEnabled = true;
            this.listBoxContestContestants.ItemHeight = 20;
            this.listBoxContestContestants.Location = new System.Drawing.Point(63, 324);
            this.listBoxContestContestants.Name = "listBoxContestContestants";
            this.listBoxContestContestants.Size = new System.Drawing.Size(186, 184);
            this.listBoxContestContestants.TabIndex = 21;
            // 
            // listBoxSubContests
            // 
            this.listBoxSubContests.FormattingEnabled = true;
            this.listBoxSubContests.ItemHeight = 20;
            this.listBoxSubContests.Location = new System.Drawing.Point(509, 43);
            this.listBoxSubContests.Name = "listBoxSubContests";
            this.listBoxSubContests.Size = new System.Drawing.Size(186, 184);
            this.listBoxSubContests.TabIndex = 27;
            // 
            // CreateSubContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CreateSubContestView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void buttonAddContestantToSubContest_Click(object sender, EventArgs e)
        {
            this.EventAddContestantToSubContest?.Invoke();
        }
    }
}
