using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ChessGame.Network
{

    public class ServerStategy : RoleStategy
    {
        TcpListener listener;
        Socket socket;

        public ServerStategy(NetworkInfo localInfo) : base(localInfo)
        {

        }

        public Packet Packet
        {
            get => default(Packet);
            set
            {
            }
        }

        public override void Connect(NetworkInfo receiverInfo)
        {
            Listen();
        }

        void Listen()
        {
            listener = new TcpListener(IPAddress.Parse(thisPC.IPAddress), thisPC.port);
            listener.Start();

            socket = listener.AcceptSocket();

            stream = new NetworkStream(socket);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
        }

        public override string ReceivePacket()
        {
            string result = "";

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

        public override void SendPacket(Packet requestPacket)
        {
            string message = requestPacket.GetType() + "#" + thisPC.IPAddress + "#" + thisPC.port + "#" + thisPC.hostName + "#" + requestPacket.GetMessage();
            writer.WriteLine(message);
        }

        public override void Disconnect()
        {
            stream.Close();
            socket.Close();
            listener.Stop();
        }

    }

}