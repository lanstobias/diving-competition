using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public partial class ServerBrowser : Form
    {
        public List<string> ServerList { get; set; }

        public string ChosenIp { get; set; }

        public ServerBrowser()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            ServerList = GetServerList();

            foreach(var host in ServerList)
                listBoxServers.Items.Add(host);
        }

        private void Connect()
        {
            var host = listBoxServers.SelectedItem as string;

            ChosenIp = host.Substring(host.IndexOf(":") + 1);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ConnectToIp(string ip)
        {
            ChosenIp = ip;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// This method collects the list of servers/contest that are active from a file stored on a FTP.
        /// Right now it uses a free shitty ftp but this can easily be changed
        /// </summary>
        /// <returns>A string containing the IP</returns>
        public List<string> GetServerList()
        {
            List<string> serverList = new List<string>();
            WebClient request = new WebClient();
            string url = "ftp://files.000webhost.com/simhopp/simhoppServers.txt";

            // Get network credentials.
            request.Credentials = new NetworkCredential("oskarsandh", "simmalungt1");

            string servers = "";

            try
            {
                byte[] bytes = request.DownloadData(url);
                servers = System.Text.Encoding.UTF8.GetString(bytes);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not connect to serverlist...");
            }

            StringReader readServers = new StringReader(servers);

            // read each line containing server info
            string host = null;
            while (true)
            {
                host = readServers.ReadLine();

                if(host != null)
                {
                    serverList.Add(host);
                }
                else
                {
                    break;
                }
            }
            return serverList;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void buttonConnectToIP_Click(object sender, EventArgs e)
        {
            
            string input = InputDialog.OpenDialog("Skriv in det ip du vill ansluta till");

            if (input != "" && CheckDataInput.IpAddressCheckFormat(input))
                ConnectToIp(input);

            else
                MessageBox.Show("Inte en korrekt ip-adress!");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            listBoxServers.Items.Clear();

            foreach (var server in GetServerList())
                listBoxServers.Items.Add(server);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
