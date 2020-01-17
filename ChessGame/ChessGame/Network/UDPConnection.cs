using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    class UDPConnection : ConnectionProtocol
    {
        UdpClient uClient;
        IPEndPoint RemoteIpEndPoint;

        public void Initial(NetworkInfo receiver)
        {
            try
            {
                RemoteIpEndPoint = ConnectTo(receiver);
            }
            catch
            {
                try
                {
                    RemoteIpEndPoint = ListenForConnection();
                }
                catch
                {
                }
            }
        }

        public override IPEndPoint ConnectTo(NetworkInfo receiver)
        {
            uClient = new UdpClient(thisPC.port);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(receiver.broadcastAddress), 0);
            return RemoteIpEndPoint;
        }

        public override IPEndPoint ListenForConnection()
        {
            uClient = new UdpClient(thisPC.port);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            return RemoteIpEndPoint;
        }

        public override string ReceivePacket()
        {
            string message = "";
            
            Byte[] data = uClient.Receive(ref RemoteIpEndPoint);
            Disconnect();
            message = Encoding.UTF8.GetString(data);

            return message;

        }

        public override void SendPacket(NetworkInfo receiver, RequestPacket requestPacket)
        {
            uClient.Connect(receiver.broadcastAddress, receiver.port);
            Byte[] data = Encoding.UTF8.GetBytes("#" + thisPC.hostName + "#" + thisPC.broadcastAddress + ":" + thisPC.port + "#" + requestPacket.GetMessage());
            uClient.Send(data, data.Length);
            uClient.Close();
        }

        public override void Disconnect()
        {
            if (uClient != null)
            {
                uClient.Close();
            }
        }

        public override Dictionary<string, string> AnalysisReceiveString(string message)
        {
            Dictionary<string, string> receivedString = new Dictionary<string, string>();
            return receivedString;
        }
    }
}
