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
    public delegate void InvokeJudgeListView();

    public class TCPServer
    {
        private static TCPServer server = null;

        public List<HandleClient> ClientList { get; set; } = new List<HandleClient>();

        public string HostInfo { get; set; } = "";

        private ContestPresenter contestPresenter = null;

        public static TCPServer Instance(ContestPresenter contest)
        {
            if (server == null)
                server = new TCPServer(contest);
            return server;
        }

        private Int32 port = 27015;
        private IPAddress serverIp = IPAddress.Parse("127.0.0.1");
       
        private TcpListener tcpListener = null;
        private Thread threadServer = null;

        public TCPServer(ContestPresenter contest)
        {
            // Hämta ditt ip
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    serverIp = ip;
                }
            }

            this.contestPresenter = contest;

            HostInfo = contestPresenter.CurrentContest.Info.Name + ":" + serverIp.ToString();

            // kallar Instance()
            server = this;

            AddIpToServerList();

            threadServer = new Thread(server.ThreadListener);
            threadServer.IsBackground = true;

            
            threadServer.Start();
        }



        private void AddIpToServerList()
        {
            //// hämta hem serverlistan så detta ip kan läggas till
            //WebClient webClient = new WebClient();


            //// Loggin in på ftp:n
            //webClient.Credentials = new NetworkCredential("oskarsandh", "simmalungt1");

            //string hostList = "";

            //try
            //{
            //    byte[] bytes = webClient.DownloadData(url);
            //    hostList = System.Text.Encoding.UTF8.GetString(bytes);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Could not connect to serverlist...");
            //}


            // Get the object used to communicate with the server.
            string url = "ftp://files.000webhost.com/simhoppServers.txt";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.AppendFile;
            

            // Get network credentials.
            request.Credentials = new NetworkCredential("oskarsandh", "simmalungt1");

            // Write the ipLists bytes into the request stream.
            string finalHostList = HostInfo + "\n";

            Stream request_stream = request.GetRequestStream();
            byte[] bytes = Encoding.UTF8.GetBytes(finalHostList);

            request.ContentLength = bytes.Length;

            request_stream.Write(bytes, 0, bytes.Length);
            request_stream.Close();
        }

        public void RemoveIpFromServerList()
        {
            // hämta hem serverlistan så detta ip kan tas bort till
            WebClient webClient = new WebClient();
            string url = "ftp://files.000webhost.com/simhoppServers.txt";

            // Loggin in på ftp:n
            webClient.Credentials = new NetworkCredential("oskarsandh", "simmalungt1");

            string ipList = "";

            try
            {
                byte[] bytes = webClient.DownloadData(url);
                ipList = System.Text.Encoding.UTF8.GetString(bytes);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not connect to serverlist...");
            }


            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // Get network credentials.
            request.Credentials = webClient.Credentials;

            // Write the ipLists bytes into the request stream.
            int index = ipList.IndexOfAny(HostInfo.ToCharArray());

            ipList = ipList.Remove(index, (HostInfo + "\n").Length);

            request.ContentLength = ipList.Length;

            using (Stream request_stream = request.GetRequestStream())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(ipList);
                request_stream.Write(bytes, 0, ipList.Length);
                request_stream.Close();
            }
        }

        internal void RequestPoints()
        {
            foreach (var client in ClientList)
            {
                client.StreamWriter?.WriteLine("give");
                client.StreamWriter?.Flush();
            }
        }


        public void TieToContest(ContestPresenter contest)
        {
            //this.contestPresenter = contest;
        }

        // lyssnar efter clienter
        private void ThreadListener()
        {
            try
            {
                tcpListener = new TcpListener(serverIp, port);
                tcpListener.Start();

                while (true)
                {
                    //UpdateLabel("Waiting for connection...");

                    TcpClient client = tcpListener.AcceptTcpClient();

                    HandleClient c = new HandleClient(this, client, (ClientList.Count + 1), contestPresenter);

                    
                    AddToJudgeListView(c);
                }

            }
            catch (SocketException e)
            {

            }
            finally
            {
                RemoveIpFromServerList();
                KillThreads();
                tcpListener.Stop();
            }
        }

        public void KillThreads()
        {
            threadServer.IsBackground = true;
            foreach (var client in ClientList)
            {
                client.ThreadClient.IsBackground = true;
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
