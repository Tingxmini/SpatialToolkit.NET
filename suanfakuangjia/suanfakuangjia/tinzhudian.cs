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
    public partial class tinzhudian : Form
    {
        public int tPoints = 0;
        int HowMany = 0;
        Point point = new Point();
        Point point1 = new Point();
        Point point2 = new Point();
        Point point3 = new Point();
        Pen p = new Pen(Color.Red, 2);
        Pen p3 = new Pen(Color.Yellow, 2);
        Graphics g;
        datatype dt = new datatype();
        // PainOutLine POL = new PainOutLine();
        public tinzhudian()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //Set Vertex coordinates where you clicked the form 
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
                g = this.CreateGraphics();
                g.DrawEllipse(p, e.X, e.Y, 3, 3);
                Update();
            }
            tPoints++;
            Label1.Text = "点个数是 " + tPoints;
            Label2.Text = "三角形个数是" + HowMany;
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
        private void eXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tPoints = 1;
        }
        private void circumcircle_Click(object sender, EventArgs e)
        {
            barycenter bc = new barycenter();
            bc.CalculateBC(HowMany, dt);
            for (int i = 1; i <= HowMany; i++)
            {
                SolidBrush brush1 = new SolidBrush(Color.Black);
                g.FillEllipse(brush1, Convert.ToInt64(dt.OutHert[i].a), Convert.ToInt64(dt.OutHert[i].b), 4, 4);
            }
        }
        private void connect_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 1; i <= HowMany; i++)
            {
                long ax = dt.Vertex[dt.Triangle[i].vv0].x;
                long ay = dt.Vertex[dt.Triangle[i].vv0].y;
                long bx = dt.Vertex[dt.Triangle[i].vv1].x;
                long by = dt.Vertex[dt.Triangle[i].vv1].y;
                long cx = dt.Vertex[dt.Triangle[i].vv2].x;
                long cy = dt.Vertex[dt.Triangle[i].vv2].y;
                bool pointNumvv0 = false;
                bool pointNumvv1 = false;
                bool pointNumvv2 = false;
                dt.Vertex[dt.Triangle[i].vv0].SUM = 0;
                dt.Vertex[dt.Triangle[i].vv1].SUM = 0;
                dt.Vertex[dt.Triangle[i].vv2].SUM = 0;
                dt.OutHert[i].NUM = 0;
                dt.OutHert[i].ID = true;
                count = 1;
                for (int j = 1; j <= HowMany; j++)
                {
                    if (i != j)
                    {
                        if ((dt.Vertex[dt.Triangle[j].vv0].x == ax && dt.Vertex[dt.Triangle[j].vv0].y == ay) || (dt.Vertex[dt.Triangle[j].vv1].x == ax && dt.Vertex[dt.Triangle[j].vv1].y == ay) || (dt.Vertex[dt.Triangle[j].vv2].x == ax && dt.Vertex[dt.Triangle[j].vv2].y == ay))
                        {
                            pointNumvv0 = true;
                            count++;
                            if ((dt.Vertex[dt.Triangle[j].vv0].x == bx && dt.Vertex[dt.Triangle[j].vv0].y == by) || (dt.Vertex[dt.Triangle[j].vv1].x == bx && dt.Vertex[dt.Triangle[j].vv1].y == by) || (dt.Vertex[dt.Triangle[j].vv2].x == bx && dt.Vertex[dt.Triangle[j].vv2].y == by))
                            {
                                pointNumvv1 = true;
                                count++;
                            }
                            if ((dt.Vertex[dt.Triangle[j].vv0].x == cx && dt.Vertex[dt.Triangle[j].vv0].y == cy) || (dt.Vertex[dt.Triangle[j].vv1].x == cx && dt.Vertex[dt.Triangle[j].vv1].y == cy) || (dt.Vertex[dt.Triangle[j].vv2].x == cx && dt.Vertex[dt.Triangle[j].vv2].y == cy))
                            {
                                pointNumvv2 = true;
                                count++;
                            }
                            if (count >= 3)
                            {
                                dt.OutHert[j].ID = true;
                                point1 = new Point(Convert.ToInt32(dt.OutHert[j].a), Convert.ToInt32(dt.OutHert[j].b));
                                point2 = new Point(Convert.ToInt32(dt.OutHert[i].a), Convert.ToInt32(dt.OutHert[i].b));
                                g.DrawLine(p3, point1, point2);
                                if (pointNumvv0 == true)
                                    dt.Vertex[dt.Triangle[i].vv0].SUM++;
                                if (pointNumvv1 == true)
                                    dt.Vertex[dt.Triangle[i].vv1].SUM++;
                                if (pointNumvv2 == true)
                                    dt.Vertex[dt.Triangle[i].vv2].SUM++;
                                pointNumvv0 = false;
                                pointNumvv1 = false;
                                pointNumvv2 = false;
                                count = 1;
                                dt.OutHert[i].NUM++;
                            }
                            count = 1;
                            pointNumvv0 = false;
                            pointNumvv1 = false;
                            pointNumvv2 = false;
                        }
                    }
                    long x1, y1, x2, y2;
                    long xmid = 0;
                    long ymid = 0;
                    int n = i;
                    if (dt.OutHert[n].NUM <= 2)
                    {
                        if (dt.Vertex[dt.Triangle[n].vv0].SUM < 2 && dt.Vertex[dt.Triangle[n].vv1].SUM < 2)
                        {
                            x1 = dt.Vertex[dt.Triangle[n].vv0].x;
                            y1 = dt.Vertex[dt.Triangle[n].vv0].y;
                            x2 = dt.Vertex[dt.Triangle[n].vv1].x;
                            y2 = dt.Vertex[dt.Triangle[n].vv1].y;
                            xmid = (x1 + x2) / 2;
                            ymid = (y1 + y2) / 2;
                            point1 = new Point(Convert.ToInt32(xmid), Convert.ToInt32(ymid));
                            point2 = new Point(Convert.ToInt32(dt.OutHert[n].a), Convert.ToInt32(dt.OutHert[n].b));
                            g.DrawLine(p3, point1, point2);
                        }
                        if (dt.Vertex[dt.Triangle[n].vv0].SUM < 2 && dt.Vertex[dt.Triangle[n].vv2].SUM < 2)
                        {
                            x1 = dt.Vertex[dt.Triangle[n].vv0].x;
                            y1 = dt.Vertex[dt.Triangle[n].vv0].y;
                            x2 = dt.Vertex[dt.Triangle[n].vv2].x;
                            y2 = dt.Vertex[dt.Triangle[n].vv2].y;
                            xmid = (x1 + x2) / 2;
                            ymid = (y1 + y2) / 2;
                            point1 = new Point(Convert.ToInt32(xmid), Convert.ToInt32(ymid));
                            point2 = new Point(Convert.ToInt32(dt.OutHert[n].a), Convert.ToInt32(dt.OutHert[n].b));
                            g.DrawLine(p3, point1, point2);
                        }
                        if (dt.Vertex[dt.Triangle[n].vv2].SUM < 2 && dt.Vertex[dt.Triangle[n].vv1].SUM < 2)
                        {
                            x1 = dt.Vertex[dt.Triangle[n].vv2].x;
                            y1 = dt.Vertex[dt.Triangle[n].vv2].y;
                            x2 = dt.Vertex[dt.Triangle[n].vv1].x;
                            y2 = dt.Vertex[dt.Triangle[n].vv1].y;
                            xmid = (x1 + x2) / 2;
                            ymid = (y1 + y2) / 2;
                            point1 = new Point(Convert.ToInt32(xmid), Convert.ToInt32(ymid));
                            point2 = new Point(Convert.ToInt32(dt.OutHert[n].a), Convert.ToInt32(dt.OutHert[n].b));
                            g.DrawLine(p3, point1, point2);
                        }
                    }
                }
            }
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
    //        public double  a;
    //        public double b;
    //        public Boolean ID; //判断外心是否连接
    //        public int NUM;//外心累计连接次数
    //    }

    //    //Set these as applicable
    //    public static long MaxVertices=300;
    //    public static long MaxTriangles = 900;
    //    //Our points
    //    public dVertex[] Vertex=new dVertex[MaxVertices];
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
    //class function:tinzhudian
    //{
    //    public static long MaxVertices = 500;
    //    public static long MaxTriangles = 1000;

    //    // 三角划分
    //    public int Triangulate(int nvert,datatype dt)
    //    {
    //            //输入NVERT vertices in arrays Vertex()
    //            //'Returned is a list of NTRI triangular faces in the array
    //            //'Triangle(). These triangles are arranged in clockwise order.
    //            Boolean[] Complete=new Boolean[MaxVertices];
    //            long[,] Edges = new long[3, MaxTriangles * 3];
    //            long Nedge;
    //            //超级三角形
    //            long xmin,xmax,ymin, ymax;
    //            long xmid, ymid, dx, dy,dmax;         
    //           //普通变量
    //            int i, j,k,ntri;
    //            double xc,yc, r;
    //            Boolean inc;
    //            //Find the maximum and minimum vertex bounds.
    //            //This is to allow calculation of the bounding triangle
    //            xmin = dt.Vertex[1].x; ymin = dt.Vertex[1].y;
    //            xmax = xmin;  ymax = ymin;
    //            for (i = 2; i <= nvert; i++)
    //            {
    //                if (dt.Vertex[i].x < xmin)
    //                    xmin = dt.Vertex[i].x;
    //                if (dt.Vertex[i].x > xmax )
    //                    xmax = dt.Vertex[i].x;
    //                if (dt.Vertex[i].y  < ymin)
    //                    ymin = dt.Vertex[i].y ;
    //                if (dt.Vertex[i].x > ymax )
    //                    ymax  = dt.Vertex[i].y ;
    //            }
    //            dx = xmax - xmin; dy = ymax - ymin;
    //            if (dx > dy)
    //                dmax = dx;
    //            else
    //                dmax = dy;
    //            xmid = (xmax + xmin) / 2;
    //            ymid = (ymax + ymin) / 2;
    //            // 构建超级三角形
    //            //'This is a triangle which encompasses all the sample points.
    //            //'The supertriangle coordinates are added to the end of the
    //            //'vertex list. The supertriangle is the first triangle in
    //            //'the triangle list.
    //            dt.Vertex[nvert + 1].x =Convert.ToInt64( xmid - 2 * dmax);
    //            dt.Vertex[nvert + 1].y = Convert.ToInt64(ymid - dmax);
    //            dt.Vertex[nvert + 2].x = xmid;
    //            dt.Vertex[nvert + 2].y = Convert.ToInt64(ymid + 2 * dmax);
    //            dt.Vertex[nvert + 3].x = Convert.ToInt64(xmid + 2 * dmax);
    //            dt.Vertex[nvert + 3].y = Convert.ToInt64(ymid - dmax);
    //            dt.Triangle[1].vv0 = nvert + 1;
    //            dt.Triangle[1].vv1 = nvert + 2;
    //            dt.Triangle[1].vv2 = nvert + 3;
    //            Complete[1] = false;
    //            ntri = 1;  xc = 0; yc = 0;  r = 0;
    //            //Include each point one at a time into the existing mesh
    //            for (i = 1; i <= nvert; i++)
    //            {
    //                Nedge = 0;
    //                //Set up the edge buffer.
    //                // If the point (Vertex(i).x,Vertex(i).y) lies inside the circumcircle then the
    //                // 'three edges of that triangle are added to the edge buffer.
    //                j = 0;
    //                do
    //                {
    //                    j = j + 1;
    //                    if (Complete[j] != true)
    //                    {
    //                        inc = InCircle(dt.Vertex[i].x, dt.Vertex[i].y, dt.Vertex[dt.Triangle[j].vv0].x, dt.Vertex[dt.Triangle[j].vv0].y, dt.Vertex[dt.Triangle[j].vv1].x, dt.Vertex[dt.Triangle[j].vv1].y, dt.Vertex[dt.Triangle[j].vv2].x, dt.Vertex[dt.Triangle[j].vv2].y,ref xc, ref yc,ref r);
    //                        if (inc)
    //                        {
    //                            Edges[1, Nedge + 1] = dt.Triangle[j].vv0;
    //                            Edges[2, Nedge + 1] = dt.Triangle[j].vv1;
    //                            Edges[1, Nedge + 2] = dt.Triangle[j].vv1;
    //                            Edges[2, Nedge + 2] = dt.Triangle[j].vv2;
    //                            Edges[1, Nedge + 3] = dt.Triangle[j].vv2;
    //                            Edges[2, Nedge + 3] = dt.Triangle[j].vv0;
    //                            Nedge = Nedge + 3;
    //                            dt.Triangle[j].vv0 = dt.Triangle[ntri].vv0;
    //                            dt.Triangle[j].vv1 = dt.Triangle[ntri].vv1;
    //                            dt.Triangle[j].vv2 = dt.Triangle[ntri].vv2;
    //                            Complete[j] = Complete[ntri];
    //                            j = j - 1;
    //                            ntri = ntri - 1;
    //                        }
    //                    }
    //                }
    //                while (j < ntri);
    //                for(j=1;j<=(Nedge-1);j++)
    //                {
    //                    if( !( Edges[1, j] == 0) && !( Edges[2, j] == 0))
    //                    {
    //                        for (k = j + 1; k <=Nedge; k++)
    //                        {
    //                            if (!((Edges[1, k] == 0)) && !((Edges[2, k] == 0)))
    //                            {
    //                                if ((Edges[1, j] == Edges[2, k]))
    //                                {
    //                                    if (Edges[2, j] == Edges[1, k])
    //                                    {
    //                                        Edges[1, j] = 0;
    //                                        Edges[2, j] = 0;
    //                                        Edges[1, k] = 0;
    //                                        Edges[2, k] = 0;
    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //                //Form new triangles for the current point
    //                for (j = 1; j <= Nedge; j++)
    //                {
    //                    if (!(Edges[1, j] == 0) && !(Edges[2, j] == 0))
    //                    {
    //                        ntri = ntri + 1;
    //                        dt.Triangle[ntri].vv0 = Edges[1, j];
    //                        dt.Triangle[ntri].vv1 = Edges[2, j];
    //                        dt.Triangle[ntri].vv2 = i;
    //                        Complete[ntri] = false;  }}
    //            }
    //            //Remove triangles with supertriangle vertices
    //            i = 0;
    //            do
    //            {
    //                i = i + 1;
    //                if (dt.Triangle[i].vv0 > nvert || dt.Triangle[i].vv1 > nvert || dt.Triangle[i].vv2 > nvert)
    //                {
    //                    dt.Triangle[i].vv0 = dt.Triangle[ntri].vv0;
    //                    dt.Triangle[i].vv1 = dt.Triangle[ntri].vv1;
    //                    dt.Triangle[i].vv2 = dt.Triangle[ntri].vv2;
    //                    i = i - 1;
    //                    ntri = ntri-1;
    //                }
    //            }
    //            while (i < ntri);
    //            return ntri;
    //    }

    //    private Boolean InCircle(double xp, double yp, double x1, double y1, double x2, double y2, double x3, double y3, ref double xc, ref double yc, ref double r)
    //        {
    //            //'Return TRUE if the point (xp,yp) lies inside the circumcircle
    //            //made up by points (x1,y1) (x2,y2) (x3,y3)
    //            //'The circumcircle centre is returned in (xc,yc) and the radius r
    //            //'NOTE: A point on the edge is inside the circumcircle
    //            double eps, m1,m2, mx1,mx2, my1, my2, dx, dy, rsqr, drsqr;
    //            eps = 0.000001;      
    //            if (System.Math.Abs(y1 - y2) < eps && System.Math.Abs(y2 - y3) < eps)
    //                MessageBox.Show("there is some problems;");
    //            if (System.Math.Abs(y2 - y1) < eps)
    //            {
    //                m2 = -(x3 - x2) / (y3 - y2);
    //                mx2 = (x2 + x3) / 2;
    //                my2 = (y2 + y3) / 2;
    //                xc = (x2 + x1) / 2;
    //                yc = m2 * (xc - mx2) + my2;
    //            }
    //            else if (System.Math.Abs(y3 - y2) < eps)
    //            {
    //                m1 = -(x2 - x1) / (y2 - y1);
    //                mx1 = (x1 + x2) / 2;
    //                my1 = (y1 + y2) / 2;
    //                xc = (x3 + x2) / 2;
    //                yc = m1 * (xc - mx1) + my1;
    //            }
    //            else
    //            {
    //                m1 = Convert.ToDouble(((x2 - x1) / (y2 - y1)) -2 * ((x2 - x1) / (y2 - y1)));
    //                m2 = Convert.ToDouble(((x3 - x2) / (y3 - y2)) - 2 * ((x3 - x2) / (y3 - y2)));
    //                mx1 = (x1 + x2) / 2;
    //                mx2 = (x2 + x3) / 2;
    //                my1 = (y1 + y2) / 2;
    //                my2 = (y2 + y3) / 2;
    //                xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2);
    //                yc = m1 * (xc - mx1) + my1;
    //            }
    //            dx = x2 - xc;
    //            dy = y2 - yc;
    //            rsqr = dx * dx + dy * dy;
    //            r = System.Math.Sqrt(rsqr);
    //            dx = xp - xc;
    //            dy = yp - yc;
    //            drsqr = dx * dx + dy * dy;
    //            if (drsqr <= rsqr)
    //                return true;
    //            return false;
    //        }
    //}
}
