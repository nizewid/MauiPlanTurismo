using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlanTurismo.Drawables
{
    internal class ElipseSolidoDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            SolidPaint solidPaint = new SolidPaint(Colors.DarkBlue);

            RectF solidElipse = new RectF(10, 10, 100, 100);
            canvas.SetFillPaint(solidPaint, solidElipse);
            canvas.SetShadow(new SizeF(10, 10), 10, Colors.Yellow);
            canvas.FillEllipse(solidElipse);
        }
    }
}
