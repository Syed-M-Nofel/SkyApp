using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int cx = 150, cy = 150, rx = 100, ry = 100;
        int cx2 = 350, cy2 = 150, rx2=100, ry2=100; // Position for image 2
        float angle;
        float angle1;

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        Bitmap image = Properties.Resources.planet1;
        Bitmap image2 = Properties.Resources.planet3;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle += 1;
            angle1 += 1;
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.TranslateTransform(cx, cy);
            g.RotateTransform(angle);
            g.TranslateTransform(-rx / 2, -ry / 2, MatrixOrder.Append);
            g.DrawImage(image, 0, 0, rx, ry);
            g.ResetTransform();

            // Draw and rotate image 2
            g.TranslateTransform(cx2, cy2);
            g.RotateTransform(angle1);
            g.TranslateTransform(-rx2 / 2, -ry2 / 2, MatrixOrder.Append);
            g.DrawImage(image2, 0, 0, rx2, ry2);
            g.ResetTransform();
        }
    }
}
