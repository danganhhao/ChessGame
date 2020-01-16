using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    class GameManager
    {
        PieceSide turn = PieceSide.WHITE;

        public PieceSide Turn { get => turn; set => turn = value; }
    }
}
