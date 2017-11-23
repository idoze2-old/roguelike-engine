using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Screen
{
    internal class PlayArea : Classes.ScrollConsole
    {
        public PlayArea(int Width, int Height, int RWidth, int RHeight) : base(Width, Height, RWidth, RHeight)
        {
            #region Randomize
            FillWithRandomGarbage();
            Fill(Color.FromNonPremultiplied(127, 127, 127, 127), Color.FromNonPremultiplied(0, 255, 255, 127), null);
            #endregion
            #region PlayerConsole
            SadConsole.Console PlayerConsole = new SadConsole.Console(1, 1);
            PlayerConsole.Position = new Point(Width / 2, Height / 2);
            PlayerConsole.Print(0, 0, "@", Color.Yellow, Color.Transparent);
            Children.Add(PlayerConsole);
            #endregion

            #region KeyboardHandler Hook
            KeyboardHandler += (cons, inp) =>
                {
                    return HandleKeyboard(inp);
                }; 
            #endregion
        }
        #region KeyboardHandler Methods
        public bool HandleKeyboard(SadConsole.Input.Keyboard info)
        {
            bool keypressed = false;
            #region Movement
            if ((info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right)) || (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D)))
            {
                if (TryMove(1, 0))
                {
                    this.Scroll(1, 0);
                    keypressed = true;
                }
            }
            if ((info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)) || (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A)))
            {
                if (TryMove(-1, 0))
                {
                    this.Scroll(-1, 0);
                    keypressed = true;
                }
            }
            if ((info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up)) || (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W)))
            {
                if (TryMove(0, -1))
                {
                    this.Scroll(0, -1);
                    keypressed = true;
                }
            }
            if ((info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down)) || (info.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S)))
            {
                if (TryMove(0, 1))
                {
                    this.Scroll(0, 1);
                    keypressed = true;
                }

            }
            #endregion
            return keypressed;
        }
        private bool TryMove(int dx, int dy)
        {
            try
            {

                return true;
            }
            catch
            {
                return false;
            }
        } 
        #endregion

    }
}
