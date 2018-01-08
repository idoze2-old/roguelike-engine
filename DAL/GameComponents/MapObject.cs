using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace DAL.Component
{
    public class MapObject : Component
    {
        private int x, y, z;
        private Color color;
        private char glyph;
        public MapObject(int id, int X, int Y, int Z, Color color, char glyph) : base(id)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.color = color;
            this.glyph = glyph;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
        public Color Color { get => color; set => color = value; }
        public char Glyph { get => glyph; set => glyph = value; }
    }
}
