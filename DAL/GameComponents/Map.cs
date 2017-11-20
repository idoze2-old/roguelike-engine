using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Component
{
    public class Map : Component
    {
        private int width;
        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }
        private int height;
        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }
        private List<MapObject>[] objects;
        public MapObject GetObject(int X, int Y, int Z)
        {
            try
            {
                return ((MapObject)objects[Z].Where(ob => ob.X == X && ob.Y == Y));
            }
            catch { throw; }
        }
        public Map(int id, int Width, int Height) : base(id)
        {
            width = Width;
            height = Height;
        }
        /// <summary>
        /// Make Sure To Load The Map In Decs Order by Obj.Z
        /// </summary>
        /// <param name="data"></param>
        public void Load(DataTable data)
        {
            objects = new List<MapObject>[int.Parse(data.Rows[0]["PosZ"].ToString())];

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
            objects[Obj.Z].Add(Obj);
        }
    }
    public class MapObject : Component
    {
        private int x, y, z;
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
        public int Z
        {
            get
            {
                return z;
            }

            set
            {
                z = value;
            }
        }
        public MapObject(int id, int X, int Y, int Z) : base(id)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
    public class Tile : MapObject
    {
        public Tile(int id, int x, int y, int z) : base(id, x, y, z)
        {

        }
    }
}
