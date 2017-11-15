﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Oledb;

namespace Project
{
    static class DAL
    {
        
        public static DataTable GetAll()
        {
            return oledbhelper.GetTable("Select * From Character");
        }
        public static Components.Player GetPlayer(string username, string password)
        {
            try
            {
                DataTable Data = oledbhelper.GetTable("Select PlayerID,");
                DataRow DataR = Data.Rows[0];
                return new Components.Player((int.Parse(DataR["ID"].ToString())), DataR["Username"].ToString(), DataR["Password"].ToString());
            }
            catch
            {
                return null;
            }
        }
        public static void AddCharacter( int SaveFileID,string Name)
        {
            string str = "INSERT INTO MainCharacter (SaveFileID,CharacterName) VALUES ("+ SaveFileID.ToString() + ",'" + Name + "')";
            oledbhelper.Execute(str);
        }

    }
}
