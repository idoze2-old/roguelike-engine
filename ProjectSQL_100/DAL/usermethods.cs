using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Oledb;

namespace DAL
{
    class usermethods
    {
        
        public static DataTable GetAll()
        {
            return oledbhelper.GetTable("Select * From Character");
        }
        public static void AddCharacter( int SaveFileID,string Name)
        {
            string str = "INSERT INTO MainCharacter (SaveFileID,CharacterName) VALUES ("+ SaveFileID.ToString() + ",'" + Name + "')";
            oledbhelper.Execute(str);
        }

    }
}
