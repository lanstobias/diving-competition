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
        private double Points { get; set; } = -1;

        private StreamReader sr = null;
        private StreamWriter sw = null;

        private TcpClient client = null;

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
                // get ip from public serverlist
                string ip = GetServerIp();

                Int32 port = 27015;
                client = new TcpClient(ip, port);

                sr = new StreamReader(client.GetStream());
                sw = new StreamWriter(client.GetStream());

                // Send a message to the server that u wish to login 
                sw.WriteLine("Login " + JudgeName);
                sw.Flush();

                String str = "";
                
                while (!str.StartsWith("quit"))
                {

                    // read what the server has to say
                    str = sr.ReadLine();
                    
                    
                    if (str.StartsWith("give"))
                    {
                        ToggleButtonSend();
                    }
                    
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
        
        /// <summary>
        /// Writes a message with the points to the server
        /// </summary>
        private void GiveScore()
        {
            ToggleButtonSend();
            sw.WriteLine("Points " + Points);
            sw.Flush();
        }

        /// <summary>
        /// Enable/disable ButtonGiveScore
        /// </summary>
        private void ToggleButtonSend()
        {
            View.Invoke(new InvokeButtonGiveScore(
                () => { View.ButtonGiveScore.Enabled = !(View.ButtonGiveScore.Enabled); }
                ));
        }

        /// <summary>
        /// This method collects the servers ip from a serverList stored on a FTP.
        /// Right now it uses a free shitty ftp but this can be easily changed
        /// </summary>
        /// <returns>A string containing the IP</returns>
        public string GetServerIp()
        {
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
            catch(Exception e)
            {
                MessageBox.Show("Could not connect to serverlist...");
                client?.Close();
                window.GoBackToPreviuosPanel();
            }

            return ip;
        }
    }
}
