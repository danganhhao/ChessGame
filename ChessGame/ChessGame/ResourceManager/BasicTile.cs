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
            tiles.Add(TILE.AvalBlackTile, Resource1.CircleTile);
            tiles.Add(TILE.AvalWhiteTile, Resource1.CircleTile);
        }

        public override void SetLastMoveResource()
        {
            tiles.Add(TILE.LastMoveBlackTile, Resource1.ColorBlackHighlightTile);
            tiles.Add(TILE.LastMoveWhiteTile, Resource1.ColorWhiteHighlightTile);
        }

        public override void SetNormalTileResource()
        {
            tiles.Add(TILE.NormalBlackTile, Resource1.ColorBlackTile);
            tiles.Add(TILE.NormalWhiteTile, Resource1.ColorWhiteTile);
        }

        public override void SetSelectTileResource()
        {
            tiles.Add(TILE.SelectBlackTile, Resource1.ColorBlackHighlightTile);
            tiles.Add(TILE.SelectWhiteTile, Resource1.ColorWhiteHighlightTile);
        }
    }
}
