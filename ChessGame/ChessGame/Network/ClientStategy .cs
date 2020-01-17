using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ChessGame.Network
{
   
    public class ClientStategy : RoleStategy
    {
        public ClientStategy(NetworkInfo localInfo) : base(localInfo)
        {
        }

        TcpClient client;

        public override void Connect(NetworkInfo receiverInfo)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Parse(receiverInfo.IPAddress), receiverInfo.port);
            stream = client.GetStream();
        }

        public override string ReceivePacket()
        {
            string result = "";

            if (NetworkManager.GetInstance().connectionState == NetworkManager.ConnectionState.Connected)
            {
                reader = new StreamReader(stream);
                while (true)
                {
                    string str = reader.ReadLine();
                    if (str == "" || str == null)
                    {
                        return result;
                    }
                    else
                    {
                        result += str;
                    }
                }
            }
            return result;
        }

        public override void SendPacket(Packet requestPacket)
        {
            if (NetworkManager.GetInstance().connectionState == NetworkManager.ConnectionState.Connected)
            {
                writer = new StreamWriter(stream);
                string message = requestPacket.GetType() + "#" + thisPC.IPAddress + "#" + thisPC.port + "#" + thisPC.hostName + "#" + requestPacket.GetMessage();
                writer.WriteLine(message);
            }
        }

        public override void Disconnect()
        {
            stream.Close();
            client.Close();
        }
    }
}