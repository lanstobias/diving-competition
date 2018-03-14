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
        private Button buttonGiveScore;
        private Label labelScore;
        private Label labelPoints;
        private Label labelVenue;
        private Label labelCity;
        private Label labelContestName;
        private Label labelRequest;
        private Label labelMultGiven;
        private Label labelCodeGiven;
        private Label labelMult;
        private Label labelCode;
        private System.Windows.Forms.TrackBar sliderPoints;

        public Button ButtonGiveScore { get { return buttonGiveScore; } set { buttonGiveScore = value; } }

        public TrackBar SliderPoints { get { return sliderPoints; } set { sliderPoints = value; } }

        public Label LabelPoints { get { return labelPoints; } set { labelPoints = value; } }

        public Label LabelRequest { get { return labelRequest; } set { labelRequest = value; } }
        public Label LabelContestName { get { return labelContestName; } set { labelContestName = value; } }
        public Label LabelCity { get { return labelCity; } set { labelCity = value; } }
        public Label LabelVenue { get { return labelVenue; } set { labelVenue = value; } }

        public Label LabelCodeGiven { get { return labelCodeGiven; } set { labelCodeGiven = value; } }
        public Label LabelMultGiven { get { return labelMultGiven; } set { labelMultGiven = value; } }

        public event DelegateGiveScore EventGiveScore;
        public event DelegatePointSliderChanged EventPointSliderChanged;

        public JudgeDiveView()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.labelScore = new System.Windows.Forms.Label();
            this.buttonGiveScore = new System.Windows.Forms.Button();
            this.sliderPoints = new System.Windows.Forms.TrackBar();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelVenue = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelContestName = new System.Windows.Forms.Label();
            this.labelRequest = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelMult = new System.Windows.Forms.Label();
            this.labelCodeGiven = new System.Windows.Forms.Label();
            this.labelMultGiven = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.labelMultGiven);
            this.mainPanel.Controls.Add(this.labelCodeGiven);
            this.mainPanel.Controls.Add(this.labelMult);
            this.mainPanel.Controls.Add(this.labelCode);
            this.mainPanel.Controls.Add(this.labelRequest);
            this.mainPanel.Controls.Add(this.labelVenue);
            this.mainPanel.Controls.Add(this.labelCity);
            this.mainPanel.Controls.Add(this.labelContestName);
            this.mainPanel.Controls.Add(this.labelPoints);
            this.mainPanel.Controls.Add(this.sliderPoints);
            this.mainPanel.Controls.Add(this.buttonGiveScore);
            this.mainPanel.Controls.Add(this.labelScore);
            this.mainPanel.Location = new System.Drawing.Point(0, 20);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelScore.Location = new System.Drawing.Point(27, 187);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(59, 13);
            this.labelScore.TabIndex = 6;
            this.labelScore.Text = "Din poäng:";
            // 
            // buttonGiveScore
            // 
            this.buttonGiveScore.Enabled = false;
            this.buttonGiveScore.Location = new System.Drawing.Point(206, 271);
            this.buttonGiveScore.Name = "buttonGiveScore";
            this.buttonGiveScore.Size = new System.Drawing.Size(100, 51);
            this.buttonGiveScore.TabIndex = 8;
            this.buttonGiveScore.Text = "Ge Poäng";
            this.buttonGiveScore.UseVisualStyleBackColor = true;
            this.buttonGiveScore.Click += new System.EventHandler(this.buttonGiveScore_Click);
            // 
            // sliderPoints
            // 
            this.sliderPoints.Location = new System.Drawing.Point(30, 220);
            this.sliderPoints.Maximum = 20;
            this.sliderPoints.Name = "sliderPoints";
            this.sliderPoints.Size = new System.Drawing.Size(446, 45);
            this.sliderPoints.TabIndex = 9;
            this.sliderPoints.Value = 10;
            this.sliderPoints.ValueChanged += new System.EventHandler(this.sliderPoints_ValueChanged);
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelPoints.Location = new System.Drawing.Point(83, 182);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(18, 20);
            this.labelPoints.TabIndex = 10;
            this.labelPoints.Text = "5";
            // 
            // labelVenue
            // 
            this.labelVenue.AutoSize = true;
            this.labelVenue.Location = new System.Drawing.Point(27, 65);
            this.labelVenue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVenue.Name = "labelVenue";
            this.labelVenue.Size = new System.Drawing.Size(40, 13);
            this.labelVenue.TabIndex = 19;
            this.labelVenue.Text = "Simhall";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(27, 52);
            this.labelCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(29, 13);
            this.labelCity.TabIndex = 18;
            this.labelCity.Text = "Stad";
            // 
            // labelContestName
            // 
            this.labelContestName.AutoSize = true;
            this.labelContestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.labelContestName.Location = new System.Drawing.Point(26, 22);
            this.labelContestName.Name = "labelContestName";
            this.labelContestName.Size = new System.Drawing.Size(113, 20);
            this.labelContestName.TabIndex = 17;
            this.labelContestName.Text = "Contest name";
            // 
            // labelRequest
            // 
            this.labelRequest.AutoSize = true;
            this.labelRequest.ForeColor = System.Drawing.Color.DarkRed;
            this.labelRequest.Location = new System.Drawing.Point(27, 121);
            this.labelRequest.Name = "labelRequest";
            this.labelRequest.Size = new System.Drawing.Size(95, 13);
            this.labelRequest.TabIndex = 20;
            this.labelRequest.Text = "Bedömning stängd";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelCode.Location = new System.Drawing.Point(27, 154);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(54, 13);
            this.labelCode.TabIndex = 21;
            this.labelCode.Text = "Hoppkod:";
            // 
            // labelMult
            // 
            this.labelMult.AutoSize = true;
            this.labelMult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelMult.Location = new System.Drawing.Point(150, 154);
            this.labelMult.Name = "labelMult";
            this.labelMult.Size = new System.Drawing.Size(32, 13);
            this.labelMult.TabIndex = 22;
            this.labelMult.Text = "Multi:";
            // 
            // labelCodeGiven
            // 
            this.labelCodeGiven.AutoSize = true;
            this.labelCodeGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelCodeGiven.Location = new System.Drawing.Point(84, 154);
            this.labelCodeGiven.Name = "labelCodeGiven";
            this.labelCodeGiven.Size = new System.Drawing.Size(0, 13);
            this.labelCodeGiven.TabIndex = 23;
            // 
            // labelMultGiven
            // 
            this.labelMultGiven.AutoSize = true;
            this.labelMultGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelMultGiven.Location = new System.Drawing.Point(188, 154);
            this.labelMultGiven.Name = "labelMultGiven";
            this.labelMultGiven.Size = new System.Drawing.Size(0, 13);
            this.labelMultGiven.TabIndex = 24;
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
