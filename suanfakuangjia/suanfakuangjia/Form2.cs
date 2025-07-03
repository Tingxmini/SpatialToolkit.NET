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

namespace suanfakuangjia
{
    public partial class Form2 : Form
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
        public PointF a;
        public double z;
        bool result;


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
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            //System.Drawing.Pen pen = new Pen(Color.Red);
            //if (isDrawing == 1)
            //{
            //    //if (drawpaths.Count >= 1)
            //    //{
            //    //    foreach (List<PointF> drawpath in drawpaths)
            //    //    {
            //    //        if (drawpath.Count >= 2)
            //    //        {
            //    //            e.Graphics.DrawLines(pen, drawpath.ToArray());
            //    //            if (continues.Equals(PointF.Empty) == false)
            //    //            {
            //    //                e.Graphics.DrawLine(pen, start, continues);
            //    //            }
            //    //        }
            //    //        else
            //    //        {
            //    //            if (continues.Equals(PointF.Empty) == false)
            //    //            {
            //    //                e.Graphics.DrawLine(pen, start, continues);
            //    //            }
            //    //        }
            //    //    }
            //    //}
            //    if (drawpathtemp.Count >= 2)
            //    {
            //        e.Graphics.DrawLines(pen, drawpathtemp.ToArray());
            //        if (continues.Equals(PointF.Empty) == false)
            //        {
            //            e.Graphics.DrawLine(pen, start, continues);
            //        }
            //    }
            //    else
            //    {
            //        if (continues.Equals(PointF.Empty) == false)
            //        {
            //            e.Graphics.DrawLine(pen, start, continues);
            //        }
            //    }
            //}
            //else if (isDrawing == 0)
            //{
            //    foreach (List<PointF> drawpath in drawpaths)
            //    {
            //        if (drawpath.Count >= 2)
            //        {
            //            e.Graphics.DrawLines(pen, drawpath.ToArray());
            //        }
            //    }
            //}


        }
        //Region r = new System.Drawing.Region();
        //PointF start = PointF.Empty;
        //PointF continues = PointF.Empty;
        //PointF end = PointF.Empty;
        //int isDrawing = 0;
        //List<List<PointF>> drawpaths = new List<List<PointF>>();
        //List<PointF> drawpathtemp = new List<PointF>();
 private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    //if (isDrawing == 0)
            //    //{
            //    //    start = e.Location;
            //    //    isDrawing = 1;
            //    //    drawpathtemp.Add(start);
            //    //}
            //    //else if (isDrawing == 1)
            //    //{
            //    //    start = e.Location;
            //    //    drawpathtemp.Add(start);
            //    //}
            //    //else if (isDrawing == 2)
            //    //{

            //    //}
            //    //this.Refresh();
            //}
            //if (e.Button == MouseButtons.Right)
            //{
            //    //if (r.IsVisible(e.Location))
            //    //{
            //    //    MessageBox.Show("在多边形内");
            //    //}
            //    //else
            //    //{
            //    //    MessageBox.Show("不在多边形内");
            //    //}
            //    PointF a = new PointF(e.X, e.Y);
            //    IsInside(a);
            //    if(result==true)
            //    {
            //        MessageBox.Show("在多边形内");
            //    }
            //    else
            //    {
            //        MessageBox.Show("不在多边形内");
            //    }

            //}            

        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            //if (isDrawing == 1)
            //{
            //    continues = e.Location;
            //    this.Refresh();
            //}
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.Escape:
            //        drawpathtemp.Add(drawpathtemp.ElementAt(0));
            //        List<PointF> temp = new List<PointF>();
            //        if (drawpathtemp.Count > 2)
            //        {
            //            temp = drawpathtemp.GetRange(0, drawpathtemp.Count);
            //            drawpaths.Add(temp);
            //        }
            //        drawpathtemp.Clear();
            //        start = PointF.Empty;
            //        end = PointF.Empty;
            //        continues = PointF.Empty;
            //        isDrawing = 0;
            //        GraphicsPath gp = new GraphicsPath();
            //        gp.Reset();
            //        foreach (List<PointF> item in drawpaths)
            //        {
            //            gp.AddPolygon(item.ToArray());
            //            r.MakeEmpty();
            //            r.Union(gp);
            //        }
            //        this.Refresh();
            //        break;
            //    default:
            //        break;
            //}

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
            drawmode1 = 1;//设置画图类型为画线

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (pictureBox1.Cursor == Cursors.Cross && drawmode == 1)
            //{//若画线
            //    if (clicknum > 0)
            //    {//若为第一个点
            //        pen1 = mypen;
            //        x2 = e.X;
            //        y2 = e.Y;
            //        Point p = new Point(e.X, e.Y);
            //        points.Add(p);
            //        g.DrawLine(pen1, x1, y1, x2, y2);//画线

            //        x1 = x2;
            //        y1 = y2;
            //    }
            //    else
            //    {
            //        Point p = new Point(e.X, e.Y);
            //        points.Add(p);
            //        x0 = e.X;
            //        y0 = e.Y;
            //        x1 = e.X;
            //        y1 = e.Y;
            //    }
            //    clicknum = clicknum + 1;
            //}
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
            g.DrawLine(pen1, x2, y2, x0, y0);
            drawmode = 0;
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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
if (e.Button == MouseButtons.Left)
            {
                //if (isDrawing == 0)
                //{
                //    start = e.Location;
                //    isDrawing = 1;
                //    drawpathtemp.Add(start);
                //}
                //else if (isDrawing == 1)
                //{
                //    start = e.Location;
                //    drawpathtemp.Add(start);
                //}
                //else if (isDrawing == 2)
                //{

                //}
                //this.Refresh();
            }
            if (e.Button == MouseButtons.Right)
            {
                //if (r.IsVisible(e.Location))
                //{
                //    MessageBox.Show("在多边形内");
                //}
                //else
                //{
                //    MessageBox.Show("不在多边形内");
                //}
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
    }
}
