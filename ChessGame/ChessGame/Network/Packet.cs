using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    class Packet
    {
        NetworkInfo networkInfo;
        string message;

        public Packet()
        {

        }

        public Packet(NetworkInfo networkInfo, string message)
        {
            this.networkInfo = new NetworkInfo(networkInfo);
            this.message = message;
        }

        public NetworkInfo GetNetworkInfo()
        { return networkInfo; }
        public string GetMessage()
        { return message; }
    }

    class RequestPacket : Packet
    {
        public RequestPacket() : base()
        {
        }

        public RequestPacket(NetworkInfo networkInfo, string message) : base(networkInfo, message)
        {
        }
    }

    class ResponsePacket : Packet
    {
        public ResponsePacket() : base()
        {
        }

        public ResponsePacket(NetworkInfo networkInfo, string message) : base(networkInfo, message)
        {
        }
    }
}
