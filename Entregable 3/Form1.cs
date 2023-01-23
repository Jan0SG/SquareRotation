using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entregable_3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Point a, b, c, d;
        Point A1, B2, C3, D4;
        Point pivot, centerpoint;
        Double angle;
        


        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            centerpoint = new Point(bmp.Width / 2 + 60, bmp.Height / 2 - 60);
            pivot = new Point(bmp.Width/2, bmp.Height/2);

            RenderCPlane();

        }

        private void RenderCPlane()
        {
            //Plano
            a = new Point(pictureBox1.Width / 2, 0);
            b = new Point(pictureBox1.Width / 2, pictureBox1.Height);
            c = new Point(pictureBox1.Width, pictureBox1.Height / 2);
            d = new Point(0, pictureBox1.Height / 2);

            g.DrawLine(Pens.Yellow, a, b);
            g.DrawLine(Pens.Yellow, c, d);
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            RotateinCenter();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            RotateinOrigin();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RotateinPivot();
        }
        private void RotateinCenter() //Rotates Square in its center
        {
            g.Clear(Color.Black);
            RenderCPlane();
            angle = Convert.ToInt16(textBox1.Text);
            angle = -(angle * Math.PI / 180);

            a = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            b = new Point((pictureBox1.Width / 2) + 120, pictureBox1.Height / 2);
            c = new Point((pictureBox1.Width / 2) + 120, (pictureBox1.Height / 2) - 120);
            d = new Point(pictureBox1.Width / 2, (pictureBox1.Height / 2) - 120);

            A1.X = (int)(((a.X - centerpoint.X) * Math.Cos(angle)) - ((a.Y - centerpoint.Y) * Math.Sin(angle)) + centerpoint.X);
            A1.Y = (int)(((a.X - centerpoint.X) * Math.Sin(angle)) + ((a.Y - centerpoint.Y) * Math.Cos(angle)) + centerpoint.Y);
            B2.X = (int)(((b.X - centerpoint.X) * Math.Cos(angle)) - ((b.Y - centerpoint.Y) * Math.Sin(angle)) + centerpoint.X);
            B2.Y = (int)(((b.X - centerpoint.X) * Math.Sin(angle)) + ((b.Y - centerpoint.Y) * Math.Cos(angle)) + centerpoint.Y);
            C3.X = (int)(((c.X - centerpoint.X) * Math.Cos(angle)) - ((c.Y - centerpoint.Y) * Math.Sin(angle)) + centerpoint.X);
            C3.Y = (int)(((c.X - centerpoint.X) * Math.Sin(angle)) + ((c.Y - centerpoint.Y) * Math.Cos(angle)) + centerpoint.Y);
            D4.X = (int)(((d.X - centerpoint.X) * Math.Cos(angle)) - ((d.Y - centerpoint.Y) * Math.Sin(angle)) + centerpoint.X);
            D4.Y = (int)(((d.X - centerpoint.X) * Math.Sin(angle)) + ((d.Y - centerpoint.Y) * Math.Cos(angle)) + centerpoint.Y);

            g.DrawLine(Pens.Red, A1, B2);
            g.DrawLine(Pens.Red, B2, C3);
            g.DrawLine(Pens.AliceBlue, C3, D4);
            g.DrawLine(Pens.Red, D4, A1);

            pictureBox1.Invalidate();

        } 

        private void RotateinOrigin() //Rotates the square at the center of the plane
        {
            g.Clear(Color.Black);
            RenderCPlane();
            angle = Convert.ToInt16(textBox1.Text);
            angle = -(angle * Math.PI / 180);

            a = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            b = new Point((pictureBox1.Width / 2) + 120, pictureBox1.Height / 2);
            c = new Point((pictureBox1.Width / 2) + 120, (pictureBox1.Height / 2) - 120);
            d = new Point(pictureBox1.Width / 2, (pictureBox1.Height / 2) - 120);

            A1.X = (int)(((a.X - 65 - pivot.X) * Math.Cos(angle)) - ((a.Y + 65 - pivot.Y) * Math.Sin(angle)) + pivot.X);
            A1.Y = (int)(((a.X - 65 - pivot.X) * Math.Sin(angle)) + ((a.Y + 65 - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            B2.X = (int)(((b.X - 65 - pivot.X) * Math.Cos(angle)) - ((b.Y + 65  - pivot.Y) * Math.Sin(angle)) + pivot.X);
            B2.Y = (int)(((b.X - 65  - pivot.X) * Math.Sin(angle)) + ((b.Y + 65  - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            C3.X = (int)(((c.X - 65  - pivot.X) * Math.Cos(angle)) - ((c.Y + 65 - pivot.Y) * Math.Sin(angle)) + pivot.X);
            C3.Y = (int)(((c.X - 65  - pivot.X) * Math.Sin(angle)) + ((c.Y + 65 - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            D4.X = (int)(((d.X - 65  - pivot.X) * Math.Cos(angle)) - ((d.Y + 65 - pivot.Y) * Math.Sin(angle)) + pivot.X);
            D4.Y = (int)(((d.X - 65 - pivot.X) * Math.Sin(angle)) + ((d.Y + 65 - pivot.Y) * Math.Cos(angle)) + pivot.Y);

            g.DrawLine(Pens.Red, A1, B2);
            g.DrawLine(Pens.Red, B2, C3);
            g.DrawLine(Pens.AliceBlue, C3, D4);
            g.DrawLine(Pens.Red, D4, A1);

            pictureBox1.Invalidate();
        }

        private void RotateinPivot() //Rotates the square around the quadrants of the plain using the origin of the plain as pivot
        {
            g.Clear(Color.Black);
            RenderCPlane();
            angle = Convert.ToInt16(textBox1.Text);
            angle = -(angle * Math.PI / 180);

            a = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            b = new Point((pictureBox1.Width / 2) + 120, pictureBox1.Height / 2);
            c = new Point((pictureBox1.Width / 2) + 120, (pictureBox1.Height / 2) - 120);
            d = new Point(pictureBox1.Width / 2, (pictureBox1.Height / 2) - 120);

            A1.X = (int)(((a.X - pivot.X) * Math.Cos(angle)) - ((a.Y - pivot.Y) * Math.Sin(angle)) + pivot.X);
            A1.Y = (int)(((a.X - pivot.X) * Math.Sin(angle)) + ((a.Y - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            B2.X = (int)(((b.X - pivot.X) * Math.Cos(angle)) - ((b.Y - pivot.Y) * Math.Sin(angle)) + pivot.X);
            B2.Y = (int)(((b.X - pivot.X) * Math.Sin(angle)) + ((b.Y - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            C3.X = (int)(((c.X - pivot.X) * Math.Cos(angle)) - ((c.Y - pivot.Y) * Math.Sin(angle)) + pivot.X);
            C3.Y = (int)(((c.X - pivot.X) * Math.Sin(angle)) + ((c.Y - pivot.Y) * Math.Cos(angle)) + pivot.Y);
            D4.X = (int)(((d.X - pivot.X) * Math.Cos(angle)) - ((d.Y - pivot.Y) * Math.Sin(angle)) + pivot.X);
            D4.Y = (int)(((d.X - pivot.X) * Math.Sin(angle)) + ((d.Y - pivot.Y) * Math.Cos(angle)) + pivot.Y);

            g.DrawLine(Pens.Red, A1, B2);
            g.DrawLine(Pens.Red, B2, C3);
            g.DrawLine(Pens.AliceBlue, C3, D4);
            g.DrawLine(Pens.Red, D4, A1);

            pictureBox1.Invalidate();
        }

    }
}
