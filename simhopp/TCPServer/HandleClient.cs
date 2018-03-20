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

    /// <summary>
    /// HandleClient does what its name suggests.
    /// It contains a TcpClient object and runs its own ClientThread,
    /// Also has a referens to the TCPServer object where this (HandleClient) was created
    /// </summary>
    public class HandleClient
    {
        #region Properties
        public string ClientName { get; set; }
        public IPEndPoint EndPoint { get; set; } = null;
        public NetworkStream NetworkStream { get; set; } = null;
        public StreamReader StreamReader { get; set; } = null;
        public StreamWriter StreamWriter { get; set; } = null;
        public TcpClient Client { get; set; } = null;
        public Thread ThreadClient { get; set; } = null;
        public TCPServer Server { get; set; } = null;

        public bool IsHost { get; set; }

        public string Points { get; set; } = "-1";

        private ContestPresenter contestPresenter;

        #endregion

        #region Constructor

        public HandleClient(TCPServer server, TcpClient client, ContestPresenter contest)
        {
            this.contestPresenter = contest;
            this.Server = server;
            this.Client = client;
            ClientName = "";

            ThreadClient = new Thread(ClientThread);
            ThreadClient.IsBackground = true;
            ThreadClient.Name = "Client ";
            ThreadClient.Start();
            
        }

        #endregion

        #region Methods
        /// <summary>
        /// Listens for messages from a client
        /// </summary>
        public void ClientThread()
        {
            string msg = "";

            try
            {
                NetworkStream = Client.GetStream();
                StreamReader = new StreamReader(NetworkStream);
                StreamWriter = new StreamWriter(NetworkStream);

                ContestInfo info = contestPresenter.CurrentContest.Info;
                msg = "contest:" + info.Name + "|" + info.City + "|" + info.Arena;
                // contest: Example Event|Lyon|Arena

                StreamWriter.WriteLine(msg);
                StreamWriter.Flush();

                while (true)
                {
                    // read what the client has to say
                    msg = StreamReader.ReadLine();

                    if (msg == null || msg.StartsWith("quit"))
                    {
                        break;
                    }
                    else if (msg.StartsWith("Login:"))
                    {
                        string msgName = msg.Substring(6);

                        if (AcceptClient(msgName))
                        {
                            ClientName = msg.Substring(6);
                            Server.UpdateJudgeListView();
                        }
                        else
                        {
                            StreamWriter.WriteLine("denied");
                            StreamWriter.Flush();
                        }
                        
                    }
                    else if (msg.StartsWith("Points:"))
                    {
                        Points = msg.Substring(7);
                        AddPointToList(Points.ToString());

                    }
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            finally
            {
                if (!IsHost)
                {
                    Client.Close();

                    foreach (var client in Server.ClientList)
                    {
                        if (this == client)
                        {
                            Server.ClientList.Remove(client);
                            break;
                        }

                    }
                    Server.UpdateJudgeListView();
                    ThreadClient.Abort();
                }
            }

        }

        /// <summary>
        /// Checks if the client connecting is a judge in the contest.
        /// </summary>
        /// <param name="msgName"></param>
        /// <returns>True if connected client is a judge in the contest</returns>
        private bool AcceptClient(string msgName)
        {
            foreach(var judge in contestPresenter.CurrentContest.Judges)
            {
                if (judge.GetFullName() == msgName)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// This method handles communication with the GUI-thread belonging to contestPresenter
        /// </summary>
        /// <param name="point">The score to be added</param>
        public void AddPointToList(string point)
        {
            contestPresenter.View.Invoke(new InvokeContestPresenter(
                () => { lock (contestPresenter.View.ListViewJudgeClients)
                {
                    contestPresenter.AddToPointList(ClientName, point);
                } }
                ));
        }

        #endregion
    }
}
