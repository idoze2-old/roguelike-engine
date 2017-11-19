using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;
using Microsoft.Xna.Framework;

namespace Project.Screen
{
    class Register:ControlsConsole
    {
        SadConsole.Controls.InputBox UsernameInput;
        SadConsole.Controls.InputBox PasswordInput;
        SadConsole.Controls.Button RegisterButton;
        SadConsole.Themes.InputBoxTheme InpTheme;
        int ControlSize = 8;
        public Register(int Width, int Height) : base(Width, Height)
        {
            textSurface.Font = Global.LoadFont(Program.Font).GetFont(Font.FontSizes.Two);
            Width /= 2;
            Height /= 2;
            InpTheme = new SadConsole.Themes.InputBoxTheme();
            #region UserNameInput
            UsernameInput = new SadConsole.Controls.InputBox(ControlSize);
            UsernameInput.Position = new Point(Width / 2 - UsernameInput.Width / 2, Height / 2 - 2);
            UsernameInput.Theme.Focused.Foreground = Color.White;
            UsernameInput.Theme.MouseOver.Foreground = Color.White;
            UsernameInput.Theme.Normal.Foreground = Color.White;
            InpTheme = UsernameInput.Theme;
            Add(UsernameInput);
            SadConsole.Global.FocusedConsoles.Set(this);
            #endregion
            #region PasswordInput
            PasswordInput = new SadConsole.Controls.InputBox(ControlSize);
            PasswordInput.Position = new Point(Width / 2 - PasswordInput.Width / 2, Height / 2 - 1);
            PasswordInput.Theme = InpTheme;
            Add(PasswordInput);
            SadConsole.Global.FocusedConsoles.Set(this);
            #endregion
            #region RegisterButton
            RegisterButton = new SadConsole.Controls.Button(ControlSize);
            RegisterButton.Position = new Point(Width / 2 - RegisterButton.Width / 2, Height / 2);
            RegisterButton.ShowEnds = false;
            RegisterButton.Text = "Register";
            RegisterButton.TextAlignment = System.Windows.HorizontalAlignment.Center;
            Add(RegisterButton);
            RegisterButton.Click += (btn, args) =>
            {
                if ((PasswordInput.Text != "") && (UsernameInput.Text != ""))
                {
                    if (!Program.Register(UsernameInput.Text, PasswordInput.Text))
                    {
                        Print(RegisterButton.Position.X, RegisterButton.Position.Y + 1, "User Already Exists", Color.Red);
                    }
                    else
                    {
                        Print(RegisterButton.Position.X, RegisterButton.Position.Y + 1, "User Created", Color.Green);
                    }
                }
            };
            #endregion
        }
    }
}
