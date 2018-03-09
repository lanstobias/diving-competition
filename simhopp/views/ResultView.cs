using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class ResultView : PanelViewControl
    {
        private System.Windows.Forms.ListView listViewContestants;
        private System.Windows.Forms.ColumnHeader columnFirstName;
        private System.Windows.Forms.ListView listViewSubContest;
        private System.Windows.Forms.ColumnHeader columnSubContest;
        private ColumnHeader columnScore;
        private ColumnHeader columnRank;
        private System.Windows.Forms.ColumnHeader columnLastName;

        public event DelegateSubContestSelection EventSubContestSelection;

        public ListView ListViewSubContests { get { return listViewSubContest; } set { listViewSubContest = value; } }
        public ListView ListViewContestants { get { return listViewContestants; } set { listViewContestants = value; } }

        public ResultView()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.listViewContestants = new System.Windows.Forms.ListView();
            this.columnFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewSubContest = new System.Windows.Forms.ListView();
            this.columnSubContest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.listViewSubContest);
            this.mainPanel.Controls.Add(this.listViewContestants);
            // 
            // listViewContestants
            // 
            this.listViewContestants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRank,
            this.columnFirstName,
            this.columnLastName,
            this.columnScore});
            this.listViewContestants.Location = new System.Drawing.Point(56, 307);
            this.listViewContestants.Name = "listViewContestants";
            this.listViewContestants.Size = new System.Drawing.Size(477, 224);
            this.listViewContestants.TabIndex = 2;
            this.listViewContestants.UseCompatibleStateImageBehavior = false;
            this.listViewContestants.View = System.Windows.Forms.View.Details;
            // 
            // columnFirstName
            // 
            this.columnFirstName.Text = "Förnamn";
            this.columnFirstName.Width = 100;
            // 
            // columnLastName
            // 
            this.columnLastName.Text = "Efternamn";
            this.columnLastName.Width = 91;
            // 
            // columnScore
            // 
            this.columnScore.Text = "Poäng";
            this.columnScore.Width = 82;
            // 
            // listViewSubContest
            // 
            this.listViewSubContest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSubContest});
            this.listViewSubContest.Location = new System.Drawing.Point(550, 36);
            this.listViewSubContest.Name = "listViewSubContest";
            this.listViewSubContest.Size = new System.Drawing.Size(180, 224);
            this.listViewSubContest.TabIndex = 3;
            this.listViewSubContest.UseCompatibleStateImageBehavior = false;
            this.listViewSubContest.View = System.Windows.Forms.View.Details;
            this.listViewSubContest.SelectedIndexChanged += new System.EventHandler(this.listViewSubContest_SelectedIndexChanged);
            // 
            // columnSubContest
            // 
            this.columnSubContest.Text = "Deltävling";
            this.columnSubContest.Width = 123;
            // 
            // columnRank
            // 
            this.columnRank.Text = "Plats";
            // 
            // ResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ResultView";
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void listViewSubContest_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventSubContestSelection?.Invoke();
        }
    }
}
