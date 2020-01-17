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

        public override void SendPacket(NetworkInfo receiver, Packet requestPacket)
        {
            UdpClient udp = new UdpClient();
            udp.Connect(receiver.broadcastAddress, thisPC.port);
            Byte[] data = Encoding.UTF8.GetBytes("#" + requestPacket.GetType() + "#" + thisPC.broadcastAddress + "#" + thisPC.hostName + "#" + requestPacket.GetMessage());
            udp.Send(data, data.Length);
            udp.Close();
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
            int iType = message.IndexOf('#');
            int iReceiverIP = message.IndexOf('#', iType + 1);
            int iReceiverName = message.IndexOf('#', iReceiverIP + 1);
            int iMessage = message.IndexOf('#', iReceiverName + 1);

            receivedString.Add("Type",message.Substring(0, iType));
            receivedString.Add("ReceiverIP",message.Substring(iType + 1, iReceiverIP - iType - 1));
            receivedString.Add("ReceiverName",message.Substring(iReceiverIP + 1, iReceiverName - iReceiverIP - 1));
            receivedString.Add("Message",message.Substring(iReceiverName + 1, message.Length - iReceiverName - 1));

            return receivedString;
        }
    }
}
