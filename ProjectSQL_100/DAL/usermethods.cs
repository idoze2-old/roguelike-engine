using System;
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
                DataTable Data = oledbhelper.GetTable("Select PlayerID, Username,Password From Player Where Username=='"+username+"' AND Password=='"+password+"'");
                DataRow DataR = Data.Rows[0];
                return new Components.Player((int.Parse(DataR["ID"].ToString())), DataR["Username"].ToString(), DataR["Password"].ToString());
        }
        public static void AddCharacter( int SaveFileID,string Name)
        {
            string str = "INSERT INTO MainCharacter (SaveFileID,CharacterName) VALUES ("+ SaveFileID.ToString() + ",'" + Name + "')";
            oledbhelper.Execute(str);
        }
        public static String AddUser (string Username, string Password)
        {
            try
            {
                string cmd = "INSERT INTO Player (Username, Password) Values ('" + Username + "', '" + Password + "');";
                oledbhelper.Execute(cmd);
                return "Successfuly Added User - " + Username + " With Password - " + Password + ".";
            }
            catch(Exception e)
            {
                return "Fail. "+e.Message;
            }
            return "Fail.";
            }

    }
}
