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
        private readonly MyOwnEllipse bigEllipse;
        private readonly MyOwnEllipse mediumEllipse;
        private readonly MyOwnEllipse smallEllipse;

        private readonly BufferedGraphics grafx;

        public Form1()
        {
            InitializeComponent();
            grafx = BufferedGraphicsManager.Current.Allocate(CreateGraphics(), this.DisplayRectangle);

            bigEllipse = new MyOwnEllipse(ref grafx, 400, 200, new Point(ClientSize.Width / 2, ClientSize.Height / 2));
            mediumEllipse = new MyOwnEllipse(ref grafx, 200, 100, new Point(ClientSize.Width / 2, ClientSize.Height / 2));
            smallEllipse = new MyOwnEllipse(ref grafx, 100, 50, new Point(ClientSize.Width / 2, ClientSize.Height / 2));

            bigEllipse.BeginInit();
            mediumEllipse.BeginInit();
            smallEllipse.BeginInit();

            SuspendLayout();
            Controls.Add(bigEllipse);
            Controls.Add(mediumEllipse);
            Controls.Add(smallEllipse);

            ((System.ComponentModel.ISupportInitialize)(this.bigEllipse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediumEllipse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smallEllipse)).EndInit();
            ResumeLayout(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grafx.Graphics.FillRectangle(SystemBrushes.Control, new Rectangle(0, 0, Width, Height));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                bigEllipse.Rotate((int)bigEllipseRotateSpeed.Value * Math.PI / 180);
                mediumEllipse.Rotate((int)mediumEllipseRotateSpeed.Value * Math.PI / 180);
                smallEllipse.Rotate((int)smallEllipseRotateSpeed.Value * Math.PI / 180);

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