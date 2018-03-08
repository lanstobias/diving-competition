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
        private Button buttonFinalizeContest;
        private Button buttonAddSubContest;
        private Button buttonRemoveContestantFromSubContest;
        private Button buttonAddContestantToSubContest;
        private Label labelContestName;
        private Button buttonCancelEdit;
        private Button buttonUpdateSubContest;
        private Label labelSubContestContestants;
        private Label labelContestContestants;
        private ListView listViewContestContestants;
        private ListView listViewSubContestConstestants;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ListView listViewSubContests;
        private ColumnHeader columnSubContest;
        private ColumnHeader columnFirstName;
        private ColumnHeader columnLastName;
        private Label labelSubContestName;

        public event DelegateAddContestantToSubContest EventAddContestantToSubContest;
        public event DelegateRemoveContestantFromSubContest EventRemoveContestantFromSubContest;
        public event DelegateAddSubContest EventAddSubContest;
        public event DelegateFinalizeContest EventFinalizeContest;
        public event DelegateSubContestSelected EventSubContestSelected;
        public event DelegateUpdateSubContest EventUpdateSubContest;
        public event DelegateCancelEdit EventCancelEdit;

        public TextBox TextBoxName { get { return textBoxName; } set { textBoxName = value; } }

        public Label LabelContestName { get { return labelContestName; } set { labelContestName = value; } }

        public Button ButtonUpdateSubContest { get { return buttonUpdateSubContest; } set { buttonUpdateSubContest = value; } }

        public Button ButtonCancelEdit { get { return buttonCancelEdit; } set { buttonCancelEdit = value; } }

        public Button ButtonAddSubContest { get { return buttonAddSubContest; } set { buttonAddSubContest = value; } }

        public ListView ListViewContestContestants { get { return listViewContestContestants; } set { listViewContestContestants = value; } }
        public ListView ListViewSubContestContestants { get { return listViewSubContestConstestants; } set { listViewSubContestConstestants = value; } }
        public ListView ListViewSubContests { get { return listViewSubContests; } set { listViewSubContests = value; } }
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
            this.buttonRemoveContestantFromSubContest = new System.Windows.Forms.Button();
            this.buttonAddContestantToSubContest = new System.Windows.Forms.Button();
            this.labelContestName = new System.Windows.Forms.Label();
            this.buttonUpdateSubContest = new System.Windows.Forms.Button();
            this.buttonCancelEdit = new System.Windows.Forms.Button();
            this.labelContestContestants = new System.Windows.Forms.Label();
            this.labelSubContestContestants = new System.Windows.Forms.Label();
            this.listViewContestContestants = new System.Windows.Forms.ListView();
            this.columnFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewSubContests = new System.Windows.Forms.ListView();
            this.columnSubContest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewSubContestConstestants = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.listViewSubContestConstestants);
            this.mainPanel.Controls.Add(this.listViewSubContests);
            this.mainPanel.Controls.Add(this.listViewContestContestants);
            this.mainPanel.Controls.Add(this.labelSubContestContestants);
            this.mainPanel.Controls.Add(this.labelContestContestants);
            this.mainPanel.Controls.Add(this.buttonCancelEdit);
            this.mainPanel.Controls.Add(this.buttonUpdateSubContest);
            this.mainPanel.Controls.Add(this.labelContestName);
            this.mainPanel.Controls.Add(this.buttonFinalizeContest);
            this.mainPanel.Controls.Add(this.buttonAddSubContest);
            this.mainPanel.Controls.Add(this.buttonRemoveContestantFromSubContest);
            this.mainPanel.Controls.Add(this.buttonAddContestantToSubContest);
            this.mainPanel.Controls.Add(this.textBoxName);
            this.mainPanel.Controls.Add(this.labelSubContestName);
            // 
            // labelSubContestName
            // 
            this.labelSubContestName.AutoSize = true;
            this.labelSubContestName.Location = new System.Drawing.Point(39, 80);
            this.labelSubContestName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSubContestName.Name = "labelSubContestName";
            this.labelSubContestName.Size = new System.Drawing.Size(126, 20);
            this.labelSubContestName.TabIndex = 0;
            this.labelSubContestName.Text = "Deltävlingsnamn";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(44, 103);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(154, 26);
            this.textBoxName.TabIndex = 1;
            // 
            // listViewContestContestants
            // 
            this.listViewContestContestants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFirstName,
            this.columnLastName});
            this.listViewContestContestants.Location = new System.Drawing.Point(29, 364);
            this.listViewContestContestants.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewContestContestants.Name = "listViewContestContestants";
            this.listViewContestContestants.Size = new System.Drawing.Size(186, 184);
            this.listViewContestContestants.TabIndex = 2;
            this.listViewContestContestants.UseCompatibleStateImageBehavior = false;
            this.listViewContestContestants.View = System.Windows.Forms.View.Details;
            // 
            // columnFirstName
            // 
            this.columnFirstName.Text = "Förnamn";
            // 
            // columnLastName
            // 
            this.columnLastName.Text = "Efternamn";
            // 
            // buttonAddContestantToSubContest
            // 
            this.buttonAddContestantToSubContest.Location = new System.Drawing.Point(237, 408);
            this.buttonAddContestantToSubContest.Name = "buttonAddContestantToSubContest";
            this.buttonAddContestantToSubContest.Size = new System.Drawing.Size(231, 45);
            this.buttonAddContestantToSubContest.TabIndex = 3;
            this.buttonAddContestantToSubContest.Text = "Lägg till i deltävling";
            this.buttonAddContestantToSubContest.UseVisualStyleBackColor = true;
            this.buttonAddContestantToSubContest.Click += new System.EventHandler(this.buttonAddContestantToSubContest_Click);
            // 
            // listViewSubContestConstestants
            // 
            this.listViewSubContestConstestants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewSubContestConstestants.Location = new System.Drawing.Point(476, 364);
            this.listViewSubContestConstestants.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewSubContestConstestants.Name = "listViewSubContestConstestants";
            this.listViewSubContestConstestants.Size = new System.Drawing.Size(186, 184);
            this.listViewSubContestConstestants.TabIndex = 4;
            this.listViewSubContestConstestants.UseCompatibleStateImageBehavior = false;
            this.listViewSubContestConstestants.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Förnamn";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Efternamn";
            // 
            // buttonRemoveContestantFromSubContest
            // 
            this.buttonRemoveContestantFromSubContest.Location = new System.Drawing.Point(237, 458);
            this.buttonRemoveContestantFromSubContest.Name = "buttonRemoveContestantFromSubContest";
            this.buttonRemoveContestantFromSubContest.Size = new System.Drawing.Size(231, 45);
            this.buttonRemoveContestantFromSubContest.TabIndex = 5;
            this.buttonRemoveContestantFromSubContest.Text = "Ta bort från deltävling";
            this.buttonRemoveContestantFromSubContest.UseVisualStyleBackColor = true;
            this.buttonRemoveContestantFromSubContest.Click += new System.EventHandler(this.buttonRemoveContestantFromSubContest_Click);
            // 
            // buttonAddSubContest
            // 
            this.buttonAddSubContest.Location = new System.Drawing.Point(474, 208);
            this.buttonAddSubContest.Name = "buttonAddSubContest";
            this.buttonAddSubContest.Size = new System.Drawing.Size(188, 35);
            this.buttonAddSubContest.TabIndex = 6;
            this.buttonAddSubContest.Text = "Lägg till deltävling";
            this.buttonAddSubContest.UseVisualStyleBackColor = true;
            this.buttonAddSubContest.Click += new System.EventHandler(this.buttonAddSubContest_Click);
            // 
            // buttonFinalizeContest
            // 
            this.buttonFinalizeContest.Location = new System.Drawing.Point(664, 531);
            this.buttonFinalizeContest.Name = "buttonFinalizeContest";
            this.buttonFinalizeContest.Size = new System.Drawing.Size(102, 66);
            this.buttonFinalizeContest.TabIndex = 7;
            this.buttonFinalizeContest.Text = "Skapa Tävling";
            this.buttonFinalizeContest.UseVisualStyleBackColor = true;
            this.buttonFinalizeContest.Click += new System.EventHandler(this.ButtonFinalizeContest_Click);
            // 
            // listViewSubContests
            // 
            this.listViewSubContests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSubContest});
            this.listViewSubContests.Location = new System.Drawing.Point(476, 16);
            this.listViewSubContests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewSubContests.Name = "listViewSubContests";
            this.listViewSubContests.Size = new System.Drawing.Size(186, 184);
            this.listViewSubContests.TabIndex = 8;
            this.listViewSubContests.UseCompatibleStateImageBehavior = false;
            this.listViewSubContests.View = System.Windows.Forms.View.Details;
            this.listViewSubContests.SelectedIndexChanged += new System.EventHandler(this.listViewSubContests_SelectedIndexChanged);
            // 
            // columnSubContest
            // 
            this.columnSubContest.Text = "Deltävling";
            this.columnSubContest.Width = 67;
            // 
            // buttonUpdateSubContest
            // 
            this.buttonUpdateSubContest.Location = new System.Drawing.Point(474, 249);
            this.buttonUpdateSubContest.Name = "buttonUpdateSubContest";
            this.buttonUpdateSubContest.Size = new System.Drawing.Size(188, 34);
            this.buttonUpdateSubContest.TabIndex = 9;
            this.buttonUpdateSubContest.Text = "Uppdatera";
            this.buttonUpdateSubContest.UseVisualStyleBackColor = true;
            this.buttonUpdateSubContest.Visible = false;
            this.buttonUpdateSubContest.Click += new System.EventHandler(this.buttonUpdateSubContest_Click);
            // 
            // buttonCancelEdit
            // 
            this.buttonCancelEdit.Location = new System.Drawing.Point(474, 289);
            this.buttonCancelEdit.Name = "buttonCancelEdit";
            this.buttonCancelEdit.Size = new System.Drawing.Size(188, 31);
            this.buttonCancelEdit.TabIndex = 10;
            this.buttonCancelEdit.Text = "Cancel";
            this.buttonCancelEdit.UseVisualStyleBackColor = true;
            this.buttonCancelEdit.Visible = false;
            this.buttonCancelEdit.Click += new System.EventHandler(this.buttonCancelEdit_Click);
            // 
            // labelContestName
            // 
            this.labelContestName.AutoSize = true;
            this.labelContestName.Location = new System.Drawing.Point(39, 15);
            this.labelContestName.Name = "labelContestName";
            this.labelContestName.Size = new System.Drawing.Size(0, 20);
            this.labelContestName.TabIndex = 11;
            // 
            // labelContestContestants
            // 
            this.labelContestContestants.AutoSize = true;
            this.labelContestContestants.Location = new System.Drawing.Point(25, 339);
            this.labelContestContestants.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContestContestants.Name = "labelContestContestants";
            this.labelContestContestants.Size = new System.Drawing.Size(135, 20);
            this.labelContestContestants.TabIndex = 12;
            this.labelContestContestants.Text = "Deltagare i tävling";
            // 
            // labelSubContestContestants
            // 
            this.labelSubContestContestants.AutoSize = true;
            this.labelSubContestContestants.Location = new System.Drawing.Point(470, 337);
            this.labelSubContestContestants.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSubContestContestants.Name = "labelSubContestContestants";
            this.labelSubContestContestants.Size = new System.Drawing.Size(156, 20);
            this.labelSubContestContestants.TabIndex = 13;
            this.labelSubContestContestants.Text = "Deltagare i deltävling";
            // 
            // CreateSubContestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "CreateSubContestView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void ButtonFinalizeContest_Click(object sender, EventArgs e)
        {
            this.EventFinalizeContest?.Invoke();
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

        //private void listBoxSubContests_SelectionChanged(object sender, EventArgs e)
        //{
        //    this.EventSubContestSelected?.Invoke();
        //}

        private void buttonUpdateSubContest_Click(object sender, EventArgs e)
        {
            this.EventUpdateSubContest?.Invoke();
        }

        private void buttonCancelEdit_Click(object sender, EventArgs e)
        {
            this.EventCancelEdit?.Invoke();
        }

        private void listViewSubContests_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EventSubContestSelected?.Invoke();
        }
    }
}
