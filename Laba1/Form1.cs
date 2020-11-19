using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox2.Paint += pictureBox2_Paint;
            pictureBox3.Paint += pictureBox3_Paint;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Invalidate();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            pictureBox3.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen red = new Pen(Color.Red, 1);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawPolygon(red, new PointF[] { new PointF(10, 50), new PointF(10, 250), new PointF(190 + trackBar1.Value * 2, 150) });
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            float _r = trackBar2.Value / 7f;
            List<PointF> points;
            points = new List<PointF>();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            for (float angle = 0.01f; angle < 6 * Math.PI; angle += 0.1f)
            {
                points.Add(new PointF((float)(_r * Math.Exp(angle * 0.2f) * Math.Cos(angle) + 150), (float)(_r * (float)Math.Exp(angle * 0.2f) * (float)Math.Sin(angle) + 150)));
            }
            e.Graphics.DrawCurve(Pens.Green, points.ToArray());
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            float angle_max = 5f;
            float _r = trackBar3.Value / 1.5f;
            List<PointF> points;
            points = new List<PointF>();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            for (float angle = 0.01f; angle < angle_max; angle += 0.1f)
                points.Add(new PointF((float)(3 * _r * Math.Tan(angle) / (1 + Math.Pow(Math.Tan(angle), 3)) + 150), (float)(3 * _r * Math.Pow(Math.Tan(angle), 2) / (1 + Math.Pow(Math.Tan(angle), 3))) + 150));
            int i = 0;
            for (float angle = 0.01f; angle < angle_max; angle += 0.1f)
            {
                if(angle != 0.01f && i != 24)
                    e.Graphics.DrawLine(Pens.Blue, points[i-1], points[i]);
                i++;
            }
        }
    }
}
