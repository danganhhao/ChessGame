using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    public class Packet
    {
        NetworkInfo networkInfo;
        string type;
        string message;

        public Packet(string type, string message)
        {
            this.networkInfo = new NetworkInfo();
            this.type = type;
            this.message = message;
        }

        public Packet(NetworkInfo networkInfo, string type, string message)
        {
            this.networkInfo = new NetworkInfo(networkInfo);
            this.type = type;
            this.message = message;
        }

        public NetworkInfo GetNetworkInfo()
        { return networkInfo; }
        public string GetMessage()
        { return message; }
        public string GetType()
        { return type; }
    }
}
