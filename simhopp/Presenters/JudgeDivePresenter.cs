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
    public delegate void InvokeButtonGiveScore();
    public class JudgeDivePresenter
    {
        public string JudgeName { get; set; }
        public JudgeDiveView View { get; set; }

        private ProjectMainWindow window;

        private Thread threadClient = null;
        private double points = -1;
        private string message = "";

        public JudgeDivePresenter(JudgeDiveView view, ProjectMainWindow window)
        {
            LoginForm login = new LoginForm();
            if(login.ShowDialog() == DialogResult.OK)
            {
                JudgeName = login.JudgeName;
            }
            this.View = view;
            this.window = window;

            View.EventGiveScore += GiveScore;
            View.EventPointSliderChanged += SetPoints;

            threadClient = new Thread(RunClient);
            threadClient.IsBackground = false;
            threadClient.Start();
        }

        private void SetPoints()
        {
            points = (double)View.SliderPoints.Value / 2;
            View.LabelPoints.Text = points.ToString();
        }

        public void RunClient()
        {
            TcpClient client = null;


            try
            {
                // get ip from public serverlist
                WebClient request = new WebClient();
                string url = "ftp://files.000webhost.com/simhoppServers.txt";

                // Get network credentials.
                request.Credentials = new NetworkCredential("oskarsandh", "simmalungt1");

                string ip = "127.0.0.1";

                try
                {
                    byte[] bytes = request.DownloadData(url);
                    ip = System.Text.Encoding.UTF8.GetString(bytes);
                }
                catch
                {
                    // do something
                }

                Int32 port = 27015;
                client = new TcpClient(ip, port);

                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());

                String str = "";

                bool firstRun = true;
                

                while (!str.StartsWith("quit"))
                {
                    str = sr.ReadLine();

                    if (str.StartsWith("l ") && firstRun)
                    {
                        sw.WriteLine("Login " + JudgeName);
                        firstRun = false;
                    }

                    // server har skickat ut att den vill ha något
                    if (str.StartsWith("give"))
                    {
                        sw.WriteLine(" ");
                        ToggleButtonSend();
                    }
                    // knappen är tryckt
                    else if (str.StartsWith("open") && sendPoints)
                    {
                        ToggleButtonSend();
                        sw.WriteLine(message);
                        sendPoints = false;
                    }

                    message = "";
                    sw.Flush();
                }
            }
            catch (IOException ioe)
            {
                client?.Close();
            }
            finally
            {
                client?.Close();
            }
        }

        bool sendPoints = false;
        private void GiveScore()
        {
            message = "Points " + points;
            sendPoints = true;
        }

        private void ToggleButtonSend()
        {
            View.Invoke(new InvokeButtonGiveScore(
                () => { View.ButtonGiveScore.Enabled = !(View.ButtonGiveScore.Enabled); }
                ));
        }
    }
}
