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
                DataTable Data = oledbhelper.GetTable("Select UserID, UName,PWord From User Where UName=='"+username+"' AND PWord=='"+password+"'");
                DataRow DataR = Data.Rows[0];
                return new Components.Player((int.Parse(DataR["UserID"].ToString())), DataR["UName"].ToString(), DataR["PWord"].ToString());
        }
        public static String AddUser (string Username, string Password)
        {
            try
            {
                string cmd = "INSERT INTO User (UName,PWord) Values ('" + Username + "','" + Password + "');";
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
