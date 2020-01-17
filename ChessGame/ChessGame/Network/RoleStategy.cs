using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ChessGame.Network
{
    public class RoleStategy
    {
        protected NetworkInfo thisPC;
        protected NetworkStream stream;
        protected StreamReader reader;
        protected StreamWriter writer;

        public RoleStategy(NetworkInfo localInfo)
        {
            thisPC = localInfo;
        }

        public virtual void Connect(NetworkInfo guestInfo)
        {

        }

        public virtual void SendPacket(Packet requestPacket)
        {

        }


        public virtual string ReceivePacket()
        {
            return null;
        }

        public virtual void Disconnect()
        {

        }

    }

    
}