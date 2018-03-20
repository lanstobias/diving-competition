using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class AddDiveView : Form, IAddDiveView
    {

        private Panel mainPanel;
        private TextBox textBoxDiveMultiplier;
        private Label labelDiveMultiplier;
        private TextBox textBoxDiveCode;
        private Label labelDiveCode;
        private Button buttonAddDive;

        public TextBox TextBoxDiveCode { get { return textBoxDiveCode; } set { textBoxDiveCode = value; } }

        public TextBox TextBoxDiveMultiplier { get { return textBoxDiveMultiplier; } set { textBoxDiveMultiplier = value; } }

        public event DelegateAddDive EventAddDive;

        public AddDiveView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mainPanel = new Panel();
            this.textBoxDiveMultiplier = new TextBox();
            this.labelDiveMultiplier = new Label();
            this.textBoxDiveCode = new TextBox();
            this.labelDiveCode = new Label();
            this.buttonAddDive = new Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.textBoxDiveMultiplier);
            this.mainPanel.Controls.Add(this.labelDiveMultiplier);
            this.mainPanel.Controls.Add(this.textBoxDiveCode);
            this.mainPanel.Controls.Add(this.labelDiveCode);
            this.mainPanel.Controls.Add(this.buttonAddDive);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(489, 334);
            this.mainPanel.TabIndex = 0;
            // 
            // textBoxDiveMultiplier
            // 
            this.textBoxDiveMultiplier.Location = new System.Drawing.Point(201, 163);
            this.textBoxDiveMultiplier.Name = "textBoxDiveMultiplier";
            this.textBoxDiveMultiplier.Size = new System.Drawing.Size(127, 20);
            this.textBoxDiveMultiplier.TabIndex = 4;
            // 
            // labelDiveMultiplier
            // 
            this.labelDiveMultiplier.AutoSize = true;
            this.labelDiveMultiplier.Location = new System.Drawing.Point(115, 166);
            this.labelDiveMultiplier.Name = "labelDiveMultiplier";
            this.labelDiveMultiplier.Size = new System.Drawing.Size(48, 13);
            this.labelDiveMultiplier.TabIndex = 3;
            this.labelDiveMultiplier.Text = "Multiplier";
            // 
            // textBoxDiveCode
            // 
            this.textBoxDiveCode.Location = new System.Drawing.Point(201, 97);
            this.textBoxDiveCode.Name = "textBoxDiveCode";
            this.textBoxDiveCode.Size = new System.Drawing.Size(127, 20);
            this.textBoxDiveCode.TabIndex = 2;
            // 
            // labelDiveCode
            // 
            this.labelDiveCode.AutoSize = true;
            this.labelDiveCode.Location = new System.Drawing.Point(115, 100);
            this.labelDiveCode.Name = "labelDiveCode";
            this.labelDiveCode.Size = new System.Drawing.Size(51, 13);
            this.labelDiveCode.TabIndex = 1;
            this.labelDiveCode.Text = "Hoppkod";
            // 
            // buttonAddDive
            // 
            this.buttonAddDive.Location = new System.Drawing.Point(214, 277);
            this.buttonAddDive.Name = "buttonAddDive";
            this.buttonAddDive.Size = new System.Drawing.Size(75, 23);
            this.buttonAddDive.TabIndex = 0;
            this.buttonAddDive.Text = "Lägg till hopp";
            this.buttonAddDive.UseVisualStyleBackColor = true;
            this.buttonAddDive.Click += new EventHandler(this.ButtonAddDive_Click);
            // 
            // AddDiveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 358);
            this.Controls.Add(this.mainPanel);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "AddDiveView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void ButtonAddDive_Click(object sender, EventArgs e)
        {
            this.EventAddDive?.Invoke();
        }
    }
}
