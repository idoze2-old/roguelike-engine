using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SadConsole Is A Monogame Based Console
using Console = SadConsole.Console;
using SadConsole;
using Microsoft.Xna.Framework;

namespace Engine.Screen
{
    internal class Login : ControlsConsole
    {
        SadConsole.Controls.InputBox UsernameInput;
        SadConsole.Controls.InputBox PasswordInput;
        SadConsole.Controls.Button LoginButton;
        SadConsole.Controls.Button RegisterButton;
        SadConsole.Themes.InputBoxTheme InpTheme;
        int ControlSize = 7;
        public Login(int Width, int Height) : base(Width, Height)
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
            #region LoginButton
            
            LoginButton = new SadConsole.Controls.Button(ControlSize);
            LoginButton.Position = new Point(Width / 2 - LoginButton.Width / 2, Height / 2);
            LoginButton.ShowEnds = false;
            LoginButton.Text = "Login";
            LoginButton.TextAlignment = System.Windows.HorizontalAlignment.Center;
            Add(LoginButton);
            LoginButton.Click += (btn, args) =>
            {
                if ((PasswordInput.Text != "") && (UsernameInput.Text != ""))
                {
                    if (!Program.Login(UsernameInput.Text, PasswordInput.Text))
                    {
                        Print(LoginButton.Position.X, LoginButton.Position.Y + 1, "Username Or Password", Color.Red);
                        Print(LoginButton.Position.X, LoginButton.Position.Y + 2, "Incorrect.", Color.Red);
                        Add(RegisterButton);
                        
                    }
                    else
                    {
                        parentConsole.Children.Remove(this);
                    }
                }
            };
            #endregion
            #region RegisterButton

            RegisterButton = new SadConsole.Controls.Button(8);
            RegisterButton.Position = new Point(LoginButton.Position.X+9, LoginButton.Position.Y);
            RegisterButton.ShowEnds = false;
            RegisterButton.Text = "Register";
            RegisterButton.TextAlignment = System.Windows.HorizontalAlignment.Center;
            RegisterButton.Click += (btn, args) =>
            {
                if ((PasswordInput.Text != "") && (UsernameInput.Text != ""))
                {
                    Global.CurrentScreen.Children.Add(new Screen.Register(base.Width, base.Height));
                }
            };
            #endregion
        }

    }
}
