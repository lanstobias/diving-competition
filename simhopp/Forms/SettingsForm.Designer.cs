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
            this.SuspendLayout();
            // 
            // labelServerType
            // 
            this.labelServerType.AutoSize = true;
            this.labelServerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerType.Location = new System.Drawing.Point(36, 22);
            this.labelServerType.Name = "labelServerType";
            this.labelServerType.Size = new System.Drawing.Size(209, 37);
            this.labelServerType.TabIndex = 0;
            this.labelServerType.Text = "Välj servertyp";
            // 
            // radioButtonLAN
            // 
            this.radioButtonLAN.AutoSize = true;
            this.radioButtonLAN.Location = new System.Drawing.Point(22, 90);
            this.radioButtonLAN.Name = "radioButtonLAN";
            this.radioButtonLAN.Size = new System.Drawing.Size(65, 24);
            this.radioButtonLAN.TabIndex = 1;
            this.radioButtonLAN.Checked = false;
            this.radioButtonLAN.TabStop = true;
            this.radioButtonLAN.Text = "LAN";
            this.radioButtonLAN.UseVisualStyleBackColor = true;
            this.radioButtonLAN.Click += new System.EventHandler(this.radioButtonLAN_Click);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(18, 164);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(42, 20);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port:";
            this.labelPort.Visible = false;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(66, 158);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(117, 26);
            this.textBoxPort.TabIndex = 4;
            this.textBoxPort.Visible = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(66, 228);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(117, 52);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // radioButtonOnline
            // 
            this.radioButtonOnline.AutoSize = true;
            this.radioButtonOnline.Location = new System.Drawing.Point(154, 90);
            this.radioButtonOnline.Name = "radioButtonOnline";
            this.radioButtonOnline.Size = new System.Drawing.Size(79, 24);
            this.radioButtonOnline.TabIndex = 2;
            this.radioButtonOnline.TabStop = true;
            this.radioButtonOnline.Text = "Online";
            this.radioButtonOnline.UseVisualStyleBackColor = true;
            this.radioButtonOnline.Click += new System.EventHandler(this.radioButtonOnline_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 329);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.radioButtonOnline);
            this.Controls.Add(this.radioButtonLAN);
            this.Controls.Add(this.labelServerType);
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
    }
}