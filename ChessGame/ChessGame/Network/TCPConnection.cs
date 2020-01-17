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

        public TCPConnection(NetworkInfo host)
        {
            thisPC = host;
        }

        public void Initial(NetworkInfo receiver)
        {
            if (NetworkManager.GetInstance().role == NetworkManager.Role.Server)
            {
                ListenForConnection();
            }
            else
            {
                ConnectTo(receiver);
            }
            client = new TcpClient();
        }

        public override IPEndPoint ConnectTo(NetworkInfo receiver)
        {
            iep = new IPEndPoint(IPAddress.Parse(receiver.IPAddress), receiver.port);

            tActiveListenTCP = new Thread(new ThreadStart(ActiveListenTCP));
            tActiveListenTCP.IsBackground = true;
            tActiveListenTCP.Start();

            return iep;
        }

        public override IPEndPoint ListenForConnection()
        {
            iep = new IPEndPoint(IPAddress.Any, thisPC.port);
            server = new TcpListener(iep);
            server.Start();
            NetworkManager.GetInstance().UDP.SendPacket(NetworkManager.GetInstance().receiverInfo, new Packet("SERVERREADY", ""));

            tActiveListenTCP = new Thread(new ThreadStart(ActiveListenTCP));
            tActiveListenTCP.IsBackground = true;
            tActiveListenTCP.Start();

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
                if (NetworkManager.GetInstance().role == NetworkManager.Role.Server)
                {
                    client = server.AcceptTcpClient();
                }
                else
                {
                    client.Connect(iep);
                    NetworkManager.GetInstance().UDP.SendPacket(NetworkManager.GetInstance().receiverInfo, new Packet("CLIENTREADY", ""));
                }
            }
        }

        public override void SendPacket(NetworkInfo receiver, Packet requestPacket)
        {
            sw = new StreamWriter(client.GetStream());
            if (this.sw != null)
            {
                this.sw.WriteLine(requestPacket.GetType() + "#" + thisPC.IPAddress + "#" + thisPC.port + "#" + thisPC.hostName + "#" + requestPacket.GetMessage());
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
            if (NetworkManager.GetInstance().connectionState == NetworkManager.ConnectionState.Disconnected)
            {
                tActiveListenTCP.Abort();
                if (NetworkManager.GetInstance().connectionState == NetworkManager.ConnectionState.Connected)
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

        public override Dictionary<string, string> AnalysisReceiveString(string message)
        {
            Dictionary<string, string> receivedString = new Dictionary<string, string>();
            int iType = message.IndexOf('#');
            int iReceiverIP = message.IndexOf('#', iType + 1);
            int iReceiverPort = message.IndexOf('#', iReceiverIP + 1);
            int iReceiverName = message.IndexOf('#', iReceiverPort + 1);
            int iMessage = message.IndexOf('#', iReceiverName + 1);

            receivedString.Add("Type", message.Substring(0, iType));
            receivedString.Add("ReceiverIP", message.Substring(iType + 1, iReceiverIP - iType - 1));
            receivedString.Add("ReceiverPort", message.Substring(iReceiverIP + 1, iReceiverPort - iReceiverIP - 1));
            receivedString.Add("ReceiverName", message.Substring(iReceiverPort + 1, iReceiverName - iReceiverPort - 1));
            receivedString.Add("Message", message.Substring(iReceiverName + 1, message.Length - iReceiverName - 1));

            return receivedString;
        }
    }
}
