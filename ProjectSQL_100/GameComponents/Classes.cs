using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
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
    class SaveFile
    {
        int SaveFileID;
    }
    class Map
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
        public Map(int Width,int Height)
        {
            width = Width;
            height = Height; 
        }
    }
    class MapObject:Component
    {

    }
    class Tile : MapObject
    {

    }
}
