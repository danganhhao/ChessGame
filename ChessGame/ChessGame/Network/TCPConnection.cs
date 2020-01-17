using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChessGame.Network
{
   
    class TCPConnection : ConnectionProtocol
    {
        private TcpClient client;
        private TcpListener server;
        private NetworkStream ns;
        private StreamReader sr = null;
        private StreamWriter sw = null;
        private IPEndPoint iep;
        private Thread tActiveListenTCP;

        public void Initial(NetworkInfo receiver)
        {
            if (NetworkManager.GetInstance().cState == NetworkManager.ConnectionState.Listening)
            {
                iep = ListenForConnection();
            }
            else if (NetworkManager.GetInstance().cState == NetworkManager.ConnectionState.Connecting)
            {
                iep = ConnectTo(receiver);
            }
            client = new TcpClient();
            tActiveListenTCP = new Thread(new ThreadStart(ActiveListenTCP));
            tActiveListenTCP.IsBackground = true;
            tActiveListenTCP.Start();
        }

        public override IPEndPoint ConnectTo(NetworkInfo receiver)
        {
            return new IPEndPoint(IPAddress.Parse(receiver.broadcastAddress), receiver.port);
        }

        public override IPEndPoint ListenForConnection()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Any.Address, thisPC.port);
            server = new TcpListener(iep);
            server.Start();
            return iep;
        }

        void ActiveListenTCP()
        {
            while (true)
            {
                if (client.Connected)
                {
                    ns = client.GetStream();
                    sr = new StreamReader(ns);
                    sw = new StreamWriter(ns);
                    return;
                }
                if (NetworkManager.GetInstance().cState == NetworkManager.ConnectionState.Listening)
                {
                    client = server.AcceptTcpClient();
                }
                else
                {
                    client.Connect(iep);
                }
            }
        }

        public void SendPacket(string type, string item)
        {
            sw = new StreamWriter(client.GetStream());
            if (this.sw != null)
            {
                this.sw.WriteLine(type + "#" + item);
                this.sw.Flush();
            }
        }
        public override string ReceivePacket()
        {
            string strdata = "";
            sr = new StreamReader(client.GetStream());

            if (sr != null)
            {
                strdata = this.sr.ReadLine();
            }
            return strdata;
        }

        public override void Disconnect()
        {
            if (NetworkManager.GetInstance().cState == NetworkManager.ConnectionState.Disconnected)
            {
                tActiveListenTCP.Abort();
                if (NetworkManager.GetInstance().cState == NetworkManager.ConnectionState.Connected)
                {
                    server.Stop();
                }
                client.Close();
                iep = null;

                if (ns != null)
                {
                    ns.Close();
                    ns = null;
                }
                if (sw != null)
                {
                    sw.Close();
                    sw = null;
                }
                if (sr != null)
                {
                    sr.Close();
                    sr = null;
                }
            }
        }

        public void AnalysisReceiveString(string message, out string strT, out string strI)
        {
            int iType = message.IndexOf('#');
            int iItem = message.IndexOf('#', iType + 1);
            strT = message.Substring(0, iType);
            strI = message.Substring(iType + 1, message.Length - iType - 1);
        }
    }
}
