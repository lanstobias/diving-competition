namespace simhopp
{
    partial class DatePicker
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
            this.calender = new System.Windows.Forms.MonthCalendar();
            this.buttonSelectDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calender
            // 
            this.calender.Location = new System.Drawing.Point(18, 18);
            this.calender.MaxSelectionCount = 1;
            this.calender.Name = "calender";
            this.calender.TabIndex = 0;
            // 
            // buttonSelectDate
            // 
            this.buttonSelectDate.Location = new System.Drawing.Point(93, 192);
            this.buttonSelectDate.Name = "buttonSelectDate";
            this.buttonSelectDate.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectDate.TabIndex = 1;
            this.buttonSelectDate.Text = "OK";
            this.buttonSelectDate.UseVisualStyleBackColor = true;
            this.buttonSelectDate.Click += new System.EventHandler(this.buttonSelectDate_Click);
            // 
            // DatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 238);
            this.Controls.Add(this.buttonSelectDate);
            this.Controls.Add(this.calender);
            this.Name = "DatePicker";
            this.Text = "DatePicker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calender;
        private System.Windows.Forms.Button buttonSelectDate;
    }
}