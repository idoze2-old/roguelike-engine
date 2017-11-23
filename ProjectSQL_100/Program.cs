using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
// SadConsole Is A Monogame Based Console
using Console = SadConsole.Console;
using SadConsole;
using DAL;
using DAL.Component;

namespace Engine
{
    class Program
    { 
        #region Globals
        public const int Width = 100;
        public const int Height = 50;
        public const string Font = "Cheepicus12.font";
        public static User User;
        #endregion
        #region Entry Point
        static void Main(string[] args)
        { 
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
            SadConsole.Global.CurrentScreen.Children.Add(new Screen.Login(Width, Height));
        }
        #endregion
        #region Game Logic
        private static void Update(GameTime time)
        {
            #region KeyHandling
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                SadConsole.Game.Instance.Exit();
            }
            #endregion
            ((Console)SadConsole.Global.CurrentScreen.Children.Last()).ProcessKeyboard(Global.KeyboardState);

        }
        #endregion
        public static bool Login(string username, string password)
        {
            try
            {
                User = UserMethods.GetUser(username, password);
                
                Global.CurrentScreen.Children.Add(new Screen.PlayArea(Width * 2, Height * 2, Width, Height));
                return true;
            }
            catch (Exception e)
            {
                //throw e;
                return false;
            }
        }
        public static bool Register(string username, string password)
        {
            try
            {
                
                return UserMethods.AddUser(username, password); 
            }
            catch (Exception e)
            { 
                return false;
            }
        }
        
    }
}

