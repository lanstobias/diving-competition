using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public class JudgeDiveView : PanelViewControl, IJudgeDiveView
    {
        private System.Windows.Forms.Button buttonGiveScore;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelDiver;
        private System.Windows.Forms.Label labelTypeOfDive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.TrackBar sliderPoints;
        private System.Windows.Forms.TextBox textBox1;

        public System.Windows.Forms.Button ButtonGiveScore { get { return buttonGiveScore; } set { buttonGiveScore = value; } }
        public TrackBar SliderPoints { get { return sliderPoints; } set { sliderPoints = value; } }
        public Label LabelPoints { get { return labelPoints; } set { labelPoints = value; } }

        public event DelegateGiveScore EventGiveScore;
        public event DelegatePointSliderChanged EventPointSliderChanged;

        public JudgeDiveView()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTypeOfDive = new System.Windows.Forms.Label();
            this.labelDiver = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.buttonGiveScore = new System.Windows.Forms.Button();
            this.sliderPoints = new System.Windows.Forms.TrackBar();
            this.labelPoints = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.labelPoints);
            this.mainPanel.Controls.Add(this.sliderPoints);
            this.mainPanel.Controls.Add(this.buttonGiveScore);
            this.mainPanel.Controls.Add(this.textBox4);
            this.mainPanel.Controls.Add(this.labelScore);
            this.mainPanel.Controls.Add(this.labelDiver);
            this.mainPanel.Controls.Add(this.labelTypeOfDive);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.textBox3);
            this.mainPanel.Controls.Add(this.textBox2);
            this.mainPanel.Controls.Add(this.textBox1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(206, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(206, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(206, 162);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hopp nr:";
            // 
            // labelTypeOfDive
            // 
            this.labelTypeOfDive.AutoSize = true;
            this.labelTypeOfDive.Location = new System.Drawing.Point(130, 109);
            this.labelTypeOfDive.Name = "labelTypeOfDive";
            this.labelTypeOfDive.Size = new System.Drawing.Size(70, 13);
            this.labelTypeOfDive.TabIndex = 4;
            this.labelTypeOfDive.Text = "Typ av hopp:";
            // 
            // labelDiver
            // 
            this.labelDiver.AutoSize = true;
            this.labelDiver.Location = new System.Drawing.Point(149, 169);
            this.labelDiver.Name = "labelDiver";
            this.labelDiver.Size = new System.Drawing.Size(51, 13);
            this.labelDiver.TabIndex = 5;
            this.labelDiver.Text = "Hoppare:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(141, 243);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(59, 13);
            this.labelScore.TabIndex = 6;
            this.labelScore.Text = "Din poäng:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(206, 205);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            // 
            // buttonGiveScore
            // 
            this.buttonGiveScore.Enabled = false;
            this.buttonGiveScore.Location = new System.Drawing.Point(206, 299);
            this.buttonGiveScore.Name = "buttonGiveScore";
            this.buttonGiveScore.Size = new System.Drawing.Size(100, 51);
            this.buttonGiveScore.TabIndex = 8;
            this.buttonGiveScore.Text = "Ge Poäng";
            this.buttonGiveScore.UseVisualStyleBackColor = true;
            this.buttonGiveScore.Click += new System.EventHandler(this.buttonGiveScore_Click);
            // 
            // sliderPoints
            // 
            this.sliderPoints.Location = new System.Drawing.Point(206, 231);
            this.sliderPoints.Maximum = 20;
            this.sliderPoints.Name = "sliderPoints";
            this.sliderPoints.Size = new System.Drawing.Size(104, 45);
            this.sliderPoints.TabIndex = 9;
            this.sliderPoints.ValueChanged += new System.EventHandler(this.sliderPoints_ValueChanged);
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(226, 263);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(0, 13);
            this.labelPoints.TabIndex = 10;
            // 
            // JudgeDiveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "JudgeDiveView";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPoints)).EndInit();
            this.ResumeLayout(false);

        }

        private void buttonGiveScore_Click(object sender, EventArgs e)
        {
            this.EventGiveScore?.Invoke();
        }

        private void sliderPoints_ValueChanged(object sender, EventArgs e)
        {
            this.EventPointSliderChanged?.Invoke();
        }
    }
}
