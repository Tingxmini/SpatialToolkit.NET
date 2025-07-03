using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace suanfakuangjia
{
    public partial class ltl : Form
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
        public ltl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pb.CreateGraphics();//创建画板
            pb.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 1;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pb.MouseDown += new MouseEventHandler(this.pictureBoxArea_MouseDown);//定约事件
            //pic.MouseUp += new MouseEventHandler(this.pic_MouseUp);
            //pb.DoubleClick += new EventHandler(this.pb1_DoubleClick);
        }
        private void pictureBoxArea_MouseDown(object sender, MouseEventArgs e)
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
            if (pointlist.Count != 4)
            {
                MessageBox.Show("请绘制线段！");
            }
            else
            {
                CulDist();
            }
        }
        double maxdist;
        int maxindex;
        double mindist;
        int minindex;
        public void CulDist()
        {
            CulEdge();
            for (int i = 0; i < edgelist.Count; i++)
            {
                distlist.Add(distanceP(edgelist[i].a, edgelist[i].b));
            }
            maxdist = distlist.Max();
            maxindex = distlist.IndexOf(maxdist);
            mindist = distlist.Min();
            minindex = distlist.IndexOf(mindist);
            if (IsIntersection(pointlist[0], pointlist[1], pointlist[2], pointlist[3]))
            {
                textBox1.Text = Convert.ToInt16(0).ToString();//最短
            }
            else
            {
                textBox1.Text = Convert.ToInt16(mindist).ToString();//最短
                g.DrawLine(minpen, edgelist[minindex].a, edgelist[minindex].b);
            }

            textBox2.Text = Convert.ToInt16(maxdist).ToString();//最长
            g.DrawLine(maxpen, edgelist[maxindex].a, edgelist[maxindex].b);

        }

        //计算距离边
        public void CulEdge()
        {
            边 edge_AC = new 边(pointlist[0], pointlist[2]);
            edgelist.Add(edge_AC);
            边 edge_AD = new 边(pointlist[0], pointlist[3]);
            edgelist.Add(edge_AD);
            边 edge_BC = new 边(pointlist[1], pointlist[2]);
            edgelist.Add(edge_BC);
            边 edge_BD = new 边(pointlist[1], pointlist[3]);
            edgelist.Add(edge_BD);

            for (int i = 2; i < 4; i++)
            {
                PointF pointf = GetProjectivePoint(pointlist[0], pointlist[1], pointlist[i]);
                if (Judge(pointlist[0], pointlist[1], pointf))
                {
                    边 edge = new 边(pointlist[i], pointf);
                    edgelist.Add(edge);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                PointF pointf = GetProjectivePoint(pointlist[2], pointlist[3], pointlist[i]);
                if (Judge(pointlist[2], pointlist[3], pointf))
                {
                    边 edge = new 边(pointlist[i], pointf);
                    edgelist.Add(edge);
                }
            }
        }
        PointF pProject;
        protected PointF GetProjectivePoint(PointF p1, PointF p2, PointF p)
        {
            double k = (p2.Y - p1.Y) / (p2.X - p1.X);
            if (k == 0) //垂线斜率不存在情况
            {
                pProject.X = p.X;
                pProject.Y = p1.Y;
            }
            else
            {
                pProject.X = (float)((k * p1.X + p.X / k + p.Y - p1.Y) / (1 / k + k));
                pProject.Y = (float)(-1 / k * (pProject.X - p.X) + p.Y);
            }
            return pProject;
        }

        //判断点p是否在线段p1 p2内
        public bool Judge(PointF p1, PointF p2, PointF p)
        {
            if ((p.X <= Math.Max(p1.X, p2.X)) && (p.X >= Math.Min(p1.X, p2.X)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //求两点距离
        public double distanceP(PointF p1, PointF p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
        private static bool IsInsideLine(PointF start, PointF end, float x, float y)
        {
            return ((x >= start.X && x <= end.X)
                || (x >= end.X && x <= start.X))
                && ((y >= start.Y && y <= end.Y)
                    || (y >= end.Y && y <= start.Y));
        }
        public static bool IsIntersection(PointF lineAStart, PointF lineAEnd, PointF lineBStart, PointF lineBEnd)
        {
            float x1 = lineAStart.X, y1 = lineAStart.Y;
            float x2 = lineAEnd.X, y2 = lineAEnd.Y;

            float x3 = lineBStart.X, y3 = lineBStart.Y;
            float x4 = lineBEnd.X, y4 = lineBEnd.Y;

            //equations of the form x=c (two vertical lines)
            if (x1 == x2 && x3 == x4 && x1 == x3)
            {
                return false;
            }

            //equations of the form y=c (two horizontal lines)
            if (y1 == y2 && y3 == y4 && y1 == y3)
            {
                return false;
            }

            //equations of the form x=c (two vertical lines)
            if (x1 == x2 && x3 == x4)
            {
                return false;
            }

            //equations of the form y=c (two horizontal lines)
            if (y1 == y2 && y3 == y4)
            {
                return false;
            }
            float x, y;

            if (x1 == x2)
            {
                float m2 = (y4 - y3) / (x4 - x3);
                float c2 = -m2 * x3 + y3;

                x = x1;
                y = c2 + m2 * x1;
            }
            else if (x3 == x4)
            {
                float m1 = (y2 - y1) / (x2 - x1);
                float c1 = -m1 * x1 + y1;

                x = x3;
                y = c1 + m1 * x3;
            }
            else
            {
                //compute slope of line 1 (m1) and c2
                float m1 = (y2 - y1) / (x2 - x1);
                float c1 = -m1 * x1 + y1;

                //compute slope of line 2 (m2) and c2
                float m2 = (y4 - y3) / (x4 - x3);
                float c2 = -m2 * x3 + y3;

                //solving equations (3) & (4) => x = (c1-c2)/(m2-m1)
                //plugging x value in equation (4) => y = c2 + m2 * x
                x = (c1 - c2) / (m2 - m1);
                y = c2 + m2 * x;

                //          if (!(-m1 * x + y == c1
                //              && -m2 * x + y == c2))
                //          {
                //              return Vector3.zero;
                //          }
            }

            if (IsInsideLine(lineAStart, lineAEnd, x, y) &&
                IsInsideLine(lineBStart, lineBEnd, x, y))
            {
                return true;
            }

            //return default null (no intersection)
            return false;
        }
        private void button3_Click(object sender, EventArgs e)
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
