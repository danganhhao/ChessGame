using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    public class NetworkInfo
    {
        public string hostName;
        public string broadcastAddress;
        public int port;

        public NetworkInfo()
        {
            //NetworkInfo defaultInfo = new NetworkInfo(Dns.GetHostName(), Dns.GetHostAddresses(Dns.GetHostName())[0].MapToIPv4().ToString(), FreeTcpPort());
            this.hostName = Dns.GetHostName();
            this.port = FreeTcpPort();
            this.broadcastAddress = GetHostAddress(this.hostName);
        }

        private string GetHostAddress(string hostName)
        {
            IPHostEntry _ipHostEntry = Dns.GetHostEntry(hostName);
            foreach (IPAddress ip in _ipHostEntry.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.MapToIPv4().ToString();
                }
            }
            return "";
        }

        public NetworkInfo(string broadcastAddress, int port)
        {
            this.hostName = "";
            this.broadcastAddress = broadcastAddress;
            this.port = port;
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

        static int FreeTcpPort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }
    }
}
