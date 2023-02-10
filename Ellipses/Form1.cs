using static System.Windows.Forms.AxHost;
using System.Drawing;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.Resources;
using System;
using System.Reflection;

namespace Ellipses
{
    public partial class Form1 : Form
    {
        MyEllipse bigEllipse;
        MyEllipse mediumEllipse;
        MyEllipse smallEllipse;

        EllipseBinder mainEllipseBinder;
        EllipseBinder secondEllipseBinder;
        public Form1()
        {
            InitializeComponent();

            bigEllipse = new MyEllipse(400, 200, new PointF(ClientSize.Width / 2, ClientSize.Height / 2));
            mediumEllipse = new MyEllipse(200, 100, new PointF(ClientSize.Width / 2, ClientSize.Height / 2));
            smallEllipse = new MyEllipse(100, 50, new PointF(ClientSize.Width / 2, ClientSize.Height / 2));
            mainEllipseBinder = new EllipseBinder();
            secondEllipseBinder = new EllipseBinder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EllipseReporter secondReporter = new EllipseReporter(mediumEllipse);
            EllipseReporter thirdReporter = new EllipseReporter(smallEllipse);

            mainEllipseBinder.Subscribe(secondReporter);
            secondEllipseBinder.Subscribe(thirdReporter);
            mainEllipseBinder.Notify(bigEllipse);
            secondEllipseBinder.Notify(mediumEllipse);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                bigEllipse.Rotate((int)bigEllipseRotateSpeed.Value * Math.PI / 180);
                mediumEllipse.Rotate((int)mediumEllipseRotateSpeed.Value * Math.PI / 180);
                smallEllipse.Rotate((int)smallEllipseRotateSpeed.Value * Math.PI / 180);

                mediumEllipse.Move((int)mediumEllipseMoveSpeed.Value);
                smallEllipse.Move((int)smallEllipseMoveSpeed.Value);

                mainEllipseBinder.Notify(bigEllipse);
                secondEllipseBinder.Notify(mediumEllipse);

                await Task.Delay(1);
                Invalidate();
            }
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            bigEllipse.Paint(e);
            mediumEllipse.Paint(e);
            smallEllipse.Paint(e);
        }
    }
}