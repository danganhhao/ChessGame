using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    class NetworkModule
    {
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

        public void SendPacket(RequestPacket packet)
        {
            
        }

        public void ReceivePacket(ResponsePacket packet)
        {
            
        }
    }
}
