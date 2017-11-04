using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Oledb;
using Microsoft.Xna.Framework;
// SadConsole Is A Monogame Based Console
using Console = SadConsole.Console;
using Global = SadConsole.Global;


namespace Project
{
    class Program
    {
        #region Globals
        public const int Width = 120;
        public const int Height = 120;
        public const double _delay = 2;
        public const string Font = "Cheepicus12.font";
        public static int ticks=0;
        public static int x;
        public static int y;
        public static Engine.ScrollConsole BG;
        public static Console PlayerConsole;
        #endregion
        #region Entry Point
        static void Main(string[] args)
        {
            x = 1;
            y = 4;
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
        private static void Init()
        {
            ticks = 0;
            SadConsole.Settings.ToggleFullScreen();
            BG = new Engine.ScrollConsole(Width*2,Height*2,Width,Height);
            BG.FillWithRandomGarbage();
            BG.Fill(Color.FromNonPremultiplied(127, 127, 127, 127), Color.FromNonPremultiplied(0, 255, 255, 127),null);
            PlayerConsole = new Console(1, 1);
            PlayerConsole.Position = new Point(Width / 2, Height / 2);
            BG.Children.Add(PlayerConsole);
            PlayerConsole.Print(0, 0, "@", Color.Yellow, Color.Transparent);
            SadConsole.Global.CurrentScreen = BG;
        }
        #endregion
        #region Game Logic
        private static void Update(GameTime time)
        {
            ticks++;
            //BG.Print(6, 6, "#", Color.White, Color.Transparent);
            //Recall
            #region KeyHandling
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                SadConsole.Game.Instance.Exit();
            }
            if ((SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right))||(SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D)))
            {
                if (ticks % _delay == 0)
                    BG.Scroll(1,0);
            }
            if ((SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left))||(SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A)))
            {
                if (ticks % _delay == 0)
                    BG.Scroll(-1, 0);
            }
            if ((SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up))||(SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W)))
            {
                if (ticks % _delay == 0)
                    BG.Scroll(0,-1);
            }
            if ((SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))||(SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S)))
            {
                if (ticks % _delay == 0)
                    BG.Scroll(0, 1);

            }
            #endregion
        }
        #endregion
    }
}
