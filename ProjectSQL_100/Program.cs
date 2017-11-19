﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Oledb;
// SadConsole Is A Monogame Based Console
using Console = SadConsole.Console;
using SadConsole;


namespace Project
{
    class Program
    { 
        #region Globals
        public const int Width = 80;
        public const int Height = 25;
        public const double _delay = 2;
        public const string Font = "Cheepicus12.font";
        public static int ticks = 0;
        public static Engine.ScrollConsole BG;
        public static Console PlayerConsole;
        public static Components.User Player;
        #endregion
        #region Entry Point
        static void Main(string[] args)
        {
            SQL();
            StartEngine();
        }
        #endregion 
        #region Engine Logic 
        static void StartEngine()
        {
            // Start Instance Of a 'Game' - A Monogame Method
            SadConsole.Game.Create(Font, Width, Height);
            // Hook the start event          
            SadConsole.Game.OnInitialize = Init;
            // Hook the update event that happens each frame           
            SadConsole.Game.OnUpdate = Update;
            // handle Fonts
            // Start the game.            
            SadConsole.Game.Instance.Run();
            // Dispose When Game Ends [Saves RAM]
            SadConsole.Game.Instance.Dispose();
        }
        #endregion
        #region Game Casting
        private static void Init()
        {
            ticks = 0;
            //SadConsole.Settings.ToggleFullScreen();
            SadConsole.Global.CurrentScreen.Children.Add(new Screen.Login(Width, Height));
            #region GameConsoles
            #region BG
            BG = new Engine.ScrollConsole(Width * 2, Height * 2, Width, Height);
            BG.FillWithRandomGarbage();
            BG.Fill(Color.FromNonPremultiplied(127, 127, 127, 127), Color.FromNonPremultiplied(0, 255, 255, 127), null);
            #endregion
            #region PlayerConsole
            PlayerConsole = new Console(1, 1);
            PlayerConsole.Position = new Point(Width / 2, Height / 2);
            PlayerConsole.Print(0, 0, "@", Color.Yellow, Color.Transparent);
            BG.Children.Add(PlayerConsole);
            #endregion 
            #endregion
        }
        #endregion
        #region Game Logic
        private static void Update(GameTime time)
        {
            ticks++;
            #region KeyHandling
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                SadConsole.Game.Instance.Exit();
            }
            #region Movement
            if ((SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right)) || (SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D)))
            {
                if (ticks % _delay == 0)
                    BG.Scroll(1, 0);
            }
            if ((SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)) || (SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A)))
            {
                if (ticks % _delay == 0)
                    BG.Scroll(-1, 0);
            }
            if ((SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up)) || (SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W)))
            {
                if (ticks % _delay == 0)
                    BG.Scroll(0, -1);
            }
            if ((SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down)) || (SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S)))
            {
                if (ticks % _delay == 0)
                    BG.Scroll(0, 1);

            }
            #endregion
            #endregion
        }
        #endregion
        public static bool Login(string username, string password)
        {
            try
            {
                Player = DAL.GetUser(username, password);
                SadConsole.Global.CurrentScreen = BG;
                return true;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
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
                    else if(str.ToLower().Contains("adduser"))
                    {
                        string UName = "";
                        string PWord = "";
                        for (int i = 0; i < 3; i++)
                        {
                            UName += (Global.Random.Next(10).ToString());
                            PWord += (Global.Random.Next(10).ToString());
                        }
                        System.Console.ForegroundColor = ConsoleColor.Yellow;
                            System.Console.Write(DAL.AddUser(UName,PWord)+"\n");
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
