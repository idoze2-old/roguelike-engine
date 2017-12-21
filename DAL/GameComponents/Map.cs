using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace DAL.Component
{
    public class Map : Component
    {
        private int width;
        private int layers;
        private int height;
        private int depth;
        public int Layers { get => layers; set => layers = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        public int Depth { get => depth; set => depth = value; }

        private List<MapObject>[] objects;
        public MapObject GetObject(int X, int Y, int Z)
        {
            try
            {
                return ((MapObject)objects[Z].Where(ob => ob.X == X && ob.Y == Y));
            }
            catch { throw; }
        }
        public Map(int id) : base(id)
        {
            Load();
        }
        private void Load()
        {
            DataTable data = oledbhelper.GetTable("Select * from TileToMap Where MapID = '"+this.ID+"' ORDER BY [PosZ] DESC");
            objects = new List<MapObject>[int.Parse(data.Rows[0]["PosZ"].ToString())];
            layers = objects.Length;
            foreach (DataRow item in data.Rows)
            {
                int id, x, y, z;
                x = int.Parse(item["PosX"].ToString());
                
                y = int.Parse(item["PosY"].ToString());
                
                z = int.Parse(item["PosZ"].ToString());
                id = int.Parse(item["TileID"].ToString());
                MapObject current = new MapObject(id, x, y, z);
                Add(current);
            }
            
        }
        public void Add(MapObject Obj)
        {
            if (objects[Obj.Z] == null)
                objects[Obj.Z] = new List<MapObject>();
            int w = 0, h = 0;
            if (Obj.X > w)
                w = Obj.X;
            if (Obj.Y > h)
                h = Obj.Y;
            Width = w;
            Height = h;
            objects[Obj.Z].Add(Obj);
        }

    }
    public class MapObject : Component
    {
        private int x, y, z;
        private Color color;
        private char glyph;
        public MapObject(int id, int X, int Y, int Z) : base(id)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
        public Color Color { get => color; set => color = value; }
        public char Glyph { get => glyph; set => glyph = value; }
    }
    public class Tile : MapObject
    {
        public Tile(int id, int x, int y, int z) : base(id, x, y, z)
        {

        }
    }
}
