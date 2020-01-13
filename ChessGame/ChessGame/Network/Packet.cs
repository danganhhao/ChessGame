using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    class RequestPacket
    {
        public RequestPacket() { }
    }

    class ResponsePacket
    {
        public ResponsePacket()
        {
        }
    }

    class MoveRequestPacket : RequestPacket
    {
        public MoveRequestPacket()
        {
        }
    }

    class MoveResponsePacket : ResponsePacket
    {
        public MoveResponsePacket()
        {
        }
    }
}
