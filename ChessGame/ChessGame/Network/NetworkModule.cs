using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    partial class NetworkModule
    {
        ConnectionState cState = ConnectionState.StandingBy;
        NetworkInfo networkInfo = new NetworkInfo();

        private NetworkModule() { }
        public static NetworkModule instance = null;
        public static NetworkModule GetInstance()
        {
            if (instance == null)
            {
                instance = new NetworkModule();
            }
            return instance;
        }

        public ConnectionState GetConnectionStatus()
        {
            return cState;
        }

        void ConnectTo(NetworkInfo receiverInfo)
        {
            cState = ConnectionState.Connecting;
        }

        void ListenForConnection()
        {
            cState = ConnectionState.Listening;
        }

        public void SendPacket(RequestPacket packet)
        {
            
        }

        public void ReceivePacket(ResponsePacket packet)
        {
            
        }


    }
}
