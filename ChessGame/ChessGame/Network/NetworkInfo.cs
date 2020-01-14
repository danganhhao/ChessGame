using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    public class NetworkInfo
    {
        public string broadcastAddress;
        public string port;
        NetworkInfo defaultInfo = new NetworkInfo("","");

        public NetworkInfo()
        {
            this.broadcastAddress = defaultInfo.broadcastAddress;
            this.port = defaultInfo.port;
        }

        public NetworkInfo(string broadcastAddress, string port)
        {
            this.broadcastAddress = broadcastAddress;
            this.port = port;
        }

        public NetworkInfo(NetworkInfo networkInfo)
        {
            this.broadcastAddress = networkInfo.broadcastAddress;
            this.port = networkInfo.port;
        }

        public NetworkInfo GetInfo { get => this; }
    }
}
