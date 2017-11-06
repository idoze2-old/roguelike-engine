using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Project.Components
{
    class Component
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

    }
    class SaveFile : Component
    {

    }
    class Map : Component
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
                return objects[Z].Where(i=>((i.X==X)&&(i.Y==Y))).ToArray()[0];
            }
            catch { throw; }
        }
        public Map(int Width, int Height)
        {
            width = Width;
            height = Height;
        }
        public void Load(DataTable data)
        {
            foreach (DataRow item in data.Rows)
            {
                int x, y, z;
                x = int.Parse(item["PosX"].ToString());
                y = int.Parse(item["PosY"].ToString());
                z = int.Parse(item["PosZ"].ToString());
                MapObject current = new MapObject(x, y, z);
                Add(current);
            }
        }
        public void Add(MapObject Obj)
        {
            objects[Obj.Z].Add(Obj);
        }
    }
    class MapObject : Component
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
        public MapObject(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
    class Tile : MapObject
    {
        public Tile(int x, int y, int z):base(x,y,z)
        {

        }
    }
}
