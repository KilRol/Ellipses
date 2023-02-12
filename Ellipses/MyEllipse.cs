namespace Ellipses
{
    public class EllipseReporter : IObserver<MyEllipse>
    {
        private readonly MyEllipse ellipse;

        public EllipseReporter(MyEllipse ellipse)
        {
            this.ellipse = ellipse;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(MyEllipse ellipse)
        {
            this.ellipse.SetCenter(ellipse.Points[this.ellipse.Index]);
        }
    }

    public class EllipseBinder : IObservable<MyEllipse>
    {
        private readonly List<IObserver<MyEllipse>> observers;

        public EllipseBinder()
        {
            observers = new List<IObserver<MyEllipse>>();
        }

        public IDisposable Subscribe(IObserver<MyEllipse> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return null;
        }

        public void Notify(MyEllipse ellipse)
        {
            foreach (IObserver<MyEllipse> observer in observers)
            {
                observer.OnNext(ellipse);
            }
        }
    }

    public class MyEllipse : Control
    {
        private readonly float a;
        private readonly float b;
        private readonly float step;
        private readonly BufferedGraphics g;
        private PointF center;
        public int Index { get; private set; }
        public List<PointF> Points { get; private set; }

        public MyEllipse(ref BufferedGraphics grafx, int width, int height, Point center)
        {
            g = grafx;
            Points = new List<PointF>();

            this.Size = new Size(1, 1);
            this.center = center;
            Index = 0;

            a = width / 2;
            b = height / 2;

            step = width / 100;
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

        public new void Move(int step)
        {
            if (step > 0)
            {
                Index = (Index + step) % Points.Count;
            }
            else if (step < 0)
            {
                if (Index + step <= 0)
                {
                    Index = Points.Count - 1 - (Index - step);
                }
                else
                {
                    Index += step;
                }
            }
        }

        public void SetCenter(PointF point)
        {
            float diffX = center.X - point.X;
            float diffY = center.Y - point.Y;

            center = point;

            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new PointF(Points[i].X - diffX, Points[i].Y - diffY);
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            g.Graphics.DrawRectangle(Pens.Red, center.X - 3, center.Y - 3, 6, 6);
            for (int i = 1; i < Points.Count; i++)
            {
                g.Graphics.DrawLine(Pens.Black, Points[i - 1], Points[i]);
            }
            g.Graphics.DrawLine(Pens.Black, Points.Last(), Points[0]);
        }
    }
}
