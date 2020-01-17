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
        public string IPAddress;
        public int port;

        public NetworkInfo()
        {
            this.hostName = Dns.GetHostName();
            this.port = FreePort();
            this.IPAddress = GetHostAddress(this.hostName);
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
            this.IPAddress = broadcastAddress;
            this.port = port;
        }

        public NetworkInfo(string hostName, string broadcastAddress, int port)
        {
            this.hostName = hostName;
            this.IPAddress = broadcastAddress;
            this.port = port;
        }

        public NetworkInfo(NetworkInfo networkInfo)
        {
            this.hostName = networkInfo.hostName;
            this.IPAddress = networkInfo.IPAddress;
            this.port = networkInfo.port;
        }

        static int FreePort()
        {
            TcpListener l = new TcpListener(System.Net.IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }
    }
}
