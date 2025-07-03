using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace suanfakuangjia
{
    public partial class podu11 : Form
    {
        public string Filename;
        public System.Drawing.Bitmap curBitmap;
        public podu11()
        {
            InitializeComponent();
        }
        int[] t1 = new int[1000];
        int[] t2 = new int[1000];
        int[] t3 = new int[1000];
        //创建高程点的结构，存储高程点的名称,X、Y坐标,高程H值
        public struct Point1
        {
            public int Number;
            public string Name;      //存储点的名称
            public double x;         //存储点的X坐标
            public double y;         //存储点的Y坐标
            public double h;         //存储点的高程值H
        }
        Point1[] pt = new Point1[1000];   //定义初始的点数组大小为1000
        int Lines;                      //记录文件的行数，即点的个数
        double xmax, xmin, ymax, ymin;  //记录所有点中的x，y坐标最大最小值
        int K;

        //打开高程点数据文件
        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog filename = new OpenFileDialog();
            filename.Filter = "All files(*.*)|*.*|txt files(*.txt)|*.txt|dat files(*.dat)|*.dat";
            filename.FilterIndex = 2;
            //filename.RestoreDirectory = true;                          
            if (filename.ShowDialog() == DialogResult.OK)
            {
                Filename = filename.FileName.ToString();
                string[] lines = File.ReadAllLines(Filename);
                Lines = lines.Length;
                for (int i = 1; i <= Lines; i++)
                {
                    string[] sArray = lines[i - 1].Split(',');  //按","将每一行分割成四个字符串
                    pt[i].Number = i;
                    pt[i].Name = sArray[0];
                    pt[i].x = Convert.ToDouble(sArray[1]);
                    pt[i].y = Convert.ToDouble(sArray[2]);
                    pt[i].h = Convert.ToDouble(sArray[3]);
                }
            }
        }

        //确定所有点的范围
        private void Area()
        {
            xmax = xmin = pt[1].x;
            ymax = ymin = pt[1].y;
            for (int i = 2; i <= Lines; i++)
            {
                if (xmax < pt[i].x) xmax = pt[i].x;
                if (xmin > pt[i].x) xmin = pt[i].x;
                if (ymax < pt[i].y) ymax = pt[i].y;
                if (ymin > pt[i].y) ymin = pt[i].y;
            }
        }

        //计算坐标转换比例因子
        public double CalcScale()
        {
            Area();
            Rectangle m_rect = pictureBox1.ClientRectangle;
            double ds = 1.0;
            double dsx, dsy;
            if ((xmax - xmin != 0) && (ymax - ymin != 0))
            {
                dsx = Math.Abs((xmax - xmin) / m_rect.Height);
                dsy = Math.Abs((ymax - ymin) / m_rect.Width);
                ds = Math.Max(dsx, dsy);
            }
            else
            {
                if (xmax - xmin != 0)
                {
                    ds = Math.Abs((xmax - xmin) / m_rect.Height);
                }
                else
                {
                    if (ymax - ymin != 0)
                    {
                        ds = Math.Abs((ymax - ymin) / m_rect.Width);
                    }
                    else { ds = 1; }
                }
            }
            return ds;
        }

        //找到两个最近的高程点
        public void MinDistance(Point1[] pt, out int pt1, out int pt2)
        {
            int i, j;
            double[,] Distance = new double[Lines, Lines];
            //将任意两点间的距离存储到矩阵Distance中
            for (i = 1; i <= Lines; i++)
                for (j = i + 1; j < Lines; j++)
                    if (i != j)
                        Distance[i, j] = Math.Sqrt(Math.Pow(pt[i].x - pt[j].x, 2) + Math.Pow(pt[i].y - pt[j].y, 2));
            double[] Mindistance = { 10000, 0, 0 };
            //找到矩阵Distance中的最小值，并记录行列号
            for (i = 1; i <= Lines; i++)
                for (j = i + 1; j < Lines; j++)
                    if (Mindistance[0] > Distance[i, j])
                    {
                        Mindistance[0] = Distance[i, j];
                        Mindistance[1] = i;
                        Mindistance[2] = j;
                    }
            pt1 = (int)Mindistance[1];
            pt2 = (int)Mindistance[2];
        }

        //找到离中点最近的点
        public void Find(int pt1, int pt2, out int pt3)
        {
            int i;
            double meanx = (pt[pt1].x + pt[pt2].x) / 2;
            double meany = (pt[pt1].y + pt[pt2].y) / 2;
            double Min = 10000000000;
            pt3 = 0;
            for (i = 1; i <= Lines; i++)
            {
                if (i != pt1 && i != pt2)
                {
                    double temp = Math.Sqrt(Math.Pow(pt[i].x - meanx, 2) + Math.Pow(pt[i].y - meany, 2));
                    if (Min > temp)
                    {
                        Min = temp;
                        pt3 = i;
                    }
                }
            }
        }

        //判断三角形扩展点是否在同一侧
        public bool Direction(int point1, int point2, int point3, int point4)
        {
            //计算直线方程的系数a，b
            double a = (pt[point2].y - pt[point1].y) / (pt[point2].x - pt[point1].x);
            double b = (pt[point1].x * pt[point2].y - pt[point2].x * pt[point1].y) / (pt[point2].x - pt[point1].x);
            double fxy1 = pt[point3].y - (a * pt[point3].x - b);
            double fxy2 = pt[point4].y - (a * pt[point4].x - b);
            //当位于非同一侧时
            if (fxy1 < 0 && fxy2 > 0 || fxy1 > 0 && fxy2 < 0)
                return true;
            //当位于同一侧时
            else return false;
        }

        //计算扩展边的角度余弦值
        public double Angle(int pt1, int pt2, int pt3)
        {
            double angle;
            double L1 = Math.Sqrt((pt[pt2].x - pt[pt3].x) * (pt[pt2].x - pt[pt3].x) + (pt[pt2].y - pt[pt3].y) * (pt[pt2].y - pt[pt3].y));
            double L2 = Math.Sqrt((pt[pt1].x - pt[pt3].x) * (pt[pt1].x - pt[pt3].x) + (pt[pt1].y - pt[pt3].y) * (pt[pt1].y - pt[pt3].y));
            double L3 = Math.Sqrt((pt[pt2].x - pt[pt1].x) * (pt[pt2].x - pt[pt1].x) + (pt[pt2].y - pt[pt1].y) * (pt[pt2].y - pt[pt1].y));
            angle = (L1 * L1 + L2 * L2 - L3 * L3) / (2 * L1 * L2);
            return angle;
        }

        //找到扩展边形成张角最大的点
        private int MaxAngle(int[] x, int A, int B, int n)
        {
            double C = 0, temp, s = 0;
            int max = 0;
            for (int i = 1; i <= n; i++)
            {
                if (x[i] != A && x[i] != B)
                {
                    s = Angle(A, B, x[i]);
                    if (s < 1)
                        C = Math.Acos(s);
                    else C = 0;
                    max = x[i];
                    break;
                }
            }
            for (int i = 1; i <= n; i++)
            {
                if (i != A && i != B)
                {
                    s = Angle(A, B, x[i]);
                    if (s < 1)
                        temp = Math.Acos(s);
                    else temp = 0;
                    if (temp > C)
                    {
                        C = temp;
                        max = x[i];
                    }
                }
            }
            return max;
        }

        //判断三角形的一条边是否已经出现过两次
        public bool Repeat(int point1, int point2, int L)
        {
            int sum = 0;
            for (int i = 1; i <= L; i++)
            {
                if (point1 == t1[i] && point2 == t2[i] || point1 == t2[i] && point2 == t1[i] ||
                    point1 == t2[i] && point2 == t3[i] || point1 == t3[i] && point2 == t2[i] ||
                    point1 == t3[i] && point2 == t1[i] || point1 == t1[i] && point2 == t3[i])
                {
                    sum++;
                    if (sum == 2)
                        return false;
                }
            }
            return true;
        }

        private void 构建TINCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //找到所有点中距离最小的两个点，作为第一个三角形的第一个点和第二个点
            MinDistance(pt, out int point1, out int point2);
            t1[1] = point1;
            t2[1] = point2;

            //寻找第一个三角形的第三个点：离第一条边距离最短的点
            Find(point1, point2, out int point3);
            t3[1] = point3;

            //设置计数变量K记录扩展的三角形数
            K = 0;
            //设置计数变量L记录已经形成的三角形数
            int L = 1;
            //设置数组存储可能的扩展点
            int[] x = new int[Lines];

            //扩展三角形
            while (K != L)
            {
                K++;
                point1 = t1[K];
                point2 = t2[K];
                point3 = t3[K];

                //第一条扩展边不重复，没有被两个三角形共用
                if (Repeat(point1, point2, L))
                {
                    //判断新扩展的边
                    int t = 0;
                    x[t++] = 0;
                    //寻找可能的扩展点
                    for (int i = 1; i <= Lines; i++)
                        if (i != point1 && i != point2 && i != point3 && Direction(point1, point2,point3, i))
                        {
                            x[t++] = i;
                        }
                    //存在扩展点
                    if (t > 1)
                    {
                        int max = MaxAngle(x, point1, point2, t - 1);
                        L = L + 1;
                        t1[L] = point1;
                        t2[L] = point2;
                        t3[L] = max;
                    }
                }

                //第二条扩展边不重复，没有被两个三角形共用
                if (Repeat(point1, point3, L))
                {
                    int t = 0;
                    x[t++] = 0;
                    for (int i = 1; i <= Lines; i++)
                        if (i != point1 && i != point3 && i != point2 && Direction(point1, point3, point2, i))
                        {
                            x[t++] = i;
                        }
                    if (t > 1)
                    {
                        int max = MaxAngle(x, point1, point3, t - 1);
                        L = L + 1;
                        t1[L] = point1;
                        t2[L] = point3;
                        t3[L] = max;
                    }
                }

                //第三条扩展边不重复，没有被两个三角形共用
                if (Repeat(point2, point3, L))
                {
                    int t = 0;
                    x[t++] = 0;
                    for (int i = 1; i <= Lines; i++)
                        if (i != point2 && i != point3 && i != point1 && Direction(point2, point3, point1, i))
                        {
                            x[t++] = i;
                        }
                    if (t > 1)
                    {
                        int max = MaxAngle(x, point2, point3, t - 1);
                        L = L + 1;
                        t1[L] = point2;
                        t2[L] = point3;
                        t3[L] = max;
                    }
                }
            }

            //绘制TIN
            Graphics g = pictureBox1.CreateGraphics();
            double m_scale = CalcScale();
            Pen mypen = new Pen(Color.Red, 1);                   //创建画笔
            Rectangle m_rect = pictureBox1.ClientRectangle;      //获得画布大小
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality; //消除锯齿
            for (int i = 1; i <= L; i++)
            {
                //由测量坐标计算屏幕坐标
                double ix1 = (pt[t1[i]].y - ymin) / m_scale;
                double iy1 = m_rect.Height - (pt[t1[i]].x - xmin) / m_scale - 20;

                double ix2 = (pt[t2[i]].y - ymin ) / m_scale;
                double iy2 = m_rect.Height - (pt[t2[i]].x - xmin) / m_scale - 20;

                double ix3 = (pt[t3[i]].y - ymin) / m_scale;
                double iy3 = m_rect.Height - (pt[t3[i]].x - xmin) / m_scale - 20;


                g.DrawLine(mypen, (float)ix1, (float)iy1, (float)ix2, (float)iy2);
                g.DrawLine(mypen, (float)ix1, (float)iy1, (float)ix3, (float)iy3);
                g.DrawLine(mypen, (float)ix3, (float)iy3, (float)ix2, (float)iy2);
            }
            //g.Dispose();
        }

        //展高程点
        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Area();
            Graphics g = pictureBox1.CreateGraphics();
            Rectangle m_rect = pictureBox1.ClientRectangle;//获得画布大小
            Font myFont = new Font("宋体", 8, FontStyle.Bold);//创建字体
            Brush bush = new SolidBrush(Color.Black);//创建单色画刷
            double m_scale = CalcScale();
            for (int i = 1; i <= Lines; i++)
            {
                //由测量坐标计算屏幕坐标
                double ix = (pt[i].y - ymin ) / (m_scale);
                double iy = m_rect.Height - (pt[i].x - xmin) / (m_scale) -20;

                g.DrawEllipse(new Pen(Color.Black), (float)ix, (float)iy, 3, 3);
                g.FillEllipse(new SolidBrush(Color.Black), (float)ix, (float)iy, 3, 3);
                g.DrawString(pt[i].Name, myFont, bush, (float)ix - 3, (float)iy + 5);
            }
        }

        //导出三角形
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog filename1 = new SaveFileDialog();
            string newTxtPath = Application.StartupPath + "/Result-All-Tri.txt";
            StreamWriter sw = new StreamWriter(newTxtPath, false, Encoding.Default);
            sw.WriteLine("=========================三角形组成========================");
            sw.WriteLine("三角形序号      第一点序号      第二点序号       第三点序号");
            for (int i = 1; i <= K; i++)
            {
                sw.WriteLine("{0,5}{1,17}{2,17}{3,17}", i.ToString(), t1[i].ToString(), t2[i].ToString(), t3[i].ToString());
            }
            sw.Flush();
            System.Diagnostics.Process.Start(newTxtPath);
        }

        //退出窗口
        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
