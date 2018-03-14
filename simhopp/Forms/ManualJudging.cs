using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public partial class ManualJudging : Form
    {
        private JudgeList judgeList;
        private Dive dive;
        public ScoreList ScoreList = new ScoreList();
        private int index = 0;

        public ManualJudging(Dive dive, JudgeList judgeList)
        {
            InitializeComponent();

            this.dive = dive;
            this.judgeList = judgeList;

            Setup();
        }

        private void Setup()
        {
            foreach(var j in judgeList)
            {
                ListViewItem item = new ListViewItem(j.GetFullName());
                item.SubItems.Add("");

                lvJudges.Items.Add(item);
            }

            labelJudge.Text = judgeList[0].GetFullName();

        }

        private void buttonGiveScore_Click(object sender, EventArgs e)
        {
            if(lvJudges.SelectedItems.Count == 1)
            {
                foreach (var judge in judgeList)
                {
                    if (judge.GetFullName() == lvJudges.SelectedItems[0].SubItems[0].Text)
                    {
                        int i = 0;

                        foreach (var score in ScoreList)
                        {
                            if (score.Judge == judge)
                                break;
                            i++;
                        }

                        if (i == ScoreList.Count)
                        {
                            ScoreList.Add(new Score(double.Parse(labelPoints.Text), judge));
                        }
                        else
                        {
                            ScoreList[i].Value = double.Parse(labelPoints.Text);
                        }
                    }
                }

                lvJudges.Items.Clear();

                foreach (var j in judgeList)
                {
                    ListViewItem item = new ListViewItem(j.GetFullName());

                    foreach (var score in ScoreList)
                    {
                        if (score.Judge == j)
                        {
                            item.SubItems.Add(score.Value.ToString());
                        }
                    }

                    lvJudges.Items.Add(item);
                }
            }

            labelJudge.Text = judgeList[index].GetFullName();
            lvJudges.Items[index++].Selected = true;
            lvJudges.Select();
            

            if (index == lvJudges.Items.Count)
                index = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(ScoreList.Count == judgeList.Count)
            {
                dive.Scores = ScoreList;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void SliderPoints_ValueChanged(object sender, EventArgs e)
        {
            double points = (double)sliderPoints.Value / 2;
            labelPoints.Text = points.ToString();
        }
    }
}
