using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    partial class NetworkManager
    {
        public ConnectionState connectionState = ConnectionState.StandingBy;
        public PacketTranferState ptState = PacketTranferState.None;
        public NetworkInfo senderInfo;
        public NetworkInfo receiverInfo;
        public Role role;
        public UDPConnection UDP;
        public TCPConnection TCP;

        private NetworkManager() {
            senderInfo = new NetworkInfo();
            UDP = new UDPConnection(senderInfo);
            TCP = new TCPConnection(senderInfo);
        }
        public static NetworkManager instance = null;
        public static NetworkManager GetInstance()
        {
            if (instance == null)
            {
                instance = new NetworkManager();
            }
            return instance;
        }

        public ConnectionState GetConnectionState()
        {
            return connectionState;
        }

        void ConnectTo(NetworkInfo receiverInfo)
        {
            ListenForConnection();
            if (connectionState == ConnectionState.Listening)
            {
                if (receiverInfo != null)
                {
                    connectionState = ConnectionState.Connecting;
                    this.receiverInfo = new NetworkInfo(receiverInfo);
                }
            }
        }

        void ListenForConnection()
        {
            connectionState = ConnectionState.Listening;
        }

        void Disconnect()
        {
            receiverInfo = null;
            connectionState = ConnectionState.Disconnected;
        }

       
        public Packet SendPacket(Packet packet)
        {
            if (connectionState == ConnectionState.Connected)
            {
                ptState = PacketTranferState.Sending;
            }
            return null;
        }


        public Packet ReceivePacket()
        {
            if (connectionState == ConnectionState.Connected)
            {
                ptState = PacketTranferState.Receiving;
            }
            return null;
        }

        public void CheckConnection()
        {
            if (receiverInfo == null)
            {
                connectionState = ConnectionState.StandingBy;
            }
            else
            {

            }
        }

        void ResetState()
        {
            connectionState = ConnectionState.StandingBy;
            ptState = PacketTranferState.None;
        }

        public string GetMessageFromPackage(Packet packet)
        {
            return packet.GetMessage();
        }

    }
}
