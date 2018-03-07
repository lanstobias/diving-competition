using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simhopp
{
    public delegate void InvokeJudgeListView();

    public class TCPServer
    {
        private static TCPServer server = null;

        public List<HandleClient> ClientList { get; set; } = new List<HandleClient>();

        private ContestPresenter contestPresenter = null;

        public static TCPServer Instance()
        {
            if (server == null)
                server = new TCPServer();
            return server;
        }

        private Int32 port = 27015;
        private IPAddress localAddress = IPAddress.Parse("127.0.0.1");
        private TcpListener tcpListener = null;
        private Thread threadServer = null;

        public TCPServer()
        {
            // Hämta ditt ip
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localAddress = ip;
                }
            }

            UploadServerList();

            // kallar Instance()
            server = this;

            threadServer = new Thread(server.ThreadListener);
            threadServer.IsBackground = true;

            
            threadServer.Start();
        }

        private void UploadServerList()
        {

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com/simhoppServers.txt");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // Get network credentials.
            request.Credentials = new NetworkCredential("oskarsandh", "simmalungt1");

            // Write the text's bytes into the request stream.
            string text = localAddress.ToString();
            request.ContentLength = text.Length;

            using (Stream request_stream = request.GetRequestStream())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                request_stream.Write(bytes, 0, text.Length);
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
            this.contestPresenter = contest;
        }

        // lyssnar efter clienter
        private void ThreadListener()
        {
            try
            {
                tcpListener = new TcpListener(localAddress, port);
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
