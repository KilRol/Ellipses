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
        private readonly MyEllipse bigEllipse;
        private readonly MyEllipse mediumEllipse;
        private readonly MyEllipse smallEllipse;

        private readonly EllipseBinder bigEllipseBinder;
        private readonly EllipseBinder mediumEllipseBinder;

        private readonly EllipseReporter mediumEllipseReporter;
        private readonly EllipseReporter smallEllipseReporter;

        private readonly BufferedGraphics grafx;
        private bool runAnimation;

        public Form1()
        {
            InitializeComponent();
            grafx = BufferedGraphicsManager.Current.Allocate(CreateGraphics(), this.DisplayRectangle);

            bigEllipse = new MyEllipse(ref grafx, 400, 200, new Point(ClientSize.Width / 2, ClientSize.Height / 2));
            mediumEllipse = new MyEllipse(ref grafx, 200, 100, new Point(ClientSize.Width / 2, ClientSize.Height / 2));
            smallEllipse = new MyEllipse(ref grafx, 100, 50, new Point(ClientSize.Width / 2, ClientSize.Height / 2));

            bigEllipseBinder = new EllipseBinder();
            mediumEllipseBinder = new EllipseBinder();
            mediumEllipseReporter = new EllipseReporter(mediumEllipse);
            smallEllipseReporter = new EllipseReporter(smallEllipse);

            bigEllipse.Init();
            mediumEllipse.Init();
            smallEllipse.Init();

            Controls.Add(bigEllipse);
            Controls.Add(mediumEllipse);
            Controls.Add(smallEllipse);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grafx.Graphics.FillRectangle(SystemBrushes.Control, new Rectangle(0, 0, Width, Height));

            bigEllipseBinder.Subscribe(mediumEllipseReporter);
            mediumEllipseBinder.Subscribe(smallEllipseReporter);

            bigEllipseBinder.Notify(bigEllipse);
            mediumEllipseBinder.Notify(mediumEllipse);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            runAnimation = !runAnimation;
            while (true)
            {
                if (!runAnimation) { break; }

                bigEllipse.Rotate((int)bigEllipseRotateSpeed.Value * Math.PI / 180);
                mediumEllipse.Rotate((int)mediumEllipseRotateSpeed.Value * Math.PI / 180);
                smallEllipse.Rotate((int)smallEllipseRotateSpeed.Value * Math.PI / 180);

                mediumEllipse.Move((int)mediumEllipseMoveSpeed.Value);
                smallEllipse.Move((int)smallEllipseMoveSpeed.Value);

                bigEllipseBinder.Notify(bigEllipse);
                mediumEllipseBinder.Notify(mediumEllipse);

                await Task.Delay(1);
                grafx.Render(Graphics.FromHwnd(this.Handle));
            }
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            grafx.Render(e.Graphics);
        }
    }
}