using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Component
{
    public class Tile:Component
    {
        private string tileName;
        private char glyph;
        public Tile(int TileID,string TileName,char Glyph):base(TileID)
        {
            tileName = TileName;
            glyph = Glyph;
        }
        public string TileName { get => tileName; set => tileName = value; }
        public char Glyph { get => glyph; set => glyph = value; }
        public override string ToString()
        {
            return TileName + " - '" + glyph +"'";
        }
    }
}
