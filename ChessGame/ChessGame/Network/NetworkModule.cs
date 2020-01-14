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
        PacketTranferState ptState = PacketTranferState.None;
        NetworkInfo senderInfo = new NetworkInfo();
        NetworkInfo receiverInfo;

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
            ListenForConnection();
            if (cState == ConnectionState.Listening)
            {
                if (receiverInfo != null)
                {
                    cState = ConnectionState.Connecting;
                    this.receiverInfo = new NetworkInfo(receiverInfo);
                }
            }
        }

        void ListenForConnection()
        {
            cState = ConnectionState.Listening;
        }

        void Disconnect()
        {
            receiverInfo = null;
            cState = ConnectionState.Disconnected;
        }

       
        public RequestPacket SendPacket(RequestPacket packet)
        {
            if (cState == ConnectionState.Connected)
            {
                ptState = PacketTranferState.Sending;
            }
            return null;
        }


        public ResponsePacket ReceivePacket()
        {
            if (cState == ConnectionState.Connected)
            {
                ptState = PacketTranferState.Receiving;
            }
            return null;
        }

        public void CheckConnection()
        {
            if (receiverInfo == null)
            {
                cState = ConnectionState.StandingBy;
            }
            else
            {

            }
        }

        void ResetState()
        {
            cState = ConnectionState.StandingBy;
            ptState = PacketTranferState.None;
        }



    }
}
