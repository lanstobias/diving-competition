using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public delegate void InvokeJudgeListView();

    public class TCPServer
    {
        private bool Run { get; set; } = true;

        private bool LANServer { get; set; } = true;

        private static TCPServer server = null;

        public List<HandleClient> ClientList { get; set; } = new List<HandleClient>();

        public string HostInfo { get; set; } = "";

        private ContestPresenter contestPresenter = null;

        private string url = "ftp://files.000webhost.com/simhopp/simhoppServers.txt";

        public static TCPServer Instance(ContestPresenter contest)
        {
            if (server == null)
                server = new TCPServer(contest);
            return server;
        }

        private Int32 port = 9058;
        private IPAddress serverIp = IPAddress.Parse("127.0.0.1");
       
        private TcpListener tcpListener = null;
        private Thread threadServer = null;

        public TCPServer(ContestPresenter contest)
        {
            LANServer = contest.window.LAN;
            port = contest.window.Port;

            if (LANServer)
            {
                serverIp = GetInternalIP();
            }
            else
            {
                serverIp = GetPublicIP();
                // the port will also need to be opened for the server
            }

            contestPresenter = contest;

            HostInfo = contestPresenter.CurrentContest.Info.Name + ":" + serverIp.ToString();

            // kallar Instance()
            server = this;

            AddIpToServerList();

            threadServer = new Thread(server.ThreadListener);
            threadServer.IsBackground = true;
            threadServer.Start();
        }

        // Listens for clients
        private void ThreadListener()
        {
            try
            {
                tcpListener = new TcpListener(GetInternalIP(), port);
                tcpListener.Start();

                while (true)
                {
                    if (!Run)
                        break;

                    TcpClient client = tcpListener.AcceptTcpClient();

                    HandleClient c = new HandleClient(this, client, (ClientList.Count + 1), contestPresenter);

                    AddToJudgeListView(c);
                }
            }
            catch (SocketException e)
            {
                // hantera om servern inte kan sättas upp
                // manuel input av poäng?
            }
            finally
            {
                Kill();
            }
        }

        /// <summary>
        /// Shutdown the server
        /// </summary>
        public void Kill()
        {
            RemoveIpFromServerList();

            foreach (var client in ClientList)
            {
                client.StreamWriter.WriteLine("quit");
            }

            tcpListener.Stop();
            threadServer.Abort();
        }

        public void ShutDown()
        {
            Run = false;
        }

        /// <summary>
        /// Finds and stores the servers local ip-address
        /// </summary>
        /// <returns>IPAddress</returns>
        private IPAddress GetInternalIP()
        {
            IPAddress ip = null;

            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var _ip in host.AddressList)
            {
                if (_ip.AddressFamily == AddressFamily.InterNetwork)
                    ip = _ip;
            }

            return ip;
        }

        /// <summary>
        /// Finds and stores the servers public ip-address.
        /// </summary>
        /// <returns>IPAddress</returns>
        private IPAddress GetPublicIP()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");

            using (WebClient webClient = new WebClient())
            {

                try
                {
                    string text = webClient.DownloadString("http://checki.dyndns.org");
                    
                    text = text.Substring( text.LastIndexOfAny(": ".ToCharArray()) + 1 );

                    string ipAddr = text.Substring(0, text.IndexOf('<'));

                    ip = IPAddress.Parse(ipAddr);
                }
                catch (WebException)
                {
                    if(MessageBox.Show("Kan inte hitta din publika IP-adress. Tryck Ok för att skriva in den manuellt.") == DialogResult.OK)
                    {
                        string input = InputDialog.OpenDialog("Fyll i ditt ip");
                        if (input != "" && CheckDataInput.IpAddressCheckFormat(input))
                            ip = IPAddress.Parse(input);
                    }
                }
            }

            return ip;
        }

        /// <summary>
        /// Adds this servers ip-address to the online serverList
        /// </summary>
        private void AddIpToServerList()
        {
            try
            {
                // Create a ftp request on the chosen url
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);

                // use the AppendFile method
                request.Method = WebRequestMethods.Ftp.AppendFile;

                // Get ftp credentials.
                request.Credentials = new NetworkCredential("oskarsandh", "simmalungt1");

                // Write the new host to the server list
                using (Stream request_stream = request.GetRequestStream())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(HostInfo + "\n");

                    request.ContentLength = bytes.Length;

                    request_stream.Write(bytes, 0, bytes.Length);
                    request_stream.Close();
                }

            }
            catch (WebException)
            {
                MessageBox.Show("Kan inte ansluta till server listan!");
            }
            
        }

        public bool RemoveIpFromServerList()
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.Credentials = new NetworkCredential("oskarsandh", "simmalungt1");

                string ipList = "";

                try
                {
                    byte[] bytes = webClient.DownloadData(url);

                    ipList = Encoding.UTF8.GetString(bytes);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not connect to serverlist...");
                    return false;
                }


                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // Get network credentials.
                request.Credentials = webClient.Credentials;

                // Find the start index of the host in the hostList
                int index = ipList.IndexOfAny(HostInfo.ToCharArray());

                if(index != -1)
                {
                    ipList = ipList.Remove(index, (HostInfo + "\n").Length);

                    request.ContentLength = ipList.Length;

                    using (Stream request_stream = request.GetRequestStream())
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(ipList);
                        request_stream.Write(bytes, 0, ipList.Length);
                        request_stream.Close();
                    }
                }
                
            }

            return true;
        }

        internal void RequestPoints()
        {
            foreach (var client in ClientList)
            {
                client.StreamWriter?.WriteLine("give");
                client.StreamWriter?.Flush();
            }
        }

        private void AddToJudgeListView(HandleClient client)
        {
            lock (ClientList)
            {
                if(!ClientList.Contains(client))
                    ClientList.Add(client);
            }

            contestPresenter?.View?.Invoke(new InvokeJudgeListView(
                () => { contestPresenter.AddToClientListView(client); }
                ));
           
        }

        public void UpdateJudgeListView()
        {
            contestPresenter?.View?.Invoke(new InvokeJudgeListView(
               () => { contestPresenter.RefreshClientListView(); }
               ));
        }
    }
}
