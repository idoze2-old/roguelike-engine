using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace DAL
{
    public static class UserMethods
    {

        public static DataTable GetAll()
        {
            return oledbhelper.GetTable("Select * From Character");
        }
        #region Data Pulling
        public static Component.User GetUser(string username, string password)
        {
            DataTable Data = oledbhelper.GetTable("Select UserID From Users Where UName='" + username + "' AND PWord='" + password + "'");
            DataRow DataR = Data.Rows[0];
            return new Component.User(int.Parse(DataR["UserID"].ToString()));
        }
        #region Map Pulling
        public static Component.Map GetMap(int MapID)
        {
            Component.Map RetMap = new Component.Map(MapID);
            return RetMap;
        }
        public static Component.Map[] GetMapsBySaveFile(int SaveFileID)
        {

            DataTable Data = oledbhelper.GetTable("Select [MapID] from Map Where SaveFileID = " + SaveFileID + " ORDER BY Depth ASC");
            Component.Map[] maps = new Component.Map[Data.Rows.Count];
            int count = 0;
            foreach (DataRow map in Data.Rows)
            {
                Component.Map m = new Component.Map(int.Parse(map["MapID"].ToString()));
                maps[count++] = m;
            }
            return maps;
        }
        #endregion
        #region SaveFile Pulling
        public static Component.SaveFile[] GetSaveFilesByUser(int UserID)
        {
            DataTable Data = oledbhelper.GetTable("Select [SaveFileID] from UserToSaveFile Where UserID = " + UserID);
            Component.SaveFile[] SaveFiles = new Component.SaveFile[Data.Rows.Count];
            int count = 0;
            foreach (DataRow SaveFile in Data.Rows)
            {
                Component.SaveFile sf = new Component.SaveFile(int.Parse(SaveFile["SaveFileID"].ToString()));
                SaveFiles[count++] = sf;
            }
            return SaveFiles;
        }
        #endregion
        #region Tile Pulling
        public static Component.Tile[] GetTiles()
        {
            List<Component.Tile> Tiles = new List<Component.Tile>();
            DataTable Data = oledbhelper.GetTable("Select * From Tile");
            foreach (DataRow DataR in Data.Rows)
            {
                int ID = int.Parse(DataR["TileID"].ToString());
                string TileName = DataR["TileName"].ToString();
                char Glyph = DataR["Glyph"].ToString()[0];
                Tiles.Add(new Component.Tile(ID, TileName, Glyph));
            }
            return Tiles.ToArray();
        } 
        #endregion
        #endregion
        #region Data Validation
        public static bool UserExists(string Username, string Password)
        {
            try
            {
                GetUser(Username, Password);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Data Modification
        #region Add
        public static bool AddUser(string Username, string Password)
        {
            try
            {
                if (!UserExists(Username, Password))
                {
                    string cmd = "INSERT INTO Users (UName,PWord) Values ('" + Username + "','" + Password + "');";
                    oledbhelper.Execute(cmd);
                    return true;
                }
                else
                {
                    throw new Exception("User Exists");
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Update

        #endregion
        #endregion

    }
}
