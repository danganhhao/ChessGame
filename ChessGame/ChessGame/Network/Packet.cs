using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    class RequestPacket
    {
        NetworkInfo networkInfo;
        string message;

        public RequestPacket() {
            
        }

        public RequestPacket(NetworkInfo networkInfo, string message)
        {
            this.networkInfo = new NetworkInfo(networkInfo);
            this.message = message;
        }

        public NetworkInfo GetNetworkInfo()
        { return networkInfo; }
        public string GetMessage()
        { return message; }
    }

    class ResponsePacket
    {
        NetworkInfo networkInfo;
        string message;

        public ResponsePacket()
        {

        }

        public ResponsePacket(NetworkInfo networkInfo, string message)
        {
            this.networkInfo = new NetworkInfo(networkInfo);
            this.message = message;
        }

        public NetworkInfo GetNetworkInfo()
        { return networkInfo; }
        public string GetMessage()
        { return message; }

    }

    class MoveRequestPacket : RequestPacket
    {
        public MoveRequestPacket()
        {
        }
    }

    class MoveResponsePacket : ResponsePacket
    {
        public MoveResponsePacket()
        {
        }
    }
}
