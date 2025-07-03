using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
namespace suanfakuangjia
{
    public partial class jisuan : Form
    {
        private Pen pen1;
        private SolidBrush bs;
        private int drawmode1 = 0;
        int clicknum = 0;
        int x0;
        int y0;
        int x1;
        int y1;
        int x2;
        int y2;
        Graphics g;
        List<Point> points = new List<Point>();
        List<Double> pointZ = new List<Double>();
        public double z;
        public int drawmode
        {
            get
            {
                return drawmode1;
            }
            set
            {
                drawmode1 = value;
            }
        }
        public Pen mypen
        {
            get
            {
                return pen1;
            }
        }
        public jisuan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pb1.CreateGraphics();//创建画板
            pb1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 1;//设置画图类型为画线
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb1.MouseDown += new MouseEventHandler(this.pictureBoxArea_MouseDown);//定约事件
            //pic.MouseUp += new MouseEventHandler(this.pic_MouseUp);
            pb1.DoubleClick += new EventHandler(this.pb1_DoubleClick);
        }
        private void pictureBoxArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (pb1.Cursor == Cursors.Cross && drawmode == 1)
            {//若画线
                if (clicknum > 0)
                {//若为第一个点
                    pen1 = mypen;
                    x2 = e.X;
                    y2 = e.Y;
                    Point p = new Point(e.X, e.Y);
                    points.Add(p);
                    g.DrawLine(pen1, x1, y1, x2, y2);//画线
                    x1 = x2;
                    y1 = y2;
                }
                else
                {
                    Point p = new Point(e.X, e.Y);
                    points.Add(p);
                    x0 = e.X;
                    y0 = e.Y;
                    x1 = e.X;
                    y1 = e.Y;
                }
                clicknum = clicknum + 1;
            }

        }

        private void pb1_DoubleClick(object sender, EventArgs e)
        {
            if (drawmode == 1)
            {
                g.DrawLine(pen1, x2, y2, x0, y0);
                textBox1.Text=("求得面积为" + CalculateArea(points).ToString());
                pb1.Cursor = Cursors.Arrow;
                drawmode = 0;
                clicknum = 0;
                x0 = 0;
                y0 = 0;
                x1 = 0;
                y1 = 0;
                x2 = 0;
                y2 = 0;
                points.Clear();
            }
            double CalculateArea(List<System.Drawing.Point> points)
            {
                var count = points.Count;
                double area0 = 0;
                double area1 = 0;
                for (int i = 0; i < count; i++)
                {
                    var x = points[i].X;
                    var y = i + 1 < count ? points[i + 1].Y : points[0].Y;
                    area0 += x * y;
                    var y1 = points[i].Y;
                    var x1 = i + 1 < count ? points[i + 1].X : points[0].X;
                    area1 += x1 * y1;
                }
                return Math.Round(Math.Abs(0.5 * (area0 - area1)), 2);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (drawmode == 1)
            {
                g.DrawLine(pen1, x2, y2, x0, y0);
                textBox1.Text = ("求得面积为" + CalculateArea(points).ToString());
                pb1.Cursor = Cursors.Arrow;
                drawmode = 0;
                clicknum = 0;
                x0 = 0;
                y0 = 0;
                x1 = 0;
                y1 = 0;
                x2 = 0;
                y2 = 0;
                points.Clear();
            }
            double CalculateArea(List<System.Drawing.Point> points)
            {
                var count = points.Count;
                double area0 = 0;
                double area1 = 0;
                for (int i = 0; i < count; i++)
                {
                    var x = points[i].X;
                    var y = i + 1 < count ? points[i + 1].Y : points[0].Y;
                    area0 += x * y;
                    var y1 = points[i].Y;
                    var x1 = i + 1 < count ? points[i + 1].X : points[0].X;
                    area1 += x1 * y1;
                }
                return Math.Round(Math.Abs(0.5 * (area0 - area1)), 2);
            }
        }
    }
}
