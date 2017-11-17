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
    internal class Login:ControlsConsole
    {
        SadConsole.Controls.InputBox UsernameInput;
        SadConsole.Controls.InputBox PasswordInput;
        SadConsole.Controls.Button LoginButton;
        SadConsole.Themes.InputBoxTheme InpTheme;
        public Login(int Width, int Height) : base(Width, Height)
        {
            InpTheme = new SadConsole.Themes.InputBoxTheme();
            #region UserNameInput
            UsernameInput = new SadConsole.Controls.InputBox(5);
            UsernameInput.Position = new Point(Width / 2 - UsernameInput.Width / 2, Height / 2 - 2);
            UsernameInput.Theme.Focused.Foreground = Color.White;
            UsernameInput.Theme.MouseOver.Foreground = Color.White;
            UsernameInput.Theme.Normal.Foreground = Color.White;
            InpTheme = UsernameInput.Theme;
            Add(UsernameInput);
            SadConsole.Global.FocusedConsoles.Set(this);
            #endregion
            #region PasswordInput
            PasswordInput = new SadConsole.Controls.InputBox(5);
            PasswordInput.Position = new Point(Width / 2 - PasswordInput.Width / 2, Height / 2 - 1);
            PasswordInput.Theme = InpTheme;
            Add(PasswordInput);
            SadConsole.Global.FocusedConsoles.Set(this);
            #endregion
            #region LoginButton
            LoginButton = new SadConsole.Controls.Button(5);
            LoginButton.Position = new Point(Width / 2 - LoginButton.Width / 2, Height / 2);
            LoginButton.ShowEnds = false;
            LoginButton.IsEnabled = false;
            LoginButton.Text = "Login";
            LoginButton.TextAlignment = System.Windows.HorizontalAlignment.Center;
            Add(LoginButton);
            LoginButton.Click += (btn, args) =>
            {
                if (LoginButton.IsEnabled = ((PasswordInput.Text != "") && (UsernameInput.Text != "")))
                {
                    if (!Program.Login(UsernameInput.Text, PasswordInput.Text))
                    {

                    }
                }
            };
            #endregion
        }
        public override void Update(TimeSpan time)
        {
            base.Update(time);
            LoginButton.IsEnabled = ((PasswordInput.Text != "")&&(UsernameInput.Text != ""));
        }

    }
}
