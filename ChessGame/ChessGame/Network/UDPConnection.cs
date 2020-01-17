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

        public UDPConnection(NetworkInfo host)
        {
            thisPC = host;
        }

        public string ReceivePacket(NetworkInfo sender)
        {
            try
            {
                uClient = new UdpClient(thisPC.port);
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(sender.IPAddress), 0);

                Byte[] data = uClient.Receive(ref RemoteIpEndPoint);
                uClient.Close();
                string message = Encoding.UTF8.GetString(data);
                return message;
            }
            catch
            {
                return "";
            }

        }

        public override void SendPacket(NetworkInfo receiver, Packet requestPacket)
        {
            UdpClient udp = new UdpClient();
            udp.Connect(receiver.IPAddress, thisPC.port);
            Byte[] data = Encoding.UTF8.GetBytes(requestPacket.GetType() + "#" + thisPC.IPAddress + "#" + thisPC.port + "#" + thisPC.hostName + "#" + requestPacket.GetMessage());
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
            int iReceiverPort = message.IndexOf('#', iReceiverIP + 1);
            int iReceiverName = message.IndexOf('#', iReceiverPort + 1);
            int iMessage = message.IndexOf('#', iReceiverName + 1);

            receivedString.Add("Type",message.Substring(0, iType));
            receivedString.Add("ReceiverIP",message.Substring(iType + 1, iReceiverIP - iType - 1));
            receivedString.Add("ReceiverPort", message.Substring(iReceiverIP + 1, iReceiverPort - iReceiverIP - 1));
            receivedString.Add("ReceiverName",message.Substring(iReceiverPort + 1, iReceiverName - iReceiverPort - 1));
            receivedString.Add("Message",message.Substring(iReceiverName + 1, message.Length - iReceiverName - 1));

            return receivedString;
        }
    }
}
