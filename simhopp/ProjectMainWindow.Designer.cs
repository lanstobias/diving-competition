using System.Windows.Forms;

namespace Simhopp
{
    partial class ProjectMainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goBackItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.goBackItem,
            this.closeMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(46, 22);
            this.fileMenuItem.Text = "Arkiv";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsMenuItem.Text = "Inställningar";
            this.settingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // settingsGobackItem
            // 
            this.goBackItem.Name = "goBackItem";
            this.goBackItem.Size = new System.Drawing.Size(152, 22);
            this.goBackItem.Text = "Gå tillbaka";
            this.goBackItem.Click += new System.EventHandler(this.SettingsGoBackItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeMenuItem.Text = "Stäng";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualMenuItem,
            this.resultsMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(47, 22);
            this.helpMenuItem.Text = "Hjälp";
            // 
            // manualMenuItem
            // 
            this.manualMenuItem.Name = "manualMenuItem";
            this.manualMenuItem.Size = new System.Drawing.Size(137, 22);
            this.manualMenuItem.Text = "Manual";
            // 
            // resultsMenuItem
            // 
            this.resultsMenuItem.Name = "resultsMenuItem";
            this.resultsMenuItem.Size = new System.Drawing.Size(137, 22);
            this.resultsMenuItem.Text = "Resultatsida";
            this.resultsMenuItem.Click += new System.EventHandler(this.ResultsMenuItem_Click);
            // 
            // ProjectMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 421);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProjectMainWindow";
            this.Text = "Simhopp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem closeMenuItem;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem manualMenuItem;
        private ToolStripMenuItem resultsMenuItem;
        private ToolStripMenuItem settingsMenuItem;
        private ToolStripMenuItem goBackItem;
    }
}

