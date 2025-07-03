using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace suanfakuangjia
{
    public partial class pointweeding : Form
    {
        private Pen pen1;
        private SolidBrush bs;
        private int drawmode1 = 0;
        int clicknum = 0;
        float x0;
        float y0;
        float x1;
        float y1;
        float x2;
        float y2;
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
        public pointweeding()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 1;//设置画图类型为画线


            //int[,] points = new int[8, 2]{
            //                            {87,110},
            //                            {59,245},
            //                            {141,241},
            //                            {185,200},
            //                            {245,230},
            //                            {265,290},
            //                            {318,250},
            //                            {325,220}};

            //string points0 = "";
            //string points1 = "";
            //for (int i = 0; i < 8; i++)
            //{
            //    points0 = points[i, 0].ToString() + "," + points[i, 1].ToString();
            //    points1 = points1 + "Point" + i + ": {" + points0 + "}\n";
            //};
            //label2.Text = points1;//显示了数值
            ////Graphics g;//创建一个图形对象
            //Pen pen = new Pen(Color.FromArgb(255, 255, 0), 2);//创建画笔，设置颜色、笔触为3个像素
            Brush brush = new SolidBrush(Color.FromArgb(0, 0, 0));//创建笔刷，颜色为绿色
            //g = pictureBox1.CreateGraphics();

            //for (int i = 0; i < points.GetLength(0); i++)
            //{//画点
            //    int X1 = points[i, 0], Y1 = points[i, 1];
            //    g.FillEllipse(brush, X1 - 3, Y1 - 3, 6, 6);
            //};
            //for (int i = 0; i < points.GetLength(0) - 1; i++)
            //{
            //    int X1 = points[i, 0], Y1 = points[i, 1];
            //    int X2 = points[i + 1, 0], Y2 = points[i + 1, 1];
            //    g.DrawLine(pen, X1, Y1, X2, Y2);
            //};
        }
        public class canshu
        {
            public float k;
            public float b;
        }
        //求斜率
        public canshu xielv(float X1, float Y1, float X2, float Y2)//求斜率  传出k b
        {
            float k0, b0;
            canshu xielv_0 = new canshu();
            k0 = (float)(Y2 - Y1) / (X2 - X1);
            b0 = (float)(Y1 - k0 * X1);
            xielv_0.k = k0;
            xielv_0.b = b0;
            return xielv_0;
        }
        //点到直线的距离
        public canshu distance_me(float X, float Y, canshu C)
        {
            float dis = (float)(Math.Abs(C.k * X - Y + C.b)) / (float)Math.Sqrt(C.k * C.k);
            //点（x0，y0）到直线Ax+By+c=0的距离d=|Ax0+By0+c|/(A2+B2)1/2
            canshu distance_0 = new canshu();
            distance_0.k = dis;
            distance_0.b = -999;
            return distance_0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            canshu KB = xielv(points[1].X, points[1].Y, points[points.Count()-1].X, points[points.Count()-1].Y);
            string comboBox1_ = comboBox1.Text;
            float YuZhi = Convert.ToSingle(comboBox1_);
            canshu dis = KB;
            ArrayList list = new ArrayList();
            for (int i = 1; i < points.Count()-1; i++)
            {
                dis = distance_me(points[i].X, points[i].Y, KB);
                if (dis.k > YuZhi)
                {
                    //int j = max.Length;
                    list.Add(i);
                }
            }
            string List_1 = "";
            for (int j = 0; j < list.Count; j++)
            {
                List_1 = List_1 + "" + list[j] + ",";
            }
            //label3.Text = List_1 + "号点";//dis.k.ToString() +"\n" + dis.b.ToString();

            Graphics g;//创建一个图形对象
            Pen pen1 = new Pen(Color.FromArgb(0, 0, 255), 4);//创建画笔，设置颜色、笔触为3个像素
            g = pictureBox1.CreateGraphics();
            g.DrawLine(pen1, points[0].X, points[0].Y, points[(int)list[0]].X, points[(int)list[0]].Y);
            g.DrawLine(pen1, points[points.Count()-1].X, points[points.Count()-1].Y, points[(int)list[list.Count - 1]].X, points[(int)list[list.Count - 1]].Y);
            for (int i = 0; i < list.Count - 1; i++)
            {
                int j = (int)list[i];
                int k = (int)list[i + 1];
                int X11 = points[j].X, Y11 = points[j].Y;
                int X22 = points[k].X, Y22 = points[k].Y;
                g.DrawLine(pen1, X11, Y11, X22, Y22);
            };
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Cursor == Cursors.Cross && drawmode == 1)
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
            Brush brush = new SolidBrush(Color.FromArgb(0, 255, 255));//创建笔刷
            for (int i = 0; i < points.Count(); i++)
            {//画点
                int X1 = points[i].X, Y1 = points[i].Y;
                g.FillEllipse(brush, X1 - 3, Y1 - 3, 6, 6);
            };
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
