using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Program
    {
        public static Random Random;
        static void Main(string[] args)
        {
            Random = new Random();
            SQL();
        }
        #region SQLMode
        public static void SQL()
        {
            bool SQL = true;
            string str = "";
            System.Console.Clear();
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("SQL Mode ");
            System.Console.ResetColor();
            while (SQL)
            {
                System.Console.WriteLine("---------");
                System.Console.WriteLine(str);
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write("> ");
                System.Console.ResetColor();
                str = System.Console.ReadLine();
                try
                {
                    if (str == "")
                    {
                        SQL = false;
                    }
                    else if (str.ToLower().Contains("adduser"))
                    {
                        string UName = "";
                        string PWord = "";
                        for (int i = 0; i < 3; i++)
                        {
                            UName += (Random.Next(10).ToString());
                            PWord += (Random.Next(10).ToString());
                        }
                        System.Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.Write(Methods.AddUser(UName, PWord) + "\n");
                        System.Console.ResetColor();

                    }
                    else if (str.ToLower().Contains("select"))
                    {
                        System.Data.DataTable Table = oledbhelper.GetTable(str);
                        foreach (System.Data.DataColumn Col in Table.Columns)
                        {
                            System.Console.ForegroundColor = ConsoleColor.Cyan;
                            System.Console.Write("{0,15}|", Col.ColumnName.ToString());
                            System.Console.ResetColor();
                        }
                        System.Console.Write("\n");
                        foreach (System.Data.DataRow Row in Table.Rows)
                        {
                            foreach (var item in Row.ItemArray)
                            {
                                System.Console.Write("{0,15}|", item.ToString());
                            }
                            System.Console.Write("\n");
                        }
                    }
                    else
                    {
                        oledbhelper.Execute(str);
                        System.Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write("Success. ");
                        System.Console.ResetColor();
                    }
                    //System.Console.ReadLine();
                }
                catch (Exception e)
                {
                    //throw e;
                    if (str == "")
                    {
                        SQL = false;
                    }
                    else
                    {
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.Write("Invalid. ");
                        System.Console.WriteLine(e.Message);
                        System.Console.ResetColor();
                        //   System.Console.ReadLine();
                    }
                }
            }
        }
        #endregion
    }
}
