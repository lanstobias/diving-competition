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
    public delegate void InvokeContestPresenter();
    public class HandleClient
    {
        public string ClientName { get; set; }
        public IPEndPoint EndPoint { get; set; } = null;
        public NetworkStream NetworkStream { get; set; } = null;
        public StreamReader StreamReader { get; set; } = null;
        public StreamWriter StreamWriter { get; set; } = null;
        public TcpClient Client { get; set; } = null;
        public Thread ThreadClient { get; set; } = null;
        public TCPServer Server { get; set; } = null;

        public double Points { get; set; } = -1;

        public bool AcceptPoints { get; set; }

        private ContestPresenter contestPresenter;

        public HandleClient(TCPServer server, TcpClient client, int id, ContestPresenter contest)
        {
            this.contestPresenter = contest;
            this.Server = server;
            this.Client = client;
            ClientName = "";

            ThreadClient = new Thread(ClientThread);
            ThreadClient.IsBackground = true;
            ThreadClient.Name = "Client " + id;
            ThreadClient.Start();
            
        }

        public void ClientThread()
        {
            string msg = "";

            try
            {
                NetworkStream = Client.GetStream();
                StreamReader = new StreamReader(NetworkStream);
                StreamWriter = new StreamWriter(NetworkStream);
                

                while (true)
                {
                    msg = StreamReader.ReadLine();

                    if (msg == null || msg.StartsWith("quit"))
                    {
                        break;
                    }
                    else if (msg.StartsWith("Login "))
                    {
                        ClientName = msg.Substring(6);
                        Server.UpdateJudgeListView();
                    }
                    else if (msg.StartsWith("Points "))
                    {
                        Points = Convert.ToDouble(msg.Substring(7));
                        AddPointToList(Points.ToString());

                    }
                }

            }
            catch (IOException ioe) { }
            finally
            {
                Client.Close();
                ThreadClient.IsBackground = true;

                foreach (var client in Server.ClientList)
                {
                    if (this == client)
                    {
                        Server.ClientList.Remove(client);
                        break;
                    }

                }

                ThreadClient.Abort();

            }

        }

        public void AddPointToList(string point)
        {
            contestPresenter.View.Invoke(new InvokeContestPresenter(
                () => { lock (contestPresenter.View.ListViewJudgeClients)
                {
                    contestPresenter.AddToPointList(ClientName, point);
                } }
                ));
        }
    }
}
