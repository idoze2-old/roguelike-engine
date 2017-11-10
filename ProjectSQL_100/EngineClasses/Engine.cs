using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;

namespace Project.Engine
{
    public class ScrollConsole : SadConsole.Console
    {
        public ScrollConsole(int Width, int Height, int RWidth, int RHeight) : base(Width, Height)
        {
            base.TextSurface.RenderArea = new Rectangle(0, 0, RWidth, RHeight);
        }
        public void Scroll(int dx, int dy)
        {
            if (dx < 0)
                base.ShiftRight(Math.Abs(dx), true);
            else if (dx > 0)
                base.ShiftLeft(dx, true);
            if (dy < 0)
                base.ShiftDown(Math.Abs(dy), true);
            else if (dy > 0)
                base.ShiftUp(dy, true);
        }
    }
}
