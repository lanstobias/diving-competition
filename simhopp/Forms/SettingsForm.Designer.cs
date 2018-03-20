namespace Simhopp
{
    partial class SettingsForm
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
            this.labelServerType = new System.Windows.Forms.Label();
            this.radioButtonLAN = new System.Windows.Forms.RadioButton();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.radioButtonOnline = new System.Windows.Forms.RadioButton();
            this.radioButtonOffline = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelServerType
            // 
            this.labelServerType.AutoSize = true;
            this.labelServerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerType.Location = new System.Drawing.Point(24, 14);
            this.labelServerType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServerType.Name = "labelServerType";
            this.labelServerType.Size = new System.Drawing.Size(144, 26);
            this.labelServerType.TabIndex = 0;
            this.labelServerType.Text = "Välj servertyp";
            // 
            // radioButtonLAN
            // 
            this.radioButtonLAN.AutoSize = true;
            this.radioButtonLAN.Location = new System.Drawing.Point(15, 58);
            this.radioButtonLAN.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonLAN.Name = "radioButtonLAN";
            this.radioButtonLAN.Size = new System.Drawing.Size(46, 17);
            this.radioButtonLAN.TabIndex = 1;
            this.radioButtonLAN.TabStop = true;
            this.radioButtonLAN.Text = "LAN";
            this.radioButtonLAN.UseVisualStyleBackColor = true;
            this.radioButtonLAN.Click += new System.EventHandler(this.RadioButtonLAN_Click);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(26, 115);
            this.labelPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port:";
            this.labelPort.Visible = false;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(58, 111);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(79, 20);
            this.textBoxPort.TabIndex = 4;
            this.textBoxPort.Visible = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(58, 156);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(78, 34);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // radioButtonOnline
            // 
            this.radioButtonOnline.AutoSize = true;
            this.radioButtonOnline.Location = new System.Drawing.Point(103, 58);
            this.radioButtonOnline.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonOnline.Name = "radioButtonOnline";
            this.radioButtonOnline.Size = new System.Drawing.Size(55, 17);
            this.radioButtonOnline.TabIndex = 2;
            this.radioButtonOnline.TabStop = true;
            this.radioButtonOnline.Text = "Online";
            this.radioButtonOnline.UseVisualStyleBackColor = true;
            this.radioButtonOnline.Click += new System.EventHandler(this.RadioButtonOnline_Click);
            // 
            // radioButtonOffline
            // 
            this.radioButtonOffline.AutoSize = true;
            this.radioButtonOffline.Location = new System.Drawing.Point(15, 79);
            this.radioButtonOffline.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonOffline.Name = "radioButtonOffline";
            this.radioButtonOffline.Size = new System.Drawing.Size(100, 17);
            this.radioButtonOffline.TabIndex = 6;
            this.radioButtonOffline.TabStop = true;
            this.radioButtonOffline.Text = "Endast en dator";
            this.radioButtonOffline.UseVisualStyleBackColor = true;
            this.radioButtonOffline.Click += new System.EventHandler(this.radioButtonOffline_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 214);
            this.Controls.Add(this.radioButtonOffline);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.radioButtonOnline);
            this.Controls.Add(this.radioButtonLAN);
            this.Controls.Add(this.labelServerType);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inställningar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelServerType;
        private System.Windows.Forms.RadioButton radioButtonLAN;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.RadioButton radioButtonOnline;
        private System.Windows.Forms.RadioButton radioButtonOffline;
    }
}