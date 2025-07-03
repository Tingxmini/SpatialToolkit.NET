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
    public partial class huanchong : Form
    {
        private int drawmode1 = 0;
        int clicknum = 0;
        public huanchong()
        {
            InitializeComponent();
        }
        List<Point> points = new List<Point>();
        List<Point> points1 = new List<Point>();
        List<Point> points2 = new List<Point>();
        List<PointF> pointlist = new List<PointF>();//存放点数据
        List<PointF> pointlist1 = new List<PointF>();
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
        private Pen pen1;
        Pen pen2= new Pen(Color.HotPink, 3);
        float x1;
        float y1;
        float x0;
        float y0;
        
        float x2;
        float y2;
        float x3;
        float y3;
        float x4;
        float y4;
        float x5;
        float y5;
        float x6;
        float y6;
        float x7;
        float y7;
        float x;
        float y;
        Graphics g;
        public Point p;
        public Point pt1;
        public static int N = 100;
        double startRadian = 0.0;
        double endRadian = 0.0;
        private void button1_Click(object sender, EventArgs e)
        {
            pointlist.Clear();
            pictureBox1.Invalidate();

            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 0;//设置画图类型为画点
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
        }
        public void GetBufferEdgeCoords(double radius)
        {
            pen1 = new Pen(Color.Black, 3);
            double alpha = 0.0;//Math.PI / 6;
            double gamma = (2 * Math.PI) / N;

            StringBuilder strCoords = new StringBuilder();
            double x = 0.0, y = 0.0;
            for (int i = 0; i < pointlist.Count ; i++)
            {
                for (double phi = 0; phi < (N - 1) * gamma; phi += gamma)
            {
                
                x = pointlist[i].X + radius * Math.Cos(alpha + phi);
                y = pointlist[i].Y + radius * Math.Sin(alpha + phi);
                    pt1 = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                points.Add(pt1);

                //if (strCoords.Length > 0) strCoords.Append(";");
                //strCoords.Append(x.ToString() + "," + y.ToString());

                g.FillEllipse(Brushes.Red, Convert.ToInt32(x), Convert.ToInt32(y), 3, 3);
                //g.DrawEllipse(pen1, pointlist[0].X, pointlist[0].Y, Convert.ToInt32(radius), Convert.ToInt32(radius));
            }
            }

            //return strCoords.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetBufferEdgeCoords(30);

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
                x2 = pointlist[pointlist.Count()-3].X - pointlist[pointlist.Count() - 1].X;
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
        private void GetBufferCoordsByRadian(float x1,float y1,double startRadian, double endRadian, double radius)
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

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            points.Clear();
            g = pictureBox1.CreateGraphics();//创建画板



            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 1;//设置画图类型为画多边形或折线
            clicknum = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int tt11;
            tt11 = Convert.ToInt32(textBox1.Text);
            GetLeftBufferEdgeCoords(tt11);
            //g.DrawLine(pen2, pointlist[0].X, pointlist[0].Y, points[0].X, points[0].Y);
            for (int i = 0; i < points.Count-1; i++)
            {
                g.DrawLine(pen2, points[i].X, points[i].Y, points[i+1].X, points[i+1].Y);//画线
            }
            //g.DrawLine(pen2, points[points.Count - 1].X, points[points.Count - 1].Y, pointlist[pointlist.Count - 1].X, pointlist[pointlist.Count - 1].Y);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int tt11;
            tt11 = Convert.ToInt32(textBox1.Text);
            GetRightBufferEdgeCoords(tt11);
            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(pen2, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);//画线
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            points.Clear();
            points1.Clear();
            pointlist.Clear();

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            g.DrawLine(pen1, pointlist[pointlist.Count() - 1].X, pointlist[pointlist.Count() - 1].Y, pointlist[0].X, pointlist[0].Y);
            drawmode = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int tt11;
            tt11 = Convert.ToInt32(textBox1.Text);
            GetpolyBufferEdgeCoords(tt11);
            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(pen2, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);//画线
            }
            g.DrawLine(pen2, points[points.Count() - 1].X, points[points.Count() - 1].Y, points[0].X, points[0].Y);//画线
            //g.FillEllipse(Brushes.Red, pointlist[pointlist.Count() - 1].X, pointlist[pointlist.Count() - 1].Y, 4, 4);
            //g.FillEllipse(Brushes.Red, pointlist[pointlist.Count() - 2].X, pointlist[pointlist.Count() - 2].Y, 4, 4);
            //g.FillEllipse(Brushes.Red, pointlist[0].X, pointlist[0].Y, 4, 4);
            //g.FillEllipse(Brushes.Red, pointlist[pointlist.Count() - 1].X, pointlist[pointlist.Count() - 1].Y, 4, 4);
            //g.FillEllipse(Brushes.Red, pointlist[pointlist.Count() - 1].X, pointlist[pointlist.Count() - 1].Y, 4, 4);
            //g.FillEllipse(Brushes.Red, pointlist[pointlist.Count() - 1].X, pointlist[pointlist.Count() - 1].Y, 4, 4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int tt11;
            tt11 = Convert.ToInt32(textBox1.Text);
            GetpolyneiBufferEdgeCoords(tt11);
            for (int i = 0; i < points1.Count - 1; i++)
            {
                g.DrawLine(pen2, points1[i].X, points1[i].Y, points1[i + 1].X, points1[i + 1].Y);//画线
            }
            g.DrawLine(pen2, points1[points1.Count() - 1].X, points1[points1.Count() - 1].Y, points1[0].X, points1[0].Y);//画线
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

        private void tIN相关算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            voronoi vrn11 = new voronoi();
            vrn11.TopLevel = false;
            vrn11.FormBorderStyle = FormBorderStyle.None;
            vrn11.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(vrn11);
            vrn11.Show();
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
    }
}
