using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class AddDiveView : PanelViewControl, IAddDiveView
    {
        private System.Windows.Forms.TextBox textBoxDiveMultiplier;
        private System.Windows.Forms.Label labelDiveMultiplier;
        private System.Windows.Forms.TextBox textBoxDiveCode;
        private System.Windows.Forms.Label labelDiveCode;
        private System.Windows.Forms.Button buttonAddDive;

        public event DelegateAddDive EventAddDive;

        public AddDiveView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.buttonAddDive = new System.Windows.Forms.Button();
            this.labelDiveCode = new System.Windows.Forms.Label();
            this.textBoxDiveCode = new System.Windows.Forms.TextBox();
            this.labelDiveMultiplier = new System.Windows.Forms.Label();
            this.textBoxDiveMultiplier = new System.Windows.Forms.TextBox();
            
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
            // 
            // buttonAddDive
            // 
            this.buttonAddDive.Location = new System.Drawing.Point(214, 277);
            this.buttonAddDive.Name = "buttonAddDive";
            this.buttonAddDive.Size = new System.Drawing.Size(75, 23);
            this.buttonAddDive.TabIndex = 0;
            this.buttonAddDive.Text = "Lägg till hopp";
            this.buttonAddDive.UseVisualStyleBackColor = true;
            // 
            // labelDiveCode
            // 
            this.labelDiveCode.AutoSize = true;
            this.labelDiveCode.Location = new System.Drawing.Point(115, 100);
            this.labelDiveCode.Name = "labelDiveCode";
            this.labelDiveCode.Size = new System.Drawing.Size(35, 13);
            this.labelDiveCode.TabIndex = 1;
            this.labelDiveCode.Text = "Hopp nr";
            // 
            // textBoxDiveCode
            // 
            this.textBoxDiveCode.Location = new System.Drawing.Point(201, 97);
            this.textBoxDiveCode.Name = "textBoxDiveNumber";
            this.textBoxDiveCode.Size = new System.Drawing.Size(127, 20);
            this.textBoxDiveCode.TabIndex = 2;
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
            this.labelDiveMultiplier.Size = new System.Drawing.Size(35, 13);
            this.labelDiveMultiplier.TabIndex = 3;
            this.labelDiveMultiplier.Text = "Multiplier";
            // 
            // AddDiveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "AddDiveView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
