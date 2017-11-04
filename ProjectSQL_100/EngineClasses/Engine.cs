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
    class Engine
    {

    }
    public class BorderedConsole : SadConsole.Console
    {
        SadConsole.Surfaces.BasicSurface borderSurface;

        public BorderedConsole(int width, int height) : base(width, height)
        {

            borderSurface = new SadConsole.Surfaces.BasicSurface(width, height, base.textSurface.Font);

            var editor = new SadConsole.Surfaces.SurfaceEditor(borderSurface);

            SadConsole.Shapes.Box box = SadConsole.Shapes.Box.GetDefaultBox();
            box.Width = borderSurface.Width;
            box.Height = borderSurface.Height;
            box.Draw(editor);

            base.Renderer.Render(borderSurface);
        }

        public override void Draw(TimeSpan delta)
        {
            // Draw our border to the screen
            Global.DrawCalls.Add(new DrawCallSurface(borderSurface, Position, UsePixelPositioning));

            // Draw the main console to the screen
            base.Draw(delta);
        }
    }
    public class ScrollableConsole : SadConsole.ConsoleContainer
    {
        private SadConsole.Console mainConsole;
        public ScrollableConsole(SadConsole.Console MainConsole, int RWidth, int RHeight)
        {
            mainConsole = MainConsole;
            mainConsole.TextSurface.RenderArea = new Rectangle(0, 0, RWidth, RHeight);
        }
        public ScrollableConsole(int Width, int Height, int RWidth, int RHeight)
            : this(new Console(Width, Height), RWidth, RHeight)
        {
        }
        public void Scroll(int dx, int dy)
        {
            Rectangle NRA = mainConsole.TextSurface.RenderArea;//Change To 'NewRenderArea'
            if (TryDy(dy))
                NRA.Offset(0, dy);
            if (TryDx(dx))
                NRA.Offset(dx, 0);
            mainConsole.TextSurface.RenderArea = NRA;
        }
        private bool TryDx(int d)
        {
            if (d > 0)
                return mainConsole.TextSurface.RenderArea.Right + d <= mainConsole.Width;
            else if (d < 0)
                return mainConsole.TextSurface.RenderArea.Left + d >= 0;
            return true;
        }
        private bool TryDy(int d)
        {
            if (d > 0)
                return mainConsole.TextSurface.RenderArea.Bottom + d <= mainConsole.Height;
            else if (d < 0)
                return mainConsole.TextSurface.RenderArea.Top + d >= 0;
            return true;
        }
        public Console GetConsole()
        {
            return mainConsole;
        }
    }
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
