using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SadConsole Is A Monogame Based Console
using Console = SadConsole.Console;
using SadConsole;
using Microsoft.Xna.Framework;

namespace Project.Screen
{
    internal class Login : ControlsConsole
    {
        SadConsole.Controls.InputBox UsernameInput;
        SadConsole.Controls.InputBox PasswordInput;
        SadConsole.Controls.Button LoginButton;
        SadConsole.Themes.InputBoxTheme InpTheme;
        int ControlSize = 6;
        public Login(int Width, int Height) : base(Width, Height)
        {
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
                    }
                }
            };
            #endregion
        }
        public override void Update(TimeSpan time)
        {
            base.Update(time);
            //LoginButton.IsEnabled = ((PasswordInput.Text != "")&&(UsernameInput.Text != ""));
        }

    }
}
