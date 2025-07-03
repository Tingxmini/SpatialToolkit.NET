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
using System.Collections;
using System.IO;
using CSPoint = System.Drawing.Point;//重命名内置类的名称，因为与自定义的类同名

namespace suanfakuangjia
{
    public partial class zhixin : Form
    {
        Graphics newGraphics1;
        Graphics newGraphics2;
        Graphics addGraphics;
        Graphics uniGraphics;
        Graphics abGraphics;
        Graphics baGraphics;
        Bitmap bitmap1;
        Bitmap bitmap2;
        Bitmap addbitmap;
        Bitmap unibitmap;
        Bitmap abbitmap;
        Bitmap babitmap;
        int clickcount1 = 0;
        int clickcount2 = 0;
        List<Point> listpoint1 = new List<Point>();
        List<Point> listpoint2 = new List<Point>();
        List<Point> listpoint3 = new List<Point>();
        List<Point> listpoint4 = new List<Point>();
        int[,] firstpolygen;
        int[,] secondpolygen;
        int[,] addpolygen;
        int[,] unipolygen;
        int[,] abpolygen;
        int[,] bapolygen;
        int times = 0;
        int diejia1 = 0;
        int diejia2 = 0;



        public Point MyPoint1, MyPoint2;
        public int[] pointX = new int[1000];
        public int[] pointY = new int[1000];
        public int[] pX = new int[1];
        public int[] pY = new int[1];
        public int MyFlag = 0;
        bool z12 = false;
        int i1 = 1;
        double d;
        int quxian = 0;



        Pen pen2 = new Pen(Color.HotPink, 3);
        double yuz11;
        float x3;
        float y3;
        float x4;
        float y4;
        float x5;
        float y5;
        float x6;
        float y6;
        //public Point pt1;
        public static int N = 100;
        int hc3=0;
        int start;
        int end;
        int ed;

        //定义地点数

        static int M = 7;
        //初始化地点间权重
        static int[,] ADD = new int[,]{
                                        {00,20,50,30,100,100,100},
                                        {20,00,25,500,100,70,70},
                                        {50,25,00,40,25,50,10},
                                        {30,50,40,00,55,100,100},
                                        {100,100,25,55,00,10,70},
                                        {100,70,50,100,10,00,50},
                                        {100,70,10,100,70,50,00}
                                      };
        //定义最后路经数组
        static int[,] path = new int[M, M];

        //定义新生成的距离
        static int[,] dis = new int[M, M];




        int zhudian = 0;
        public int tPoints = 0;
        int HowMany = 0;
        Point point = new Point();
        Point point1 = new Point();
        Point point2 = new Point();
        Point point3 = new Point();
        Pen p11 = new Pen(Color.Red, 2);
        Pen p31 = new Pen(Color.Yellow, 2);
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






        private myDEM DEM;
        private double[,] arr;
        private double[,] slopeSN;
        private double[,] slopeWE;
        private double[,] slopeSN1;
        private double[,] slopeWE1;
        private double[,] slope;
        private double[,] aspect;
        private double[,] slope1;
        private double[,] slope2;
        private double[,] sloper;
        private double[,] aspect1;
        private double[,] aspect2;
        private double[,] slopeSN2;
        private double[,] slopeWE2;
        private double[,] deep;
        private double[,] HH;
        List<double> W1;
        private double[,] deep1;
        private double[,] HH1;
        int tongsh = 0;
        double px;
        double py;




        int siteCount = 10;//初始设定点数为10
        Voronoi voroObject = new Voronoi();
        Random seeder;
        int seed;
        Bitmap backImage;
        
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
        private List<List<PointF>> pointgroups;
        List<Point> points = new List<Point>();
        List<Double> pointZ = new List<Double>();
        List<PointF> pointlist = new List<PointF>();//存放点数据
        List<PointF> points1 = new List<PointF>();
        List<double> distlist = new List<double>();//存放距离数据
        List<边> edgelist = new List<边>();//存放边数据
        Pen maxpen = new Pen(Color.Red, 3);
        Pen minpen = new Pen(Color.Yellow, 3);
        public PointF a;
        public Point p;
        public Point pt1;
        public Point pt2;
        public PointF p1;
        public PointF p2;
        public PointF p3;
        public PointF p4;
        public PointF p5;
        public Point p6;
        public double z;
        bool result;
        

        public int nn1;
        string Filename;

        public static int phase = 0;
        public static double a1 = 0, b1 = 0, d1 = 0;
        Random r = new Random();

        public class Drop      //定义一个云滴类
        {
            public double x;//横坐标
            public double y;//纵坐标
            public Drop(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        List<Drop> cloud = new List<Drop>();//定义一个云滴的集合
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

        //Point[] S;
     
        int[,] t;
        int n1 = 0;
        List<int> W;

        private System.Drawing.Bitmap curBitmap;


        public zhixin()
        {
            InitializeComponent();
            

        }


        
        List<int> W3;
        List<int> W4;

        int i, j, L = 0, len;
        int z1 = 0;
        string D;

        
        public class NODE//定义一个类，表示节点
        {
            public int num;
            public int tag;

            public int Tag
            {
                get { return tag; }
                set { tag = value; }
            }

        };
        public class EDGE//定义一个类，表示边
        {
            public int cost;//边的权值
            public int node1;//边的起点
            public int node2;//边的终点
        };
        public static List<NODE> pList = new List<NODE>();//节点集
        public static List<EDGE> eList = new List<EDGE>();//边集
        public static List<EDGE> meList = new List<EDGE>();//最小生成树的边集
        List<EDGE> nes = new List<EDGE>();




        C_Trianglate trianglate = null;
        C_Trianglate2 trianglate2 = null;

        double dMax_X = -999999999;
        double dMax_Y = -999999999;
        double dMin_X = 9999999999;
        double dMin_Y = 9999999999;
        double dMax_Z = -9999999999;
        double dMin_Z = 9999999999;

        C_ContourTrace conTrace = null;
        bool isDrawConLine = true;
        bool isMarkTriangle = false;
        bool isDrawTriangle = false;
        string str_FilePath = null;


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
        




        private void button1_Click(object sender, EventArgs e)
        {
            //diejia1 = 0;
            hc3 = 0;
            zhudian = 0;
            if (tongsh==1)
            {
                pictureBox1.Invalidate();
                points.Clear();
                pointlist.Clear();
                tongsh = 0;
            }
            else
            {
            pictureBox1.Invalidate();
                //bitmap1.
            points.Clear();
            pointlist.Clear();
                listpoint1.Clear();
                listpoint2.Clear();
                listpoint3.Clear();
                listpoint4.Clear();
                points1.Clear();
                pictureBox1.BackgroundImage = null;
                pictureBox1.Image = null;
                Array.Clear(pointX, 0, pointX.Length);
                Array.Clear(pointY, 0, pointY.Length);
                Array.Clear(pX, 0, pX.Length);
                Array.Clear(pY, 0, pY.Length);
                z12 = false;
                i1 = 0;
                clickcount1 = 0;
               clickcount2 = 0;
                times = 0;
            }
            
            //g = pictureBox1.CreateGraphics();//创建画板
            //pictureBox1.Cursor = Cursors.Cross;
            //pen1 = new Pen(Color.Black, 3);
            //drawmode1 = 1;//设置画图类型为画多边形或折线
            //clicknum = 0;

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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //if(diejia1==1)
            //{
            //    if (times == 0)
            //    {
            //        pictureBox1.Image = bitmap1;
            //        System.Drawing.Pen myPen;
            //        myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
            //        Point point = new Point();
            //        clickcount1++;
            //        point.X = e.X;
            //        point.Y = e.Y;
            //        listpoint1.Add(point);
            //        newGraphics1.FillEllipse(Brushes.Red, e.X - 2.5f, e.Y - 2.5f, 5, 5);
            //    }
            //    else if (times == 1)
            //    {
            //        pictureBox1.Image = bitmap2;
            //        clickcount2++;
            //        Point point = new Point();
            //        point.X = e.X;
            //        point.Y = e.Y;
            //        listpoint2.Add(point);
            //        newGraphics2.FillEllipse(Brushes.Red, e.X - 2.5f, e.Y - 2.5f, 5, 5);
            //        if (clickcount2 > 1)
            //        {
            //            newGraphics2.DrawLine(Pens.Black, listpoint2[clickcount2 - 2], listpoint2[clickcount2 - 1]);
            //            newGraphics1.DrawLine(Pens.Black, listpoint1[clickcount1 - 2], listpoint1[clickcount1 - 1]);
            //        }
            //    }
            //}
            //else if(diejia1==2)
            //{

            //}
            //else
            //{
                 if (hc3 == 1)
            {
                if (pictureBox1.Cursor == Cursors.Cross && drawmode == 1)
                {//若画线
                    if (clicknum > 0)
                    {//若为第一个点
                        pen1 = mypen;
                        x2 = e.X;
                        y2 = e.Y;
                        p = new Point(e.X, e.Y);
                        pointlist.Add(p);
                        g.DrawLine(pen1, x1, y1, x2, y2);//画线
                        x1 = x2;
                        y1 = y2;
                    }
                    else
                    {
                        p = new Point(e.X, e.Y);
                        pointlist.Add(p);
                        x0 = e.X;
                        y0 = e.Y;
                        x1 = e.X;
                        y1 = e.Y;
                    }
                    clicknum = clicknum + 1;
                }
                if (drawmode == 0)
                {
                    Point point = new Point(e.X, e.Y);
                    pointlist.Add(point);
                    g.FillEllipse(Brushes.Red, e.X, e.Y, 4, 4);
                }
                //hc3 = 0;
                return;
            }
            if (zhudian==1)
            {
                dt.Vertex[tPoints].x = e.X;
                dt.Vertex[tPoints].y = e.Y;
                //Perform Triangulation Function if there are more than 2 points
                if (tPoints > 2)
                {
                    // set form's color as white
                    //g.Clear(Color.White);
                    function fu = new function();
                    HowMany = fu.Triangulate(tPoints, dt);
                }
                else
                {
                    point = new Point(e.X, e.Y);
                    g = pictureBox1.CreateGraphics();
                    g.DrawEllipse(p11, e.X, e.Y, 3, 3);
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
                    g.DrawLine(p11, point1, point2);
                    g.DrawLine(p11, point2, point3);
                    g.DrawLine(p11, point1, point3);
                }
                
            }
            if (pictureBox1.Cursor == Cursors.Cross && drawmode == 1)
            {//若画线
                if (clicknum > 0)
                {//若为第一个点
                    pen1 = mypen;
                    x2 = e.X;
                    y2 = e.Y;
                    p = new Point(e.X, e.Y);
                    //if(hc3==1)
                    //{
                    //    pointlist.Add(p);
                    //}
                    points.Add(p);
                    g.DrawLine(pen1, x1, y1, x2, y2);//画线
                    x1 = x2;
                    y1 = y2;
                }
                else
                {
                    p = new Point(e.X, e.Y);
                    //if (hc3 == 1)
                    //{
                    //    pointlist.Add(p);
                        
                    //}
                   
                       points.Add(p);
                    
                    
                    x0 = e.X;
                    y0 = e.Y;
                    x1 = e.X;
                    y1 = e.Y;
                }
                clicknum = clicknum + 1;
            }
            if(drawmode==0)
            {
                Point point = new Point(e.X, e.Y);
                //if (hc3 == 1)
                //{
                //    pointlist.Add(p);
                //}
                pointlist.Add(point);
                g.FillEllipse(Brushes.Red, e.X-2, e.Y-2, 4, 4);
            }
            if(drawmode==2)
            {
                Point point = new Point(e.X, e.Y);
                pointlist.Add(point);
                if (pointlist.Count == 1)
                {
                    
                    g.FillEllipse(Brushes.Red, pointlist[0].X - 2, pointlist[0].Y - 2, 4, 4);
                }
                if (pointlist.Count == 2)
                {
                    
                    g.FillEllipse(Brushes.Red, pointlist[1].X - 2, pointlist[1].Y - 2, 4, 4);
                    g.DrawLine(Pens.Black, pointlist[0], pointlist[1]);
                }
                if (pointlist.Count == 3)
                {
                    
                    g.FillEllipse(Brushes.Red, pointlist[2].X - 2, pointlist[2].Y - 2, 4, 4);
                }
                if (pointlist.Count == 4)
                {
                    
                    g.FillEllipse(Brushes.Red, pointlist[3].X - 2, pointlist[3].Y - 2, 4, 4);
                    g.DrawLine(Pens.Black, pointlist[2], pointlist[3]);
                }

            }
                if (drawmode == 3)
                {
                //if (listpoint1.Count() != 0 || listpoint3.Count() != 0)
                //{
                //    times = 1;
                //}
                if (times == 0)
                {
                    pictureBox1.Image = bitmap1;
                    System.Drawing.Pen myPen;
                    myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
                    Point point = new Point();
                    clickcount1++;
                    point.X = e.X;
                    point.Y = e.Y;
                    listpoint1.Add(point);
                    newGraphics1.FillEllipse(Brushes.Red, e.X - 2.5f, e.Y - 2.5f, 5, 5);
                }
                else if (times == 1)
                {
                    pictureBox1.Image = bitmap2;
                    System.Drawing.Pen myPen;
                    myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
                    clickcount2++;
                    Point point = new Point();
                    point.X = e.X;
                    point.Y = e.Y;
                    listpoint2.Add(point);
                    newGraphics2.FillEllipse(Brushes.Red, e.X - 2.5f, e.Y - 2.5f, 5, 5);
                    //if (clickcount2 > 1)
                    //{
                    //    newGraphics2.DrawLine(Pens.Black, listpoint2[clickcount2 - 2], listpoint2[clickcount2 - 1]);
                    //}
                }
            }  //}
                if(drawmode==4)
                     //if (times == 1)
                    {
                //if (listpoint1.Count() != 0 || listpoint3.Count() != 0)
                //{
                //    times = 1;
                //}
                if (times == 0)
                {
                    pictureBox1.Image = bitmap1;
                    clickcount1++;
                    Point point = new Point();
                    point.X = e.X;
                    point.Y = e.Y;
                    listpoint3.Add(point);
                    newGraphics1.FillEllipse(Brushes.Red, e.X - 2.5f, e.Y - 2.5f, 5, 5);
                    if (clickcount1 > 1)
                    {
                        newGraphics1.DrawLine(Pens.Black, listpoint3[clickcount1 - 2], listpoint3[clickcount1 - 1]);
                    }
                }
                else if (times == 1)
                {
                    pictureBox1.Image = bitmap2;
                    clickcount2++;
                    Point point = new Point();
                    point.X = e.X;
                    point.Y = e.Y;
                    listpoint4.Add(point);
                    newGraphics2.FillEllipse(Brushes.Red, e.X - 2.5f, e.Y - 2.5f, 5, 5);
                    if (clickcount2 > 1)
                    {
                        newGraphics2.DrawLine(Pens.Black, listpoint4[clickcount2 - 2], listpoint4[clickcount2 - 1]);
                    }
                }
            }

                

                if (z12 == true)
            {
                this.MyFlag = 1;
                this.MyPoint1.X = e.X;
                this.MyPoint1.Y = e.Y;
                pointX[0] = MyPoint1.X;
                pointY[0] = MyPoint1.Y;
            }
            else
            {
                pX[0] = e.X;
                pY[0] = e.Y;

                g.DrawEllipse(Pens.Red, pX[0], pY[0], 2, 2);
                z12 = true;
            }
            //}


            

        }


        double CalculateZhixin(List<System.Drawing.Point> points)
        {
            float area = 0.0f;//多边形面积  
            float Gx = 0.0f, Gy = 0.0f;// 重心的x、y  
            for (int i = 1; i <= points.Count; i++)
            {
                float iLat = points[(i % points.Count())].X;
                float iLng = points[(i % points.Count())].Y;
                float nextLat = points[(i - 1)].X;
                float nextLng = points[(i - 1)].Y;
                float temp = (iLat * nextLng - iLng * nextLat) / 2.0f;
                area += temp;
                Gx += temp * (iLat + nextLat) / 3.0f;
                Gy += temp * (iLng + nextLng) / 3.0f;
            }
            Gx = Gx / area;
            Gy = Gy / area;

            return Gx;

        }
        double CalculateZhixinY(List<System.Drawing.Point> points)
        {
            float area = 0.0f;//多边形面积  
            float Gx = 0.0f, Gy = 0.0f;// 重心的x、y  
            for (int i = 1; i <= points.Count; i++)
            {
                float iLat = points[(i % points.Count())].X;
                float iLng = points[(i % points.Count())].Y;
                float nextLat = points[(i - 1)].X;
                float nextLng = points[(i - 1)].Y;
                float temp = (iLat * nextLng - iLng * nextLat) / 2.0f;
                area += temp;
                Gx += temp * (iLat + nextLat) / 3.0f;
                Gy += temp * (iLng + nextLng) / 3.0f;
            }
            Gx = Gx / area;
            Gy = Gy / area;

            return Gy;
        }

        /// <summary>
        /// 获取不规则多边形几何中心点
        /// </summary>
        /// <param name="mPoints"></param>
        /// <returns></returns>
        float GetCenterPoint(List<System.Drawing.Point> mPoints)
        {
            float cx = (GetMinX(mPoints) + GetMaxX(mPoints)) / 2;
            float cy = (GetMinY(mPoints) + GetMaxY(mPoints)) / 2;
            return cx;

        }
        float GetCenterPointY(List<System.Drawing.Point> mPoints)
        {
            float cx = (GetMinX(mPoints) + GetMaxX(mPoints)) / 2;
            float cy = (GetMinY(mPoints) + GetMaxY(mPoints)) / 2;
            return cy;

        }
        /// <summary>
        /// 获取最小X值
        /// </summary>
        /// <param name="mPoints"></param>
        /// <returns></returns>
        public static float GetMinX(List<System.Drawing.Point> mPoints)
        {
            float minX = 0;
            if (mPoints.Count > 0)
            {
                minX = mPoints[0].X;
                foreach (Point point in mPoints)
                {
                    if (point.X < minX)
                        minX = point.X;
                }
            }
            return minX;
        }
        /// <summary>
        /// 获取最大X值
        /// </summary>
        /// <param name="mPoints"></param>
        /// <returns></returns>
        public static float GetMaxX(List<System.Drawing.Point> mPoints)
        {
            float maxX = 0;
            if (mPoints.Count > 0)
            {
                maxX = mPoints[0].X;
                foreach (Point point in mPoints)
                {
                    if (point.X > maxX)
                        maxX = point.X;
                }
            }
            return maxX;
        }
        /// <summary>
        /// 获取最小Y值
        /// </summary>
        /// <param name="mPoints"></param>
        /// <returns></returns>
        public static float GetMinY(List<System.Drawing.Point> mPoints)
        {
            float minY = 0;
            if (mPoints.Count > 0)
            {
                minY = mPoints[0].Y;
                foreach (Point point in mPoints)
                {
                    if (point.Y < minY)
                        minY = point.Y;
                }
            }
            return minY;
        }
        /// <summary>
        /// 获取最大Y值
        /// </summary>
        /// <param name="mPoints"></param>
        /// <returns></returns>
        public static float GetMaxY(List<System.Drawing.Point> mPoints)
        {
            float maxY = 0;
            if (mPoints.Count > 0)
            {
                maxY = mPoints[0].Y;
                foreach (Point point in mPoints)
                {
                    if (point.Y > maxY)
                        maxY = point.Y;
                }
            }
            return maxY;
        }

        

        

        
        public bool IsInside(PointF a)
        {
            int count = points.Count;

            if (count < 3)
            {
                return false;
            }

            result = false;

            for (int i = 0, j = count - 1; i < count; i++)
            {
                var p1 = points[i];
                var p2 = points[j];

                if (p1.X < a.X && p2.X >= a.X || p2.X < a.X && p1.X >= a.X)
                {
                    if (p1.Y + (a.X - p1.X) / (p2.X - p1.X) * (p2.Y - p1.Y) < a.Y)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;

        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if(drawmode!=3&&drawmode!=4)
            {
            if(hc3==1)
            {
                g.DrawLine(pen1, pointlist[pointlist.Count() - 1].X, pointlist[pointlist.Count() - 1].Y, pointlist[0].X, pointlist[0].Y);
                return;
            }
            g.DrawLine(pen1, points[points.Count() - 1].X, points[points.Count() - 1].Y, points[0].X, points[0].Y);
            drawmode = 0;
            }
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
            }
            if (e.Button == MouseButtons.Right)
            {
                
                PointF a = new PointF(e.X, e.Y);
                IsInside(a);
                if (result == true)
                {
                    MessageBox.Show("在多边形内");
                }
                else
                {
                    MessageBox.Show("不在多边形内");
                }

            }
        }
        int n;
        
        //private void ZheXian(Point p1, Point p2, Graphics g)
        //{

        //    g = pictureBox1.CreateGraphics();
        //    Point p3 = new Point(p1.X + (p2.X - p1.X) / 3, p1.Y + (p2.Y - p1.Y) / 3);    // 三等分点坐标
        //    Point p4 = new Point(p1.X + (p2.X - p1.X) * 2 / 3, p1.Y + (p2.Y - p1.Y) * 2 / 3);    // 三等分点坐标
        //    Point p4XD3 = new Point(p4.X - p3.X, p4.Y - p3.Y);    // p4相对于p3点的坐标
                                                                  
        //    int x = (int)Math.Round(p4XD3.X * Math.Cos(Math.PI / 3) + p4XD3.Y * Math.Sin(Math.PI / 3));
        //    int y = (int)Math.Round(p4XD3.Y * Math.Cos(Math.PI / 3) - p4XD3.X * Math.Sin(Math.PI / 3));
        //    Point p5XD3 = new Point(x, y);    // p5相对于p3点的坐标
        //    Point p5 = new Point(p3.X + x, p3.Y + y);    // p5相对于原点的坐标
        //    Pen pen = new Pen(Brushes.Black, 1);
        //    double length = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 3;
            
        //    if(Convert.ToInt32(comboBox3.Text)==4)//通过输入的迭代次数设置最终线段长度
        //    {
        //        len1 = 20;
        //    }
        //    if (Convert.ToInt32(comboBox3.Text) == 5)
        //    {
        //        len1 = 10;
        //    }
        //    if (Convert.ToInt32(comboBox3.Text) == 3)
        //    {
        //        len1 = 40;
        //    }
        //    if (Convert.ToInt32(comboBox3.Text) == 2)
        //    {
        //        len1 = 120;
        //    }
        //    if (Convert.ToInt32(comboBox3.Text) == 6)
        //    {
        //        len1 = 3;
        //    }
        //    if (length > len1) // 通过最终线段长度控制迭代
        //    {
        //        ZheXian(p1, p3, g);
        //        ZheXian(p3, p5, g);
        //        ZheXian(p5, p4, g);
        //        ZheXian(p4, p2, g);
        //    }
        //    else
        //    {
        //        g.DrawLine(pen, p1, p3);
        //        g.DrawLine(pen, p3, p5);
        //        g.DrawLine(pen, p5, p4);
        //        g.DrawLine(pen, p4, p2);
        //    }
        //}
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
        
        private void Tree(Point O11, double angle, double length, float width, Graphics g)
        {
            if (width < 1)
                width = 1;
            if (length < 10)//通过树枝长度控制递归次数
            {
                return;
            }
            Point p = new Point(O11.X + (int)(length * Math.Cos(angle)), O11.Y - (int)(length * Math.Sin(angle)));
            Pen pen = new Pen(Brushes.Green, width);
            g.DrawLine(pen, O11, p);
            Tree(p, angle + Math.PI / 9, length * 0.8, width * 0.8f, g);//递归画左半个
            Tree(p, angle - Math.PI / 9, length * 0.8, width * 0.8f, g);//递归画右半个
        }


        

        

        
        private double getCouldNumber(double ex, double e, int i)//获取服从（ex,e2）分布的正态随机数
        {
            return ex + (redomNumber(i) * e);
        }

        private double redomNumber(int i)//获取服从（0,1）分布的正态随机数
        {
            double c;
            if (phase == 0)
            {
                do
                {
                    a1 = r.NextDouble() * 2 - 1.0;
                    b1 = r.NextDouble() * 2 - 1.0;
                    d1 = a1 * a1 + b1 * b1;
                }
                while (d1 == 0 || d1 >= 1);
                c = a1 * Math.Sqrt((-2 * Math.Log(d1)) / d1);
            }
            else
            {
                c = b1 * Math.Sqrt((-2 * Math.Log(d1)) / d1);
            }
            phase = 1 - phase;
            return c;
        }
        public static void DrawXY(PictureBox pan)
        {
            Graphics g = pan.CreateGraphics();//创建画板
            //float move = 50f;//整体内缩move像素
            float newX = pan.Width;
            float newY = pan.Height;
            //绘制X轴
            PointF px1 = new PointF(0, newY);
            PointF px2 = new PointF(newX, newY);
            g.DrawLine(new Pen(Brushes.Black, 2), px1, px2);//画笔属性
            //绘制Y轴
            PointF py1 = new PointF(0, newY);
            PointF py2 = new PointF(0, 0);
            g.DrawLine(new Pen(Brushes.Black, 2), py1, py2);
        }
        //绘制Y轴上的分值线，从零开始
        public static void DrawYLine(PictureBox pan, double maxY, int len)
        {
            float move = 0f;
            float LenX = pan.Width;
            float LenY = pan.Height;
            Graphics g = pan.CreateGraphics();
            for (int i = 0; i <= len; i++)
            {
                PointF px1 = new PointF(move, LenY * i / len + move);
                PointF px2 = new PointF(move + 4, LenY * i / len + move);
                string sx = (maxY - maxY * i / len).ToString();
                g.DrawLine(new Pen(Brushes.Black, 2), px1, px2);
                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Near;
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(sx, new Font("宋体", 8f), Brushes.Black, new PointF(move / 1.2f, LenY * i / len + move * 1.1f), drawFormat);
            }
            Pen pen = new Pen(Color.Black, 1);//创建画笔
            g.DrawString("Y/不确定度", new Font("宋体", 10f), Brushes.Black, new PointF(10f / 3, move / 2f));
        }
        //绘制X轴上的分值线，从零开始
        public static void DrawXLine(PictureBox pan, double maxX, int len)
        {
            float move = 0f;
            float LenX = pan.Width - 2 * move;
            float LenY = pan.Height - 2 * move;
            Graphics g = pan.CreateGraphics();
            for (int i = 0; i <= len; i++)
            {
                PointF py1 = new PointF(LenX * i / len + move, pan.Height - move - 4);
                PointF py2 = new PointF(LenX * i / len + move, pan.Height - move);
                string sy = (maxX * i / len).ToString();
                g.DrawLine(new Pen(Brushes.Black, 2), py1, py2);
                StringFormat drawFormat = new StringFormat();
                drawFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(sy, new Font("宋体", 8f), Brushes.Black, new PointF(LenX * i / len - 5f, pan.Height - 15f / 1.1f));
            }
            Pen pen = new Pen(Color.Black, 1);//创建画笔
            g.DrawString("X/云滴", new Font("宋体", 10f), Brushes.Black, new PointF(pan.Width - 100f / 1.5f, pan.Height - 50f / 1.5f));

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
                MessageBox.Show("最短距离为"+ 0);
                //textBox1.Text = Convert.ToInt16(0).ToString();//最短
            }
            else
            {
                MessageBox.Show("最短距离为" + mindist);
                //textBox1.Text = Convert.ToInt16(mindist).ToString();//最短
                g.DrawLine(minpen, edgelist[minindex].a, edgelist[minindex].b);
            }
            MessageBox.Show("最长距离为" + maxdist);
            //textBox2.Text = Convert.ToInt16(maxdist).ToString();//最长
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

        

        private void radioButton1_Click(object sender, EventArgs e)
        {
            //diejia1 = 0;
            pictureBox1.Invalidate();
            points.Clear();
            pointlist.Clear();
            points1.Clear();
            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 1;//设置画图类型为画多边形或折线
            clicknum = 0;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //DrawYLine(pictureBox1, 1, 10);
            //DrawXLine(pictureBox1, 40, 8);
            //DrawXY(pictureBox1);
        }

        
        private void culster(PointF[] center)  //参数为中心点
        {
            //先将point定义（清空）
            pointgroups = new List<List<PointF>>();
            int k = center.Length;
            for (int i = 0; i < k; i++)  //中心点数组初始化
            {
                pointgroups.Add(new List<PointF>());  //初始化一个点云集
            }

            //求所有最短距离者，聚集为一类
            for (int i = 0; i < pointlist.Count - k; i++)
            {
                //求点与各中心点的距离
                double mindis = 9999;
                int id = 0;
                for (int j = 0; j < k; j++)
                {
                    double dis = getDis(pointlist[i], center[j]);
                    if (dis < mindis)
                    {
                        mindis = dis;
                        id = j;
                    }
                }
                pointgroups[id].Add(pointlist[i]);
            }
            //分类形成
            //计算新中心点
            PointF[] newcenter = new PointF[k];

            bool couldbreak = false;
            for (int i = 0; i < k; i++)
            {
                newcenter[i] = getCenter(pointgroups[i]);

                //都一样，弹出
                if (newcenter[i].X == center[i].X)
                {
                    couldbreak = true;
                }
                else
                {
                    couldbreak = false;
                }
            }
            if (couldbreak) return;
            //形成迭代
            culster(newcenter);
        }
        //虚拟的中心点
        private PointF getCenter(List<PointF> po)  //获得点云中心点
        {
            //可能一个点云为空
            if (po.Count == 0) return new PointF(0, 0);
            float xall = 0;
            float yall = 0;
            int ponum = po.Count;
            foreach (PointF p in po)
            {
                xall += p.X;
                yall += p.Y;
            }
            float xmean = xall / ponum;
            float ymean = yall / ponum;
            return new PointF(xmean, ymean);
        }
        private double getDis(PointF p, PointF q)
        {
            float dis2 = (p.X - q.X) * (p.X - q.X) + (p.Y - q.Y) * (p.Y - q.Y);
            double dis = System.Math.Sqrt(dis2);
            return dis;
        }
        private void render()
        {
            //g.Clear(Color.White);
            g = pictureBox1.CreateGraphics();//创建画板
            foreach (List<PointF> polist in pointgroups)
            {
                int rgbr = new Random(Guid.NewGuid().GetHashCode()).Next(0, 255);
                int rgbg = new Random(Guid.NewGuid().GetHashCode()).Next(0, 255);
                int rgbb = new Random(Guid.NewGuid().GetHashCode()).Next(0, 255);
                foreach (PointF p in polist)
                {
                    g.FillEllipse(new SolidBrush(Color.FromArgb(rgbr, rgbg, rgbb)), p.X-2, p.Y-2, 6, 6);
                }
            }
        }

        private int MIN(int[] Q, out int j)
        {
            int a1 = 10000;
            j = 0;
            for (int i = 0; i < Q.Length; i++)
            {
                if (a1 >= Q[i])
                {
                    a1 = Q[i];
                    j = i;
                }
            }
            return a1;
        }
        /// <summary>
        /// 最短路径
        /// </summary>
        /// <param name="t"></param>      
        /// <param name="v"></param>
        /// <param name="d"></param>
        private void shortpan(int[,] t, int v, out int[] d)
        {
            g = pictureBox1.CreateGraphics();
            int[,] h;
            int[] Q;
            h = new int[t.GetLength(0), t.GetLength(0)];
            d = new int[t.GetLength(0)];
            Q = new int[t.GetLength(0)];
            d[v] = 0;//源点到源点为0;
            int u = v;//记录移除的节点                    
            int w = v;//记录前一个节点
            int max = 10000;
            //判断是否存在边，初始化Q
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(0); j++)
                {
                    if (t[i, j] < max && t[i, j] != 0)
                    {
                        h[i, j] = 1;
                    }
                }
                Q[i] = max;
            }
            //更新最短路径
            for (int j = 1; j < d.Length; j++)
            {
                int l = 0;
                for (int i = 0; i < Q.Length; i++)
                {
                    if (h[u, i] == 1)
                    {
                        if (t[u, i] + d[u] <= Q[i])
                        {
                            g.DrawLine(new Pen(Brushes.Red, 2), pointlist[u], pointlist[i]);
                            System.Threading.Thread.Sleep(500);
                            if (Q[i] != max && h[w, i] != 0)
                                g.DrawLine(new Pen(Brushes.Yellow, 2), pointlist[w], pointlist[i]);
                            Q[i] = t[u, i] + d[u];
                        }
                        else
                        {
                            g.DrawLine(new Pen(Brushes.Red, 2), pointlist[u], pointlist[i]);
                            System.Threading.Thread.Sleep(500);
                            g.DrawLine(new Pen(Brushes.Yellow, 2), pointlist[u], pointlist[i]);
                            System.Threading.Thread.Sleep(500);
                        }
                        h[i, u] = 2;
                    }
                }
                w = u;
                int r = MIN(Q, out u);
                d[u] = r;
                Q[u] = max;
            }
        }



        private void 最短路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n2 = 0;
            if (n2 == 0)
            {
                shuruyuan sy1 = new shuruyuan();
                sy1.Show();
                n2 = 1;
            }


            W = new List<int>();
            t = new int[5, 5];
            //S = new Point[5];
            //Point a = new Point(100, 100);
            //pointlist[0] = a1;
            //Point E = new Point(150, 150);
            //pointlist[1] = E;
            //Point b = new Point(200, 100);
            //pointlist[3] = b;
            //Point c = new Point(200, 200);
            //pointlist[4] = c;
            //Point f = new Point(100, 200);
            //pointlist[2] = f;


            t[0, 1] = 10;
            t[0, 2] = 20;
            t[0, 3] = 30;
            t[0, 4] = 10000;
            t[1, 2] = 5;
            t[1, 3] = 10;
            t[1, 4] = 10000;
            t[2, 3] = 10000;
            t[2, 4] = 30;
            t[3, 4] = 20;
            for (int i = 0; i < 5; i++)
            {
                //t[i, i] = 0;                      
                for (int j = 0; j < 5; j++)
                {
                    t[j, i] = t[i, j];
                }
            }


            n1 = 1;
            int v = 0;
            //int  v = int.Parse(toolStripTextBox1.Text);
           
            string str = shuruyuan.sy1.textBox1.Text;
            switch (str)
            {
                case "A":
                    v = 0; break;
                case "B":
                    v = 1; break;
                case "C":
                    v = 2; break;
                case "D":
                    v = 3; break;
                case "E":
                    v = 4; break;
                default:
                    MessageBox.Show("请输入正确的源点");
                    break;
            }
            int[] d;//最短路径
            shortpan(t, v, out d);
            //for (int i = 0; i < 5; i++)
            //{
            //    listBox1.Items.Add(Convert.ToString(d[i]));
            //}



        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //hc3 = 0;
            pointlist.Clear();
            pictureBox1.Invalidate();

            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 0;//设置画图类型为画点
        }

        private void 绘制最短路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (n1 == 0)
            {
                g = pictureBox1.CreateGraphics();
                Pen pen = new Pen(Brushes.Yellow, 2);
                g.DrawString("A", new Font("宋体", 18), Brushes.Red, pointlist[0].X - 18, pointlist[0].Y - 18);
                g.DrawString("B", new Font("宋体", 18), Brushes.Red, pointlist[1].X + 6, pointlist[1].Y + 6);
                g.DrawString("C", new Font("宋体", 18), Brushes.Red, pointlist[2].X - 18, pointlist[2].Y - 18);
                g.DrawString("D", new Font("宋体", 18), Brushes.Red, pointlist[3].X, pointlist[3].Y);
                g.DrawString("E", new Font("宋体", 18), Brushes.Red, pointlist[4].X, pointlist[4].Y - 18);
                g.DrawString("10", new Font("宋体", 12), Brushes.Red, (pointlist[0].X + pointlist[1].X) / 2, (pointlist[0].Y + pointlist[1].Y) / 2);
                g.DrawString("20", new Font("宋体", 12), Brushes.Red, (pointlist[0].X + pointlist[2].X) / 2, (pointlist[0].Y + pointlist[2].Y) / 2);
                g.DrawString("30", new Font("宋体", 12), Brushes.Red, (pointlist[0].X + pointlist[3].X) / 2, (pointlist[0].Y + pointlist[3].Y) / 2);
                g.DrawString("10", new Font("宋体", 12), Brushes.Red, (pointlist[1].X + pointlist[3].X) / 2 - 12, (pointlist[1].Y + pointlist[3].Y) / 2);
                g.DrawString("5", new Font("宋体", 12), Brushes.Red, (pointlist[1].X + pointlist[2].X) / 2 - 12, (pointlist[1].Y + pointlist[2].Y) / 2);
                g.DrawString("30", new Font("宋体", 12), Brushes.Red, (pointlist[2].X + pointlist[4].X) / 2, (pointlist[2].Y + pointlist[4].Y) / 2);
                g.DrawString("20", new Font("宋体", 12), Brushes.Red, (pointlist[3].X + pointlist[4].X) / 2, (pointlist[3].Y + pointlist[4].Y) / 2);
                g.DrawLine(pen, pointlist[0], pointlist[1]);
                g.DrawLine(pen, pointlist[0], pointlist[2]);
                g.DrawLine(pen, pointlist[0], pointlist[3]);
                g.DrawLine(pen, pointlist[1], pointlist[3]);
                g.DrawLine(pen, pointlist[1], pointlist[2]);
                g.DrawLine(pen, pointlist[2], pointlist[4]);
                g.DrawLine(pen, pointlist[3], pointlist[4]);
            }
        }

        private void 空间分布量测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zhixin zx111 = new zhixin();
            //zx111.TopLevel = false;
            //zx111.FormBorderStyle = FormBorderStyle.None;
            //zx111.Dock = DockStyle.Fill;
            //this.Controls.Clear();
            //this.Controls.Add(zx111);
            //zx111.Show();
        }

        private void tIN相关算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //voronoi vrn11 = new voronoi();
            //vrn11.TopLevel = false;
            //vrn11.FormBorderStyle = FormBorderStyle.None;
            //vrn11.Dock = DockStyle.Fill;
            //this.Controls.Clear();
            //this.Controls.Add(vrn11);
            //vrn11.Show();
        }

        private void dEM相关算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //podu pd1 = new podu();
            ////tiji.ShowDialog();
            ////设置子窗口不显示为顶级窗口
            //pd1.TopLevel = false;
            ////设置子窗口的样式，没有上面的标题栏
            //pd1.FormBorderStyle = FormBorderStyle.None;
            ////填充
            //pd1.Dock = DockStyle.Fill;

            //this.Controls.Clear();
            //////加入控件
            //this.Controls.Add(pd1);
            ////让窗体显示
            //pd1.Show();
        }

        private void 网络分析算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //zxshchsh zxss11 = new zxshchsh();
            //zxss11.TopLevel = false;
            //zxss11.FormBorderStyle = FormBorderStyle.None;
            //zxss11.Dock = DockStyle.Fill;
            //this.Controls.Clear();
            //this.Controls.Add(zxss11);
            //zxss11.Show();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void 缓冲区分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //huanchong hch1 = new huanchong();
            //hch1.TopLevel = false;
            //hch1.FormBorderStyle = FormBorderStyle.None;
            //hch1.Dock = DockStyle.Fill;
            //this.Controls.Clear();
            //this.Controls.Add(hch1);
            //hch1.Show();
        }

        private void 随机生成三角网ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //seeder = new Random();
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            //初始化pictureBox背景图
            backImage = new Bitmap(923, 1045);
            g = Graphics.FromImage(backImage);
            g.SmoothingMode = SmoothingMode.HighQuality;
            //g.Clear(Color.White);

            //将背景图填充到pictureBox中
            pictureBox1.Image = backImage;
            seeder = new Random();
            //g = pictureBox1.CreateGraphics();
            tindv dv1 = new tindv();
            dv1.ShowDialog();
            
            siteCount = (int)dv1.value;
            //g.Clear(Color.White);
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

        private void 随机生成三角网ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            //seeder = new Random();
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            ////初始化pictureBox背景图
            //backImage = new Bitmap(510, 410);
            //g = Graphics.FromImage(backImage);
            //g.SmoothingMode = SmoothingMode.HighQuality;
            //g.Clear(Color.White);

            ////将背景图填充到pictureBox中
            ////pictureBox1.Image = backImage;
            ////Random seeder = new seeder();
            ////g = pictureBox1.CreateGraphics();//创建画板
            //tindv dv1 = new tindv();
            //dv1.ShowDialog();

            //siteCount = (int)dv1.value;
            ////g.Clear(Color.White);
            //List<DelaunayTriangle> allTriangle = new List<DelaunayTriangle>();//delaunay三角形集合
            //List<PointF> sites = new List<PointF>();
            //List<Site> sitesP = new List<Site>();
            //seed = seeder.Next();
            //Random rand = new Random(seed);
            //List<Edge> trianglesEdgeList = new List<Edge>();//Delaunay三角形网所有边
            //List<Edge> voronoiEdgeList = new List<Edge>();//vironoi图所有边
            //List<Edge> voronoiRayEdgeList = new List<Edge>();//voroni图外围射线边

            ////初始设定点数为20
            ////初始设定画布大小是500*400
            ////超级三角形顶点坐标为（250,0），（0,400），（500,400）
            ////点集区域为（125,200），（125,400），（375,200），（375,400），随便设置，只要满足点落在三角形区域中
            //for (int i = 0; i < siteCount; i++)
            //{

            //    PointF pf = new PointF((float)(rand.NextDouble() * 500), (float)(rand.NextDouble() * 400));
            //    //PointF pf=new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200));
            //    Site site = new Site(pf.X, pf.Y);
            //    sitesP.Add(site);
            //    //sitesP.Add(new PointF((float)(rand.NextDouble() * 250 + 125), (float)(rand.NextDouble() * 200 + 200)));
            //}

            ////按点集坐标X值排序
            //sitesP.Sort(new SiteSorterXY());
            //for (int i = 0; i < sitesP.Count; i++)
            //{
            //    //listBox1.Items.Add(sitesP[i].x);
            //}

            ////将超级三角形的三点添加到三角形网中
            //Site A = new Site(250, -5000);
            //Site B = new Site(-5000, 400);
            //Site C = new Site(5000, 400);
            //DelaunayTriangle dt = new DelaunayTriangle(A, B, C);
            //allTriangle.Add(dt);

            ////构造Delaunay三角形网
            //voroObject.setDelaunayTriangle(allTriangle, sitesP);


            ////voroObject.remmoveTrianglesByOnePoint(allTriangle,A);
            ////voroObject.remmoveTrianglesByOnePoint(allTriangle,B);
            ////voroObject.remmoveTrianglesByOnePoint(allTriangle,C);

            ////返回Delaunay三角形网所有边
            //trianglesEdgeList = voroObject.returnEdgesofTriangleList(allTriangle);

            ////获取所有Voronoi边
            //voronoiEdgeList = voroObject.returnVoronoiEdgesFromDelaunayTriangles(allTriangle, voronoiRayEdgeList);

            ////画点(填充圆)
            //for (int i = 0; i < sitesP.Count; i++)
            //{
            //    g.FillEllipse(Brushes.Blue, (float)(sitesP[i].x - 1.5f), (float)(sitesP[i].y - 1.5f), 3, 3);
            //}

            ////显示Delaunay三角形网
            ////if (checkBox1.Checked == true)
            ////{
            //for (int i = 0; i < voronoiEdgeList.Count; i++)
            //{
            //    CSPoint p1 = new CSPoint((int)trianglesEdgeList[i].a.x, (int)trianglesEdgeList[i].a.y);
            //    CSPoint p2 = new CSPoint((int)trianglesEdgeList[i].b.x, (int)trianglesEdgeList[i].b.y);
            //    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //}
            ////}

            ////根据维诺图的边画线段
            ////if (checkBox2.Checked == true)
            ////{
            ////    for (int i = 0; i < voronoiEdgeList.Count; i++)
            ////    {
            ////        CSPoint p1 = new CSPoint((int)voronoiEdgeList[i].a.x, (int)voronoiEdgeList[i].a.y);
            ////        CSPoint p2 = new CSPoint((int)voronoiEdgeList[i].b.x, (int)voronoiEdgeList[i].b.y);
            ////        g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            ////    }
            ////}

            ////根据Voronoi的射线边画线
            ////for (int i = 0; i < voronoiRayEdgeList.Count; i++)
            ////{
            ////    CSPoint p1 = new CSPoint((int)voronoiRayEdgeList[i].a.x, (int)voronoiRayEdgeList[i].a.y);
            ////    CSPoint p2 = new CSPoint((int)voronoiRayEdgeList[i].b.x, (int)voronoiRayEdgeList[i].b.y);
            ////    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            ////}

            ////更新pictureBox背景图片
            //pictureBox1.Image = backImage;

            g = pictureBox1.CreateGraphics();//创建画板
            tindv dv1 = new tindv();
            dv1.ShowDialog();
            int tt1 = dv1.value;
            int length = 300;
            Point origin = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);//设置中心点坐标
            Point A = new Point(origin.X - length / 2, (int)(origin.Y + length / (2 * Math.Sqrt(3))));
            Point B = new Point(origin.X, (int)(origin.Y - length / Math.Sqrt(3)));
            Point C = new Point(origin.X + length / 2, (int)(origin.Y + length / (2 * Math.Sqrt(3))));
            ZheXian(A, B, g, tt1);
            ZheXian(B, C, g, tt1);
            ZheXian(C, A, g, tt1);
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float x1 = pointlist[0].X;
            float y1 = pointlist[0].Y;
            float x2 = pointlist[1].X;
            float y2 = pointlist[1].Y;
            float x3 = pointlist[2].X;
            float y3 = pointlist[0].Y;

            double result2 = 0;
            double x, ca, cb, ab, d;
            ca = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
            cb = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            ab = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            x = Math.Max(ca, cb);
            d = PTL(x1, x2, x3, y1, y2, y3);
            if (Math.Sqrt(Math.Pow(x, 2) - Math.Pow(d, 2)) > ab)
            {
                result2 = Math.Min(ca, cb);
            }

            else
            {
                result2 = d;
            }
            MessageBox.Show("点到直线距离为" + result2);

            //MessageBox.Show("求得面积为" + CalculateArea(points).ToString());


            //double CalculateArea(List<System.Drawing.Point> points)
            //{
            //    var count = points.Count;
            //    double area0 = 0;
            //    double area1 = 0;
            //    for (int i = 0; i < count; i++)
            //    {
            //        var x = points[i].X;
            //        var y = i + 1 < count ? points[i + 1].Y : points[0].Y;
            //        area0 += x * y;
            //        var y1 = points[i].Y;
            //        var x1 = i + 1 < count ? points[i + 1].X : points[0].X;
            //        area1 += x1 * y1;
            //    }
            //    return Math.Round(Math.Abs(0.5 * (area0 - area1)), 2);
            //}
        }


        private void initialArr()
        {
            arr[0, 0] = DEM.CellData[0, 0];
            arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1] = DEM.CellData[DEM.RowCount - 1, DEM.ColCount - 1];
            arr[0, arr.GetLength(1) - 1] = DEM.CellData[0, DEM.ColCount - 1];
            arr[arr.GetLength(0) - 1, 0] = DEM.CellData[DEM.RowCount - 1, 0];
            for (int i = 1; i < arr.GetLength(1) - 1; i++)
                arr[0, i] = DEM.CellData[0, i - 1];
            for (int i = 1; i < arr.GetLength(1) - 1; i++)
                arr[1002, i] = DEM.CellData[1000, i - 1];
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
                arr[i, 0] = DEM.CellData[i - 1, 0];
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
                arr[i, 1002] = DEM.CellData[i - 1, 1000];
            for (int i = 0; i < DEM.RowCount; i++)
                for (int j = 0; j < DEM.ColCount; j++)
                {
                    arr[i + 1, j + 1] = DEM.CellData[i, j];
                }
        }
        private void initialSlopeWE()
        {
            slopeWE = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < slopeWE.GetLength(0); i++)
                for (int j = 0; j < slopeWE.GetLength(1); j++)
                {
                    slopeWE[i, j] = ((arr[i + 2, j] + 2 * arr[i + 1, j] + arr[i, j]) - (arr[i + 2, j + 2] + 2 * arr[i + 1, j + 2] + arr[i, j + 2])) / 240;
                }
        }
        private void initialSlopeSN()
        {
            slopeSN = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < slopeSN.GetLength(0); i++)
                for (int j = 0; j < slopeSN.GetLength(1); j++)
                {
                    slopeSN[i, j] = ((arr[i + 2, j + 2] + 2 * arr[i + 2, j + 1] + arr[i + 2, j]) - (arr[i, j + 2] + 2 * arr[i, j + 1] + arr[i, j])) / 240;
                }
        }
        private void initialSlopeWE1()
        {
            slopeWE1 = new double[slope1.GetLength(0), slope1.GetLength(1)];
            for (int i = 0; i < slopeWE1.GetLength(0) - 2; i++)
                for (int j = 0; j < slopeWE1.GetLength(1) - 2; j++)
                {
                    slopeWE1[i, j] = ((slope1[i + 2, j] + 2 * slope1[i + 1, j] + slope1[i, j]) - (slope1[i + 2, j + 2] + 2 * slope1[i + 1, j + 2] + slope1[i, j + 2])) / 240;
                }
        }
        private void initialSlopeSN1()
        {
            slopeSN1 = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < slopeSN1.GetLength(0) - 2; i++)
                for (int j = 0; j < slopeSN1.GetLength(1) - 2; j++)
                {
                    slopeSN1[i, j] = ((slope1[i + 2, j + 2] + 2 * slope1[i + 2, j + 1] + slope1[i + 2, j]) - (slope1[i, j + 2] + 2 * slope1[i, j + 1] + slope1[i, j])) / 240;
                }
        }

        private void initialSlopeWE2()
        {
            slopeWE2 = new double[aspect1.GetLength(0), aspect1.GetLength(1)];
            for (int i = 0; i < slopeWE2.GetLength(0) - 2; i++)
                for (int j = 0; j < slopeWE2.GetLength(1) - 2; j++)
                {
                    slopeWE2[i, j] = ((aspect1[i + 2, j] + 2 * aspect1[i + 1, j] + aspect1[i, j]) - (aspect1[i + 2, j + 2] + 2 * aspect1[i + 1, j + 2] + aspect1[i, j + 2])) / 240;
                }
        }
        private void initialSlopeSN2()
        {
            slopeSN2 = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < slopeSN2.GetLength(0) - 2; i++)
                for (int j = 0; j < slopeSN2.GetLength(1) - 2; j++)
                {
                    slopeSN2[i, j] = ((aspect1[i + 2, j + 2] + 2 * aspect1[i + 2, j + 1] + aspect1[i + 2, j]) - (aspect1[i, j + 2] + 2 * aspect1[i, j + 1] + aspect1[i, j])) / 240;
                }
        }
        private void 求坡度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            ////初始化pictureBox背景图
            //backImage = new Bitmap(510, 410);
            //g = Graphics.FromImage(backImage);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                DEM = new myDEM(filename);
                Bitmap bm = new Bitmap(DEM.ColCount, DEM.RowCount);
                g = Graphics.FromImage(bm);
                for (int i = 0; i < DEM.ColCount; i++)
                    for (int j = 0; j < DEM.RowCount; j++)
                    {
                        int gray = Convert.ToInt32(DEM.CellData[j, i] * 255 / DEM.MaxZ);
                        if (gray < 0) gray = 0;
                        if (gray > 255) gray = 255;
                        bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                pictureBox1.BackgroundImage = bm;
                arr = new double[DEM.RowCount + 2, DEM.ColCount + 2];
                initialArr();
                initialSlopeWE();
                initialSlopeSN();
            }
        }

        private void 坡度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            slope = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < DEM.RowCount; i++)
                for (int j = 0; j < DEM.ColCount; j++)
                {
                    slope[i, j] = Math.Sqrt(slopeWE[i, j] * slopeWE[i, j] + slopeSN[i, j] * slopeSN[i, j]);
                }
            double maxSlope = -1;
            double minSlope = 100;
            for (int i = 0; i < slope.GetLength(0); i++)
                for (int j = 0; j < slope.GetLength(1); j++)
                {
                    if (slope[i, j] > maxSlope)
                        maxSlope = slope[i, j];
                    if (slope[i, j] < minSlope)
                        minSlope = slope[i, j];
                }
            //MessageBox.Show(maxSlope.ToString()+"\n"+minSlope.ToString());
            Bitmap bm = new Bitmap(slope.GetLength(1), slope.GetLength(0));
            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                {
                    int gray = Convert.ToInt32(slope[j, i] * 255 / maxSlope);
                    bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            pictureBox1.BackgroundImage = bm;
        }

        private void 欧式距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double result = Math.Sqrt(Math.Pow(pointlist[0].X - pointlist[1].X, 2) + Math.Pow(pointlist[0].Y - pointlist[1].Y, 2));
            MessageBox.Show("欧氏距离为" + result);
        }

        private void 绝对值距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double result1 = Math.Abs(pointlist[0].X - pointlist[1].X) + Math.Abs(pointlist[0].Y - pointlist[1].Y);
            MessageBox.Show("绝对值距离为" + result1);
        }

        private void 切氏距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double res = Math.Max(Math.Abs(pointlist[0].X - pointlist[1].X), Math.Abs(pointlist[0].Y - pointlist[1].Y));
            MessageBox.Show("切比雪夫距离为" + res);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void zhixin_Load(object sender, EventArgs e)
        {
            tPoints = 1;
            bitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            newGraphics1 = Graphics.FromImage(bitmap1);
            bitmap2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            newGraphics2 = Graphics.FromImage(bitmap2);
            addbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            addGraphics = Graphics.FromImage(addbitmap);
            unibitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            uniGraphics = Graphics.FromImage(unibitmap);
            abbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            abGraphics = Graphics.FromImage(abbitmap);
            babitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            baGraphics = Graphics.FromImage(babitmap);
        }

        private void 随机生成Voronoi图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backImage = new Bitmap(923, 1045);
            g = Graphics.FromImage(backImage);
            g.SmoothingMode = SmoothingMode.HighQuality;
            //g.Clear(Color.White);

            //将背景图填充到pictureBox中
            pictureBox1.Image = backImage;
            seeder = new Random();
            //g = pictureBox1.CreateGraphics();
            tindv dv1 = new tindv();
            dv1.ShowDialog();

            siteCount = (int)dv1.value;
            //spreadPoints();
            //for (int i = 0; i < voronoiEdgeList.Count; i++)
            //{
            //    CSPoint p1 = new CSPoint((int)trianglesEdgeList[i].a.x, (int)trianglesEdgeList[i].a.y);
            //    CSPoint p2 = new CSPoint((int)trianglesEdgeList[i].b.x, (int)trianglesEdgeList[i].b.y);
            //    g.DrawLine(Pens.Red, p1.X, p1.Y, p2.X, p2.Y);
            //}
            //pictureBox1.Image = backImage;

            //g.Clear(Color.White);
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

        private void 逐点法生成TINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zhudian = 1;
            g = pictureBox1.CreateGraphics();
            barycenter bc = new barycenter();
            bc.CalculateBC(HowMany, dt);
            for (int i = 1; i <= HowMany; i++)
            {
                SolidBrush brush1 = new SolidBrush(Color.Black);
                g.FillEllipse(brush1, Convert.ToInt64(dt.OutHert[i].a), Convert.ToInt64(dt.OutHert[i].b), 4, 4);
            }
            
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
                //pictureBox1.Invalidate();
            }
        }
        private void btn_ConTrace_Click(object sender, EventArgs e)
        {
            conTrace = new C_ContourTrace(trianglate);
            conTrace.d_Max = dMax_Z;
            conTrace.d_Min = dMin_Z;
            conTrace.CTrace_ContourLineTrace();
            //pictureBox1.Invalidate();
        }
        private void voronoi_Resize(object sender, EventArgs e)
        {
            if (str_FilePath != null)
            {
                ReadReguXFile();
                btn_ConTrace_Click(sender, e);
            }
        }


        private void 生成等高线ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    
                    conTrace.CTrace_MarkContourLine(g);
                }

                //三角形 
                if (isDrawTriangle)
                    trianglate.drawtriangle(g);

            }
        }

        private void 等值线平滑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pictureBox1.Invalidate();
            g = pictureBox1.CreateGraphics();
            if (trianglate != null)
            {
                if (conTrace != null && conTrace.list_ContourLine.Count > 0)
                {
                   
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
                    
                    conTrace.CTrace_MarkContourLine(g);
                }

                //三角形 
                if (isDrawTriangle)
                    trianglate.drawtriangle(g);

            }

           
        }

        private void 计算坡向ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aspect = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < DEM.RowCount; i++)
                for (int j = 0; j < DEM.ColCount; j++)
                {
                    if (slopeSN[i, j] == 0 && slopeWE[i, j] == 0)
                        aspect[i, j] = 1000;
                    else
                    {
                        aspect[i, j] = (180 / 3.1415926) * Math.Atan2(slopeSN[i, j], -slopeWE[i, j]);
                        if (aspect[i, j] < 0)
                            aspect[i, j] = 90 - aspect[i, j];
                        else if (aspect[i, j] > 90.0)
                            aspect[i, j] = 360 - aspect[i, j] + 90;
                        else
                            aspect[i, j] = 90 - aspect[i, j];
                    }
                }
            double maxAspect = -10000;
            double minAspect = 100000;
            for (int i = 0; i < aspect.GetLength(0); i++)
                for (int j = 0; j < aspect.GetLength(1); j++)
                {
                    if (aspect[i, j] < 900)
                    {
                        if (aspect[i, j] > maxAspect)
                            maxAspect = aspect[i, j];
                        if (aspect[i, j] < minAspect)
                            minAspect = aspect[i, j];
                    }
                }
            //MessageBox.Show( maxAspect.ToString()+"\n"+minAspect.ToString());
            Bitmap bm = new Bitmap(aspect.GetLength(1), aspect.GetLength(0));
            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                {
                    if (aspect[j, i] < 900)
                    {
                        int gray = Convert.ToInt32((aspect[j, i] - minAspect) * 255 / (maxAspect - minAspect));
                        bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                    else
                    {
                        bm.SetPixel(i, j, Color.FromArgb(65, 105, 255));
                    }
                }
            pictureBox1.BackgroundImage = bm;
        }

        private void 计算坡度变率ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            slope1 = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < DEM.RowCount; i++)
                for (int j = 0; j < DEM.ColCount; j++)
                {
                    slope1[i, j] = Math.Sqrt(slopeWE[i, j] * slopeWE[i, j] + slopeSN[i, j] * slopeSN[i, j]);
                }
            double maxSlope1 = -1;
            double minSlope1 = 100;
            for (int i = 0; i < slope1.GetLength(0); i++)
                for (int j = 0; j < slope1.GetLength(1); j++)
                {
                    if (slope1[i, j] > maxSlope1)
                        maxSlope1 = slope1[i, j];
                    if (slope1[i, j] < minSlope1)
                        minSlope1 = slope1[i, j];
                }
            initialSlopeWE1();
            initialSlopeSN1();
            slope2 = new double[slope1.GetLength(0), slope1.GetLength(1)];
            for (int i = 0; i < DEM.RowCount - 2; i++)
                for (int j = 0; j < DEM.ColCount - 2; j++)
                {
                    slope2[i, j] = Math.Sqrt(slopeWE1[i, j] * slopeWE1[i, j] + slopeSN1[i, j] * slopeSN1[i, j]);
                }
            double maxSlope2 = -1;
            double minSlope2 = 100;
            for (int i = 0; i < slope2.GetLength(0); i++)
                for (int j = 0; j < slope2.GetLength(1); j++)
                {
                    if (slope2[i, j] > maxSlope2)
                        maxSlope2 = slope2[i, j];
                    if (slope2[i, j] < minSlope2)
                        minSlope2 = slope2[i, j];
                }
            //MessageBox.Show(maxSlope.ToString()+"\n"+minSlope.ToString());
            Bitmap bm = new Bitmap(slope2.GetLength(1), slope2.GetLength(0));
            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                {
                    int gray = Convert.ToInt32(slope2[j, i] * 255 / maxSlope2);
                    bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            pictureBox1.BackgroundImage = bm;
        }

        private void 计算坡向变率ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aspect1 = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < DEM.RowCount; i++)
                for (int j = 0; j < DEM.ColCount; j++)
                {
                    if (slopeSN[i, j] == 0 && slopeWE[i, j] == 0)
                        aspect1[i, j] = 1000;
                    else
                    {
                        aspect1[i, j] = (180 / 3.1415926) * Math.Atan2(slopeSN[i, j], -slopeWE[i, j]);
                        if (aspect1[i, j] < 0)
                            aspect1[i, j] = 90 - aspect1[i, j];
                        else if (aspect1[i, j] > 90.0)
                            aspect1[i, j] = 360 - aspect1[i, j] + 90;
                        else
                            aspect1[i, j] = 90 - aspect1[i, j];
                    }
                }
            double maxAspect1 = -10000;
            double minAspect1 = 100000;
            for (int i = 0; i < aspect1.GetLength(0); i++)
                for (int j = 0; j < aspect1.GetLength(1); j++)
                {
                    if (aspect1[i, j] < 900)
                    {
                        if (aspect1[i, j] > maxAspect1)
                            maxAspect1 = aspect1[i, j];
                        if (aspect1[i, j] < minAspect1)
                            minAspect1 = aspect1[i, j];
                    }
                }
            initialSlopeWE2();
            initialSlopeSN2();
            aspect2 = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < DEM.RowCount - 2; i++)
                for (int j = 0; j < DEM.ColCount - 2; j++)
                {
                    if (slopeSN2[i, j] == 0 && slopeWE2[i, j] == 0)
                        aspect2[i, j] = 1000;
                    else
                    {
                        aspect2[i, j] = (180 / 3.1415926) * Math.Atan2(slopeSN2[i, j], -slopeWE2[i, j]);
                        if (aspect2[i, j] < 0)
                            aspect2[i, j] = 90 - aspect2[i, j];
                        else if (aspect2[i, j] > 90.0)
                            aspect2[i, j] = 360 - aspect2[i, j] + 90;
                        else
                            aspect2[i, j] = 90 - aspect2[i, j];
                    }
                }
            double maxAspect2 = -10000;
            double minAspect2 = 100000;
            for (int i = 0; i < aspect2.GetLength(0); i++)
                for (int j = 0; j < aspect2.GetLength(1); j++)
                {
                    if (aspect2[i, j] < 900)
                    {
                        if (aspect2[i, j] > maxAspect2)
                            maxAspect2 = aspect2[i, j];
                        if (aspect2[i, j] < minAspect2)
                            minAspect2 = aspect2[i, j];
                    }
                }
            //MessageBox.Show( maxAspect.ToString()+"\n"+minAspect.ToString());
            Bitmap bm = new Bitmap(aspect2.GetLength(1), aspect2.GetLength(0));
            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                {
                    if (aspect2[j, i] < 900)
                    {
                        int gray = Convert.ToInt32((aspect2[j, i] - minAspect2) * 255 / (maxAspect2 - minAspect2));
                        bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                    else
                    {
                        bm.SetPixel(i, j, Color.FromArgb(65, 105, 255));
                    }
                }
            pictureBox1.BackgroundImage = bm;
        }

        private void 计算地表粗糙度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            slope1 = new double[DEM.RowCount, DEM.ColCount];
            sloper = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < DEM.RowCount; i++)
                for (int j = 0; j < DEM.ColCount; j++)
                {
                    slope1[i, j] = Math.Sqrt(slopeWE[i, j] * slopeWE[i, j] + slopeSN[i, j] * slopeSN[i, j]);
                }
            for (int i = 0; i < DEM.RowCount; i++)
                for (int j = 0; j < DEM.ColCount; j++)
                {
                    sloper[i, j] = 1 / Math.Cos(slope1[i, j]);
                }
            double maxSloper = -1;
            double minSloper = 100;
            for (int i = 0; i < sloper.GetLength(0); i++)
                for (int j = 0; j < sloper.GetLength(1); j++)
                {
                    if (sloper[i, j] > maxSloper)
                        maxSloper = sloper[i, j];
                    if (sloper[i, j] < minSloper)
                        minSloper = sloper[i, j];
                }
            //MessageBox.Show(maxSlope.ToString()+"\n"+minSlope.ToString());
            Bitmap bm = new Bitmap(sloper.GetLength(1), sloper.GetLength(0));
            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                {
                    int gray = Convert.ToInt32(sloper[j, i] * 255 / maxSloper);
                    bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            pictureBox1.BackgroundImage = bm;
        }

        private void 计算地形起伏度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            int h = pictureBox1.Width;
            int f = pictureBox1.Height;
            double ma = 0;
            Bitmap bm = new Bitmap(DEM.ColCount, DEM.RowCount);
            deep = new double[DEM.RowCount, DEM.ColCount];
            HH = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 1; i < DEM.ColCount - 1; i++)
            {
                for (int j = 1; j < DEM.RowCount - 1; j++)
                {
                    double[] num = new double[9];
                    num[0] = DEM.CellData[j, i];
                    num[1] = DEM.CellData[j - 1, i];
                    num[2] = DEM.CellData[j + 1, i];
                    num[3] = DEM.CellData[j, i + 1];
                    num[4] = DEM.CellData[j, i - 1];
                    num[5] = DEM.CellData[j - 1, i - 1];
                    num[6] = DEM.CellData[j - 1, i + 1];
                    num[7] = DEM.CellData[j + 1, i - 1];
                    num[8] = DEM.CellData[j + 1, i + 1];
                    deep[j, i] = num[0];
                    for (int u = 0; u < 8; u++)
                    {
                        ma = Math.Max(num[u], num[u + 1]);
                        num[u + 1] = ma;
                    }

                    for (int z = 0; z < 9; z++)
                    {

                        if (num[z] < deep[j, i])
                        {
                            deep[j, i] = num[z];
                        }
                    }
                    HH[j, i] = ma - deep[j, i];
                }
            }
            double max = -1;

            for (int i = 1; i < DEM.ColCount - 1; i++)//计算最大HH作为分母
            {
                for (int j = 1; j < DEM.RowCount - 1; j++)
                {
                    if (HH[j, i] > max)
                        max = HH[j, i];

                }
            }
            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                {
                    int gray = Convert.ToInt32(HH[j, i] * 255 / max);
                    if (gray < 0) gray = 0;
                    if (gray > 255) gray = 255;
                    bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));

                }
            pictureBox1.BackgroundImage = bm;
        }

        private void 计算地表切割深度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            int h = pictureBox1.Width;
            int f = pictureBox1.Height;
            double average;
            Bitmap bm = new Bitmap(DEM.ColCount, DEM.RowCount);
            deep1 = new double[DEM.RowCount, DEM.ColCount];
            HH1 = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 1; i < DEM.ColCount - 1; i++)
            {
                for (int j = 1; j < DEM.RowCount - 1; j++)
                {
                    double[] num = new double[9];
                    num[0] = DEM.CellData[j, i];
                    num[1] = DEM.CellData[j - 1, i];
                    num[2] = DEM.CellData[j + 1, i];
                    num[3] = DEM.CellData[j, i + 1];
                    num[4] = DEM.CellData[j, i - 1];
                    num[5] = DEM.CellData[j - 1, i - 1];
                    num[6] = DEM.CellData[j - 1, i + 1];
                    num[7] = DEM.CellData[j + 1, i - 1];
                    num[8] = DEM.CellData[j + 1, i + 1];
                    deep1[j, i] = num[0];
                    average = (num[0] + num[1] + num[2] + num[3] + num[4] + num[5] + num[6] + num[7] + num[8]) / 9;
                    for (int z = 0; z < 9; z++)
                    {

                        if (num[z] < deep1[j, i])
                        {
                            deep1[j, i] = num[z];
                        }
                    }
                    HH1[j, i] = average - deep1[j, i];
                }
            }
            double max = -1;

            for (int i = 1; i < DEM.ColCount - 1; i++)//计算最大HH作为分母
            {
                for (int j = 1; j < DEM.RowCount - 1; j++)
                {
                    if (HH1[j, i] > max)
                        max = HH1[j, i];

                }
            }
            for (int i = 0; i < bm.Width; i++)
                for (int j = 0; j < bm.Height; j++)
                {
                    int gray = Convert.ToInt32(HH1[j, i] * 255 / max);
                    if (gray < 0) gray = 0;
                    if (gray > 255) gray = 255;
                    bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));

                }
            pictureBox1.BackgroundImage = bm;
        }

        private void 最小生成树ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pointlist.Count()==0)
            {
                MessageBox.Show("请先画6个点");
            }
            else
            {
            int i, j, L = 0, len;
            int[] X = new int[15];

            X[0] = 6;
            X[1] = 1;
            X[2] = 5;
            X[3] = -1;
            X[4] = -1;
            X[5] = 5;
            X[6] = -1;
            X[7] = 3;
            X[8] = -1;
            X[9] = 2;
            X[10] = 6;
            X[11] = 4;
            X[12] = -1;
            X[13] = 2;
            X[14] = 6;

            int A = 0;
            int B = 0;
            int z = 0;
            string D;

            string[] F = new string[10];
            SolidBrush brush = new SolidBrush(Color.Green);
            List<EDGE> nes = new List<EDGE>();
            for (i = 0; i < 6; i++)//给节点集赋值
            {
                NODE p = new NODE();
                p.num = i;//给节点集中的每个节点赋上编号，并把标签初始化为-1
                p.Tag = -1;
                pList.Add(p);//将节点添加到节点集pList中
            }
            for (i = 0; i < 6; i++)//给边集赋值
            {
                for (j = i + 1; j < 6; j++)
                {

                    EDGE k = new EDGE();
                    k.cost = X[z];//Convert.ToInt32(Console.ReadLine());//边的权值
                    D = k.cost.ToString();
                    k.node1 = i;//边的起点
                    k.node2 = j;//边的终点
                    eList.Add(k);//将边添加到边集eList中
                    if (k.cost > 0)
                    {
                        g.DrawLine(Pens.Black, pointlist[i], pointlist[j]);
                        g.DrawString(D, new Font("宋体", 8f), brush, (pointlist[i].X + pointlist[j].X) / 2, (pointlist[i].Y + pointlist[j].Y) / 2);
                    }
                    z++;
                }
            }
            Ququanzhi(eList, ref nes, ref L);//找出权值大于0的边数
            InsertSort(nes, L); //将权值递增排列
            len = Kruskal(nes, pList, L, eList, 5);
            //SolidBrush brush = new SolidBrush(Color.Green);
            for (i = 0; i < len; i++)
            {
                //Console.WriteLine("树边 {0} :{1}<-->{2}={3}", i + 1, st[i].node1 + 1, st[i].node2 + 1, st[i].cost);
                A = eList[i].node1 + 1;
                B = eList[i].node2 + 1;
                F[i] = eList[i].cost.ToString();
                g.DrawLine(Pens.Red, pointlist[A - 1], pointlist[B - 1]);

                //   g.DrawString(F[i], new Font("宋体", 12f), brush, (pointlist[A - 1].X+ pointlist[B - 1].X)/2, (pointlist[A - 1].Y + pointlist[B - 1].Y) / 2);
            }
            }
            
        }

        public static int Kruskal(List<EDGE> es, List<NODE> set, int length, List<EDGE> st, int num)
        {
            int i, k = 1, m, n, mincost = 0;
            st[0] = es[0];
            m = Find(set, st[0].node1);//在节点集set中查找第一条边的起点，并返回索引值m
            n = Find(set, st[0].node2);//在节点集set中查找第一条遍的终点，并发挥索引值n
            Union(ref set, m, n);//在不构成闭合回路的情况下将两个连通分量合并
            mincost += es[0].cost;
            for (i = 1; i < length; i++) //继续查找其他边
            {
                m = Find(set, es[i].node1);
                n = Find(set, es[i].node2);
                if (m != n)
                {
                    Union(ref set, m, n);
                    st[k] = es[i];
                    mincost += es[i].cost;
                    k++;
                }
                if (k == num) break;
            }
            return k;
        }
        public static void Union(ref List<NODE> set, int elem1, int elem2)
        {
            int m, n, sum;
            m = Find(set, elem1);//找到elem1在节点集set中的子集的索引
            n = Find(set, elem2);//找到elem2在节点集set中的子集的索引
            sum = set[m].Tag + set[n].Tag;//将两个子集合并
            if (set[m].Tag > set[n].Tag)
            {
                set[n].Tag = sum;
                set[m].Tag = n;
            }
            else
            {
                set[m].Tag = sum;
                set[n].Tag = m;
            }
        }
        public static int Find(List<NODE> set, int elem)
        {
            int i, j, k;
            i = elem;
            while (set[i].Tag >= 0)
            {
                i = set[i].Tag;
            }
            j = elem;
            while (j != i)
            {
                k = set[j].Tag;
                set[j].Tag = i;
                j = k;
            }
            return i;
        }
        public static void InsertSort(List<EDGE> dat, int n)//用冒泡法对边的权值进行排序
        {
            int i, j;
            EDGE e = new EDGE();
            for (i = 0; i < n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if (dat[i].cost > dat[j].cost)
                    {
                        e = dat[j];
                        dat[j] = dat[i];
                        dat[i] = e;
                    }
                }
            }
        }
        public static void Ququanzhi(List<EDGE> es, ref List<EDGE> nes, ref int l)
        {
            int i;
            for (i = 0; i < es.Count; i++)
            {
                if (es[i].cost > 0)
                {
                    nes.Add(es[i]);
                }
            }
            l = nes.Count;
        }

        private void diToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pointlist.Count() == 0)
            {
                MessageBox.Show("请先画5个点");
            }
            else
            {
             if (n1 == 0)
            {
                g = pictureBox1.CreateGraphics();
                Pen pen = new Pen(Brushes.Yellow, 2);
                g.DrawString("A", new Font("宋体", 14), Brushes.Red, pointlist[0].X - 18, pointlist[0].Y - 18);
                g.DrawString("B", new Font("宋体", 14), Brushes.Red, pointlist[1].X + 6, pointlist[1].Y + 6);
                g.DrawString("C", new Font("宋体", 14), Brushes.Red, pointlist[2].X - 18, pointlist[2].Y - 18);
                g.DrawString("D", new Font("宋体", 14), Brushes.Red, pointlist[3].X, pointlist[3].Y);
                g.DrawString("E", new Font("宋体", 14), Brushes.Red, pointlist[4].X, pointlist[4].Y - 18);
                g.DrawString("10", new Font("宋体", 8), Brushes.Red, (pointlist[0].X + pointlist[1].X) / 2, (pointlist[0].Y + pointlist[1].Y) / 2);
                g.DrawString("20", new Font("宋体", 8), Brushes.Red, (pointlist[0].X + pointlist[2].X) / 2, (pointlist[0].Y + pointlist[2].Y) / 2);
                g.DrawString("30", new Font("宋体", 8), Brushes.Red, (pointlist[0].X + pointlist[3].X) / 2, (pointlist[0].Y + pointlist[3].Y) / 2);
                g.DrawString("10", new Font("宋体", 8), Brushes.Red, (pointlist[1].X + pointlist[3].X) / 2 - 12, (pointlist[1].Y + pointlist[3].Y) / 2);
                g.DrawString("5", new Font("宋体", 8), Brushes.Red, (pointlist[1].X + pointlist[2].X) / 2 - 12, (pointlist[1].Y + pointlist[2].Y) / 2);
                g.DrawString("30", new Font("宋体", 8), Brushes.Red, (pointlist[2].X + pointlist[4].X) / 2, (pointlist[2].Y + pointlist[4].Y) / 2);
                g.DrawString("20", new Font("宋体", 8), Brushes.Red, (pointlist[3].X + pointlist[4].X) / 2, (pointlist[3].Y + pointlist[4].Y) / 2);
                g.DrawLine(pen, pointlist[0], pointlist[1]);
                g.DrawLine(pen, pointlist[0], pointlist[2]);
                g.DrawLine(pen, pointlist[0], pointlist[3]);
                g.DrawLine(pen, pointlist[1], pointlist[3]);
                g.DrawLine(pen, pointlist[1], pointlist[2]);
                g.DrawLine(pen, pointlist[2], pointlist[4]);
                g.DrawLine(pen, pointlist[3], pointlist[4]);
            }

            djsktra dj1 = new djsktra();
            dj1.ShowDialog();

            W3 = new List<int>();
            t = new int[5, 5];
            //S = new Point[5];
            //Point a = new Point(100, 100);
            //pointlist[0] = a1;
            //Point E = new Point(150, 150);
            //pointlist[1] = E;
            //Point b = new Point(200, 100);
            //pointlist[3] = b;
            //Point c = new Point(200, 200);
            //pointlist[4] = c;
            //Point f = new Point(100, 200);
            //pointlist[2] = f;


            t[0, 1] = 10;
            t[0, 2] = 20;
            t[0, 3] = 30;
            t[0, 4] = 0;
            t[1, 2] = 5;
            t[1, 3] = 10;
            t[1, 4] = 0;
            t[2, 3] = 0;
            t[2, 4] = 30;
            t[3, 4] = 20;
            for (int i = 0; i < 5; i++)
            {
                //t[i, i] = 0;                      
                for (int j = 0; j < 5; j++)
                {
                    t[j, i] = t[i, j];
                }
            }


            n1 = 1;
            int v = 0;
            //int  v = int.Parse(toolStripTextBox1.Text);

            string str = dj1.qidian1;
            switch (str)
            {
                case "A":
                    v = 0; break;
                case "B":
                    v = 1; break;
                case "C":
                    v = 2; break;
                case "D":
                    v = 3; break;
                case "E":
                    v = 4; break;
                default:
                    MessageBox.Show("请输入正确的起点");
                    break;
            }
            int[] d;//最短路径
            shortpan(t, v, out d);
            //for (int i = 0; i < 5; i++)
            //{
            //    listBox1.Items.Add(Convert.ToString(d[i]));
            //}
            }

            
        }

        private void floyd最短路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pointlist.Count() == 0)
            {
                MessageBox.Show("请先画7个点");
            }
            else
            { 
            int[] X1 = new int[21];
            X1[0] = 20;
            X1[1] = 50;
            X1[2] = 30;
            X1[3] = 100;
            X1[4] = 100;
            X1[5] = 100;
            X1[6] = 25;
            X1[7] = 500;
            X1[8] = 100;
            X1[9] = 70;
            X1[10] = 70;
            X1[11] = 40;
            X1[12] = 25;
            X1[13] = 50;
            X1[14] = 10;
            X1[15] = 55;
            X1[16] = 100;
            X1[17] = 100;
            X1[18] = 10;
            X1[19] = 70;
            X1[20] = 50;

            //int A = 0;
            //int B = 0;


            string[] F = new string[10];
            SolidBrush brush = new SolidBrush(Color.Green);

            for (i = 0; i < 7; i++)//给节点集赋值
            {
                NODE p = new NODE();
                p.num = i;//给节点集中的每个节点赋上编号，并把标签初始化为-1
                p.Tag = -1;
                pList.Add(p);//将节点添加到节点集pList中
            }
            for (i = 0; i < 7; i++)//给边集赋值
            {
                for (j = i + 1; j < 7; j++)
                {

                    EDGE k = new EDGE();
                    k.cost = X1[z1];//Convert.ToInt32(Console.ReadLine());//边的权值
                    D = k.cost.ToString();
                    k.node1 = i;//边的起点
                    k.node2 = j;//边的终点
                    eList.Add(k);//将边添加到边集eList中
                    if (k.cost > 0)
                    {
                        g.DrawLine(Pens.Black, pointlist[i], pointlist[j]);
                        g.DrawString(D, new Font("宋体", 8f), brush, (pointlist[i].X + pointlist[j].X) / 2, (pointlist[i].Y + pointlist[j].Y) / 2);
                    }
                    z1++;
                }
            }
            Ququanzhi(eList, ref nes, ref L);//找出权值大于0的边数
            InsertSort(nes, L); //将权值递增排列
            len = Kruskal(nes, pList, L, eList, 5);
            //SolidBrush brush = new SolidBrush(Color.Green);
            //for (i = 0; i < len; i++)
            //{
            //    //Console.WriteLine("树边 {0} :{1}<-->{2}={3}", i + 1, st[i].node1 + 1, st[i].node2 + 1, st[i].cost);
            //    A = eList[i].node1 + 1;
            //    B = eList[i].node2 + 1;
            //    F[i] = eList[i].cost.ToString();
            //    g.DrawLine(Pens.Red, pointlist[A - 1], pointlist[B - 1]);

            //    //   g.DrawString(F[i], new Font("宋体", 12f), brush, (pointlist[A - 1].X+ pointlist[B - 1].X)/2, (pointlist[A - 1].Y + pointlist[B - 1].Y) / 2);
            //}
            g.DrawString("0", new Font("宋体", 14), Brushes.Red, pointlist[0].X - 18, pointlist[0].Y - 18);
            g.DrawString("1", new Font("宋体", 14), Brushes.Red, pointlist[1].X - 18, pointlist[1].Y - 18);
            g.DrawString("2", new Font("宋体", 14), Brushes.Red, pointlist[2].X - 18, pointlist[2].Y - 18);
            g.DrawString("3", new Font("宋体", 14), Brushes.Red, pointlist[3].X - 18, pointlist[3].Y - 18);
            g.DrawString("4", new Font("宋体", 14), Brushes.Red, pointlist[4].X - 18, pointlist[4].Y - 18);
            g.DrawString("5", new Font("宋体", 14), Brushes.Red, pointlist[5].X - 18, pointlist[5].Y - 18);
            g.DrawString("6", new Font("宋体", 14), Brushes.Red, pointlist[6].X - 18, pointlist[6].Y - 18);


            flydd fl1 = new flydd();
            fl1.ShowDialog();




            W4 = new List<int>();
            g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Brushes.Yellow, 2);
            dis = ADD;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    path[i, j] = i;
                    //path[j, i] = j;
                }
            }

            //floyd算法
            for (int k = 0; k < M; k++)
            {
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (dis[i, j] > dis[i, k] + dis[k, j])
                        {
                            dis[i, j] = dis[i, k] + dis[k, j];
                            //dis[j, i] = dis[i, k] + dis[k, j];
                            path[i, j] = k;
                            //path[j, i] = k;
                        }
                    }
                }
            }
            start = fl1.st11;
            end = fl1.ed11;
            showpath(start, end);
            //textBox2.Text = W[0].ToString();
            for (int i = 0; i < W4.Count() - 1; i++)
            {
                g.DrawLine(pen, pointlist[W4[i]], pointlist[W4[i + 1]]);
                ed = W4[i + 1];
            }
            g.DrawLine(pen, pointlist[ed], pointlist[end]);
                MessageBox.Show("最短距离和为" + dis[start, end].ToString());
            //label11.Text = dis[start, end].ToString();//最终距离
             }
               
        }

        void showpath(int s, int e)
        {
            //g = pictureBox1.CreateGraphics();

            if (path[s, e] != e)
            {

                showpath(s, path[s, e]);

            }
            //return;
            //Console.Write(path[s, e].ToString() + " => ");
            //g.DrawLine(pen,pointlist[])
            W4.Add(path[s, e]);

        }

        private void 生成正态云ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zhengtaiy zt1 = new zhengtaiy();
            zt1.ShowDialog();


            DrawYLine(pictureBox1, 1, 10);
            DrawXLine(pictureBox1, 40, 8);
            DrawXY(pictureBox1);


            //pointlist.Clear();
            //pictureBox1.Invalidate();

            //g = pictureBox1.CreateGraphics();//创建画板
            //pictureBox1.Cursor = Cursors.Cross;
            //pen1 = new Pen(Color.Black, 3);
            //drawmode1 = 2;//设置画图类型为画线段
            double x, xx, y, temp;
            double ex, en, he;
            ex = zt1.shang;//熵
            en = zt1.qiwang;//期望
            //he = double.Parse(textBox3.Text);//超熵
            //ex = 10;//熵
            //en = 20;//期望
            he = 0.5;//超熵
            for (int i = 0; i < 1000; i++)//i代表云滴数
            {
                xx = getCouldNumber(en, he, i);
                x = getCouldNumber(ex, xx, i);
                temp = -1 * (x - ex) * (x - ex) / (2 * xx * xx);
                y = Math.Exp(temp);
                cloud.Add(new Drop(x, y));//将云滴添加到云的集合中去
            }
            foreach (Drop p in cloud)//遍历云滴的集合
            {
                PointF t = new PointF((float)p.x, (float)p.y);
                SolidBrush brush = new SolidBrush(Color.Blue);
                Graphics g = pictureBox1.CreateGraphics();
                g.FillEllipse(brush, 150 + t.X * 3, 250 - t.Y * 210, 2, 2);//将云集合中的每一个云滴都绘制到panel上
            }
        }

        private void k均值聚类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pointlist.Count() == 0)
            {
                MessageBox.Show("请先任意画一些点");
            }
            else
            {
                julei jl1 = new julei();
            jl1.ShowDialog();

            int content = jl1.kzhi1;

            if (content != 0)
            {
                int k = content;
                PointF[] center = new PointF[k];
                //初始化中心点
                for (int i = 0; i < k; i++)
                {
                    center[i].X = i * 100;
                    center[i].Y = i * 100;
                }

                //执行聚类函数
                culster(center);
                //渲染点云
                render();
            }

            }
                
        }

        private void 判断点在多边形内ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请单击右键选择点的位置");
        }


        public void GetBufferEdgeCoords(double radius)
        {
            pen1 = new Pen(Color.Black, 3);
            double alpha = 0.0;//Math.PI / 6;
            double gamma = (2 * Math.PI) / N;

            StringBuilder strCoords = new StringBuilder();
            double x = 0.0, y = 0.0;
            for (int i = 0; i < pointlist.Count; i++)
            {
                for (double phi = 0; phi < (N - 1) * gamma; phi += gamma)
                {

                    x = pointlist[i].X + radius * Math.Cos(alpha + phi);
                    y = pointlist[i].Y + radius * Math.Sin(alpha + phi);
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    points.Add(pt1);                  
                    g.FillEllipse(Brushes.Red, Convert.ToInt32(x), Convert.ToInt32(y), 3, 3);
                   
                }
            }          
        }
        private void 点的缓冲区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pointlist.Count() == 0)
            {
                MessageBox.Show("请先画6个点");
            }
            else
            {
               GetBufferEdgeCoords(yuz11);
            }
                
        }

        private void 设置缓冲区阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hc3 = 1;
            huanchyuzhi hc11 = new huanchyuzhi();
            hc11.ShowDialog();
            yuz11 = hc11.hyz;
        }

        private void 线的左侧缓冲区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int tt11;
            //tt11 = Convert.ToInt32(textBox1.Text);
            GetRightBufferEdgeCoords(yuz11);
            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(pen2, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);//画线
            }
        }
        public static double GetQuadrantAngle(float x, float y)
        {
            //float x;
            //float y;

            //for (int i = 1; i < pointlist.Count - 1; i++)
            //{
            //    x = pointlist[i + 1].X - pointlist[i].X;
            //    y = pointlist[i + 1].Y - pointlist[i].Y;
            //}

            double theta = Math.Atan(y / x);
            if (x > 0 && y > 0) return theta;
            if (x > 0 && y < 0) return Math.PI * 2 + theta;
            if (x < 0 && y > 0) return theta + Math.PI;
            if (x < 0 && y < 0) return theta + Math.PI;
            return theta;
        }
        //public static double GetQuadrantAngle(List<PointF> pointlist, List<PointF> pointlist1)
        //{
        //    return GetQuadrantAngle(nextCoord.X - preCoord.X, nextCoord.Y - preCoord.Y);
        //}
        public static double GetIncludedAngel(float x1, float x2, float x3, float y1, float y2, float y3)
        {
            double innerProduct = (x2 - x1) * (x3 - x2) + (y2 - y1) * (y3 - y2);
            double mode1 = Math.Sqrt(Math.Pow((x2 - x1), 2.0) + Math.Pow((y2 - y1), 2.0));
            double mode2 = Math.Sqrt(Math.Pow((x3 - x2), 2.0) + Math.Pow((y3 - y2), 2.0));
            return Math.Acos(innerProduct / (mode1 * mode2));
        }
        private static double GetVectorProduct(float x1, float x2, float x3, float y1, float y2, float y3)
        {
            return (x2 - x1) * (y3 - y2) - (x3 - x2) * (y2 - y1);
        }
        private void GetLeftBufferEdgeCoords(double radius)
        {
            //参数处理
            //if (pointlist.Count < 1) return "";
            //else if (pointlist.Count < 2) return PointBuffer.GetBufferEdgeCoords(pointlist[0], radius);

            //计算时所需变量
            double alpha = 0.0;//向量绕起始点沿顺时针方向旋转到X轴正半轴所扫过的角度
            double delta = 0.0;//前后线段所形成的向量之间的夹角
            double l = 0.0;//前后线段所形成的向量的叉积

            //辅助变量
            StringBuilder strCoords = new StringBuilder();
            double startRadian = 0.0;
            double endRadian = 0.0;
            double beta = 0.0;
            double x = 0.0, y = 0.0;
            x1 = pointlist[1].X - pointlist[0].X;
            y1 = pointlist[1].Y - pointlist[0].Y;


            //第一节点的缓冲区
            {
                alpha = GetQuadrantAngle(x1, y1);
                startRadian = alpha + Math.PI;
                endRadian = alpha + (3 * Math.PI) / 2;
                //strCoords.Append(GetBufferCoordsByRadian(pointlist[0], startRadian, endRadian, radius));
                GetBufferCoordsByRadian(pointlist[0].X, pointlist[0].Y, startRadian, endRadian, radius);
            }
            //for (int i = 1; i < pointlist.Count - 1; i++)
            //{
            //    x2 = pointlist[i + 1].X - pointlist[i].X;
            //    y2 = pointlist[i + 1].Y - pointlist[i].Y;
            //}
            //{
            //    alpha = GetQuadrantAngle(x1, y1);
            //    startRadian = alpha + Math.PI;
            //    endRadian = alpha + (Math.PI) / 2;
            //    //strCoords.Append(GetBufferCoordsByRadian(pointlist[0], startRadian, endRadian, radius));
            //    GetBufferCoordsByRadian(pointlist[0].X, pointlist[0].Y,  endRadian,startRadian, radius);
            //}

            //中间节点
            for (int i = 1; i < pointlist.Count - 1; i++)
            {
                x2 = pointlist[i + 1].X - pointlist[i].X;
                y2 = pointlist[i + 1].Y - pointlist[i].Y;
                alpha = GetQuadrantAngle(x2, y2);
                x3 = pointlist[i - 1].X;
                y3 = pointlist[i - 1].Y;
                x4 = pointlist[i].X;
                y4 = pointlist[i].Y;
                x5 = pointlist[i + 1].X;
                y5 = pointlist[i + 1].Y;

                delta = GetIncludedAngel(x3, x4, x5, y3, y4, y5);
                l = GetVectorProduct(x3, x4, x5, y3, y4, y5);
                if (l > 0)
                {
                    startRadian = alpha + (3 * Math.PI) / 2 - delta;
                    endRadian = alpha + (3 * Math.PI) / 2;
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(GetBufferCoordsByRadian(pointlist[i], startRadian, endRadian, radius));
                    GetBufferCoordsByRadian(x4, y4, startRadian, endRadian, radius);
                }
                else if (l < 0)
                {
                    beta = alpha - (Math.PI - delta) / 2;
                    x = pointlist[i].X + radius * Math.Cos(beta);
                    y = pointlist[i].Y + radius * Math.Sin(beta);
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(x.ToString() + "," + y.ToString());
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    points.Add(pt1);
                    //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);
                }
            }

            //最后一个点
            {
                x6 = pointlist[pointlist.Count - 1].X - pointlist[pointlist.Count - 2].X;
                y6 = pointlist[pointlist.Count - 1].Y - pointlist[pointlist.Count - 2].Y;
                alpha = GetQuadrantAngle(x6, y6);
                startRadian = alpha + (3 * Math.PI) / 2;
                endRadian = alpha + 2 * Math.PI;
                //if (strCoords.Length > 0) strCoords.Append(";");
                //strCoords.Append(GetBufferCoordsByRadian(pointlist[pointlist.Count - 1], startRadian, endRadian, radius));
                GetBufferCoordsByRadian(pointlist[pointlist.Count - 1].X, pointlist[pointlist.Count - 1].Y, startRadian, endRadian, radius);
            }

            //return strCoords.ToString();
        }
        private void GetpolyBufferEdgeCoords(double radius)
        {
            //参数处理
            //if (pointlist.Count < 1) return "";
            //else if (pointlist.Count < 2) return PointBuffer.GetBufferEdgeCoords(pointlist[0], radius);

            //计算时所需变量
            double alpha = 0.0;//向量绕起始点沿顺时针方向旋转到X轴正半轴所扫过的角度
            double delta = 0.0;//前后线段所形成的向量之间的夹角
            double l = 0.0;//前后线段所形成的向量的叉积

            //辅助变量
            StringBuilder strCoords = new StringBuilder();
            double startRadian = 0.0;
            double endRadian = 0.0;
            double beta = 0.0;
            double x = 0.0, y = 0.0;
            x1 = pointlist[1].X - pointlist[0].X;
            y1 = pointlist[1].Y - pointlist[0].Y;


            //第一节点的缓冲区
            //{
            //    alpha = GetQuadrantAngle(x1, y1);
            //    startRadian = alpha + Math.PI;
            //    endRadian = alpha + (3 * Math.PI) / 2;
            //    //strCoords.Append(GetBufferCoordsByRadian(pointlist[0], startRadian, endRadian, radius));
            //    GetBufferCoordsByRadian(pointlist[0].X, pointlist[0].Y, startRadian, endRadian, radius);
            //}
            //for (int i = 1; i < pointlist.Count - 1; i++)
            //{
            //    x2 = pointlist[i + 1].X - pointlist[i].X;
            //    y2 = pointlist[i + 1].Y - pointlist[i].Y;
            //}
            //{
            //    alpha = GetQuadrantAngle(x1, y1);
            //    startRadian = alpha + Math.PI;
            //    endRadian = alpha + (Math.PI) / 2;
            //    //strCoords.Append(GetBufferCoordsByRadian(pointlist[0], startRadian, endRadian, radius));
            //    GetBufferCoordsByRadian(pointlist[0].X, pointlist[0].Y,  endRadian,startRadian, radius);
            //}

            //中间节点
            for (int i = 1; i < pointlist.Count - 2; i++)
            {
                x2 = pointlist[i + 1].X - pointlist[i].X;
                y2 = pointlist[i + 1].Y - pointlist[i].Y;
                alpha = GetQuadrantAngle(x2, y2);
                x3 = pointlist[i - 1].X;
                y3 = pointlist[i - 1].Y;
                x4 = pointlist[i].X;
                y4 = pointlist[i].Y;
                x5 = pointlist[i + 1].X;
                y5 = pointlist[i + 1].Y;

                delta = GetIncludedAngel(x3, x4, x5, y3, y4, y5);
                l = GetVectorProduct(x3, x4, x5, y3, y4, y5);
                if (l > 0)
                {
                    startRadian = alpha + (3 * Math.PI) / 2 - delta;
                    endRadian = alpha + (3 * Math.PI) / 2;
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(GetBufferCoordsByRadian(pointlist[i], startRadian, endRadian, radius));
                    GetBufferCoordsByRadian(x4, y4, startRadian, endRadian, radius);
                }
                else if (l < 0)
                {
                    beta = alpha - (Math.PI - delta) / 2;
                    x = pointlist[i].X + radius * Math.Cos(beta);
                    y = pointlist[i].Y + radius * Math.Sin(beta);
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(x.ToString() + "," + y.ToString());
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    points.Add(pt1);
                    //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);
                }
            }

            //for (int i = 0; i < pointlist.Count - 1; i++)
            {
                x2 = pointlist[0].X - pointlist[pointlist.Count() - 1].X;
                y2 = pointlist[0].Y - pointlist[pointlist.Count() - 1].Y;
                alpha = GetQuadrantAngle(x2, y2);
                x3 = pointlist[pointlist.Count() - 3].X;
                y3 = pointlist[pointlist.Count() - 3].Y;
                x4 = pointlist[pointlist.Count() - 1].X;
                y4 = pointlist[pointlist.Count() - 1].Y;
                x5 = pointlist[0].X;
                y5 = pointlist[0].Y;

                delta = GetIncludedAngel(x3, x4, x5, y3, y4, y5);
                l = GetVectorProduct(x3, x4, x5, y3, y4, y5);
                if (l > 0)
                {
                    startRadian = alpha + (3 * Math.PI) / 2 - delta;
                    endRadian = alpha + (3 * Math.PI) / 2;
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(GetBufferCoordsByRadian(pointlist[i], startRadian, endRadian, radius));
                    GetBufferCoordsByRadian(x4, y4, startRadian, endRadian, radius);
                }
                else if (l < 0)
                {
                    beta = alpha - (Math.PI - delta) / 2;
                    x = x4 + radius * Math.Cos(beta);
                    y = x4 + radius * Math.Sin(beta);
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(x.ToString() + "," + y.ToString());
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    points.Add(pt1);
                    //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);
                }
            }

            //for (int i = 0; i < pointlist.Count - 1; i++)
            {
                x2 = pointlist[1].X - pointlist[0].X;
                y2 = pointlist[1].Y - pointlist[0].Y;
                alpha = GetQuadrantAngle(x2, y2);
                x3 = pointlist[pointlist.Count() - 1].X;
                y3 = pointlist[pointlist.Count() - 1].Y;
                x4 = pointlist[0].X;
                y4 = pointlist[0].Y;
                x5 = pointlist[1].X;
                y5 = pointlist[1].Y;

                delta = GetIncludedAngel(x3, x4, x5, y3, y4, y5);
                l = GetVectorProduct(x3, x4, x5, y3, y4, y5);
                if (l > 0)
                {
                    startRadian = alpha + (3 * Math.PI) / 2 - delta;
                    endRadian = alpha + (3 * Math.PI) / 2;
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(GetBufferCoordsByRadian(pointlist[i], startRadian, endRadian, radius));
                    GetBufferCoordsByRadian(x4, y4, startRadian, endRadian, radius);
                }
                else if (l < 0)
                {
                    beta = alpha - (Math.PI - delta) / 2;
                    x = x4 + radius * Math.Cos(beta);
                    y = x4 + radius * Math.Sin(beta);
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(x.ToString() + "," + y.ToString());
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    points.Add(pt1);
                    //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);
                }
            }


        }

        private void GetRightBufferEdgeCoords(double radius)
        {
            //参数处理
            //if (pointlist.Count < 1) return "";
            //else if (pointlist.Count < 2) return PointBuffer.GetBufferEdgeCoords(pointlist[0], radius);

            //计算时所需变量
            double alpha = 0.0;//向量绕起始点沿顺时针方向旋转到X轴正半轴所扫过的角度
            double delta = 0.0;//前后线段所形成的向量之间的夹角
            double l = 0.0;//前后线段所形成的向量的叉积

            //辅助变量
            StringBuilder strCoords = new StringBuilder();
            double startRadian = 0.0;
            double endRadian = 0.0;
            double beta = 0.0;
            double x = 0.0, y = 0.0;
            //x1 = pointlist[1].X - pointlist[0].X;
            //y1 = pointlist[1].Y - pointlist[0].Y;
            x1 = pointlist[pointlist.Count - 2].X - pointlist[pointlist.Count - 1].X;
            y1 = pointlist[pointlist.Count - 2].Y - pointlist[pointlist.Count - 1].Y;



            //第一节点的缓冲区
            {
                alpha = GetQuadrantAngle(x1, y1);
                startRadian = alpha + Math.PI;
                endRadian = alpha + (3 * Math.PI) / 2;
                //strCoords.Append(GetBufferCoordsByRadian(pointlist[0], startRadian, endRadian, radius));
                GetBufferCoordsByRadian(pointlist[pointlist.Count - 1].X, pointlist[pointlist.Count - 1].Y, startRadian, endRadian, radius);
            }
            //for (int i = 1; i < pointlist.Count - 1; i++)
            //{
            //    x2 = pointlist[i + 1].X - pointlist[i].X;
            //    y2 = pointlist[i + 1].Y - pointlist[i].Y;
            //}
            //{
            //    alpha = GetQuadrantAngle(x1, y1);
            //    startRadian = alpha + Math.PI;
            //    endRadian = alpha + (Math.PI) / 2;
            //    //strCoords.Append(GetBufferCoordsByRadian(pointlist[0], startRadian, endRadian, radius));
            //    GetBufferCoordsByRadian(pointlist[0].X, pointlist[0].Y,  endRadian,startRadian, radius);
            //}

            //中间节点
            for (int i = pointlist.Count - 2; i > 0; i--)
            {
                x2 = pointlist[i - 1].X - pointlist[i].X;
                y2 = pointlist[i - 1].Y - pointlist[i].Y;
                alpha = GetQuadrantAngle(x2, y2);
                x3 = pointlist[i - 1].X;
                y3 = pointlist[i - 1].Y;
                x4 = pointlist[i].X;
                y4 = pointlist[i].Y;
                x5 = pointlist[i + 1].X;
                y5 = pointlist[i + 1].Y;

                delta = GetIncludedAngel(x5, x4, x3, y5, y4, y3);
                l = GetVectorProduct(x5, x4, x3, y5, y4, y3);
                if (l > 0)
                {
                    startRadian = alpha + (3 * Math.PI) / 2 - delta;
                    endRadian = alpha + (3 * Math.PI) / 2;
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(GetBufferCoordsByRadian(pointlist[i], startRadian, endRadian, radius));
                    GetBufferCoordsByRadian(x4, y4, startRadian, endRadian, radius);
                }
                else if (l < 0)
                {
                    beta = alpha - (Math.PI - delta) / 2;
                    //beta = Math.PI - alpha ;
                    //startRadian = beta + (3 * Math.PI) / 2 - delta;
                    //endRadian = beta + (3 * Math.PI) / 2;
                    x = pointlist[i].X + radius * Math.Cos(beta);
                    y = pointlist[i].Y + radius * Math.Sin(beta);
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(x.ToString() + "," + y.ToString());
                    //GetBufferCoordsByRadian(x4, y4, startRadian, endRadian, radius);
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    points.Add(pt1);
                    //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);
                }
            }

            //最后一个点
            {
                x6 = pointlist[0].X - pointlist[1].X;
                y6 = pointlist[0].Y - pointlist[1].Y;
                alpha = GetQuadrantAngle(x6, y6);
                startRadian = alpha + (3 * Math.PI) / 2;
                endRadian = alpha + 2 * Math.PI;
                //if (strCoords.Length > 0) strCoords.Append(";");
                //strCoords.Append(GetBufferCoordsByRadian(pointlist[pointlist.Count - 1], startRadian, endRadian, radius));
                GetBufferCoordsByRadian(pointlist[0].X, pointlist[0].Y, startRadian, endRadian, radius);
            }

            //return strCoords.ToString();
        }

        private void GetpolyneiBufferEdgeCoords(double radius)
        {
            //参数处理
            //if (pointlist.Count < 1) return "";
            //else if (pointlist.Count < 2) return PointBuffer.GetBufferEdgeCoords(pointlist[0], radius);

            //计算时所需变量
            double alpha = 0.0;//向量绕起始点沿顺时针方向旋转到X轴正半轴所扫过的角度
            double delta = 0.0;//前后线段所形成的向量之间的夹角
            double l = 0.0;//前后线段所形成的向量的叉积

            //辅助变量
            StringBuilder strCoords = new StringBuilder();
            double startRadian = 0.0;
            double endRadian = 0.0;
            double beta = 0.0;
            double x = 0.0, y = 0.0;
            //x1 = pointlist[1].X - pointlist[0].X;
            //y1 = pointlist[1].Y - pointlist[0].Y;
            x1 = pointlist[pointlist.Count - 2].X - pointlist[pointlist.Count - 1].X;
            y1 = pointlist[pointlist.Count - 2].Y - pointlist[pointlist.Count - 1].Y;



            ////第一节点的缓冲区
            //{
            //    alpha = GetQuadrantAngle(x1, y1);
            //    startRadian = alpha + Math.PI;
            //    endRadian = alpha + (3 * Math.PI) / 2;
            //    //strCoords.Append(GetBufferCoordsByRadian(pointlist[0], startRadian, endRadian, radius));
            //    GetBufferCoordsByRadian(pointlist[pointlist.Count - 1].X, pointlist[pointlist.Count - 1].Y, startRadian, endRadian, radius);
            //}
            //for (int i = 1; i < pointlist.Count - 1; i++)
            //{
            //    x2 = pointlist[i + 1].X - pointlist[i].X;
            //    y2 = pointlist[i + 1].Y - pointlist[i].Y;
            //}
            //{
            //    alpha = GetQuadrantAngle(x1, y1);
            //    startRadian = alpha + Math.PI;
            //    endRadian = alpha + (Math.PI) / 2;
            //    //strCoords.Append(GetBufferCoordsByRadian(pointlist[0], startRadian, endRadian, radius));
            //    GetBufferCoordsByRadian(pointlist[0].X, pointlist[0].Y,  endRadian,startRadian, radius);
            //}

            //中间节点
            for (int i = pointlist.Count - 3; i > 0; i--)
            {
                x2 = pointlist[i - 1].X - pointlist[i].X;
                y2 = pointlist[i - 1].Y - pointlist[i].Y;
                alpha = GetQuadrantAngle(x2, y2);
                x3 = pointlist[i - 1].X;
                y3 = pointlist[i - 1].Y;
                x4 = pointlist[i].X;
                y4 = pointlist[i].Y;
                x5 = pointlist[i + 1].X;
                y5 = pointlist[i + 1].Y;

                delta = GetIncludedAngel(x5, x4, x3, y5, y4, y3);
                l = GetVectorProduct(x5, x4, x3, y5, y4, y3);
                if (l > 0)
                {
                    startRadian = alpha + (3 * Math.PI) / 2 - delta;
                    endRadian = alpha + (3 * Math.PI) / 2;
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(GetBufferCoordsByRadian(pointlist[i], startRadian, endRadian, radius));
                    GetBufferCoordsByRadian1(x4, y4, startRadian, endRadian, radius);
                }
                else if (l < 0)
                {
                    beta = alpha - (Math.PI - delta) / 2;
                    //beta = Math.PI - alpha ;
                    //startRadian = beta + (3 * Math.PI) / 2 - delta;
                    //endRadian = beta + (3 * Math.PI) / 2;
                    x = pointlist[i].X + radius * Math.Cos(beta);
                    y = pointlist[i].Y + radius * Math.Sin(beta);
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(x.ToString() + "," + y.ToString());
                    //GetBufferCoordsByRadian(x4, y4, startRadian, endRadian, radius);
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    points1.Add(pt1);
                    //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);
                }
            }



            {
                x2 = pointlist[pointlist.Count() - 1].X - pointlist[0].X;
                y2 = pointlist[pointlist.Count() - 1].Y - pointlist[0].Y;
                alpha = GetQuadrantAngle(x2, y2);
                x3 = pointlist[pointlist.Count() - 1].X;
                y3 = pointlist[pointlist.Count() - 1].Y;
                x4 = pointlist[0].X;
                y4 = pointlist[0].Y;
                x5 = pointlist[1].X;
                y5 = pointlist[1].Y;

                delta = GetIncludedAngel(x5, x4, x3, y5, y4, y3);
                l = GetVectorProduct(x5, x4, x3, y5, y4, y3);
                if (l > 0)
                {
                    startRadian = alpha + (3 * Math.PI) / 2 - delta;
                    endRadian = alpha + (3 * Math.PI) / 2;
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(GetBufferCoordsByRadian(pointlist[i], startRadian, endRadian, radius));
                    GetBufferCoordsByRadian1(x4, y4, startRadian, endRadian, radius);
                }
                else if (l < 0)
                {
                    beta = alpha - (Math.PI - delta) / 2;
                    //beta = Math.PI - alpha ;
                    //startRadian = beta + (3 * Math.PI) / 2 - delta;
                    //endRadian = beta + (3 * Math.PI) / 2;
                    x = pointlist[0].X + radius * Math.Cos(beta);
                    y = pointlist[0].Y + radius * Math.Sin(beta);
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(x.ToString() + "," + y.ToString());
                    //GetBufferCoordsByRadian(x4, y4, startRadian, endRadian, radius);
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    points1.Add(pt1);
                    //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);
                }
            }
            {
                x2 = pointlist[pointlist.Count() - 3].X - pointlist[pointlist.Count() - 1].X;
                y2 = pointlist[pointlist.Count() - 3].Y - pointlist[pointlist.Count() - 1].Y;
                alpha = GetQuadrantAngle(x2, y2);
                x3 = pointlist[pointlist.Count() - 3].X;
                y3 = pointlist[pointlist.Count() - 3].Y;
                x4 = pointlist[pointlist.Count() - 1].X;
                y4 = pointlist[pointlist.Count() - 1].Y;
                x5 = pointlist[0].X;
                y5 = pointlist[0].Y;

                delta = GetIncludedAngel(x5, x4, x3, y5, y4, y3);
                l = GetVectorProduct(x5, x4, x3, y5, y4, y3);
                if (l > 0)
                {
                    startRadian = alpha + (3 * Math.PI) / 2 - delta;
                    endRadian = alpha + (3 * Math.PI) / 2;
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(GetBufferCoordsByRadian(pointlist[i], startRadian, endRadian, radius));
                    GetBufferCoordsByRadian1(x4, y4, startRadian, endRadian, radius);
                }
                else if (l < 0)
                {
                    beta = alpha - (Math.PI - delta) / 2;
                    //beta = Math.PI - alpha ;
                    //startRadian = beta + (3 * Math.PI) / 2 - delta;
                    //endRadian = beta + (3 * Math.PI) / 2;
                    x = pointlist[pointlist.Count() - 1].X + radius * Math.Cos(beta);
                    y = pointlist[pointlist.Count() - 1].Y + radius * Math.Sin(beta);
                    //if (strCoords.Length > 0) strCoords.Append(";");
                    //strCoords.Append(x.ToString() + "," + y.ToString());
                    //GetBufferCoordsByRadian(x4, y4, startRadian, endRadian, radius);
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                    points1.Add(pt1);
                    //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);
                }
            }
            ////最后一个点
            //{
            //    x6 = pointlist[0].X - pointlist[1].X;
            //    y6 = pointlist[0].Y - pointlist[1].Y;
            //    alpha = GetQuadrantAngle(x6, y6);
            //    startRadian = alpha + (3 * Math.PI) / 2;
            //    endRadian = alpha + 2 * Math.PI;
            //    //if (strCoords.Length > 0) strCoords.Append(";");
            //    //strCoords.Append(GetBufferCoordsByRadian(pointlist[pointlist.Count - 1], startRadian, endRadian, radius));
            //    GetBufferCoordsByRadian(pointlist[0].X, pointlist[0].Y, startRadian, endRadian, radius);
            //}

            //return strCoords.ToString();
        }
        private void GetBufferCoordsByRadian(float x1, float y1, double startRadian, double endRadian, double radius)
        {
            double gamma = Math.PI / 60;

            StringBuilder strCoords = new StringBuilder();
            double x = 0.0, y = 0.0;
            for (double phi = startRadian; phi <= endRadian + 0.000000000000001; phi += gamma)
            {
                x = x1 + radius * Math.Cos(phi);
                y = y1 + radius * Math.Sin(phi);
                if (strCoords.Length > 0) strCoords.Append(";");
                //strCoords.Append(x.ToString() + "," + y.ToString());
                pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                points.Add(pt1);

                //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);

            }
            //return strCoords.ToString();
        }
        private void GetBufferCoordsByRadian1(float x1, float y1, double startRadian, double endRadian, double radius)
        {
            double gamma = Math.PI / 60;

            StringBuilder strCoords = new StringBuilder();
            double x = 0.0, y = 0.0;
            for (double phi = startRadian; phi <= endRadian + 0.000000000000001; phi += gamma)
            {
                x = x1 + radius * Math.Cos(phi);
                y = y1 + radius * Math.Sin(phi);
                if (strCoords.Length > 0) strCoords.Append(";");
                //strCoords.Append(x.ToString() + "," + y.ToString());
                pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));

                points1.Add(pt1);
                //g.FillEllipse(Brushes.Red, Convert.ToInt32(x - 2), Convert.ToInt32(y - 2), 4, 4);

            }
            //return strCoords.ToString();
        }

        private void 线的右侧缓冲区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetLeftBufferEdgeCoords(yuz11);
            //g.DrawLine(pen2, pointlist[0].X, pointlist[0].Y, points[0].X, points[0].Y);
            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(pen2, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);//画线
            }
        }

        private void 多边形外侧缓冲区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetpolyBufferEdgeCoords(yuz11);
            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(pen2, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);//画线
            }
            g.DrawLine(pen2, points[points.Count() - 1].X, points[points.Count() - 1].Y, points[0].X, points[0].Y);//画线
        }

        private void 多边形内侧缓冲区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int tt11;
            //tt11 = Convert.ToInt32(textBox1.Text);
            GetpolyneiBufferEdgeCoords(yuz11);
            for (int i = 0; i < points1.Count - 1; i++)
            {
                g.DrawLine(pen2, points1[i].X, points1[i].Y, points1[i + 1].X, points1[i + 1].Y);//画线
            }
            g.DrawLine(pen2, points1[points1.Count() - 1].X, points1[points1.Count() - 1].Y, points1[0].X, points1[0].Y);//画线
        }

        private void 散点图生成回归直线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = pointlist.Count();

            if (n < 2)
            {
                MessageBox.Show("请绘制散点！");
            }
            else
            {
                double sumX = 0.0, sumY = 0.0, sumXX = 0.0, sumYY = 0.0, sumXY = 0.0;
                for (int i = 0; i < pointlist.Count(); i++)
                {
                    sumX += pointlist[i].X;    //Σx
                    sumY += pointlist[i].Y;    //Σy
                    sumXX += pointlist[i].X * pointlist[i].X;    //Σx^2
                    sumYY += pointlist[i].Y * pointlist[i].Y;    //Σy^2
                    sumXY += pointlist[i].X * pointlist[i].Y;    //Σxy
                }
                double meanX, meanY;
                meanX = sumX / n;
                meanY = sumY / n;

                //斜率
                double b = (n * sumXY - sumX * sumY) / (n * sumXX - Math.Pow(sumX, 2));
                //截距
                double a = meanY - b * meanX;
                int x0 = 0;
                int y0 = (int)(a + b * x0);
                int x1 = pictureBox1.Width;
                int y1 = (int)(a + b * x1);
                //创建并实例化直线的起点和终点
                Point myPt0 = new Point(x0, y0);
                Point myPt1 = new Point(x1, y1);

                //绘制直线
                Graphics myGra = pictureBox1.CreateGraphics();
                myGra.DrawLine(new Pen(Color.Red, 1), myPt0, myPt1);

                //释放内存
                myGra.Dispose();

            }
        }

        private void 三角网生长法生成TINToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 道格拉斯扑克算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dianchouxi dc1 = new dianchouxi();
            dc1.ShowDialog();
            canshu KB = xielv(points[0].X, points[0].Y, points[points.Count() - 1].X, points[points.Count() - 1].Y);
            //string comboBox1_ = comboBox1.Text;
            float YuZhi = dc1.yz1;
            canshu dis = KB;
            ArrayList list = new ArrayList();
            for (int i = 0; i < points.Count() - 1; i++)
            {
                dis = distance_me(points[i].X, points[i].Y, KB);
                if (dis.k > YuZhi)
                {
                    list.Add(i);
                }
            }

            Graphics g;
            Pen pen1 = new Pen(Color.FromArgb(0, 0, 255), 4);
            g = pictureBox1.CreateGraphics();
            g.DrawLine(pen1, points[0].X, points[0].Y, points[(int)list[0]].X, points[(int)list[0]].Y);
            g.DrawLine(pen1, points[points.Count() - 1].X, points[points.Count() - 1].Y, points[(int)list[list.Count - 1]].X, points[(int)list[list.Count - 1]].Y);
            for (int i = 0; i < list.Count - 1; i++)
            {
                int j = (int)list[i];
                int k = (int)list[i + 1];
                int X11 = points[j].X, Y11 = points[j].Y;
                int X22 = points[k].X, Y22 = points[k].Y;
                g.DrawLine(pen1, X11, Y11, X22, Y22);
            };
        }

        private void 点到曲线的最短距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int b;
            int c;
            int x1;
            int y1;
            int x2;
            int y2;
            int x3;
            int y3;
            int x4;
            int y4;
            Graphics g = pictureBox1.CreateGraphics();
            int j = 0;
            int a = 0;
            Double distance;
            int min = 10000;
            while (j <= i1)
            {
                distance = Math.Sqrt(((pX[0] - pointX[j]) * (pX[0] - pointX[j]) + (pY[0] - pointY[j]) * (pY[0] - pointY[j])));
                if (min > distance)
                {
                    min = Convert.ToInt32(distance);
                    a = j;
                }
                j++;
            }
            b = a + 1;
            c = a - 1;
            if (a == i1)
            {
                x1 = pointX[a];
                y1 = pointY[a];
                x2 = pointX[c];
                y2 = pointY[c];
                x3 = pX[0];
                y3 = pY[0];
                double result = 0;
                double x, ca, cb, ab;
                ca = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
                cb = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
                ab = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                x = Math.Max(ca, cb);
                d = SS(x1, x2, x3, y1, y2, y3);//用海伦公式求出三角形的高
                if (Math.Sqrt(Math.Pow(x, 2) - Math.Pow(d, 2)) > ab)
                    result = Math.Min(ca, cb);

                else
                    result = d;
                //label1.Text = result.ToString();
                MessageBox.Show(result.ToString());

                g.DrawEllipse(Pens.Red, pX[0], pY[0], (float)d, (float)d);
            }
            else if (a == 1)
            {

                x1 = pointX[a];
                y1 = pointY[a];
                x2 = pointX[b];
                y2 = pointY[b];
                x3 = pX[0];
                y3 = pY[0];
                double result = 0;
                double x, ca, cb, ab;
                ca = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
                cb = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
                ab = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                x = Math.Max(ca, cb);
                d = SS(x1, x2, x3, y1, y2, y3);
                if (Math.Sqrt(Math.Pow(x, 2) - Math.Pow(d, 2)) > ab)
                    result = Math.Min(ca, cb);

                else
                    result = d;
                //label1.Text = result.ToString();
                MessageBox.Show(result.ToString());

                g.DrawEllipse(Pens.Red, pX[0], pY[0], (float)d, (float)d);
            }
            else
            {
                x1 = pointX[b];
                y1 = pointY[b];
                x2 = pointX[a];
                y2 = pointY[a];
                x3 = pX[0];
                y3 = pY[0];
                x4 = pointX[c];
                y4 = pointY[c];
                double result = 0, result1 = 0;
                double x, ca, cb, ab;
                ca = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
                cb = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
                ab = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                x = Math.Max(ca, cb);
                d = SS(x1, x2, x3, y1, y2, y3);
                if (Math.Sqrt(Math.Pow(x, 2) - Math.Pow(d, 2)) > ab)
                    result = Math.Min(ca, cb);
                else
                    result = d;

                ca = Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2));
                cb = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
                ab = Math.Sqrt(Math.Pow(x4 - x2, 2) + Math.Pow(y4 - y2, 2));
                x = Math.Max(ca, cb);
                d = SS(x4, x2, x3, y4, y2, y3);
                if (Math.Sqrt(Math.Pow(x, 2) - Math.Pow(d, 2)) > ab)
                    result1 = Math.Min(ca, cb);
                else
                    result1 = d;

                if (result > result1)
                    //label1.Text = result1.ToString();
                MessageBox.Show(result.ToString());
                else
                    //label1.Text = result.ToString();
                MessageBox.Show(result.ToString());

            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.MyFlag = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (z12 == true)
            {
                i1++;
                // this.Text = "X=" + e.X.ToString() + ",Y=" + e.Y.ToString();

                Pen MyPen = new Pen(Color.Black);

                if (this.MyFlag == 0)
                    return;
                else
                {
                    this.MyPoint2.X = e.X;
                    this.MyPoint2.Y = e.Y;
                    pointX[i1] = MyPoint2.X;

                    pointY[i1] = MyPoint2.Y;
                    //   g.DrawEllipse(MyPen, e.X, e.Y, 1, 1);
                    g.DrawLine(MyPen, MyPoint1.X, MyPoint1.Y, MyPoint2.X, MyPoint2.Y);

                    MyPoint1.X = e.X;
                    MyPoint1.Y = e.Y;
                }
            }
            else
                return;
        }

        private void 三角网的表面积与体积计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "文本文件(*.txt)|*.txt";
            openDlg.Title = "选择已知点文件";
            openDlg.ShowHelp = true;

            tijijisuan tj1 = new tijijisuan();
            tj1.ShowDialog();

            //DataTable dt = new DataTable();
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
                            tj1.zdgc = TempStr2[i];
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
                    //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //dataGridView1.AllowUserToAddRows = false;
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

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("顶点1", typeof(String));
            dt1.Columns.Add("顶点2", typeof(String));
            dt1.Columns.Add("顶点3", typeof(String));
            dt1.Columns.Add("体积", typeof(String));
            this.dataGridView1.DataSource = dt1;
            Data.dc_v = new double[L];
            for (int i = 0; i < L; i++)
            {
                DataRow dr = dt1.NewRow();
                dr[0] = Tri[i].Peak[0];
                dr[1] = Tri[i].Peak[1];
                dr[2] = Tri[i].Peak[2];

                double AB = Math.Sqrt((Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[1], 2]) * (Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[1], 2]) + (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[1], 1]) * (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[1], 1]));
                double AC = Math.Sqrt((Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[2], 2]) * (Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[2], 2]) + (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[2], 1]) * (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[2], 1]));
                double BC = Math.Sqrt((Value1[Tri[i].Peak[1], 2] - Value1[Tri[i].Peak[2], 2]) * (Value1[Tri[i].Peak[1], 2] - Value1[Tri[i].Peak[2], 2]) + (Value1[Tri[i].Peak[1], 1] - Value1[Tri[i].Peak[2], 1]) * (Value1[Tri[i].Peak[1], 1] - Value1[Tri[i].Peak[2], 1]));

                double M = (AB + AC + BC) / 2;
                double S = Math.Sqrt(M * (M - AB) * (M - AC) * (M - BC));
                Z = Z + S;
                //this.textBox3.Text = Z.ToString();

                Data.dc_v[i] = S / 3 * (Data.db_h - Value1[Tri[i].Peak[0], 3] + Data.db_h - Value1[Tri[i].Peak[1], 3] + Data.db_h - Value1[Tri[i].Peak[2], 3]);
                Data.dc_v[i] = Math.Round(Data.dc_v[i], 3); Data.dc_v[i] = Math.Abs(Data.dc_v[i]);
                dr[3] = Data.dc_v[i];
                dt1.Rows.Add(dr);
                for (int j = 0; j <= i; j++)
                {
                    x = x + Data.dc_v[j];

                }

                //this.textBox2.Text = x.ToString();
                
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
            MessageBox.Show("总表面积为" + Z.ToString() + "，总体积为" + x.ToString());
            //MessageBox.Show("计算完成！");

        }

        private void 提取洼地点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wadidian wd1 = new wadidian();
            wd1.ShowDialog();
            g = pictureBox1.CreateGraphics();
            string filename = openFileDialog1.FileName;
            DEM = new myDEM(filename);
            Double Center;
            Double Up;
            Double Down;
            Double Left;
            Double Right;
            Double UpLeft;
            Double UpRight;
            Double DownLeft;
            Double DownRight;
            int h = pictureBox1.Width;
            int f = pictureBox1.Height;

            int xx;// = Convert.ToInt32(d * h / 1001);// Convert.ToInt32((b/DEM.ColCount)*d;
            int yy;// = Convert.ToInt32(c * f / 1001); //* pictureBox1.Width;//Convert.ToInt32(a/DEM.RowCount) * f;

            for (int i = 1; i < DEM.ColCount - 1; i++)
            {
                for (int j = 1; j < DEM.RowCount - 1; j++)
                {
                    Center = DEM.CellData[j, i];
                    Up = DEM.CellData[j - 1, i];
                    Down = DEM.CellData[j + 1, i];
                    Right = DEM.CellData[j, i + 1];
                    Left = DEM.CellData[j, i - 1];
                    UpLeft = DEM.CellData[j - 1, i - 1];
                    UpRight = DEM.CellData[j - 1, i + 1];
                    DownLeft = DEM.CellData[j + 1, i - 1];
                    DownRight = DEM.CellData[j + 1, i + 1];

                    xx = Convert.ToInt32(i * h / DEM.ColCount);
                    yy = Convert.ToInt32(j * f / DEM.RowCount);
                    if (Center > wd1.gaoch2)
                        if (Center < Up)
                            if (Center < Down)
                                if (Center < Left)
                                    if (Center < Right)
                                        if (Center < UpLeft)
                                            if (Center < UpRight)
                                                if (Center < DownLeft)
                                                    if (Center < DownRight)
                                                        g.FillEllipse(Brushes.Yellow, xx, yy, 5, 5);





                }
            }
        }

        private void 曲线与面求交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = addbitmap;
            addpolygen = new int[pictureBox1.Width, pictureBox1.Height];
            Bitmap addbm = pictureBox1.Image as Bitmap;
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    addpolygen[i, j] = firstpolygen[i, j] + secondpolygen[i, j];
                    if (addpolygen[i, j] == 4)
                    {
                        addbm.SetPixel(i, j, Color.Red);
                    }
                    else
                    {
                        addbm.SetPixel(i, j, Color.MistyRose);
                    }
                }
            }

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            drawmode = 3;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(drawmode==3)
            {
                //if (listpoint1.Count() != 0 || listpoint3.Count() != 0)
                //{
                //    times = 1;
                //}
                if (times == 0)
                {
                    pictureBox1.Image = bitmap1;
                    Point[] points1 = new Point[listpoint1.Count];
                    firstpolygen = new int[pictureBox1.Width, pictureBox1.Height];
                    for (int i = 0; i < listpoint1.Count; i++)
                    {
                        points1[i] = listpoint1[i];
                    }

                    if (clickcount1 > 3)
                    {
                        System.Drawing.Pen myPen;
                        myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 5);
                        newGraphics1.DrawCurve(myPen, points1, 0, listpoint1.Count - 1, 0.9f);
                        //newGraphics1.DrawCurve.Width(1);
                        Bitmap bm1 = pictureBox1.Image as Bitmap;
                        for (int i = 0; i < pictureBox1.Width; i++)
                        {
                            for (int j = 0; j < pictureBox1.Height; j++)
                            {
                                int R = bm1.GetPixel(i, j).R;
                                int G = bm1.GetPixel(i, j).G;
                                int B = bm1.GetPixel(i, j).B;
                                int colorRGB1 = (R + G + B) / 3;
                                if (colorRGB1 != 0)
                                {
                                    firstpolygen[i, j] = 1;
                                }
                                else
                                {
                                    firstpolygen[i, j] = 0;
                                }
                            }
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("小于3点，无法构成面，请继续点击加点！");
                    //}
                    for (int i = 0; i < firstpolygen.GetLength(0); i++)
                    {
                        for (int j = 0; j < firstpolygen.GetLength(1); j++)
                        {
                            //listBox1.Items.Add(firstpolygen[i, j].ToString());
                        }
                    }
                    times++;
                }
                else if (times == 1)
                {
                    System.Drawing.Pen myPen;
                    myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 5);
                    pictureBox1.Image = bitmap2;
                    Point[] points2 = new Point[listpoint2.Count];
                    secondpolygen = new int[pictureBox1.Width, pictureBox1.Height];
                    for (int i = 0; i < listpoint2.Count; i++)
                    {
                        points2[i] = listpoint2[i];
                    }
                    if (clickcount2 > 3)
                    {
                        newGraphics2.DrawCurve(myPen, points2, 0, listpoint2.Count - 1, 0.9f);
                        Bitmap bm2 = pictureBox1.Image as Bitmap;
                        for (int i = 0; i < pictureBox1.Width; i++)
                        {
                            for (int j = 0; j < pictureBox1.Height; j++)
                            {
                                int R = bm2.GetPixel(i, j).R;
                                int G = bm2.GetPixel(i, j).G;
                                int B = bm2.GetPixel(i, j).B;
                                int colorRGB2 = (R + G + B) / 3;
                                if (colorRGB2 != 0)
                                {
                                    secondpolygen[i, j] = 3;
                                }
                                else
                                {
                                    secondpolygen[i, j] = 0;
                                }
                            }
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("小于3点，无法构成面，请继续点击加点！");
                    //}
                    for (int i = 0; i < secondpolygen.GetLength(0); i++)
                    {
                        for (int j = 0; j < secondpolygen.GetLength(1); j++)
                        {
                            //listBox2.Items.Add(listBox1.Items[i*j]+"&"+secondpolygen[i, j].ToString());
                        }
                    }

                    times++;
                }
                //  if (times == 0)
                //{
                //pictureBox1.Image = bitmap1;
                //Point[] apt = new Point[listpoint1.Count];
                //firstpolygen = new int[pictureBox1.Width, pictureBox1.Height];
                //for (int i = 0; i < listpoint1.Count; i++)
                //{
                //    apt[i] = new Point(listpoint1[i].X, listpoint1[i].Y);
                //}

                //if (clickcount1 > 3)
                //{
                //    System.Drawing.Pen myPen;
                //    myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 3);
                //    newGraphics1.DrawCurve(myPen, apt, 0, listpoint1.Count - 1, 0.9f);
                //    Bitmap bm1 = pictureBox1.Image as Bitmap;
                //    for (int i = 0; i < pictureBox1.Width; i++)
                //    {
                //        for (int j = 0; j < pictureBox1.Height; j++)
                //        {
                //            int R = bm1.GetPixel(i, j).R;
                //            int G = bm1.GetPixel(i, j).G;
                //            int B = bm1.GetPixel(i, j).B;
                //            int colorRGB1 = (R + G + B) / 3;
                //            if (colorRGB1 != 0)
                //            {
                //                firstpolygen[i, j] = 1;
                //            }
                //            else
                //            {
                //                firstpolygen[i, j] = 0;
                //            }
                //        }
                //    }
                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("小于3点，无法构成面，请继续点击加点！");
                //    //}
                //    for (int i = 0; i < firstpolygen.GetLength(0); i++)
                //    {
                //        for (int j = 0; j < firstpolygen.GetLength(1); j++)
                //        {
                //            //listBox1.Items.Add(firstpolygen[i, j].ToString());
                //        }
                //    }
                //    //times++;
                //}
            }
            if(drawmode==4)
            //else if (times == 1)
            {
                //if(listpoint1.Count()!=0||listpoint3.Count()!=0)
                //{
                //    times = 1;
                //}
                if (times == 0)
                {
                    pictureBox1.Image = bitmap1;
                    Point[] points1 = new Point[listpoint3.Count];
                    firstpolygen = new int[pictureBox1.Width, pictureBox1.Height];
                    for (int i = 0; i < listpoint3.Count; i++)
                    {
                        points1[i] = listpoint3[i];
                    }

                    if (clickcount1 > 3)
                    {
                        newGraphics1.FillPolygon(Brushes.Yellow, points1);
                        newGraphics1.DrawLine(Pens.Black, listpoint3[listpoint3.Count - 1], listpoint3[0]);
                        Bitmap bm1 = pictureBox1.Image as Bitmap;
                        for (int i = 0; i < pictureBox1.Width; i++)
                        {
                            for (int j = 0; j < pictureBox1.Height; j++)
                            {
                                int R = bm1.GetPixel(i, j).R;
                                int G = bm1.GetPixel(i, j).G;
                                int B = bm1.GetPixel(i, j).B;
                                int colorRGB1 = (R + G + B) / 3;
                                if (colorRGB1 != 0)
                                {
                                    firstpolygen[i, j] = 1;
                                }
                                else
                                {
                                    firstpolygen[i, j] = 0;
                                }
                            }
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("小于3点，无法构成面，请继续点击加点！");
                    //}
                    for (int i = 0; i < firstpolygen.GetLength(0); i++)
                    {
                        for (int j = 0; j < firstpolygen.GetLength(1); j++)
                        {
                            //listBox1.Items.Add(firstpolygen[i, j].ToString());
                        }
                    }
                    times++;
                }
                else if (times == 1)
                {
                    pictureBox1.Image = bitmap2;
                    Point[] points2 = new Point[listpoint4.Count];
                    secondpolygen = new int[pictureBox1.Width, pictureBox1.Height];
                    for (int i = 0; i < listpoint4.Count; i++)
                    {
                        points2[i] = listpoint4[i];
                    }
                    if (clickcount2 > 3)
                    {
                        newGraphics2.FillPolygon(Brushes.Yellow, points2);
                        newGraphics2.DrawLine(Pens.Black, listpoint4[listpoint4.Count - 1], listpoint4[0]);
                        Bitmap bm2 = pictureBox1.Image as Bitmap;
                        for (int i = 0; i < pictureBox1.Width; i++)
                        {
                            for (int j = 0; j < pictureBox1.Height; j++)
                            {
                                int R = bm2.GetPixel(i, j).R;
                                int G = bm2.GetPixel(i, j).G;
                                int B = bm2.GetPixel(i, j).B;
                                int colorRGB2 = (R + G + B) / 3;
                                if (colorRGB2 != 0)
                                {
                                    secondpolygen[i, j] = 3;
                                }
                                else
                                {
                                    secondpolygen[i, j] = 0;
                                }
                            }
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("小于3点，无法构成面，请继续点击加点！");
                    //}
                    for (int i = 0; i < secondpolygen.GetLength(0); i++)
                    {
                        for (int j = 0; j < secondpolygen.GetLength(1); j++)
                        {
                            //listBox2.Items.Add(listBox1.Items[i*j]+"&"+secondpolygen[i, j].ToString());
                        }
                    }

                    times++;
                }

                //pictureBox1.Image = bitmap2;
                //Point[] points2 = new Point[listpoint2.Count];
                //secondpolygen = new int[pictureBox1.Width, pictureBox1.Height];
                //for (int i = 0; i < listpoint2.Count; i++)
                //{
                //    points2[i] = listpoint2[i];
                //}
                //if (clickcount2 > 3)
                //{
                //    newGraphics2.FillPolygon(Brushes.Blue, points2);
                //    newGraphics2.DrawLine(Pens.Black, listpoint2[listpoint2.Count - 1], listpoint2[0]);
                //    Bitmap bm2 = pictureBox1.Image as Bitmap;
                //    for (int i = 0; i < pictureBox1.Width; i++)
                //    {
                //        for (int j = 0; j < pictureBox1.Height; j++)
                //        {
                //            int R = bm2.GetPixel(i, j).R;
                //            int G = bm2.GetPixel(i, j).G;
                //            int B = bm2.GetPixel(i, j).B;
                //            int colorRGB2 = (R + G + B) / 3;
                //            if (colorRGB2 != 0)
                //            {
                //                secondpolygen[i, j] = 3;
                //            }
                //            else
                //            {
                //                secondpolygen[i, j] = 0;
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("小于3点，无法构成面，请继续点击加点！");
                //}
                //for (int i = 0; i < secondpolygen.GetLength(0); i++)
                //{
                //    for (int j = 0; j < secondpolygen.GetLength(1); j++)
                //    {
                //        //listBox2.Items.Add(listBox1.Items[i*j]+"&"+secondpolygen[i, j].ToString());
                //    }
                //}

                //times++;
            }
           
            
            //else
            //{
            //    MessageBox.Show("请运算！");
            //}
        }

        private void 求交集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (diejia1 == 0)
            //{
            //    MessageBox.Show("请先绘制曲线与面");
            //    diejia1 = 1;
            //    //return;
            //}
            //else
            //{
                pictureBox1.Image = addbitmap;
                addpolygen = new int[pictureBox1.Width, pictureBox1.Height];
                Bitmap addbm = pictureBox1.Image as Bitmap;
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    for (int j = 0; j < pictureBox1.Height; j++)
                    {
                        addpolygen[i, j] = firstpolygen[i, j] + secondpolygen[i, j];
                        if (addpolygen[i, j] == 4)
                        {
                            addbm.SetPixel(i, j, Color.Red);
                        }
                        else
                        {
                            addbm.SetPixel(i, j, Color.MistyRose);
                        }
                    }
                }
            //}
        }

        private void 求并集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = unibitmap;
            unipolygen = new int[pictureBox1.Width, pictureBox1.Height];
            Bitmap unibm = pictureBox1.Image as Bitmap;
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    unipolygen[i, j] = firstpolygen[i, j] + secondpolygen[i, j];
                    if (unipolygen[i, j] == 0)
                    {
                        unibm.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        unibm.SetPixel(i, j, Color.Blue);
                    }
                }
            }
        }

        private void 曲线与面求差集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = abbitmap;
            abpolygen = new int[pictureBox1.Width, pictureBox1.Height];
            Bitmap abbm = pictureBox1.Image as Bitmap;
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    abpolygen[i, j] = firstpolygen[i, j] - secondpolygen[i, j];
                    if (abpolygen[i, j] == 1)
                    {
                        abbm.SetPixel(i, j, Color.Green);
                    }
                    else
                    {
                        abbm.SetPixel(i, j, Color.White);
                    }
                }
            }
        }

        private void 面与曲线求差集ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = babitmap;
            bapolygen = new int[pictureBox1.Width, pictureBox1.Height];
            Bitmap babm = pictureBox1.Image as Bitmap;
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    bapolygen[i, j] = secondpolygen[i, j] - firstpolygen[i, j];
                    if (bapolygen[i, j] == 3)
                    {
                        babm.SetPixel(i, j, Color.Ivory);
                    }
                    else
                    {
                        babm.SetPixel(i, j, Color.White);
                    }
                }
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            drawmode = 3;
            //times = 0;
            clickcount1 = 0;
            clickcount2 = 0;
            //diejia1 = 1;
            bitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            newGraphics1 = Graphics.FromImage(bitmap1);
            bitmap2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            newGraphics2 = Graphics.FromImage(bitmap2);
            addbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            addGraphics = Graphics.FromImage(addbitmap);
            unibitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            uniGraphics = Graphics.FromImage(unibitmap);
            abbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            abGraphics = Graphics.FromImage(abbitmap);
            babitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            baGraphics = Graphics.FromImage(babitmap);

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            drawmode = 4;
            times = 0;
            clickcount1 = 0;
            clickcount2 = 0;
            bitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            newGraphics1 = Graphics.FromImage(bitmap1);
            bitmap2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            newGraphics2 = Graphics.FromImage(bitmap2);
            addbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            addGraphics = Graphics.FromImage(addbitmap);
            unibitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            uniGraphics = Graphics.FromImage(unibitmap);
            abbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            abGraphics = Graphics.FromImage(abbitmap);
            babitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            baGraphics = Graphics.FromImage(babitmap);
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            drawmode = 4;
            //times = 0;
            bitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            newGraphics1 = Graphics.FromImage(bitmap1);
            bitmap2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            newGraphics2 = Graphics.FromImage(bitmap2);
            addbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            addGraphics = Graphics.FromImage(addbitmap);
            unibitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            uniGraphics = Graphics.FromImage(unibitmap);
            abbitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            abGraphics = Graphics.FromImage(abbitmap);
            babitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            baGraphics = Graphics.FromImage(babitmap);
        }

        private void 曲线与曲线求交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = unibitmap;
            unipolygen = new int[pictureBox1.Width, pictureBox1.Height];
            Bitmap unibm = pictureBox1.Image as Bitmap;
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    unipolygen[i, j] = firstpolygen[i, j] + secondpolygen[i, j];
                    if (unipolygen[i, j] == 0)
                    {
                        unibm.SetPixel(i, j, Color.MistyRose);
                    }
                    else
                    {
                        unibm.SetPixel(i, j, Color.Honeydew);
                    }
                }
            }
        }

        private void 面与面求交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = abbitmap;
            abpolygen = new int[pictureBox1.Width, pictureBox1.Height];
            Bitmap abbm = pictureBox1.Image as Bitmap;
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    abpolygen[i, j] = firstpolygen[i, j] - secondpolygen[i, j];
                    if (abpolygen[i, j] == 1)
                    {
                        abbm.SetPixel(i, j, Color.Purple);
                    }
                    else
                    {
                        abbm.SetPixel(i, j, Color.MistyRose);
                    }
                }
            }
        }

        private void 面与曲线求差集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = babitmap;
            bapolygen = new int[pictureBox1.Width, pictureBox1.Height];
            Bitmap babm = pictureBox1.Image as Bitmap;
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    bapolygen[i, j] = secondpolygen[i, j] - firstpolygen[i, j];
                    if (bapolygen[i, j] == 3)
                    {
                        babm.SetPixel(i, j, Color.OrangeRed);
                    }
                    else
                    {
                        babm.SetPixel(i, j, Color.MistyRose);
                    }
                }
            }
        }

        double SS(double x1, double x2, double x3, double y1, double y2, double y3)
        {
            double a = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
            double b = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double c = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            double z = (a + b + c) / 2;
            double S = Math.Sqrt(z * (z - a) * (z - b) * (z - c));
            double h = S / c;
            return h;
        }

        private void 凸壳生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pointlist.Count < 2)
            {
                MessageBox.Show("点太少！");
                return;
            }

            ConvexHull convex = new ConvexHull();
            convex.Points = pointlist;
            convex.GetConvexHull();
            Bitmap bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Graphics gs = Graphics.FromImage(bit);
            PointF[] pointList = convex.HullPoints.ToArray();
            g.DrawLines(new Pen(Color.Red), pointList);
            g.DrawLine(new Pen(Color.Red), pointList[0], pointList[pointList.Length - 1]);
            //pictureBox1.Image = bit;
        }

        private void 提取山顶点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tzhengdian sd1 = new tzhengdian();
            sd1.ShowDialog();
            g = pictureBox1.CreateGraphics();
            double max;
            Double min = Convert.ToDouble(DEM.MaxZ);
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;

            Double H;
            Double D;
            string filename = openFileDialog1.FileName;
            DEM = new myDEM(filename);
            for (int i = 0; i < DEM.ColCount; i++)
            {
                for (int j = 0; j < DEM.RowCount; j++)
                {
                    H = DEM.CellData[j, i];
                    max = Convert.ToDouble(DEM.MaxZ);

                    if (H == max)
                    {
                        // min = H;
                        a = i;
                        b = j;
                    }
                }
            }

            for (int i = 0; i < DEM.ColCount; i++)
            {
                for (int j = 0; j < DEM.RowCount; j++)
                {
                    D = DEM.CellData[j, i];

                    if (D < min)
                    {
                        min = D;
                        c = j;
                        d = i;
                    }
                }
            }
            Double Center;
            Double Up;
            Double Down;
            Double Left;
            Double Right;
            Double UpLeft;
            Double UpRight;
            Double DownLeft;
            Double DownRight;
            int h = pictureBox1.Width;
            int f = pictureBox1.Height;

            int xx;// = Convert.ToInt32(d * h / 1001);// Convert.ToInt32((b/DEM.ColCount)*d;
            int yy;// = Convert.ToInt32(c * f / 1001); //* pictureBox1.Width;//Convert.ToInt32(a/DEM.RowCount) * f;

            for (int i = 1; i < DEM.ColCount - 1; i++)
            {
                for (int j = 1; j < DEM.RowCount - 1; j++)
                {
                    Center = DEM.CellData[j, i];
                    Up = DEM.CellData[j - 1, i];
                    Down = DEM.CellData[j + 1, i];
                    Right = DEM.CellData[j, i + 1];
                    Left = DEM.CellData[j, i - 1];
                    UpLeft = DEM.CellData[j - 1, i - 1];
                    UpRight = DEM.CellData[j - 1, i + 1];
                    DownLeft = DEM.CellData[j + 1, i - 1];
                    DownRight = DEM.CellData[j + 1, i + 1];

                    xx = Convert.ToInt32(i * h / DEM.ColCount);
                    yy = Convert.ToInt32(j * f / DEM.RowCount);
                    if (Center > sd1.gaoch1)
                        if (Center > Up)
                            if (Center > Down)
                                if (Center > Left)
                                    if (Center > Right)
                                        if (Center > UpLeft)
                                            if (Center > UpRight)
                                                if (Center > DownLeft)
                                                    if (Center > DownRight)
                                                        g.FillEllipse(Brushes.Red, xx, yy, 5, 5);





                }
            }
        }

        private void 判断两点之间通视性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tongsh = 1;
            g = pictureBox1.CreateGraphics();
            int h = pictureBox1.Width;
            int f = pictureBox1.Height;
            int c = 0;
            int d = 0;
            Double D;
            W1 = new List<double>();
            int q1 = 0;
            int x1 = Convert.ToInt32(pointlist[0].X) * DEM.ColCount / h;
            int x2 = Convert.ToInt32(pointlist[1].X) * DEM.ColCount / h;
            int y1 = Convert.ToInt32(pointlist[0].Y) * DEM.RowCount / f;
            int y2 = Convert.ToInt32(pointlist[1].Y) * DEM.RowCount / f;

            for (int i = 0; i < DEM.ColCount; i++)
            {
                for (int j = 0; j < DEM.RowCount; j++)
                {
                    double cross = (x2 - x1) * (j - x1) + (y2 - y1) * (i - y1);
                    //if () return false;
                    double d2 = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
                    //if (cross >= d2) return false;
                    if (cross >= 0 && cross <= d2)
                    {
                        double r = cross / d2;
                        px = x1 + (x2 - x1) * r;
                        py = y1 + (y2 - y1) * r;
                    }
                    //判断距离是否小于误差
                    if (Math.Sqrt((j - px) * (j - px) + (py - i) * (py - i)) <= 1)
                    {
                        W1.Add(DEM.CellData[i, j]);
                        g.FillEllipse(Brushes.Red, Convert.ToInt32(j) * h / DEM.ColCount, Convert.ToInt32(i) * f / DEM.RowCount, 3, 3);
                    }
                }
            }
            for (int k = 0; k < W1.Count - 1; k++)
            {
                if (W1[k] > DEM.CellData[x1, y1] || W1[k] > DEM.CellData[x2, y2])
                {
                    q1 = 1;
                }


            }

            if (q1 == 1)
            {
                MessageBox.Show("不可通视");
            }
            if (q1 == 0)
            {
                MessageBox.Show("可以通视");
            }
            //tongsh = 0;
        }

        private void 计算球面距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qiumian qm1 = new qiumian();
            qm1.ShowDialog();
            int Alon_ = qm1.al1;
            int Alat_ = qm1.al2;
            int Blon_ = qm1.bl1;
            int Blat_ = qm1.bl2;
            double res;
            if (Alon_ > 180 || Alat_ > 90 || Blon_ > 180 || Blat_ > 90)
                MessageBox.Show("请输入正确的经纬度");
            else
            {
                res = 6371 * Math.Pow(Math.Abs(Math.Sin(Alat_) * Math.Sin(Blat_) + Math.Cos(Alat_) * Math.Cos(Blat_) * Math.Cos(Alon_ - Blon_)), -1);
                MessageBox.Show("球面距离为："+res.ToString().Substring(0, 8) + "千米");
            }
        }

        private void 线到线的距离ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 多边形面积计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            MessageBox.Show("求得面积为" + CalculateArea(points).ToString());


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

        private void 多边形质心计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.DrawLine(pen1, points[points.Count() - 1].X, points[points.Count() - 1].Y, points[0].X, points[0].Y);

            double x11;
            double y11;
            x11 = CalculateZhixin(points);
            y11 = CalculateZhixinY(points);
            g.FillEllipse(Brushes.Red, Convert.ToInt32(x11 - 2), Convert.ToInt32(y11 - 2), 4, 4);
            MessageBox.Show("平面多边形的质心为" + "(" + CalculateZhixin(points).ToString() + "," + CalculateZhixinY(points).ToString() + ")");
            pictureBox1.Cursor = Cursors.Arrow;
            drawmode = 0;
            clicknum = 0;
            x0 = 0;
            y0 = 0;
            x1 = 0;
            y1 = 0;
            x2 = 0;
            y2 = 0;
        }

        private void 多边形中心计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double x11;
            double y11;
            x11 = GetCenterPoint(points);
            y11 = GetCenterPointY(points);
            g.FillEllipse(Brushes.Red, Convert.ToInt32(x11 - 2), Convert.ToInt32(y11 - 2), 4, 4);

            //g.DrawLine(pen1, x2, y2, x0, y0);
            MessageBox.Show("平面多边形的中心为" + "(" + GetCenterPoint(points).ToString() + "," + GetCenterPointY(points).ToString() + ")");
            //pictureBox1.Cursor = Cursors.Arrow;
            //drawmode = 0;
            //clicknum = 0;
            //x0 = 0;
            //y0 = 0;
            //x1 = 0;
            //y1 = 0;
            //x2 = 0;
            //y2 = 0;
            //points.Clear();
        }

        private void 生成Koch曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();//创建画板
            kochqx kq1 = new kochqx();
            kq1.ShowDialog();
            int tt1 = kq1.value;
            int length = 300;
            Point origin = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);//设置中心点坐标
            Point A = new Point(origin.X - length / 2, (int)(origin.Y + length / (2 * Math.Sqrt(3))));
            Point B = new Point(origin.X, (int)(origin.Y - length / Math.Sqrt(3)));
            Point C = new Point(origin.X + length / 2, (int)(origin.Y + length / (2 * Math.Sqrt(3))));
            ZheXian(A, B, g, tt1);
            ZheXian(B, C, g, tt1);
            ZheXian(C, A, g, tt1);
        }

        private void 生成分形树ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fenxingshu fx1 = new fenxingshu();
            fx1.ShowDialog();
            Point O11 = new Point(pictureBox1.Width / 2, pictureBox1.Height - 30);//设置树根点坐标
            Graphics g = pictureBox1.CreateGraphics();

            Tree(O11, Math.PI / 2, fx1.lent1, fx1.widt1, g);//画分形树
        }

        private void 线状数据压缩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dianchouxi dc1 = new dianchouxi();
            dc1.ShowDialog();
            canshu KB = xielv(points[0].X, points[0].Y, points[points.Count() - 1].X, points[points.Count() - 1].Y);
            //string comboBox1_ = comboBox1.Text;
            float YuZhi = dc1.yz1;
            canshu dis = KB;
            ArrayList list = new ArrayList();
            for (int i = 0; i < points.Count() - 1; i++)
            {
                dis = distance_me(points[i].X, points[i].Y, KB);
                if (dis.k > YuZhi)
                {
                    list.Add(i);
                }
            }

            Graphics g;
            Pen pen1 = new Pen(Color.FromArgb(0, 0, 255), 4);
            g = pictureBox1.CreateGraphics();
            g.DrawLine(pen1, points[0].X, points[0].Y, points[(int)list[0]].X, points[(int)list[0]].Y);
            g.DrawLine(pen1, points[points.Count() - 1].X, points[points.Count() - 1].Y, points[(int)list[list.Count - 1]].X, points[(int)list[list.Count - 1]].Y);
            for (int i = 0; i < list.Count - 1; i++)
            {
                int j = (int)list[i];
                int k = (int)list[i + 1];
                int X11 = points[j].X, Y11 = points[j].Y;
                int X22 = points[k].X, Y22 = points[k].Y;
                g.DrawLine(pen1, X11, Y11, X22, Y22);
            };
        }

        private void 生成风向玫瑰图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog filename = new OpenFileDialog();


            filename.Filter = "All files(*.*)|*.*|txt files(*.txt)|*.txt|dat files(*.dat)|*.dat";
            if (filename.ShowDialog() == DialogResult.OK)
            {
                Filename = filename.FileName.ToString();
                //textBox3.Text = Filename;
            }
            int tu_count = 0;
            int tu_error = 0;

            string[] fx = new string[16] { "E|458|243", "ESE|440|325|", "SE|393|393|", "SSE|320|443|", "S|245|458", "SSW|156|445|", "SW|78|388", "WSW|22|320|", "W|30|243", "WNW|22|166|", "NW|83|88", "NNW|157|40|", "N|245|25", "NNE|320|40|", "NE|397|93", "ENE|440|166|" };////风向标在x,y轴方向的长度
            string[] data = File.ReadAllLines(Filename, Encoding.GetEncoding("GB2312"));
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Trim() != "")
                {
                    string[] split = data[i].Split(new Char[] { '|' });
                    Bitmap image = new Bitmap(480, 480);

                    Graphics g = pictureBox1.CreateGraphics();
                    g.Clear(Color.White);
                    Font font1 = new Font("宋体", 20);
                    Brush brush = new SolidBrush(Color.Black);
                    Pen pen = new Pen(Color.Black, 1);
                    float[] dashValues = { 5, 5 };
                    pen.DashPattern = dashValues;
                    g.DrawString(split[0], font1, brush, 5, 460);
                    for (int j = 0; j < split.Length; j++)
                    {
                        if (split[j].Substring(0, 2) == "C,")
                        {
                            g.DrawString(split[j].Replace(",", "="), font1, brush, 350, 460);
                        }
                    }
                    #region////同心圆
                    string[] yuan = new string[4] { "200,200,100,100", "150,150,200,200", "100,100,300,300", "50,50,400,400" };
                    for (int j = 0; j < yuan.Length; j++)
                    {
                        g.DrawEllipse(pen, int.Parse(yuan[j].Split(new Char[] { ',' })[0]), int.Parse(yuan[j].Split(new Char[] { ',' })[1]), int.Parse(yuan[j].Split(new Char[] { ',' })[2]), int.Parse(yuan[j].Split(new Char[] { ',' })[3]));  //绘制圆，圆心：（x+width/2,y+height/2）
                    }
                    #endregion
                    #region////风向标
                    string[] xian = new string[16];
                    int xian_count = 0;
                    //if (comboBox2.Text == "8风向")
                    //{
                    //xian_count = 8;
                    //}
                    //if (comboBox2.Text == "16风向")
                    //{
                    xian_count = 16;
                    //}
                    for (int j = 0; j < xian_count; j++)
                    {
                        double hudu = (j * 360.0 / double.Parse(xian_count.ToString())) / 180 * Math.PI;
                        //if (comboBox2.Text == "16风向")
                        //{
                        xian[j] = "250,250," + Math.Round(250 + (200 * Math.Cos(hudu)), 0).ToString() + "," + Math.Round(250 + (200 * Math.Sin(hudu)), 0).ToString() + "," + fx[j].Split(new Char[] { '|' })[0] + "," + fx[j].Split(new Char[] { '|' })[1] + "," + fx[j].Split(new Char[] { '|' })[2] + "";
                        //}
                        //if (comboBox2.Text == "8风向")
                        //{
                        //    xian[j] = "250,250," + Math.Round(250 + (200 * Math.Cos(hudu)), 0).ToString() + "," + Math.Round(250 + (200 * Math.Sin(hudu)), 0).ToString() + "," + fx[j * 2].Split(new Char[] { '|' })[0] + "," + fx[j * 2].Split(new Char[] { '|' })[1] + "," + fx[j * 2].Split(new Char[] { '|' })[2] + "";
                        //}
                    }
                    for (int j = 0; j < xian_count; j++)
                    {
                        g.DrawLine(pen, int.Parse(xian[j].Split(new Char[] { ',' })[0]), int.Parse(xian[j].Split(new Char[] { ',' })[1]), int.Parse(xian[j].Split(new Char[] { ',' })[2]), int.Parse(xian[j].Split(new Char[] { ',' })[3]));  //绘制直线
                        g.DrawString(xian[j].Split(new Char[] { ',' })[4], new Font("宋体", 15), brush, int.Parse(xian[j].Split(new Char[] { ',' })[5]), int.Parse(xian[j].Split(new Char[] { ',' })[6]));//图上写文字
                    }
                    #endregion
                    #region////绘制同心圆数值
                    double max_zhi = 0.0;
                    for (int j = 1; j < split.Length; j++)
                    {
                        if (split[j].Trim() != "")
                        {

                            if (split[j].Split(new Char[] { ',' })[0] != "C")
                            {
                                if (double.Parse(split[j].Split(new Char[] { ',' })[1]) > max_zhi)
                                {
                                    max_zhi = double.Parse(split[j].Split(new Char[] { ',' })[1]);
                                }
                            }

                        }
                    }
                    double cha = Math.Ceiling(max_zhi / 4);
                    g.DrawString(cha.ToString(), new Font("宋体", 20), brush, 210, 190);
                    g.DrawString((cha * 2).ToString(), new Font("宋体", 20), brush, 200, 140);
                    g.DrawString((cha * 3).ToString(), new Font("宋体", 20), brush, 190, 90);
                    g.DrawString((cha * 4).ToString(), new Font("宋体", 20), brush, 180, 40);
                    #endregion
                    #region////绘制玫瑰图
                    Point[] points = new Point[xian_count];
                    int points_count = 0;
                    for (int m = 0; m < fx.Length; m++)
                    {
                        double hudu = (m * 360.0 / 16) / 180 * Math.PI;
                        for (int n = 1; n < split.Length; n++)
                        {
                            if (split[n].Split(new Char[] { ',' })[0] == fx[m].Split(new Char[] { '|' })[0])
                            {
                                points[points_count].X = int.Parse(Math.Round(250 + (double.Parse(split[n].Split(new Char[] { ',' })[1]) * 50 * Math.Cos(hudu) / cha), 0).ToString());
                                points[points_count].Y = int.Parse(Math.Round(250 + (double.Parse(split[n].Split(new Char[] { ',' })[1]) * 50 * Math.Sin(hudu) / cha), 0).ToString());
                                points_count++;
                            }
                        }
                    }
                    Pen Polygon_pen = new Pen(Color.Blue, 2);  //创建画笔对象
                    g.DrawPolygon(Polygon_pen, points);  //绘制多边形
                    g.FillPolygon(Brushes.Blue, points);////充填颜色



                    #endregion
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    tu_count++;

                }
            }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //    tu_error++;
            //}
            if (tu_error == 0)
            {
                //MessageBox.Show("共生成图片" + tu_count.ToString() + "张");
            }
            else
            {
                //MessageBox.Show("共生成图片" + tu_count.ToString() + "张，失败" + tu_error.ToString() + "张");
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            //hc3 = 0;
            pointlist.Clear();
            pictureBox1.Invalidate();

            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 0;//设置画图类型为画点
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            pointlist.Clear();
            pictureBox1.Invalidate();

            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 2;//设置画图类型为画线段
        }
    }
    class datatype
    {
        // 点(Vertices)
        public struct dVertex
        {
            public long x;
            public long y;
            public int SUM;//判断点的比较次数
        }

        // 三角形, vv#代表点
        public struct dTriangle
        {
            public long vv0;
            public long vv1;
            public long vv2;
        }

        // 三角形外心结构
        public struct BaryCenter
        {
            public double a;
            public double b;
            public Boolean ID; //判断外心是否连接
            public int NUM;//外心累计连接次数
        }

        //Set these as applicable
        public static long MaxVertices = 300;
        public static long MaxTriangles = 900;
        //Our points
        public dVertex[] Vertex = new dVertex[MaxVertices];
        //Our Created Triangles
        public dTriangle[] Triangle = new dTriangle[MaxTriangles];
        public BaryCenter[] OutHert = new BaryCenter[MaxTriangles];
    }
    class barycenter
    {
        // 计算外接圆圆心
        public void CalculateBC(int Num, datatype dt)
        {
            double x1; double y1; double x2; double y2;
            double x3; double y3; double k1;
            double k2;
            for (int i = 1; i <= Num; i++)
            {
                //计算三角形外接圆
                x1 = dt.Vertex[dt.Triangle[i].vv0].x;
                y1 = dt.Vertex[dt.Triangle[i].vv0].y;
                x2 = dt.Vertex[dt.Triangle[i].vv1].x;
                y2 = dt.Vertex[dt.Triangle[i].vv1].y;
                x3 = dt.Vertex[dt.Triangle[i].vv2].x;
                y3 = dt.Vertex[dt.Triangle[i].vv2].y;
                k1 = (y2 - y1) / (x2 - x1);
                k2 = (y3 - y1) / (x3 - x1);
                dt.OutHert[i].a = (((x1 + x3) / 2) * (1 / k2) - ((x1 + x2) / 2) * (1 / k1) + (y1 + y3) / 2 - (y2 + y1) / 2) / ((1 / k2) - (1 / k1));
                dt.OutHert[i].b = (y2 + y1) / 2 - (1 / k1) * (dt.OutHert[i].a - (x1 + x2) / 2);
                dt.OutHert[i].ID = false;
            }
        }
    }
    class function : tinzhudian
    {
        public static long MaxVertices = 500;
        public static long MaxTriangles = 1000;

        // 三角划分
        public int Triangulate(int nvert, datatype dt)
        {
            //输入NVERT vertices in arrays Vertex()
            //'Returned is a list of NTRI triangular faces in the array
            //'Triangle(). These triangles are arranged in clockwise order.
            Boolean[] Complete = new Boolean[MaxVertices];
            long[,] Edges = new long[3, MaxTriangles * 3];
            long Nedge;
            //超级三角形
            long xmin, xmax, ymin, ymax;
            long xmid, ymid, dx, dy, dmax;
            //普通变量
            int i, j, k, ntri;
            double xc, yc, r;
            Boolean inc;
            //Find the maximum and minimum vertex bounds.
            //This is to allow calculation of the bounding triangle
            xmin = dt.Vertex[1].x; ymin = dt.Vertex[1].y;
            xmax = xmin; ymax = ymin;
            for (i = 2; i <= nvert; i++)
            {
                if (dt.Vertex[i].x < xmin)
                    xmin = dt.Vertex[i].x;
                if (dt.Vertex[i].x > xmax)
                    xmax = dt.Vertex[i].x;
                if (dt.Vertex[i].y < ymin)
                    ymin = dt.Vertex[i].y;
                if (dt.Vertex[i].x > ymax)
                    ymax = dt.Vertex[i].y;
            }
            dx = xmax - xmin; dy = ymax - ymin;
            if (dx > dy)
                dmax = dx;
            else
                dmax = dy;
            xmid = (xmax + xmin) / 2;
            ymid = (ymax + ymin) / 2;
            // 构建超级三角形
            //'This is a triangle which encompasses all the sample points.
            //'The supertriangle coordinates are added to the end of the
            //'vertex list. The supertriangle is the first triangle in
            //'the triangle list.
            dt.Vertex[nvert + 1].x = Convert.ToInt64(xmid - 2 * dmax);
            dt.Vertex[nvert + 1].y = Convert.ToInt64(ymid - dmax);
            dt.Vertex[nvert + 2].x = xmid;
            dt.Vertex[nvert + 2].y = Convert.ToInt64(ymid + 2 * dmax);
            dt.Vertex[nvert + 3].x = Convert.ToInt64(xmid + 2 * dmax);
            dt.Vertex[nvert + 3].y = Convert.ToInt64(ymid - dmax);
            dt.Triangle[1].vv0 = nvert + 1;
            dt.Triangle[1].vv1 = nvert + 2;
            dt.Triangle[1].vv2 = nvert + 3;
            Complete[1] = false;
            ntri = 1; xc = 0; yc = 0; r = 0;
            //Include each point one at a time into the existing mesh
            for (i = 1; i <= nvert; i++)
            {
                Nedge = 0;
                //Set up the edge buffer.
                // If the point (Vertex(i).x,Vertex(i).y) lies inside the circumcircle then the
                // 'three edges of that triangle are added to the edge buffer.
                j = 0;
                do
                {
                    j = j + 1;
                    if (Complete[j] != true)
                    {
                        inc = InCircle(dt.Vertex[i].x, dt.Vertex[i].y, dt.Vertex[dt.Triangle[j].vv0].x, dt.Vertex[dt.Triangle[j].vv0].y, dt.Vertex[dt.Triangle[j].vv1].x, dt.Vertex[dt.Triangle[j].vv1].y, dt.Vertex[dt.Triangle[j].vv2].x, dt.Vertex[dt.Triangle[j].vv2].y, ref xc, ref yc, ref r);
                        if (inc)
                        {
                            Edges[1, Nedge + 1] = dt.Triangle[j].vv0;
                            Edges[2, Nedge + 1] = dt.Triangle[j].vv1;
                            Edges[1, Nedge + 2] = dt.Triangle[j].vv1;
                            Edges[2, Nedge + 2] = dt.Triangle[j].vv2;
                            Edges[1, Nedge + 3] = dt.Triangle[j].vv2;
                            Edges[2, Nedge + 3] = dt.Triangle[j].vv0;
                            Nedge = Nedge + 3;
                            dt.Triangle[j].vv0 = dt.Triangle[ntri].vv0;
                            dt.Triangle[j].vv1 = dt.Triangle[ntri].vv1;
                            dt.Triangle[j].vv2 = dt.Triangle[ntri].vv2;
                            Complete[j] = Complete[ntri];
                            j = j - 1;
                            ntri = ntri - 1;
                        }
                    }
                }
                while (j < ntri);
                for (j = 1; j <= (Nedge - 1); j++)
                {
                    if (!(Edges[1, j] == 0) && !(Edges[2, j] == 0))
                    {
                        for (k = j + 1; k <= Nedge; k++)
                        {
                            if (!((Edges[1, k] == 0)) && !((Edges[2, k] == 0)))
                            {
                                if ((Edges[1, j] == Edges[2, k]))
                                {
                                    if (Edges[2, j] == Edges[1, k])
                                    {
                                        Edges[1, j] = 0;
                                        Edges[2, j] = 0;
                                        Edges[1, k] = 0;
                                        Edges[2, k] = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                //Form new triangles for the current point
                for (j = 1; j <= Nedge; j++)
                {
                    if (!(Edges[1, j] == 0) && !(Edges[2, j] == 0))
                    {
                        ntri = ntri + 1;
                        dt.Triangle[ntri].vv0 = Edges[1, j];
                        dt.Triangle[ntri].vv1 = Edges[2, j];
                        dt.Triangle[ntri].vv2 = i;
                        Complete[ntri] = false;
                    }
                }
            }
            //Remove triangles with supertriangle vertices
            i = 0;
            do
            {
                i = i + 1;
                if (dt.Triangle[i].vv0 > nvert || dt.Triangle[i].vv1 > nvert || dt.Triangle[i].vv2 > nvert)
                {
                    dt.Triangle[i].vv0 = dt.Triangle[ntri].vv0;
                    dt.Triangle[i].vv1 = dt.Triangle[ntri].vv1;
                    dt.Triangle[i].vv2 = dt.Triangle[ntri].vv2;
                    i = i - 1;
                    ntri = ntri - 1;
                }
            }
            while (i < ntri);
            return ntri;
        }

        private Boolean InCircle(double xp, double yp, double x1, double y1, double x2, double y2, double x3, double y3, ref double xc, ref double yc, ref double r)
        {
            //'Return TRUE if the point (xp,yp) lies inside the circumcircle
            //made up by points (x1,y1) (x2,y2) (x3,y3)
            //'The circumcircle centre is returned in (xc,yc) and the radius r
            //'NOTE: A point on the edge is inside the circumcircle
            double eps, m1, m2, mx1, mx2, my1, my2, dx, dy, rsqr, drsqr;
            eps = 0.000001;
            if (System.Math.Abs(y1 - y2) < eps && System.Math.Abs(y2 - y3) < eps)
                MessageBox.Show("there is some problems;");
            if (System.Math.Abs(y2 - y1) < eps)
            {
                m2 = -(x3 - x2) / (y3 - y2);
                mx2 = (x2 + x3) / 2;
                my2 = (y2 + y3) / 2;
                xc = (x2 + x1) / 2;
                yc = m2 * (xc - mx2) + my2;
            }
            else if (System.Math.Abs(y3 - y2) < eps)
            {
                m1 = -(x2 - x1) / (y2 - y1);
                mx1 = (x1 + x2) / 2;
                my1 = (y1 + y2) / 2;
                xc = (x3 + x2) / 2;
                yc = m1 * (xc - mx1) + my1;
            }
            else
            {
                m1 = Convert.ToDouble(((x2 - x1) / (y2 - y1)) - 2 * ((x2 - x1) / (y2 - y1)));
                m2 = Convert.ToDouble(((x3 - x2) / (y3 - y2)) - 2 * ((x3 - x2) / (y3 - y2)));
                mx1 = (x1 + x2) / 2;
                mx2 = (x2 + x3) / 2;
                my1 = (y1 + y2) / 2;
                my2 = (y2 + y3) / 2;
                xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2);
                yc = m1 * (xc - mx1) + my1;
            }
            dx = x2 - xc;
            dy = y2 - yc;
            rsqr = dx * dx + dy * dy;
            r = System.Math.Sqrt(rsqr);
            dx = xp - xc;
            dy = yp - yc;
            drsqr = dx * dx + dy * dy;
            if (drsqr <= rsqr)
                return true;
            return false;
        }
    }
}
