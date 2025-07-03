using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace suanfakuangjia
{
    public partial class pointtoline : Form
    {
        private Pen pen1;
        private int drawmode1 = 0;
        Graphics g;
        List<Point> points = new List<Point>();
        List<Double> pointZ = new List<Double>();
        public double z;
        List<PointF> pointlist = new List<PointF>();//存放点数据
        List<边> edgelist = new List<边>();//存放边数据
        List<double> distlist = new List<double>();//存放距离数据
        Pen maxpen = new Pen(Color.Red, 3);
        Pen minpen = new Pen(Color.Yellow, 3);
        public pointtoline()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 1;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointlist.Count < 4)
            {
                Point point = new Point(e.X, e.Y);
                pointlist.Add(point);
                if (pointlist.Count == 1)
                {
                    listBox1.Items.Add("A1" + point);
                    g.FillEllipse(Brushes.Red, pointlist[0].X - 2, pointlist[0].Y - 2, 4, 4);
                }
                if (pointlist.Count == 2)
                {
                    listBox1.Items.Add("A2" + point);
                    g.FillEllipse(Brushes.Red, pointlist[1].X - 2, pointlist[1].Y - 2, 4, 4);
                    g.DrawLine(Pens.Black, pointlist[0], pointlist[1]);
                }
                if (pointlist.Count == 3)
                {
                    listBox1.Items.Add("B1" + point);
                    g.FillEllipse(Brushes.Red, pointlist[2].X - 2, pointlist[2].Y - 2, 4, 4);
                }
                if (pointlist.Count == 4)
                {
                    listBox1.Items.Add("B2" + point);
                    g.FillEllipse(Brushes.Red, pointlist[3].X - 2, pointlist[3].Y - 2, 4, 4);
                    g.DrawLine(Pens.Black, pointlist[2], pointlist[3]);
                }
            }
            else
            {
                MessageBox.Show("请点击计算！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float x1 = pointlist[0].X;
            float y1 = pointlist[0].Y;
            float x2 = pointlist[1].X;
            float y2 = pointlist[1].Y;
            float x3 = pointlist[2].X;
            float y3 = pointlist[0].Y;

            double result = 0;
            double x, ca, cb, ab, d;
            ca = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
            cb = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            ab = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            x = Math.Max(ca, cb);
            d = PTL(x1, x2, x3, y1, y2, y3);
            if (Math.Sqrt(Math.Pow(x, 2) - Math.Pow(d, 2)) > ab)
                result = Math.Min(ca, cb);

            else
                result = d;
            res1.Text = result.ToString();
        }
        double PTL(double x1, double x2, double x3, double y1, double y2, double y3)
        {

            double res, a, b, c;
            a = (x3 - x1) * (y2 - y1);
            b = (y3 - y1) * (x1 - x2);
            c = a + b;
            c *= c;
            a = Math.Pow(y2 - y1, 2);
            b = Math.Pow(x1 - x2, 2);
            c /= (a + b);
            res = Math.Sqrt(c);
            return res;
        }
    }
}
