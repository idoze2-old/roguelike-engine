using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Oledb;
// SadConsole Is A Monogame Based Console
using Console = SadConsole.Console;


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
        public static Components.Player Player;
        #endregion
        #region Entry Point
        static void Main(string[] args)
        {
            //SQL();
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
            SadConsole.Settings.ToggleFullScreen();
            SadConsole.Global.CurrentScreen.Children.Add(new Components.LoginScreen(Width, Height));
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
                Player = DAL.GetPlayer(username, password);
                SadConsole.Global.CurrentScreen = BG;
                return true;
            }
            catch
            {
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
                System.Console.WriteLine("\n---------");
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
                    else if (str.ToLower().Contains("select"))
                    {
                        System.Data.DataTable Table = oledbhelper.GetTable(str);
                        System.Console.WriteLine("---START");
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
                        System.Console.WriteLine("---END");
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
                catch
                {
                    if (str == "")
                    {
                        SQL = false;
                    }
                    else
                    {
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.Write("Invalid. ");
                        System.Console.ResetColor();
                        System.Console.ReadLine();
                    }
                }
            }
        } 
        #endregion
    }
}
