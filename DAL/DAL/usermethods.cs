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
