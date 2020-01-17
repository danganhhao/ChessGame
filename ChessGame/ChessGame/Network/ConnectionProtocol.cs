using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    public abstract class ConnectionProtocol
    {
        public NetworkInfo thisPC = new NetworkInfo();

        public virtual IPEndPoint ConnectTo(NetworkInfo receiver)
        {
            return null;
        }

        public virtual IPEndPoint ListenForConnection()
        {
            return null;
        }

        public virtual string ReceivePacket()
        {
            return "";
        }

        public virtual void SendPacket(NetworkInfo receiver, RequestPacket requestPacket)
        {
            
        }

        public virtual void Disconnect()
        {
           
        }

        public virtual Dictionary<string, string> AnalysisReceiveString(string message)
        {
            return null;
        }
    }
}
