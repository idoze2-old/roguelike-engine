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
        private List<MapObject>[] objects;

        public int Width { get => width; set => width = value; }
        public int Layers { get => layers; set => layers = value; }
        public int Height { get => height; set => height = value; }
        public int Depth { get => depth; set => depth = value; }
        public List<MapObject>[] Objects { get => objects; set => objects = value; }

        public MapObject GetObject(int X, int Y, int Z)
        {
            try
            {
                return ((MapObject)(Objects[Z].Where(ob => ob.X == X && ob.Y == Y).ToArray()[0]));
            }
            catch {  return null; }
        }
        public Map(int id) : base(id)
        {
            Load();
        }
        private void Load()
        {
            string com = "SELECT TtM.*,T.Glyph FROM TileToMap TtM INNER JOIN Tile T ON ((T.TileID = TtM.TileID) AND (TtM.MapID = " + ID.ToString() + "));";
            DataTable data = oledbhelper.GetTable(com);
            try
            {
                Objects = new List<MapObject>[int.Parse(data.Rows[0]["PosZ"].ToString())+1];
            } 
            catch
            {
                throw;
            }
                Layers = Objects.Length;
            foreach (DataRow item in data.Rows)
            {
                int id, x, y, z, R, G, B;
                char glyph = item["Glyph"].ToString().ToCharArray()[0];
                id = int.Parse(item["TileID"].ToString());
                x = int.Parse(item["PosX"].ToString());
                y = int.Parse(item["PosY"].ToString());
                z = int.Parse(item["PosZ"].ToString());
                R = int.Parse(item["ColorR"].ToString());
                G = int.Parse(item["ColorG"].ToString());
                B = int.Parse(item["ColorB"].ToString());
                Color color = Color.FromArgb(R, G, B);
                MapObject current = new MapObject(id, x, y, z,color,glyph);
                Add(current);
            }
            
        }
        public void Add(MapObject Obj)
        {
            try
            {
                Objects[Obj.Z].Add(Obj);
            }
            catch
            {
                Objects[Obj.Z] = new List<MapObject>();
            }
            finally
            {
                int w = 16, h = 16;
                if (Obj.X > w)
                    w = Obj.X;
                if (Obj.Y > h)
                    h = Obj.Y;
                Width = w;
                Height = h;
                if (!Objects[Obj.Z].Contains(Obj))
                    Objects[Obj.Z].Add(Obj);
            }
            
        }
    }
}
