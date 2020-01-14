using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    static class CmdId
    {
        public static int JOIN = 1000;
        public static int MOVE = 1001;
        public static int LEAVE = 1002;
        public static int SURRENDER = 1003;
    }
}
