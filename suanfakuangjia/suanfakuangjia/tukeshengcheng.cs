using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace suanfakuangjia
{
    public partial class tukeshengcheng : Form
    {
        public tukeshengcheng()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();         
        }


        List<PointF> points = new List<PointF>();
        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            PointF point = new PointF(e.X, e.Y);
            points.Add(point);
             g.FillEllipse(Brushes.Red, e.X, e.Y , 4, 4);          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Bitmap bittt = new Bitmap(@"D:\aa.gif");
            //bittt.Save(@"D:\bb.bmp",System.Drawing.Imaging.ImageFormat.Bmp);
            if (points.Count < 2)
            {
                MessageBox.Show("点太少！");
                return;
            }

            ConvexHull convex = new ConvexHull();
            convex.Points = points;
            convex.GetConvexHull();
            Bitmap bit = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            Graphics gs = Graphics.FromImage(bit);
            PointF[] pointList = convex.HullPoints.ToArray();
            gs.DrawLines(new Pen(Color.Red), pointList);
            gs.DrawLine(new Pen(Color.Red), pointList[0], pointList[pointList.Length - 1]);
            pictureBox1.Image = bit;
        }
    }
}