using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlanTurismo.Drawables
{
    internal class RectanguloSolidoDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            SolidPaint solidPaint = new SolidPaint(Colors.DarkGreen);

            RectF rectangulo = new RectF(10, 10, 150, 100);
            canvas.SetFillPaint(solidPaint, rectangulo);
            canvas.SetShadow(new SizeF(8, 8), 8, Colors.Blue);
            canvas.FillRectangle(rectangulo);
        }
    }
}
