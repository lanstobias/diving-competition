using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public delegate void InvokeJudgeDiveView();
    public delegate void InvokeMainWindow();

    public class JudgeDivePresenter
    {
        public string JudgeName { get; set; }
        public JudgeDiveView View { get; set; }

        private ProjectMainWindow window;

        private Thread threadClient = null;
        private double Points { get; set; } = -1;

        private StreamReader sr = null;
        private StreamWriter sw = null;

        private TcpClient client = null;

        private string ServerIp { get; set; }

        public JudgeDivePresenter(JudgeDiveView view, ProjectMainWindow window, string serverIp)
        {
            ServerIp = serverIp;
            JudgeName = window.CurrentJudge.GetFullName();
            View = view;
            this.window = window;

            View.EventGiveScore += GiveScore;
            View.EventPointSliderChanged += SetPoints;

            threadClient = new Thread(RunClient);
            threadClient.IsBackground = true;
            threadClient.Start();
        }

        /// <summary>
        /// Sets the Points property to whatever the pointslider is set to
        /// </summary>
        private void SetPoints()
        {
            Points = (double)View.SliderPoints.Value / 2;
            View.LabelPoints.Text = Points.ToString();
        }

        public void RunClient()
        {
            
            try
            {
                Int32 port = 9058;
                client = new TcpClient(ServerIp, port);

                sr = new StreamReader(client.GetStream());
                sw = new StreamWriter(client.GetStream());

                // Send a message to the server that u wish to login 
                sw.WriteLine("Login:" + JudgeName);
                sw.Flush();

                String msg = "";
                
                while (!msg.StartsWith("quit"))
                {

                    // read what the server has to say
                    msg = sr.ReadLine();
                    
                    if(msg.StartsWith("contest:"))
                    {
                        UpdateContestInfo(msg.Substring(8));
                    }
                    else if (msg.StartsWith("give"))
                    {
                        ToggleGiveScore();
                    }
                }
                
            }
            catch (SocketException)
            {
                MessageBox.Show("Kan inte ansluta till server...");
            }
            finally
            {
                if(client.Connected)
                    sw.WriteLine("quit");

                client?.Close();
                MessageBox.Show("disconnected from server");

                this.GoBackToStartMenu();
            }
        }
        
        /// <summary>
        /// Writes a message with the points to the server
        /// </summary>
        private void GiveScore()
        {
            ToggleGiveScore();
            sw.WriteLine("Points:" + Points);
            sw.Flush();
        }

        /// <summary>
        /// Enable/disable ButtonGiveScore
        /// </summary>
        private void ToggleGiveScore()
        {
            View.Invoke(new InvokeJudgeDiveView(
                () => 
                {
                    View.ButtonGiveScore.Enabled = !(View.ButtonGiveScore.Enabled);

                    if (View.ButtonGiveScore.Enabled)
                    {
                        View.LabelRequest.Text = "Poäng begärd av huvuddomare";
                        View.LabelRequest.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    else
                    {
                        View.LabelRequest.Text = "Bedömning stängd";
                        View.LabelRequest.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
                ));
        }

        /// <summary>
        /// Takes information about a contest and puts said info into the correct labels in JudgeDiveView
        /// </summary>
        /// <param name="info">Need to be formated as such: Lyon Diving Event|Lyon|Venue</param>
        private void UpdateContestInfo(string info)
        {
            string[] infoArr = info.Split('|');

            View.Invoke(new InvokeJudgeDiveView(
                () =>
                {
                    View.LabelContestName.Text = infoArr[0];
                    View.LabelCity.Text = infoArr[1];
                    View.LabelVenue.Text = infoArr[2];
                }
                ));
        }

        private void GoBackToStartMenu()
        {

            window.Invoke(new InvokeMainWindow(
                () =>
                {
                    window.GoBackToStartMenu();
                }

                ));
        }
    }
}
