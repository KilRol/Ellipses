using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ellipses
{
    public class MyOwnEllipse : Control, ISupportInitialize
    {
        private Point center;

        private float a;
        private float b;
        private float step;
        private readonly int width;
        private readonly int height;
        public List<PointF> Points { get; private set; }
        private BufferedGraphics g;
        public MyOwnEllipse(ref BufferedGraphics grafx, int width, int height, Point center)
        {
            g = grafx;
            Points = new List<PointF>();

            this.Size = new Size(1, 1);
            this.width = width;
            this.height = height;

            a = width / 2;
            b = height / 2;

            step = width / 100;
            this.center = center;
        }

        public void Init()
        {
            for (float cur = -a; cur <= a; cur += step)
            {
                float curY = (float)Math.Sqrt((float)Math.Abs(b * b * (1 - ((cur * cur) / (a * a)))));

                Points.Add(new PointF(cur + center.X, curY + center.Y));
                Points.Insert(0, new PointF(cur + center.X, center.Y - curY));
            }
        }

        public void Rotate(double angle)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                PointF point = Points[i];
                point = new PointF(
                    center.X + (point.X - center.X) * (float)Math.Cos(angle) - (point.Y - center.Y) * (float)Math.Sin(angle),
                    center.Y + (point.X - center.X) * (float)Math.Sin(angle) + (point.Y - center.Y) * (float)Math.Cos(angle)
                    );
                Points[i] = point;
            }
            g.Graphics.Clear(BackColor);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            g.Graphics.DrawRectangle(Pens.Red, center.X - 3, center.Y - 3, 6, 6);
            for (int i = 1; i < Points.Count; i++)
            {
                g.Graphics.DrawLine(Pens.Red, Points[i - 1], Points[i]);
            }
            g.Graphics.DrawLine(Pens.Red, Points.Last(), Points[0]);
        }

        public void BeginInit()
        {
            Init();
        }

        public void EndInit()
        {
            Invalidate();
        }
    }
}
