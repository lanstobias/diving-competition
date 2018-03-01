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
        private System.Windows.Forms.Label labelContestName;

        public event DelegateAddJump EventAddJump;
        public event DelegateSubContestSelection EventSubContestSelection;

        public ComboBox ComboBoxSubContests { get { return comboBoxSubContests; } set { comboBoxSubContests = value; } }
        public ListBox ListBoxContestants { get { return listBoxContestants; } set { listBoxContestants = value; } }
        public ListBox ListBoxDives { get { return listBoxDives; } set { listBoxDives = value; } }


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
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
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
            this.comboBoxSubContests.SelectedIndexChanged += new EventHandler(ComboBoxSubContests_SelectedIndexChanged);
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
            // 
            // buttonAddJump
            // 
            this.buttonAddJump.Location = new System.Drawing.Point(282, 204);
            this.buttonAddJump.Name = "buttonAddJump";
            this.buttonAddJump.Size = new System.Drawing.Size(82, 23);
            this.buttonAddJump.TabIndex = 7;
            this.buttonAddJump.Text = "Lägg till hopp";
            this.buttonAddJump.UseVisualStyleBackColor = true;
            this.buttonAddJump.Click += new EventHandler(ButtonAddJump_Click);
            // 
            // ContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ContestView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

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
