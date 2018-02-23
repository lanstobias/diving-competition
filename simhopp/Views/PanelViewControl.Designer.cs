namespace Simhopp
{
    partial class PanelViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(4, 4);
            this.mainPanel.Name = "MainPanel";
            this.mainPanel.Size = new System.Drawing.Size(513, 390);
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.TabIndex = 0;
            // 
            // PanelViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "PanelViewControl";
            this.Size = new System.Drawing.Size(520, 397);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel mainPanel;
    }
}
