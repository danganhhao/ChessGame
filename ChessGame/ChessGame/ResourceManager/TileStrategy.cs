using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    class TileStrategy
    {
        CommonTile commonTile;

        public TileStrategy(CommonTile commonTile)
        {
            this.commonTile = commonTile;
        }

        public Bitmap GetTile(TILE type)
        {
            return commonTile.GetTile(type);
        }

        public void UpdatePieceResource(CommonTile commonTile)
        {
            this.commonTile = commonTile;
        }
    }
}
