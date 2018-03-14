namespace Simhopp
{
    partial class ManualJudging
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
            this.labelPoints = new System.Windows.Forms.Label();
            this.sliderPoints = new System.Windows.Forms.TrackBar();
            this.buttonGiveScore = new System.Windows.Forms.Button();
            this.labelJudge = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.lvJudges = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPoints = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.sliderPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelPoints.Location = new System.Drawing.Point(150, 197);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(18, 20);
            this.labelPoints.TabIndex = 14;
            this.labelPoints.Text = "5";
            // 
            // sliderPoints
            // 
            this.sliderPoints.Location = new System.Drawing.Point(63, 235);
            this.sliderPoints.Maximum = 20;
            this.sliderPoints.Name = "sliderPoints";
            this.sliderPoints.Size = new System.Drawing.Size(446, 45);
            this.sliderPoints.TabIndex = 13;
            this.sliderPoints.Value = 10;
            this.sliderPoints.ValueChanged += new System.EventHandler(SliderPoints_ValueChanged);
            // 
            // buttonGiveScore
            // 
            this.buttonGiveScore.Location = new System.Drawing.Point(239, 286);
            this.buttonGiveScore.Name = "buttonGiveScore";
            this.buttonGiveScore.Size = new System.Drawing.Size(100, 51);
            this.buttonGiveScore.TabIndex = 12;
            this.buttonGiveScore.Text = "Sätt poäng";
            this.buttonGiveScore.UseVisualStyleBackColor = true;
            this.buttonGiveScore.Click += new System.EventHandler(this.buttonGiveScore_Click);
            // 
            // labelJudge
            // 
            this.labelJudge.AutoSize = true;
            this.labelJudge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelJudge.Location = new System.Drawing.Point(60, 202);
            this.labelJudge.Name = "labelJudge";
            this.labelJudge.Size = new System.Drawing.Size(0, 13);
            this.labelJudge.TabIndex = 11;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(467, 311);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 26);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Spara och stäng";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // lvJudges
            // 
            this.lvJudges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPoints});
            this.lvJudges.Location = new System.Drawing.Point(256, 39);
            this.lvJudges.Name = "lvJudges";
            this.lvJudges.Size = new System.Drawing.Size(178, 108);
            this.lvJudges.TabIndex = 17;
            this.lvJudges.UseCompatibleStateImageBehavior = false;
            this.lvJudges.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Namn";
            this.colName.Width = 109;
            // 
            // colPoints
            // 
            this.colPoints.Text = "Poäng";
            // 
            // ManualJudging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 371);
            this.Controls.Add(this.lvJudges);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.sliderPoints);
            this.Controls.Add(this.buttonGiveScore);
            this.Controls.Add(this.labelJudge);
            this.Name = "ManualJudging";
            this.Text = "ManualJudging";
            ((System.ComponentModel.ISupportInitialize)(this.sliderPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.TrackBar sliderPoints;
        private System.Windows.Forms.Button buttonGiveScore;
        private System.Windows.Forms.Label labelJudge;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ListView lvJudges;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPoints;
    }
}