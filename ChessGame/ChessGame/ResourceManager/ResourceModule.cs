using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    class ResourceModule
    {
        private ResourceModule() { }
        public static ResourceModule instance = null;
        public static ResourceModule GetInstance()
        {
            if (instance == null)
            {
                instance = new ResourceModule();
            }
            return instance;
        }

        public Bitmap GetPieceResourceByType(PieceType type, PieceSide color)
        {
            return new Bitmap(Resource1.BlackKing, Const.TileSize);
        }
    }
}
