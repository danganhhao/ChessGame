using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    public class NetworkInfo
    {
        public string hostName;
        public string broadcastAddress;
        public int port;
        NetworkInfo defaultInfo = new NetworkInfo("","",0);

        public NetworkInfo()
        {
            this.hostName = defaultInfo.hostName;
            this.broadcastAddress = defaultInfo.broadcastAddress;
            this.port = defaultInfo.port;
        }

        public NetworkInfo(string hostName, string broadcastAddress, int port)
        {
            this.hostName = hostName;
            this.broadcastAddress = broadcastAddress;
            this.port = port;
        }

        public NetworkInfo(NetworkInfo networkInfo)
        {
            this.hostName = networkInfo.hostName;
            this.broadcastAddress = networkInfo.broadcastAddress;
            this.port = networkInfo.port;
        }
    }
}
