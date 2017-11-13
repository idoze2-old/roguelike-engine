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
    internal class LoginScreen:ControlsConsole
    {
        SadConsole.Controls.InputBox UsernameInput;
        SadConsole.Controls.InputBox PasswordInput;
        SadConsole.Controls.Button LoginButton;
        SadConsole.Themes.InputBoxTheme InpTheme;
        public LoginScreen(int Width, int Height) : base(Width, Height)
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
            #region Window
            var window = new SadConsole.Window(30, 7);

            var label1 = new SadConsole.Controls.DrawingSurface(20, 1);
            label1.Position = new Point(2, 2);
            label1.Print(0, 0, $"Welcome {UsernameInput.Text.ToString()},");
            var button1 = new SadConsole.Controls.Button(10);
            button1.Position = new Point(2, 5);
            button1.ShowEnds = false;
            button1.Text = "Yes Please";
            var button2 = new SadConsole.Controls.Button(12);
            button2.Position = new Point(13, 5);
            button2.ShowEnds = false;
            button2.Text = "No Thank You";
            window.Add(label1);
            window.Add(button2);
            window.Add(button1);

            button2.Click += (btn, args) =>
            {
                window.Hide();
            };
            button1.Click += (btn, args) =>
            {
                window.Hide();
                Program.Login(UsernameInput.Text, PasswordInput.Text);
            };
            window.Center();
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
                window.Title = "Question";
                window.Show(true);
                window.Center();
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
