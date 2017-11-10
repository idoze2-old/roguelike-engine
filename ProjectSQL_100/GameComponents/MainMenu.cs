using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SadConsole Is A Monogame Based Console
using Console = SadConsole.Console;
using SadConsole;
using Microsoft.Xna.Framework;

namespace Project.Components
{
    internal class MainMenu:ControlsConsole
    {
        SadConsole.Controls.Button PlayButton;
        public MainMenu(int Width, int Height):base(Width,Height)
        {
            PlayButton = new SadConsole.Controls.Button(6,1);
            PlayButton.Position = new Point(Width/2 - PlayButton.Width/2, Height/2);
            PlayButton.ShowEnds = false;
            PlayButton.Text = "Play";
            PlayButton.TextAlignment = System.Windows.HorizontalAlignment.Center;
            Add(PlayButton);
            PlayButton.Click += (btn, args) =>
            {
                Program.StartGame();
            };
        }
    }
}
