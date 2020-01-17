using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.ResourceManager
{
    enum TILE
    {
        NormalBlackTile, NormalWhiteTile,
        SelectBlackTile, SelectWhiteTile,
        AvalBlackTile, AvalWhiteTile,
        LastMoveBlackTile, LastMoveWhiteTile
    }

    abstract class CommonTile
    {
        protected Dictionary<TILE, Bitmap> tiles = new Dictionary<TILE, Bitmap>();

        public CommonTile()
        {
            SetNormalTileResource();
            SetSelectTileResource();
            SetAvalTileResource();
            SetLastMoveResource();
        }

        public Bitmap GetTile(TILE type)
        {
            if (tiles.ContainsKey(type))
            {
                return tiles[type];
            }
            return null;
        }
        public virtual void SetNormalTileResource() { }
        public virtual void SetSelectTileResource() { }
        public virtual void SetAvalTileResource() { }
        public virtual void SetLastMoveResource() { }
    }
}
