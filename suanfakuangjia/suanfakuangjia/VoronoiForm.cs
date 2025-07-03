using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Collections;
using CSPoint = System.Drawing.Point;//重命名内置类的名称，因为与自定义的类同名


namespace suanfakuangjia
{
    public partial class voronoi : Form
    {
        public string Filename;
        //public System.Drawing.Bitmap curBitmap;

        Graphics g;
        Random seeder;
        Bitmap backImage;
        int siteCount = 10;//初始设定点数为10
        Voronoi voroObject=new Voronoi();


        public int tPoints = 0;
        int HowMany = 0;
        Point point = new Point();
        Point point1 = new Point();
        Point point2 = new Point();
        Point point3 = new Point();
        Pen p = new Pen(Color.Red, 2);
        Pen p3 = new Pen(Color.Yellow, 2);
        List<DelaunayTriangle> allTriangle = new List<DelaunayTriangle>();//delaunay三角形集合
        List<PointF> sites = new List<PointF>();
        List<Site> sitesP = new List<Site>();
        List<Edge> trianglesEdgeList = new List<Edge>();//Delaunay三角形网所有边
        List<Edge> voronoiEdgeList = new List<Edge>();//vironoi图所有边
        List<Edge> voronoiRayEdgeList = new List<Edge>();//voroni图外围射线边

        datatype dt = new datatype();

        int len1;


        string rowIndex;
        bool isopen;
        bool iscal;
        private string curFileName;
        private string TempStr1;
        private string[] TempStr2;
        private double[,] Value1, Value2, Value3;
        private suanfakuangjia.Data.Triangle[] Tri;
        private Data.Line[] Line;
        int o, K, wid, hig, k;
        double x;
        double Z = 0;
        private System.Drawing.Bitmap curBitmap;

        public voronoi()
        {
            InitializeComponent();
            //初始化随机数对象
            seeder = new Random();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            //初始化pictureBox背景图
            backImage = new Bitmap(510, 410);
            g = Graphics.FromImage(backImage);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);

            //将背景图填充到pictureBox中
            pictureBox1.Image = backImage;
        }



        C_Trianglate trianglate = null;
        C_Trianglate2 trianglate2 = null;

        double dMax_X = -999999999;
        double dMax_Y = -999999999;
        double dMin_X = 9999999999;
        double dMin_Y = 9999999999;
        double dMax_Z = -9999999999;
        double dMin_Z = 9999999999;


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
        //int K;
        private void voronoi_Load(object sender, EventArgs e)
        {
            tPoints = 1;
        }

        public void spreadPoints()
        {
            g.Clear(Color.White);
            List<DelaunayTriangle> allTriangle = new List<DelaunayTriangle>();//delaunay三角形集合
            List<PointF> sites = new List<PointF>();
            List<Site> sitesP = new List<Site>();
            int seed = seeder.Next();
            Random rand = new Random(seed);
            List<Edge> trianglesEdgeList = new List<Edge>();//Delaunay三角形网所有边
            List<Edge> voronoiEdgeList = new List<Edge>();//vironoi图所有边
            List<Edge> voronoiRayEdgeList = new List<Edge>();//voroni图外围射线边

            //初始设定点数为20
            //初始设定画布大小是500*400
            //超级三角形顶点坐标为（250,0），（0,400），（500,400）
            //点集区域为（125,200），（125,400），（375,200），（375,400），随便设置，只要满足点落在三角形区域中
            for (int i = 0; i < siteCount; i++)
            {

                PointF pf = new PointF((float)(rand.NextDouble() * 500), (float)(rand.NextDouble() * 400));
                //PointF pf=new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200));
                Site site=new Site(pf.X,pf.Y);
                sitesP.Add(site);
                //sitesP.Add(new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200)));
            }

            //按点集坐标X值排序
            sitesP.Sort(new SiteSorterXY());
            for (int i = 0; i < sitesP.Count; i++)
            {
                //listBox1.Items.Add(sitesP[i].x);
            }

            //将超级三角形的三点添加到三角形网中
            Site A = new Site(250,-5000);
            Site B = new Site(-5000,400);
            Site C = new Site(5000,400);
            DelaunayTriangle dt = new DelaunayTriangle(A,B,C);
            allTriangle.Add(dt);
            
            //构造Delaunay三角形网
            voroObject.setDelaunayTriangle(allTriangle,sitesP);

            //不要移除，这样就不用画Delaunay三角形网外围边的射线
            //移除超级三角形
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,A);
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,B);
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,C);

            //返回Delaunay三角形网所有边
            trianglesEdgeList = voroObject.returnEdgesofTriangleList(allTriangle);
            
            //获取所有Voronoi边
            voronoiEdgeList = voroObject.returnVoronoiEdgesFromDelaunayTriangles(allTriangle, voronoiRayEdgeList);

            //画点(填充圆)
            for (int i = 0; i < sitesP.Count; i++)
            {
                g.FillEllipse(Brushes.Blue, (float)(sitesP[i].x - 1.5f), (float)(sitesP[i].y - 1.5f), 3, 3);
            }

            //显示Delaunay三角形网
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < voronoiEdgeList.Count; i++)
                {
                    CSPoint p1 = new CSPoint((int)trianglesEdgeList[i].a.x, (int)trianglesEdgeList[i].a.y);
                    CSPoint p2 = new CSPoint((int)trianglesEdgeList[i].b.x, (int)trianglesEdgeList[i].b.y);
                    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
                }
            }

            //根据维诺图的边画线段
            if (checkBox2.Checked == true)
            {
                for (int i = 0; i < voronoiEdgeList.Count; i++)
                {
                    CSPoint p1 = new CSPoint((int)voronoiEdgeList[i].a.x, (int)voronoiEdgeList[i].a.y);
                    CSPoint p2 = new CSPoint((int)voronoiEdgeList[i].b.x, (int)voronoiEdgeList[i].b.y);
                    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
                }
            }

            //根据Voronoi的射线边画线
            //for (int i = 0; i < voronoiRayEdgeList.Count; i++)
            //{
            //    CSPoint p1 = new CSPoint((int)voronoiRayEdgeList[i].a.x, (int)voronoiRayEdgeList[i].a.y);
            //    CSPoint p2 = new CSPoint((int)voronoiRayEdgeList[i].b.x, (int)voronoiRayEdgeList[i].b.y);
            //    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //}

            //更新pictureBox背景图片
            pictureBox1.Image = backImage;

        }
		
        //鼠标移动事件
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = e.X + ", " + e.Y;
        }

        //确定按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            //siteCount = (int)numericUpDown1.Value;
            //spreadPoints();
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
                        if (i != point1 && i != point2 && i != point3 && Direction(point1, point2, point3, i))
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

                double ix2 = (pt[t2[i]].y - ymin) / m_scale;
                double iy2 = m_rect.Height - (pt[t2[i]].x - xmin) / m_scale - 20;

                double ix3 = (pt[t3[i]].y - ymin) / m_scale;
                double iy3 = m_rect.Height - (pt[t3[i]].x - xmin) / m_scale - 20;


                g.DrawLine(mypen, (float)ix1, (float)iy1, (float)ix2, (float)iy2);
                g.DrawLine(mypen, (float)ix1, (float)iy1, (float)ix3, (float)iy3);
                g.DrawLine(mypen, (float)ix3, (float)iy3, (float)ix2, (float)iy2);
            }
        }
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dt.Vertex[tPoints].x = e.X;
            dt.Vertex[tPoints].y = e.Y;
            //Perform Triangulation Function if there are more than 2 points
            if (tPoints > 2)
            {
                // set form's color as white
                g.Clear(Color.White);
                function fu = new function();
                HowMany = fu.Triangulate(tPoints, dt);
            }
            else
            {
                point = new Point(e.X, e.Y);
                g = pictureBox1.CreateGraphics();
                g.DrawEllipse(p, e.X, e.Y, 3, 3);
                Update();
            }
            tPoints++;
            //Label1.Text = "点个数是 " + tPoints;
            //Label2.Text = "三角形个数是" + HowMany;
            for (int i = 1; i <= HowMany; i++)
            {
                point1 = new Point(Convert.ToInt32(dt.Vertex[dt.Triangle[i].vv0].x), Convert.ToInt32(dt.Vertex[dt.Triangle[i].vv0].y));
                point2 = new Point(Convert.ToInt32(dt.Vertex[dt.Triangle[i].vv1].x), Convert.ToInt32(dt.Vertex[dt.Triangle[i].vv1].y));
                point3 = new Point(Convert.ToInt32(dt.Vertex[dt.Triangle[i].vv2].x), Convert.ToInt32(dt.Vertex[dt.Triangle[i].vv2].y));
                g.DrawLine(p, point1, point2);
                g.DrawLine(p, point2, point3);
                g.DrawLine(p, point1, point3);
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            barycenter bc = new barycenter();
            bc.CalculateBC(HowMany, dt);
            for (int i = 1; i <= HowMany; i++)
            {
                SolidBrush brush1 = new SolidBrush(Color.Black);
                g.FillEllipse(brush1, Convert.ToInt64(dt.OutHert[i].a), Convert.ToInt64(dt.OutHert[i].b), 4, 4);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //if (trianglate != null)
            //{
            //    if (conTrace != null && conTrace.list_ContourLine.Count > 0)
            //    {
            //        //------- 等值线填充 -------   

            //        //------- 等值线绘制 -------
            //        if (isDrawConLine)
            //        {
            //            #region "Draw ConLine"
            //            PointF p1 = new PointF(0, 0);
            //            PointF p2 = new PointF(0, 0);
            //            contour1.Cmou_Point conP1 = new suanfakuangjia.contour1.Cmou_Point();
            //            contour1.Cmou_Point conP2 = new suanfakuangjia.contour1.Cmou_Point();
            //            foreach (contour1.Cmou_ContourLine conLine in conTrace.list_ContourLine)
            //            {
            //                //Contour.Cmou_ContourLine conLine = conTrace.list_ContourLine[0];
            //                if (conLine.conType == suanfakuangjia.contour1.ContourLineType.Opened)
            //                {
            //                    for (int iP = 0; iP < conLine.list_Point.Count; iP++)
            //                    {
            //                        if (iP == 0)
            //                        {
            //                            conP1 = conLine.list_Point[iP];
            //                            p1.X = (float)conP1.X;
            //                            p1.Y = (float)conP1.Y;
            //                        }
            //                        else
            //                        {
            //                            conP2 = conLine.list_Point[iP];
            //                            p2.X = (float)conP2.X;
            //                            p2.Y = (float)conP2.Y;
            //                            g.DrawLine(Pens.Black, p1, p2);
            //                            p1 = p2;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    for (int iP = 0; iP < conLine.list_Point.Count; iP++)
            //                    {
            //                        if (iP == 0)
            //                        {
            //                            conP1 = conLine.list_Point[iP];
            //                            p1.X = (float)conP1.X;
            //                            p1.Y = (float)conP1.Y;
            //                        }
            //                        else
            //                        {
            //                            conP2 = conLine.list_Point[iP];
            //                            p2.X = (float)conP2.X;
            //                            p2.Y = (float)conP2.Y;
            //                            g.DrawLine(Pens.Black, p1, p2);
            //                            p1 = p2;
            //                        }
            //                    }

            //                    conP1 = conLine.list_Point[0];
            //                    p1.X = (float)conP1.X;
            //                    p1.Y = (float)conP1.Y;
            //                    g.DrawLine(Pens.Black, p2, p1);
            //                }
            //            }
            //            #endregion


            //        }
            //        else
            //        {
            //            #region "Draw Beziers"
            //            //     Graphics F = this.CreateGraphics();
            //            PointF p1 = new PointF(0, 0);
            //            PointF p2 = new PointF(0, 0);
            //            PointF p3 = new PointF(0, 0);
            //            PointF p4 = new PointF(0, 0);
            //            contour1.Cmou_Point conP1 = new suanfakuangjia.contour1.Cmou_Point();
            //            contour1.Cmou_Point conP2 = new suanfakuangjia.contour1.Cmou_Point();
            //            contour1.Cmou_Point conP3 = new suanfakuangjia.contour1.Cmou_Point();
            //            contour1.Cmou_Point conP4 = new suanfakuangjia.contour1.Cmou_Point();
            //            foreach (contour1.Cmou_ContourLine conLine in conTrace.list_ContourLine)
            //            {
            //                //Contour.Cmou_ContourLine conLine = conTrace.list_ContourLine[0];
            //                if (conLine.conType == suanfakuangjia.contour1.ContourLineType.Opened)
            //                {
            //                    for (int iP = 0; iP < conLine.list_Point.Count - 3; iP = iP + 3)
            //                    {

            //                        conP1 = conLine.list_Point[iP];
            //                        p1.X = (float)conP1.X;
            //                        p1.Y = (float)conP1.Y;

            //                        conP2 = conLine.list_Point[iP + 1];
            //                        conP3 = conLine.list_Point[iP + 2];
            //                        conP4 = conLine.list_Point[iP + 3];
            //                        p4.X = (float)conP4.X;
            //                        p4.Y = (float)conP4.Y;
            //                        p3.X = (float)conP3.X;
            //                        p3.Y = (float)conP3.Y;
            //                        p2.X = (float)conP2.X;
            //                        p2.Y = (float)conP2.Y;
            //                        //  g.DrawCurve(Pens.Black, new PointF[] { p1, p2, p3,p4 });

            //                        //g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { new Point(100, 10), new Point(200, 500), new Point(407, 30), new Point(760, 80) });

            //                        g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { p1, p2, p3, p4 });
            //                        //   F.Dispose();



            //                    }
            //                }
            //                else
            //                {
            //                    for (int iP = 0; iP < conLine.list_Point.Count - 3; iP = iP + 3)
            //                    {
            //                        conP1 = conLine.list_Point[iP];
            //                        p1.X = (float)conP1.X;
            //                        p1.Y = (float)conP1.Y;

            //                        conP2 = conLine.list_Point[iP + 1];
            //                        conP3 = conLine.list_Point[iP + 2];
            //                        conP4 = conLine.list_Point[iP + 3];
            //                        p4.X = (float)conP4.X;
            //                        p4.Y = (float)conP4.Y;
            //                        p3.X = (float)conP3.X;
            //                        p3.Y = (float)conP3.Y;
            //                        p2.X = (float)conP2.X;
            //                        p2.Y = (float)conP2.Y;
            //                        // g.DrawCurve(Pens.Black, new PointF[] { p1, p2, p3,p4 });
            //                        //  g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { new Point(100, 10), new Point(200, 500), new Point(407, 30), new Point(760, 80) });
            //                        g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { p1, p2, p3, p4 });
            //                        //   F.Dispose();


            //                    }

            //                    conP1 = conLine.list_Point[0];
            //                    p1.X = (float)conP1.X;
            //                    p1.Y = (float)conP1.Y;

            //                    g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { p4, p3, p2, p1 });
            //                    //   F.Dispose();
            //                    // g.DrawCurve(Pens.Black, new PointF[] {p4, p3, p2, p1 });
            //                    //g.DrawLine(Pens.Black, p2, p1);
            //                }
            //            }
            //            #endregion
            //        }
            //        //等值线
            //        conTrace.CTrace_MarkContourLine(g);
            //    }

            //    //三角形 
            //    if (isDrawTriangle)
            //        trianglate.drawtriangle(g);

            //}
        }
        C_ContourTrace conTrace = null;
        bool isDrawConLine = true;
        bool isMarkTriangle = false;
        bool isDrawTriangle = false;
        string str_FilePath = null;

        private void button9_Click(object sender, EventArgs e)
        {
            if (isopen == false)
            {
                MessageBox.Show("请先打开文件！");
                return;
            }

            Data.db_count = dataGridView1.RowCount;

            k = TempStr2.Length / 3;
            Value2 = new double[k, k];
            double Min = 0, midx, midy;
            int m = 0, n = 1, L = 0, g = 0, h = 1;
            K = 0;
            int[] AA = new int[k];
            for (int i = 0; i < k; i++)
                for (int j = i + 1; j < k; j++)
                {
                    Value2[i, j] = (Value1[i, 1] - Value1[j, 1]) * (Value1[i, 1] - Value1[j, 1]) +
                        (Value1[i, 2] - Value1[j, 2]) * (Value1[i, 2] - Value1[j, 2]);
                    if (i == 0 && j == 1)
                        Min = Value2[0, 1];
                    else
                    {
                        if (Min > Value2[i, j])
                        {
                            m = i; n = j;
                            Min = Value2[i, j];

                        }
                    }
                }

            Tri = new Data.Triangle[k * (k - 1) / 2];
            Line = new Data.Line[k * (k - 1) / 2];
            Tri[0] = new Data.Triangle();
            Tri[0].Line[0] = new Data.Line();
            Tri[0].Line[1] = new Data.Line();
            Tri[0].Line[2] = new Data.Line();

            Tri[0].ID = 1;
            Tri[0].Peak[0] = m;
            Tri[0].Peak[1] = n;

            Tri[0].Line[0].ID = 1;
            Tri[0].Line[0].Point[0] = m;
            Tri[0].Line[0].Point[1] = n;

            Line[0] = new Data.Line();
            Line[1] = new Data.Line();
            Line[2] = new Data.Line();
            Line[0].ID = 1;
            Line[0].Point[0] = m;
            Line[0].Point[1] = n;
            o = 1;
            int q = 0;
            midx = (Value1[m, 1] + Value1[n, 1]) / 2;
            midy = (Value1[m, 2] + Value1[n, 2]) / 2;

            for (int j = 0; j < k; j++)
            {
                if ((j != m) && (j != n))
                {
                    Min = (midx - Value1[j, 1]) * (midx - Value1[j, 1]) + (midy - Value1[j, 2]) * (midy - Value1[j, 2]);
                    q = j;
                    break;
                }
            }
            for (int i = 0; i < k; i++)
            {
                if ((i != m) && (i != n) && ((midx - Value1[i, 1]) * (midx - Value1[i, 1]) + (midy - Value1[i, 2]) * (midy - Value1[i, 2]) < Min))
                {
                    Min = (midx - Value1[i, 1]) * (midx - Value1[i, 1]) + (midy - Value1[i, 2]) * (midy - Value1[i, 2]);
                    q = i;
                }
            }
            Line[1].ID = 2;
            Line[1].Point[0] = Tri[0].Line[0].Point[1];
            Line[1].Point[1] = q;
            Line[2].ID = 3;
            Line[2].Point[0] = q;
            Line[2].Point[1] = Line[0].Point[0];
            Line[0].Bor[0] = Tri[0].ID;
            Line[1].Bor[0] = Tri[0].ID;
            Line[2].Bor[0] = Tri[0].ID;

            Tri[0].Peak[2] = q;
            Tri[0].Line[1] = Line[1];
            Tri[0].Line[2] = Line[2];

            o = 3;
            L = 1;
            K = 0;
            ArrayList List1 = new ArrayList();
            ArrayList List2 = new ArrayList();
            Data.Line[] Linetemp = new Data.Line[2];
            CIrregularTriangulation BB = new CIrregularTriangulation();
            CIrregularTriangulation CC = new CIrregularTriangulation();
            while (K < L)
            {
                int d;
                d = CC.SS(BB, Tri, K, k, ref L, Value1, Line, ref o);
                K++;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("顶点1", typeof(String));
            dt.Columns.Add("顶点2", typeof(String));
            dt.Columns.Add("顶点3", typeof(String));
            dt.Columns.Add("体积", typeof(String));
            this.dataGridView1.DataSource = dt;
            Data.dc_v = new double[L];
            for (int i = 0; i < L; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = Tri[i].Peak[0];
                dr[1] = Tri[i].Peak[1];
                dr[2] = Tri[i].Peak[2];

                double AB = Math.Sqrt((Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[1], 2]) * (Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[1], 2]) + (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[1], 1]) * (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[1], 1]));
                double AC = Math.Sqrt((Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[2], 2]) * (Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[2], 2]) + (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[2], 1]) * (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[2], 1]));
                double BC = Math.Sqrt((Value1[Tri[i].Peak[1], 2] - Value1[Tri[i].Peak[2], 2]) * (Value1[Tri[i].Peak[1], 2] - Value1[Tri[i].Peak[2], 2]) + (Value1[Tri[i].Peak[1], 1] - Value1[Tri[i].Peak[2], 1]) * (Value1[Tri[i].Peak[1], 1] - Value1[Tri[i].Peak[2], 1]));

                double M = (AB + AC + BC) / 2;
                double S = Math.Sqrt(M * (M - AB) * (M - AC) * (M - BC));
                Z = Z + S;
                this.textBox3.Text = Z.ToString();

                Data.dc_v[i] = S / 3 * (Data.db_h - Value1[Tri[i].Peak[0], 3] + Data.db_h - Value1[Tri[i].Peak[1], 3] + Data.db_h - Value1[Tri[i].Peak[2], 3]);
                Data.dc_v[i] = Math.Round(Data.dc_v[i], 3); Data.dc_v[i] = Math.Abs(Data.dc_v[i]);
                dr[3] = Data.dc_v[i];
                dt.Rows.Add(dr);
                for (int j = 0; j <= i; j++)
                {
                    x = x + Data.dc_v[j];

                }

                this.textBox2.Text = x.ToString();
            }
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = false;
            //groupBox1.Text = "TIN三角形点号";

            curBitmap = new Bitmap(wid, hig);
            for (int i = 0; i < K; i++)
            {
                Graphics myGraphics = Graphics.FromImage(curBitmap);    //创建Graphics对象
                myGraphics.DrawLine(new Pen(Color.Red, 1), new PointF((float)Value3[Tri[i].Peak[0], 2], (float)Value3[Tri[i].Peak[0], 1]), new PointF((float)Value3[Tri[i].Peak[1], 2], (float)Value3[Tri[i].Peak[1], 1]));
                myGraphics.DrawLine(new Pen(Color.Red, 1), new PointF((float)Value3[Tri[i].Peak[1], 2], (float)Value3[Tri[i].Peak[1], 1]), new PointF((float)Value3[Tri[i].Peak[2], 2], (float)Value3[Tri[i].Peak[2], 1]));
                myGraphics.DrawLine(new Pen(Color.Red, 1), new PointF((float)Value3[Tri[i].Peak[0], 2], (float)Value3[Tri[i].Peak[0], 1]), new PointF((float)Value3[Tri[i].Peak[2], 2], (float)Value3[Tri[i].Peak[2], 1]));
                myGraphics.Dispose();
                this.pictureBox1.Image = curBitmap;
            }
            Data.db_num1 = K;
            Data.db_num2 = o;
            Data.db_num3 = k;
            iscal = true;
            MessageBox.Show("计算完成！");
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                SolidBrush v_SolidBrush = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
                int v_LineNo = 0;
                v_LineNo = e.RowIndex + 1;
                string v_Line = v_LineNo.ToString();
                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);

            }
            catch (Exception ex)
            {
                MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    str_FilePath = open.FileName;
                    ReadReguXFile();

                    btn_ConTrace_Click(sender, e);
                }
            }
            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            if (trianglate != null)
            {
                if (conTrace != null && conTrace.list_ContourLine.Count > 0)
                {
                    //------- 等值线填充 -------   

                    //------- 等值线绘制 -------
                    if (isDrawConLine)
                    {
                        #region "Draw ConLine"
                        PointF p1 = new PointF(0, 0);
                        PointF p2 = new PointF(0, 0);
                        contour1.Cmou_Point conP1 = new suanfakuangjia.contour1.Cmou_Point();
                        contour1.Cmou_Point conP2 = new suanfakuangjia.contour1.Cmou_Point();
                        foreach (contour1.Cmou_ContourLine conLine in conTrace.list_ContourLine)
                        {
                            //Contour.Cmou_ContourLine conLine = conTrace.list_ContourLine[0];
                            if (conLine.conType == suanfakuangjia.contour1.ContourLineType.Opened)
                            {
                                for (int iP = 0; iP < conLine.list_Point.Count; iP++)
                                {
                                    if (iP == 0)
                                    {
                                        conP1 = conLine.list_Point[iP];
                                        p1.X = (float)conP1.X;
                                        p1.Y = (float)conP1.Y;
                                    }
                                    else
                                    {
                                        conP2 = conLine.list_Point[iP];
                                        p2.X = (float)conP2.X;
                                        p2.Y = (float)conP2.Y;
                                        g.DrawLine(Pens.Black, p1, p2);
                                        p1 = p2;
                                    }
                                }
                            }
                            else
                            {
                                for (int iP = 0; iP < conLine.list_Point.Count; iP++)
                                {
                                    if (iP == 0)
                                    {
                                        conP1 = conLine.list_Point[iP];
                                        p1.X = (float)conP1.X;
                                        p1.Y = (float)conP1.Y;
                                    }
                                    else
                                    {
                                        conP2 = conLine.list_Point[iP];
                                        p2.X = (float)conP2.X;
                                        p2.Y = (float)conP2.Y;
                                        g.DrawLine(Pens.Black, p1, p2);
                                        p1 = p2;
                                    }
                                }

                                conP1 = conLine.list_Point[0];
                                p1.X = (float)conP1.X;
                                p1.Y = (float)conP1.Y;
                                g.DrawLine(Pens.Black, p2, p1);
                            }
                        }
                        #endregion


                    }
                    //else
                    //{
                    //    #region "Draw Beziers"
                    //    //     Graphics F = this.CreateGraphics();
                    //    PointF p1 = new PointF(0, 0);
                    //    PointF p2 = new PointF(0, 0);
                    //    PointF p3 = new PointF(0, 0);
                    //    PointF p4 = new PointF(0, 0);
                    //    contour1.Cmou_Point conP1 = new suanfakuangjia.contour1.Cmou_Point();
                    //    contour1.Cmou_Point conP2 = new suanfakuangjia.contour1.Cmou_Point();
                    //    contour1.Cmou_Point conP3 = new suanfakuangjia.contour1.Cmou_Point();
                    //    contour1.Cmou_Point conP4 = new suanfakuangjia.contour1.Cmou_Point();
                    //    foreach (contour1.Cmou_ContourLine conLine in conTrace.list_ContourLine)
                    //    {
                    //        //Contour.Cmou_ContourLine conLine = conTrace.list_ContourLine[0];
                    //        if (conLine.conType == suanfakuangjia.contour1.ContourLineType.Opened)
                    //        {
                    //            for (int iP = 0; iP < conLine.list_Point.Count - 3; iP = iP + 3)
                    //            {

                    //                conP1 = conLine.list_Point[iP];
                    //                p1.X = (float)conP1.X;
                    //                p1.Y = (float)conP1.Y;

                    //                conP2 = conLine.list_Point[iP + 1];
                    //                conP3 = conLine.list_Point[iP + 2];
                    //                conP4 = conLine.list_Point[iP + 3];
                    //                p4.X = (float)conP4.X;
                    //                p4.Y = (float)conP4.Y;
                    //                p3.X = (float)conP3.X;
                    //                p3.Y = (float)conP3.Y;
                    //                p2.X = (float)conP2.X;
                    //                p2.Y = (float)conP2.Y;
                    //                //  g.DrawCurve(Pens.Black, new PointF[] { p1, p2, p3,p4 });

                    //                //g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { new Point(100, 10), new Point(200, 500), new Point(407, 30), new Point(760, 80) });

                    //                g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { p1, p2, p3, p4 });
                    //                //   F.Dispose();



                    //            }
                    //        }
                    //        else
                    //        {
                    //            for (int iP = 0; iP < conLine.list_Point.Count - 3; iP = iP + 3)
                    //            {
                    //                conP1 = conLine.list_Point[iP];
                    //                p1.X = (float)conP1.X;
                    //                p1.Y = (float)conP1.Y;

                    //                conP2 = conLine.list_Point[iP + 1];
                    //                conP3 = conLine.list_Point[iP + 2];
                    //                conP4 = conLine.list_Point[iP + 3];
                    //                p4.X = (float)conP4.X;
                    //                p4.Y = (float)conP4.Y;
                    //                p3.X = (float)conP3.X;
                    //                p3.Y = (float)conP3.Y;
                    //                p2.X = (float)conP2.X;
                    //                p2.Y = (float)conP2.Y;
                    //                // g.DrawCurve(Pens.Black, new PointF[] { p1, p2, p3,p4 });
                    //                //  g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { new Point(100, 10), new Point(200, 500), new Point(407, 30), new Point(760, 80) });
                    //                g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { p1, p2, p3, p4 });
                    //                //   F.Dispose();


                    //            }

                    //            conP1 = conLine.list_Point[0];
                    //            p1.X = (float)conP1.X;
                    //            p1.Y = (float)conP1.Y;

                    //            g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { p4, p3, p2, p1 });
                    //            //   F.Dispose();
                    //            // g.DrawCurve(Pens.Black, new PointF[] {p4, p3, p2, p1 });
                    //            //g.DrawLine(Pens.Black, p2, p1);
                    //        }
                    //    }
                    //    #endregion
                    //}
                    //等值线
                    conTrace.CTrace_MarkContourLine(g);
                }

                //三角形 
                if (isDrawTriangle)
                    trianglate.drawtriangle(g);

            }
        }

        private void 空间分布量测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zhixin zx111 = new zhixin();
            zx111.TopLevel = false;
            zx111.FormBorderStyle = FormBorderStyle.None;
            zx111.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(zx111);
            zx111.Show();
        }

        private void tIN相关算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////voronoi vrn11 = new voronoi();
            ////vrn11.TopLevel = false;
            ////vrn11.FormBorderStyle = FormBorderStyle.None;
            ////vrn11.Dock = DockStyle.Fill;
            ////this.Controls.Clear();
            ////this.Controls.Add(vrn11);
            ////vrn11.Show();
        }

        private void dEM相关算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            podu pd1 = new podu();
            //tiji.ShowDialog();
            //设置子窗口不显示为顶级窗口
            pd1.TopLevel = false;
            //设置子窗口的样式，没有上面的标题栏
            pd1.FormBorderStyle = FormBorderStyle.None;
            //填充
            pd1.Dock = DockStyle.Fill;

            this.Controls.Clear();
            ////加入控件
            this.Controls.Add(pd1);
            //让窗体显示
            pd1.Show();
        }

        private void 网络分析算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zxshchsh zxss11 = new zxshchsh();
            zxss11.TopLevel = false;
            zxss11.FormBorderStyle = FormBorderStyle.None;
            zxss11.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(zxss11);
            zxss11.Show();
        }

        private void 基本统计量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jibentongji tji1 = new jibentongji();
            tji1.TopLevel = false;
            tji1.FormBorderStyle = FormBorderStyle.None;
            tji1.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(tji1);
            tji1.Show();
        }

        private void 缓冲区分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            huanchong hch1 = new huanchong();
            hch1.TopLevel = false;
            hch1.FormBorderStyle = FormBorderStyle.None;
            hch1.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(hch1);
            hch1.Show();
        }
        private void ZheXian(Point p1, Point p2, Graphics g,int tt1)
        {

            g = pictureBox1.CreateGraphics();
            Point p3 = new Point(p1.X + (p2.X - p1.X) / 3, p1.Y + (p2.Y - p1.Y) / 3);    // 三等分点坐标
            Point p4 = new Point(p1.X + (p2.X - p1.X) * 2 / 3, p1.Y + (p2.Y - p1.Y) * 2 / 3);    // 三等分点坐标
            Point p4XD3 = new Point(p4.X - p3.X, p4.Y - p3.Y);    // p4相对于p3点的坐标

            int x = (int)Math.Round(p4XD3.X * Math.Cos(Math.PI / 3) + p4XD3.Y * Math.Sin(Math.PI / 3));
            int y = (int)Math.Round(p4XD3.Y * Math.Cos(Math.PI / 3) - p4XD3.X * Math.Sin(Math.PI / 3));
            Point p5XD3 = new Point(x, y);    // p5相对于p3点的坐标
            Point p5 = new Point(p3.X + x, p3.Y + y);    // p5相对于原点的坐标
            Pen pen = new Pen(Brushes.Black, 1);
            double length = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 3;

            if (Convert.ToInt32(tt1) == 4)//通过输入的迭代次数设置最终线段长度
            {
                len1 = 20;
            }
            if (Convert.ToInt32(tt1) == 5)
            {
                len1 = 10;
            }
            if (Convert.ToInt32(tt1) == 3)
            {
                len1 = 40;
            }
            if (Convert.ToInt32(tt1) == 2)
            {
                len1 = 120;
            }
            if (Convert.ToInt32(tt1) == 6)
            {
                len1 = 3;
            }
            if (length > len1) // 通过最终线段长度控制迭代
            {
                ZheXian(p1, p3, g,tt1);
                ZheXian(p3, p5, g,tt1);
                ZheXian(p5, p4, g,tt1);
                ZheXian(p4, p2, g,tt1);
            }
            else
            {
                g.DrawLine(pen, p1, p3);
                g.DrawLine(pen, p3, p5);
                g.DrawLine(pen, p5, p4);
                g.DrawLine(pen, p4, p2);
            }
        }
        private void 生成Koch曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tindv dv1 = new tindv();
            //dv1.ShowDialog();
            //int tt1 = dv1.value;
            //int length = 300;
            //Point origin = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);//设置中心点坐标
            //Point A = new Point(origin.X - length / 2, (int)(origin.Y + length / (2 * Math.Sqrt(3))));
            //Point B = new Point(origin.X, (int)(origin.Y - length / Math.Sqrt(3)));
            //Point C = new Point(origin.X + length / 2, (int)(origin.Y + length / (2 * Math.Sqrt(3))));
            //ZheXian(A, B, g,tt1);
            //ZheXian(B, C, g,tt1);
            //ZheXian(C, A, g,tt1);
            tindv dv1 = new tindv();
            dv1.ShowDialog();

            siteCount = (int)dv1.value;
            g.Clear(Color.White);
            List<DelaunayTriangle> allTriangle = new List<DelaunayTriangle>();//delaunay三角形集合
            List<PointF> sites = new List<PointF>();
            List<Site> sitesP = new List<Site>();
            int seed = seeder.Next();
            Random rand = new Random(seed);
            List<Edge> trianglesEdgeList = new List<Edge>();//Delaunay三角形网所有边
            List<Edge> voronoiEdgeList = new List<Edge>();//vironoi图所有边
            List<Edge> voronoiRayEdgeList = new List<Edge>();//voroni图外围射线边

            //初始设定点数为20
            //初始设定画布大小是500*400
            //超级三角形顶点坐标为（250,0），（0,400），（500,400）
            //点集区域为（125,200），（125,400），（375,200），（375,400），随便设置，只要满足点落在三角形区域中
            for (int i = 0; i < siteCount; i++)
            {

                PointF pf = new PointF((float)(rand.NextDouble() * 500), (float)(rand.NextDouble() * 400));
                //PointF pf=new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200));
                Site site = new Site(pf.X, pf.Y);
                sitesP.Add(site);
                //sitesP.Add(new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200)));
            }

            //按点集坐标X值排序
            sitesP.Sort(new SiteSorterXY());
            for (int i = 0; i < sitesP.Count; i++)
            {
                //listBox1.Items.Add(sitesP[i].x);
            }

            //将超级三角形的三点添加到三角形网中
            Site A = new Site(250, -5000);
            Site B = new Site(-5000, 400);
            Site C = new Site(5000, 400);
            DelaunayTriangle dt = new DelaunayTriangle(A, B, C);
            allTriangle.Add(dt);

            //构造Delaunay三角形网
            voroObject.setDelaunayTriangle(allTriangle, sitesP);


            //voroObject.remmoveTrianglesByOnePoint(allTriangle,A);
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,B);
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,C);

            //返回Delaunay三角形网所有边
            trianglesEdgeList = voroObject.returnEdgesofTriangleList(allTriangle);

            //获取所有Voronoi边
            voronoiEdgeList = voroObject.returnVoronoiEdgesFromDelaunayTriangles(allTriangle, voronoiRayEdgeList);

            //画点(填充圆)
            for (int i = 0; i < sitesP.Count; i++)
            {
                g.FillEllipse(Brushes.Blue, (float)(sitesP[i].x - 1.5f), (float)(sitesP[i].y - 1.5f), 3, 3);
            }

            //显示Delaunay三角形网
            //if (checkBox1.Checked == true)
            //{
            for (int i = 0; i < voronoiEdgeList.Count; i++)
            {
                CSPoint p1 = new CSPoint((int)trianglesEdgeList[i].a.x, (int)trianglesEdgeList[i].a.y);
                CSPoint p2 = new CSPoint((int)trianglesEdgeList[i].b.x, (int)trianglesEdgeList[i].b.y);
                g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            }
            //}

            //根据维诺图的边画线段
            //if (checkBox2.Checked == true)
            //{
            //    for (int i = 0; i < voronoiEdgeList.Count; i++)
            //    {
            //        CSPoint p1 = new CSPoint((int)voronoiEdgeList[i].a.x, (int)voronoiEdgeList[i].a.y);
            //        CSPoint p2 = new CSPoint((int)voronoiEdgeList[i].b.x, (int)voronoiEdgeList[i].b.y);
            //        g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //    }
            //}

            //根据Voronoi的射线边画线
            //for (int i = 0; i < voronoiRayEdgeList.Count; i++)
            //{
            //    CSPoint p1 = new CSPoint((int)voronoiRayEdgeList[i].a.x, (int)voronoiRayEdgeList[i].a.y);
            //    CSPoint p2 = new CSPoint((int)voronoiRayEdgeList[i].b.x, (int)voronoiRayEdgeList[i].b.y);
            //    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //}

            //更新pictureBox背景图片
            pictureBox1.Image = backImage;
        }


        private void ReadReguXFile()
        {
            System.IO.StreamReader sr_ScatterData = new System.IO.StreamReader(str_FilePath);
            sr_ScatterData.ReadLine();
            string temp_str = sr_ScatterData.ReadLine();
            temp_str.TrimStart();
            temp_str.TrimEnd();
            string[] tempData_str = temp_str.Split(' ').ToArray();
            int iNum_Point = int.Parse(tempData_str[1]);
            //iNum_Point++;
            double[] dData_X = new double[iNum_Point];
            double[] dData_Y = new double[iNum_Point];
            double[] dData_Z = new double[iNum_Point];
            PointF[] ps = new PointF[iNum_Point];
            int iCount = 3;

            int i = 0;
            while (!sr_ScatterData.EndOfStream)
            {
                if (iCount == 3)
                {
                    temp_str = sr_ScatterData.ReadLine();
                    temp_str.TrimStart();
                    temp_str.TrimEnd();
                    tempData_str = temp_str.Split(' ').ToArray();
                    dData_X[i] = double.Parse(tempData_str[1]);
                    dData_Y[i] = double.Parse(tempData_str[2]);
                    dData_Z[i] = double.Parse(tempData_str[3]);
                    if (dMax_X < dData_X[i]) dMax_X = dData_X[i];
                    if (dMin_X > dData_X[i]) dMin_X = dData_X[i];
                    if (dMax_Y < dData_Y[i]) dMax_Y = dData_Y[i];
                    if (dMin_Y > dData_Y[i]) dMin_Y = dData_Y[i];
                    if (dMax_Z < dData_Z[i]) dMax_Z = dData_Z[i];
                    if (dMin_Z > dData_Z[i]) dMin_Z = dData_Z[i];
                    i++;
                    iCount = 0;
                }
                else
                {
                    sr_ScatterData.ReadLine();
                    iCount++;
                }
            }
            sr_ScatterData.Close();

            double dSx = (dMax_X - dMin_X) / (pictureBox1.Width - 3);
            double dSy = (dMax_Y - dMin_Y) / (pictureBox1.Height - 3);
            for (i = 0; i < iNum_Point; i++)
            {
                dData_X[i] = Convert.ToSingle((dData_X[i] - dMin_X) / dSx);
                dData_Y[i] = Convert.ToSingle((dData_Y[i] - dMin_Y) / dSy);
                //ps[i].X = (float)dData_X[i];
                //ps[i].Y = (float)dData_Y[i];
            }

            if (iNum_Point > 3)
            {
                trianglate = new C_Trianglate(dData_X, dData_Y, dData_Z);
                int iNum_Tri = trianglate.Triangulate();
                //trianglate2 = new C_Trianglate2(ps);
                //trianglate2.GeneTIN(pictureBox1.CreateGraphics());
                pictureBox1.Invalidate();
            }
        }
        private void btn_ConTrace_Click(object sender, EventArgs e)
        {
            conTrace = new C_ContourTrace(trianglate);
            conTrace.d_Max = dMax_Z;
            conTrace.d_Min = dMin_Z;
            conTrace.CTrace_ContourLineTrace();
            pictureBox1.Invalidate();
        }
        private void voronoi_Resize(object sender, EventArgs e)
        {
            if (str_FilePath != null)
            {
                ReadReguXFile();
                btn_ConTrace_Click(sender, e);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //pictureBox1.Invalidate();
            g = pictureBox1.CreateGraphics();
            if (trianglate != null)
            {
                if (conTrace != null && conTrace.list_ContourLine.Count > 0)
                {
                    //------- 等值线填充 -------   

                    //------- 等值线绘制 -------
                    //if (isDrawConLine)
                    //{
                    //    #region "Draw ConLine"
                    //    PointF p1 = new PointF(0, 0);
                    //    PointF p2 = new PointF(0, 0);
                    //    contour1.Cmou_Point conP1 = new suanfakuangjia.contour1.Cmou_Point();
                    //    contour1.Cmou_Point conP2 = new suanfakuangjia.contour1.Cmou_Point();
                    //    foreach (contour1.Cmou_ContourLine conLine in conTrace.list_ContourLine)
                    //    {
                    //        //Contour.Cmou_ContourLine conLine = conTrace.list_ContourLine[0];
                    //        if (conLine.conType == suanfakuangjia.contour1.ContourLineType.Opened)
                    //        {
                    //            for (int iP = 0; iP < conLine.list_Point.Count; iP++)
                    //            {
                    //                if (iP == 0)
                    //                {
                    //                    conP1 = conLine.list_Point[iP];
                    //                    p1.X = (float)conP1.X;
                    //                    p1.Y = (float)conP1.Y;
                    //                }
                    //                else
                    //                {
                    //                    conP2 = conLine.list_Point[iP];
                    //                    p2.X = (float)conP2.X;
                    //                    p2.Y = (float)conP2.Y;
                    //                    g.DrawLine(Pens.Black, p1, p2);
                    //                    p1 = p2;
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            for (int iP = 0; iP < conLine.list_Point.Count; iP++)
                    //            {
                    //                if (iP == 0)
                    //                {
                    //                    conP1 = conLine.list_Point[iP];
                    //                    p1.X = (float)conP1.X;
                    //                    p1.Y = (float)conP1.Y;
                    //                }
                    //                else
                    //                {
                    //                    conP2 = conLine.list_Point[iP];
                    //                    p2.X = (float)conP2.X;
                    //                    p2.Y = (float)conP2.Y;
                    //                    g.DrawLine(Pens.Black, p1, p2);
                    //                    p1 = p2;
                    //                }
                    //            }

                    //            conP1 = conLine.list_Point[0];
                    //            p1.X = (float)conP1.X;
                    //            p1.Y = (float)conP1.Y;
                    //            g.DrawLine(Pens.Black, p2, p1);
                    //        }
                    //    }
                    //    #endregion


                    //}
                    //else
                    //{
                        #region "Draw Beziers"
                        //     Graphics F = this.CreateGraphics();
                        PointF p1 = new PointF(0, 0);
                        PointF p2 = new PointF(0, 0);
                        PointF p3 = new PointF(0, 0);
                        PointF p4 = new PointF(0, 0);
                        contour1.Cmou_Point conP1 = new suanfakuangjia.contour1.Cmou_Point();
                        contour1.Cmou_Point conP2 = new suanfakuangjia.contour1.Cmou_Point();
                        contour1.Cmou_Point conP3 = new suanfakuangjia.contour1.Cmou_Point();
                        contour1.Cmou_Point conP4 = new suanfakuangjia.contour1.Cmou_Point();
                        foreach (contour1.Cmou_ContourLine conLine in conTrace.list_ContourLine)
                        {
                            //Contour.Cmou_ContourLine conLine = conTrace.list_ContourLine[0];
                            if (conLine.conType == suanfakuangjia.contour1.ContourLineType.Opened)
                            {
                                for (int iP = 0; iP < conLine.list_Point.Count - 3; iP = iP + 3)
                                {

                                    conP1 = conLine.list_Point[iP];
                                    p1.X = (float)conP1.X;
                                    p1.Y = (float)conP1.Y;

                                    conP2 = conLine.list_Point[iP + 1];
                                    conP3 = conLine.list_Point[iP + 2];
                                    conP4 = conLine.list_Point[iP + 3];
                                    p4.X = (float)conP4.X;
                                    p4.Y = (float)conP4.Y;
                                    p3.X = (float)conP3.X;
                                    p3.Y = (float)conP3.Y;
                                    p2.X = (float)conP2.X;
                                    p2.Y = (float)conP2.Y;
                                    //  g.DrawCurve(Pens.Black, new PointF[] { p1, p2, p3,p4 });

                                    //g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { new Point(100, 10), new Point(200, 500), new Point(407, 30), new Point(760, 80) });

                                    g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { p1, p2, p3, p4 });
                                    //   F.Dispose();



                                }
                            }
                            else
                            {
                                for (int iP = 0; iP < conLine.list_Point.Count - 3; iP = iP + 3)
                                {
                                    conP1 = conLine.list_Point[iP];
                                    p1.X = (float)conP1.X;
                                    p1.Y = (float)conP1.Y;

                                    conP2 = conLine.list_Point[iP + 1];
                                    conP3 = conLine.list_Point[iP + 2];
                                    conP4 = conLine.list_Point[iP + 3];
                                    p4.X = (float)conP4.X;
                                    p4.Y = (float)conP4.Y;
                                    p3.X = (float)conP3.X;
                                    p3.Y = (float)conP3.Y;
                                    p2.X = (float)conP2.X;
                                    p2.Y = (float)conP2.Y;
                                    // g.DrawCurve(Pens.Black, new PointF[] { p1, p2, p3,p4 });
                                    //  g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { new Point(100, 10), new Point(200, 500), new Point(407, 30), new Point(760, 80) });
                                    g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { p1, p2, p3, p4 });
                                    //   F.Dispose();


                                }

                                conP1 = conLine.list_Point[0];
                                p1.X = (float)conP1.X;
                                p1.Y = (float)conP1.Y;

                                g.DrawBeziers(new Pen(new SolidBrush(Color.Red)), new PointF[] { p4, p3, p2, p1 });
                                //   F.Dispose();
                                // g.DrawCurve(Pens.Black, new PointF[] {p4, p3, p2, p1 });
                                //g.DrawLine(Pens.Black, p2, p1);
                            }
                        }
                        #endregion
                    //}
                    //等值线
                    conTrace.CTrace_MarkContourLine(g);
                }

                //三角形 
                if (isDrawTriangle)
                    trianglate.drawtriangle(g);

            }

            //isDrawConLine = false;

            //if (isDrawConLine)
            //{
            //    isDrawConLine = false;
            //}
            //else
            //{
            //    isDrawConLine = true;
            //}
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    str_FilePath = open.FileName;
                    ReadReguXFile();

                    btn_ConTrace_Click(sender, e);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "文本文件(*.txt)|*.txt";
            openDlg.Title = "选择已知点文件";
            openDlg.ShowHelp = true;
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    curFileName = openDlg.FileName;
                    StreamReader myStreamReader = new StreamReader(curFileName, true);
                    TempStr1 = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    string[] a = new string[] { ",", "\n", "\r" };
                    TempStr2 = TempStr1.Split(a, StringSplitOptions.RemoveEmptyEntries);
                    Value1 = new double[TempStr2.Length / 3, 4];
                    Data.db_Value1 = new double[TempStr2.Length / 3, 4];
                    Value3 = new double[TempStr2.Length / 3, 3];
                    int j = 0;
                    double max1 = 0, max2 = 0, min1 = 0, min2 = 0;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("X", typeof(String));
                    dt.Columns.Add("Y", typeof(String));
                    dt.Columns.Add("Z", typeof(String));
                    this.dataGridView1.DataSource = dt;                 //将datatable绑定到datagridview上显示结果  
                    for (int i = 0; i < TempStr2.Length;)
                    {
                        if (i == 0)
                        {
                            textBox1.Text = TempStr2[i];
                            i = i + 1;
                        }
                        else
                        {
                            Value1[j, 0] = j + 1;
                            Value1[j, 1] = double.Parse(TempStr2[i]);
                            Value1[j, 2] = double.Parse(TempStr2[i + 1]);
                            Value1[j, 3] = double.Parse(TempStr2[i + 2]);
                            Data.db_Value1[j, 0] = j + 1;
                            Data.db_Value1[j, 1] = double.Parse(TempStr2[i]);
                            Data.db_Value1[j, 2] = double.Parse(TempStr2[i + 1]);
                            Data.db_Value1[j, 3] = double.Parse(TempStr2[i + 2]);
                            if (j == 0)
                            {
                                max1 = Value1[j, 1];
                                min1 = Value1[j, 1];
                                max2 = Value1[j, 2];
                                min2 = Value1[j, 2];
                            }
                            else
                            {
                                if (max1 < Value1[j, 1])
                                    max1 = Value1[j, 1];
                                if (max2 < Value1[j, 2])
                                    max2 = Value1[j, 2];
                                if (min1 > Value1[j, 1])
                                    min1 = Value1[j, 1];
                                if (min2 > Value1[j, 2])
                                    min2 = Value1[j, 2];
                            }


                            DataRow dr = dt.NewRow();

                            dr[0] = Value1[j, 1];
                            dr[1] = Value1[j, 2];
                            dr[2] = Value1[j, 3];
                            dt.Rows.Add(dr);
                            j++;
                            i = i + 3;
                        }
                    }
                    j = 0;
                    for (int i = 1; i < TempStr2.Length; i = i + 3)
                    {
                        Value3[j, 0] = j + 1;
                        Value3[j, 1] = 10 * (double.Parse(TempStr2[i]) - min1 + 5);
                        Value3[j, 2] = 10 * (double.Parse(TempStr2[i + 1]) - min2 + 5);
                        j++;
                    }
                    wid = (int)(10 * (max2 - min2 + 10));
                    hig = (int)(10 * (max1 - min1 + 10));
                    dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.AllowUserToAddRows = false;
                    //groupBox1.Text = "地形特征点坐标";
                    isopen = true;
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                MessageBox.Show("打开失败！");
                isopen = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            //allTriangle.Clear();
            //sites.Clear();
            //sitesP.Clear();



            seeder = new Random();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            //初始化pictureBox背景图
            backImage = new Bitmap(510, 410);
            g = Graphics.FromImage(backImage);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);

            //将背景图填充到pictureBox中
            pictureBox1.Image = backImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            siteCount = (int)numericUpDown1.Value;
            //spreadPoints();
            //for (int i = 0; i < voronoiEdgeList.Count; i++)
            //{
            //    CSPoint p1 = new CSPoint((int)trianglesEdgeList[i].a.x, (int)trianglesEdgeList[i].a.y);
            //    CSPoint p2 = new CSPoint((int)trianglesEdgeList[i].b.x, (int)trianglesEdgeList[i].b.y);
            //    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //}
            //pictureBox1.Image = backImage;

            g.Clear(Color.White);
            List<DelaunayTriangle> allTriangle = new List<DelaunayTriangle>();//delaunay三角形集合
            List<PointF> sites = new List<PointF>();
            List<Site> sitesP = new List<Site>();
            int seed = seeder.Next();
            Random rand = new Random(seed);
            List<Edge> trianglesEdgeList = new List<Edge>();//Delaunay三角形网所有边
            List<Edge> voronoiEdgeList = new List<Edge>();//vironoi图所有边
            List<Edge> voronoiRayEdgeList = new List<Edge>();//voroni图外围射线边

            //初始设定点数为20
            //初始设定画布大小是500*400
            //超级三角形顶点坐标为（250,0），（0,400），（500,400）
            //点集区域为（125,200），（125,400），（375,200），（375,400），随便设置，只要满足点落在三角形区域中
            for (int i = 0; i < siteCount; i++)
            {

                PointF pf = new PointF((float)(rand.NextDouble() * 500), (float)(rand.NextDouble() * 400));
                //PointF pf=new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200));
                Site site = new Site(pf.X, pf.Y);
                sitesP.Add(site);
                //sitesP.Add(new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200)));
            }

            //按点集坐标X值排序
            sitesP.Sort(new SiteSorterXY());
            for (int i = 0; i < sitesP.Count; i++)
            {
                //listBox1.Items.Add(sitesP[i].x);
            }

            //将超级三角形的三点添加到三角形网中
            Site A = new Site(250, -5000);
            Site B = new Site(-5000, 400);
            Site C = new Site(5000, 400);
            DelaunayTriangle dt = new DelaunayTriangle(A, B, C);
            allTriangle.Add(dt);

            //构造Delaunay三角形网
            voroObject.setDelaunayTriangle(allTriangle, sitesP);

            
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,A);
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,B);
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,C);

            //返回Delaunay三角形网所有边
            trianglesEdgeList = voroObject.returnEdgesofTriangleList(allTriangle);

            //获取所有Voronoi边
            voronoiEdgeList = voroObject.returnVoronoiEdgesFromDelaunayTriangles(allTriangle, voronoiRayEdgeList);

            //画点(填充圆)
            for (int i = 0; i < sitesP.Count; i++)
            {
                g.FillEllipse(Brushes.Blue, (float)(sitesP[i].x - 1.5f), (float)(sitesP[i].y - 1.5f), 3, 3);
            }

            //显示Delaunay三角形网
            //if (checkBox1.Checked == true)
            //{
            //    for (int i = 0; i < voronoiEdgeList.Count; i++)
            //    {
            //        CSPoint p1 = new CSPoint((int)trianglesEdgeList[i].a.x, (int)trianglesEdgeList[i].a.y);
            //        CSPoint p2 = new CSPoint((int)trianglesEdgeList[i].b.x, (int)trianglesEdgeList[i].b.y);
            //        g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //    }
            //}

            //根据维诺图的边画线段
            //if (checkBox2.Checked == true)
            //{
                for (int i = 0; i < voronoiEdgeList.Count; i++)
                {
                    CSPoint p1 = new CSPoint((int)voronoiEdgeList[i].a.x, (int)voronoiEdgeList[i].a.y);
                    CSPoint p2 = new CSPoint((int)voronoiEdgeList[i].b.x, (int)voronoiEdgeList[i].b.y);
                    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
                }
            //}

            //根据Voronoi的射线边画线
            //for (int i = 0; i < voronoiRayEdgeList.Count; i++)
            //{
            //    CSPoint p1 = new CSPoint((int)voronoiRayEdgeList[i].a.x, (int)voronoiRayEdgeList[i].a.y);
            //    CSPoint p2 = new CSPoint((int)voronoiRayEdgeList[i].b.x, (int)voronoiRayEdgeList[i].b.y);
            //    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //}

            //更新pictureBox背景图片
            pictureBox1.Image = backImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            siteCount = (int)numericUpDown1.Value;
            g.Clear(Color.White);
            List<DelaunayTriangle> allTriangle = new List<DelaunayTriangle>();//delaunay三角形集合
            List<PointF> sites = new List<PointF>();
            List<Site> sitesP = new List<Site>();
            int seed = seeder.Next();
            Random rand = new Random(seed);
            List<Edge> trianglesEdgeList = new List<Edge>();//Delaunay三角形网所有边
            List<Edge> voronoiEdgeList = new List<Edge>();//vironoi图所有边
            List<Edge> voronoiRayEdgeList = new List<Edge>();//voroni图外围射线边

            //初始设定点数为20
            //初始设定画布大小是500*400
            //超级三角形顶点坐标为（250,0），（0,400），（500,400）
            //点集区域为（125,200），（125,400），（375,200），（375,400），随便设置，只要满足点落在三角形区域中
            for (int i = 0; i < siteCount; i++)
            {

                PointF pf = new PointF((float)(rand.NextDouble() * 500), (float)(rand.NextDouble() * 400));
                //PointF pf=new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200));
                Site site = new Site(pf.X, pf.Y);
                sitesP.Add(site);
                //sitesP.Add(new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200)));
            }

            //按点集坐标X值排序
            sitesP.Sort(new SiteSorterXY());
            for (int i = 0; i < sitesP.Count; i++)
            {
                //listBox1.Items.Add(sitesP[i].x);
            }

            //将超级三角形的三点添加到三角形网中
            Site A = new Site(250, -5000);
            Site B = new Site(-5000, 400);
            Site C = new Site(5000, 400);
            DelaunayTriangle dt = new DelaunayTriangle(A, B, C);
            allTriangle.Add(dt);

            //构造Delaunay三角形网
            voroObject.setDelaunayTriangle(allTriangle, sitesP);

            
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,A);
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,B);
            //voroObject.remmoveTrianglesByOnePoint(allTriangle,C);

            //返回Delaunay三角形网所有边
            trianglesEdgeList = voroObject.returnEdgesofTriangleList(allTriangle);

            //获取所有Voronoi边
            voronoiEdgeList = voroObject.returnVoronoiEdgesFromDelaunayTriangles(allTriangle, voronoiRayEdgeList);

            //画点(填充圆)
            for (int i = 0; i < sitesP.Count; i++)
            {
                g.FillEllipse(Brushes.Blue, (float)(sitesP[i].x - 1.5f), (float)(sitesP[i].y - 1.5f), 3, 3);
            }

            //显示Delaunay三角形网
            //if (checkBox1.Checked == true)
            //{
                for (int i = 0; i < voronoiEdgeList.Count; i++)
                {
                    CSPoint p1 = new CSPoint((int)trianglesEdgeList[i].a.x, (int)trianglesEdgeList[i].a.y);
                    CSPoint p2 = new CSPoint((int)trianglesEdgeList[i].b.x, (int)trianglesEdgeList[i].b.y);
                    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
                }
            //}

            //根据维诺图的边画线段
            //if (checkBox2.Checked == true)
            //{
            //    for (int i = 0; i < voronoiEdgeList.Count; i++)
            //    {
            //        CSPoint p1 = new CSPoint((int)voronoiEdgeList[i].a.x, (int)voronoiEdgeList[i].a.y);
            //        CSPoint p2 = new CSPoint((int)voronoiEdgeList[i].b.x, (int)voronoiEdgeList[i].b.y);
            //        g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //    }
            //}

            //根据Voronoi的射线边画线
            //for (int i = 0; i < voronoiRayEdgeList.Count; i++)
            //{
            //    CSPoint p1 = new CSPoint((int)voronoiRayEdgeList[i].a.x, (int)voronoiRayEdgeList[i].a.y);
            //    CSPoint p2 = new CSPoint((int)voronoiRayEdgeList[i].b.x, (int)voronoiRayEdgeList[i].b.y);
            //    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //}

            //更新pictureBox背景图片
            pictureBox1.Image = backImage;
        }
    }



    //class datatype
    //{
    //    // 点(Vertices)
    //    public struct dVertex
    //    {
    //        public long x;
    //        public long y;
    //        public int SUM;//判断点的比较次数
    //    }

    //    // 三角形, vv#代表点
    //    public struct dTriangle
    //    {
    //        public long vv0;
    //        public long vv1;
    //        public long vv2;
    //    }

    //    // 三角形外心结构
    //    public struct BaryCenter
    //    {
    //        public double a;
    //        public double b;
    //        public Boolean ID; //判断外心是否连接
    //        public int NUM;//外心累计连接次数
    //    }

    //    //Set these as applicable
    //    public static long MaxVertices = 300;
    //    public static long MaxTriangles = 900;
    //    //Our points
    //    public dVertex[] Vertex = new dVertex[MaxVertices];
    //    //Our Created Triangles
    //    public dTriangle[] Triangle = new dTriangle[MaxTriangles];
    //    public BaryCenter[] OutHert = new BaryCenter[MaxTriangles];
    //}
    //class barycenter
    //{
    //    // 计算外接圆圆心
    //    public void CalculateBC(int Num, datatype dt)
    //    {
    //        double x1; double y1; double x2; double y2;
    //        double x3; double y3; double k1;
    //        double k2;
    //        for (int i = 1; i <= Num; i++)
    //        {
    //            //计算三角形外接圆
    //            x1 = dt.Vertex[dt.Triangle[i].vv0].x;
    //            y1 = dt.Vertex[dt.Triangle[i].vv0].y;
    //            x2 = dt.Vertex[dt.Triangle[i].vv1].x;
    //            y2 = dt.Vertex[dt.Triangle[i].vv1].y;
    //            x3 = dt.Vertex[dt.Triangle[i].vv2].x;
    //            y3 = dt.Vertex[dt.Triangle[i].vv2].y;
    //            k1 = (y2 - y1) / (x2 - x1);
    //            k2 = (y3 - y1) / (x3 - x1);
    //            dt.OutHert[i].a = (((x1 + x3) / 2) * (1 / k2) - ((x1 + x2) / 2) * (1 / k1) + (y1 + y3) / 2 - (y2 + y1) / 2) / ((1 / k2) - (1 / k1));
    //            dt.OutHert[i].b = (y2 + y1) / 2 - (1 / k1) * (dt.OutHert[i].a - (x1 + x2) / 2);
    //            dt.OutHert[i].ID = false;
    //        }
    //    }
    //}
    //class function : tinzhudian
    //{
    //    public static long MaxVertices = 500;
    //    public static long MaxTriangles = 1000;

    //    // 三角划分
    //    public int Triangulate(int nvert, datatype dt)
    //    {
    //        //输入NVERT vertices in arrays Vertex()
    //        //'Returned is a list of NTRI triangular faces in the array
    //        //'Triangle(). These triangles are arranged in clockwise order.
    //        Boolean[] Complete = new Boolean[MaxVertices];
    //        long[,] Edges = new long[3, MaxTriangles * 3];
    //        long Nedge;
    //        //超级三角形
    //        long xmin, xmax, ymin, ymax;
    //        long xmid, ymid, dx, dy, dmax;
    //        //普通变量
    //        int i, j, k, ntri;
    //        double xc, yc, r;
    //        Boolean inc;
    //        //Find the maximum and minimum vertex bounds.
    //        //This is to allow calculation of the bounding triangle
    //        xmin = dt.Vertex[1].x; ymin = dt.Vertex[1].y;
    //        xmax = xmin; ymax = ymin;
    //        for (i = 2; i <= nvert; i++)
    //        {
    //            if (dt.Vertex[i].x < xmin)
    //                xmin = dt.Vertex[i].x;
    //            if (dt.Vertex[i].x > xmax)
    //                xmax = dt.Vertex[i].x;
    //            if (dt.Vertex[i].y < ymin)
    //                ymin = dt.Vertex[i].y;
    //            if (dt.Vertex[i].x > ymax)
    //                ymax = dt.Vertex[i].y;
    //        }
    //        dx = xmax - xmin; dy = ymax - ymin;
    //        if (dx > dy)
    //            dmax = dx;
    //        else
    //            dmax = dy;
    //        xmid = (xmax + xmin) / 2;
    //        ymid = (ymax + ymin) / 2;
    //        // 构建超级三角形
    //        //'This is a triangle which encompasses all the sample points.
    //        //'The supertriangle coordinates are added to the end of the
    //        //'vertex list. The supertriangle is the first triangle in
    //        //'the triangle list.
    //        dt.Vertex[nvert + 1].x = Convert.ToInt64(xmid - 2 * dmax);
    //        dt.Vertex[nvert + 1].y = Convert.ToInt64(ymid - dmax);
    //        dt.Vertex[nvert + 2].x = xmid;
    //        dt.Vertex[nvert + 2].y = Convert.ToInt64(ymid + 2 * dmax);
    //        dt.Vertex[nvert + 3].x = Convert.ToInt64(xmid + 2 * dmax);
    //        dt.Vertex[nvert + 3].y = Convert.ToInt64(ymid - dmax);
    //        dt.Triangle[1].vv0 = nvert + 1;
    //        dt.Triangle[1].vv1 = nvert + 2;
    //        dt.Triangle[1].vv2 = nvert + 3;
    //        Complete[1] = false;
    //        ntri = 1; xc = 0; yc = 0; r = 0;
    //        //Include each point one at a time into the existing mesh
    //        for (i = 1; i <= nvert; i++)
    //        {
    //            Nedge = 0;
    //            //Set up the edge buffer.
    //            // If the point (Vertex(i).x,Vertex(i).y) lies inside the circumcircle then the
    //            // 'three edges of that triangle are added to the edge buffer.
    //            j = 0;
    //            do
    //            {
    //                j = j + 1;
    //                if (Complete[j] != true)
    //                {
    //                    inc = InCircle(dt.Vertex[i].x, dt.Vertex[i].y, dt.Vertex[dt.Triangle[j].vv0].x, dt.Vertex[dt.Triangle[j].vv0].y, dt.Vertex[dt.Triangle[j].vv1].x, dt.Vertex[dt.Triangle[j].vv1].y, dt.Vertex[dt.Triangle[j].vv2].x, dt.Vertex[dt.Triangle[j].vv2].y, ref xc, ref yc, ref r);
    //                    if (inc)
    //                    {
    //                        Edges[1, Nedge + 1] = dt.Triangle[j].vv0;
    //                        Edges[2, Nedge + 1] = dt.Triangle[j].vv1;
    //                        Edges[1, Nedge + 2] = dt.Triangle[j].vv1;
    //                        Edges[2, Nedge + 2] = dt.Triangle[j].vv2;
    //                        Edges[1, Nedge + 3] = dt.Triangle[j].vv2;
    //                        Edges[2, Nedge + 3] = dt.Triangle[j].vv0;
    //                        Nedge = Nedge + 3;
    //                        dt.Triangle[j].vv0 = dt.Triangle[ntri].vv0;
    //                        dt.Triangle[j].vv1 = dt.Triangle[ntri].vv1;
    //                        dt.Triangle[j].vv2 = dt.Triangle[ntri].vv2;
    //                        Complete[j] = Complete[ntri];
    //                        j = j - 1;
    //                        ntri = ntri - 1;
    //                    }
    //                }
    //            }
    //            while (j < ntri);
    //            for (j = 1; j <= (Nedge - 1); j++)
    //            {
    //                if (!(Edges[1, j] == 0) && !(Edges[2, j] == 0))
    //                {
    //                    for (k = j + 1; k <= Nedge; k++)
    //                    {
    //                        if (!((Edges[1, k] == 0)) && !((Edges[2, k] == 0)))
    //                        {
    //                            if ((Edges[1, j] == Edges[2, k]))
    //                            {
    //                                if (Edges[2, j] == Edges[1, k])
    //                                {
    //                                    Edges[1, j] = 0;
    //                                    Edges[2, j] = 0;
    //                                    Edges[1, k] = 0;
    //                                    Edges[2, k] = 0;
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //            //Form new triangles for the current point
    //            for (j = 1; j <= Nedge; j++)
    //            {
    //                if (!(Edges[1, j] == 0) && !(Edges[2, j] == 0))
    //                {
    //                    ntri = ntri + 1;
    //                    dt.Triangle[ntri].vv0 = Edges[1, j];
    //                    dt.Triangle[ntri].vv1 = Edges[2, j];
    //                    dt.Triangle[ntri].vv2 = i;
    //                    Complete[ntri] = false;
    //                }
    //            }
    //        }
    //        //Remove triangles with supertriangle vertices
    //        i = 0;
    //        do
    //        {
    //            i = i + 1;
    //            if (dt.Triangle[i].vv0 > nvert || dt.Triangle[i].vv1 > nvert || dt.Triangle[i].vv2 > nvert)
    //            {
    //                dt.Triangle[i].vv0 = dt.Triangle[ntri].vv0;
    //                dt.Triangle[i].vv1 = dt.Triangle[ntri].vv1;
    //                dt.Triangle[i].vv2 = dt.Triangle[ntri].vv2;
    //                i = i - 1;
    //                ntri = ntri - 1;
    //            }
    //        }
    //        while (i < ntri);
    //        return ntri;
    //    }

    //    private Boolean InCircle(double xp, double yp, double x1, double y1, double x2, double y2, double x3, double y3, ref double xc, ref double yc, ref double r)
    //    {
    //        //'Return TRUE if the point (xp,yp) lies inside the circumcircle
    //        //made up by points (x1,y1) (x2,y2) (x3,y3)
    //        //'The circumcircle centre is returned in (xc,yc) and the radius r
    //        //'NOTE: A point on the edge is inside the circumcircle
    //        double eps, m1, m2, mx1, mx2, my1, my2, dx, dy, rsqr, drsqr;
    //        eps = 0.000001;
    //        if (System.Math.Abs(y1 - y2) < eps && System.Math.Abs(y2 - y3) < eps)
    //            MessageBox.Show("there is some problems;");
    //        if (System.Math.Abs(y2 - y1) < eps)
    //        {
    //            m2 = -(x3 - x2) / (y3 - y2);
    //            mx2 = (x2 + x3) / 2;
    //            my2 = (y2 + y3) / 2;
    //            xc = (x2 + x1) / 2;
    //            yc = m2 * (xc - mx2) + my2;
    //        }
    //        else if (System.Math.Abs(y3 - y2) < eps)
    //        {
    //            m1 = -(x2 - x1) / (y2 - y1);
    //            mx1 = (x1 + x2) / 2;
    //            my1 = (y1 + y2) / 2;
    //            xc = (x3 + x2) / 2;
    //            yc = m1 * (xc - mx1) + my1;
    //        }
    //        else
    //        {
    //            m1 = Convert.ToDouble(((x2 - x1) / (y2 - y1)) - 2 * ((x2 - x1) / (y2 - y1)));
    //            m2 = Convert.ToDouble(((x3 - x2) / (y3 - y2)) - 2 * ((x3 - x2) / (y3 - y2)));
    //            mx1 = (x1 + x2) / 2;
    //            mx2 = (x2 + x3) / 2;
    //            my1 = (y1 + y2) / 2;
    //            my2 = (y2 + y3) / 2;
    //            xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2);
    //            yc = m1 * (xc - mx1) + my1;
    //        }
    //        dx = x2 - xc;
    //        dy = y2 - yc;
    //        rsqr = dx * dx + dy * dy;
    //        r = System.Math.Sqrt(rsqr);
    //        dx = xp - xc;
    //        dy = yp - yc;
    //        drsqr = dx * dx + dy * dy;
    //        if (drsqr <= rsqr)
    //            return true;
    //        return false;
    //    }
    //}
}
