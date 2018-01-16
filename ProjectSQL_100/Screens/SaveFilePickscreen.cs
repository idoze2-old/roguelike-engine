using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// SadConsole Is A Monogame Based Console
using Console = SadConsole.Console;
using SadConsole;
using Microsoft.Xna.Framework;
using DAL;

namespace Engine.Screen
{
   
    internal class SaveFilePickscreen:ControlsConsole
    {
        List<SadConsole.Controls.Button> Btns;
        int ControlSize = 16;
        public SaveFilePickscreen(int Width, int Height) : base(Width, Height)
        {
            Btns = new List<SadConsole.Controls.Button>();
            int Count = 0;
            DAL.Component.SaveFile[] sfs = DAL.UserMethods.GetSaveFilesByUser(Program.User.ID);
            foreach (DAL.Component.SaveFile sf in sfs)
            {
                #region RegisterButton
                SadConsole.Controls.Button SFButton = new SadConsole.Controls.Button(ControlSize);
                SFButton.Position = new Point(Width / 2 - SFButton.Width / 2, Height/(sfs.Length+1) + Count);
                SFButton.ShowEnds = false;
                SFButton.Text = sf.ToString() ;
                SFButton.TextAlignment = System.Windows.HorizontalAlignment.Center;
                SFButton.Click += (btn, args) =>
                {
                    Program.SaveFile = sf;
                    Global.CurrentScreen.Children.Add(new Screen.PlayArea(Width * 2, Height * 2, Width, Height));
                };
                #endregion
                Btns.Add(SFButton);
                Add(Btns[Count]);
                Count++;
            }
        }

    }
}
