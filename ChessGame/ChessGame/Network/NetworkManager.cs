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
        private RoleStategy roleStategy;
        public NetworkInfo senderInfo;
        public NetworkInfo receiverInfo;
        public Role role;

        private NetworkManager() {
            senderInfo = new NetworkInfo();
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

        public void ChangeRole(Role newRole)
        {
            role = newRole;
            if (role == Role.Client)
            {
                roleStategy = new ClientStategy(senderInfo);
            }
            else
            {
                roleStategy = new ServerStategy(senderInfo);
            }
        }

        public ConnectionState GetConnectionState()
        {
            return connectionState;
        }

        public void Connect(NetworkInfo receiverInfo)
        {
            roleStategy.Connect(receiverInfo);
            connectionState = ConnectionState.Connected;
        }

        public void Disconnect()
        {
            roleStategy.Disconnect();
            connectionState = ConnectionState.Disconnected;
        }


        public void SendPacket(Packet packet)
        {
            if (connectionState == ConnectionState.Connected)
            {
                roleStategy.SendPacket(packet);
            }
        }


        public string ReceivePacket()
        {
            if (connectionState == ConnectionState.Connected)
            {
                return roleStategy.ReceivePacket();
            }
            return "";
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
        }

        public string GetMessageFromPackage(Packet packet)
        {
            return packet.GetMessage();
        }

        public Dictionary<string, string> AnalysisReceiveString(string message)
        {
            Dictionary<string, string> receivedString = new Dictionary<string, string>();
            int iType = message.IndexOf('#');
            int iReceiverIP = message.IndexOf('#', iType + 1);
            int iReceiverPort = message.IndexOf('#', iReceiverIP + 1);
            int iReceiverName = message.IndexOf('#', iReceiverPort + 1);
            int iMessage = message.IndexOf('#', iReceiverName + 1);

            receivedString.Add("Type", message.Substring(0, iType));
            receivedString.Add("ReceiverIP", message.Substring(iType + 1, iReceiverIP - iType - 1));
            receivedString.Add("ReceiverPort", message.Substring(iReceiverIP + 1, iReceiverPort - iReceiverIP - 1));
            receivedString.Add("ReceiverName", message.Substring(iReceiverPort + 1, iReceiverName - iReceiverPort - 1));
            receivedString.Add("Message", message.Substring(iReceiverName + 1, message.Length - iReceiverName - 1));

            return receivedString;
        }

    }
}
