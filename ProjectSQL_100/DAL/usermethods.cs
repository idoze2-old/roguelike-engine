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
        public static Components.User GetUser(string username, string password)
        {
            DataTable Data = oledbhelper.GetTable("Select UserID, UName, PWord From Users Where UName='" + username + "' AND PWord='" + password + "'");
            DataRow DataR = Data.Rows[0];
            return new Components.User((int.Parse(DataR["UserID"].ToString())), DataR["UName"].ToString(), DataR["PWord"].ToString());
        }
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
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
