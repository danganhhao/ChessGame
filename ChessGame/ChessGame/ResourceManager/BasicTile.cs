using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    class BasicTile : CommonTile
    {
        public BasicTile() : base()
        {
        }

        public override void SetAvalTileResource()
        {
            tiles.Add(TILE.AvalBlackTile, Resource1.BlackBishop);
        }

        public override void SetLastMoveResource()
        {
            base.SetLastMoveResource();
        }

        public override void SetNormalTileResource()
        {
            base.SetNormalTileResource();
        }

        public override void SetSelectTileResource()
        {
            base.SetSelectTileResource();
        }
    }
}
