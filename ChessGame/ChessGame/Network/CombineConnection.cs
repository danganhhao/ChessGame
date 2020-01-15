using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Network
{
    class CombineConnection : ConnectionProtocol
    {
        List<ConnectionProtocol> protocols = new List<ConnectionProtocol>();
    }
}
