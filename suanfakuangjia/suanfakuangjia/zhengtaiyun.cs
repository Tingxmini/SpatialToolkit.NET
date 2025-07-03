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
    public partial class zhengtaiyun : Form
    {
        public static int phase = 0;
        public static double a = 0, b = 0, d = 0;
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

        public zhengtaiyun()
        {
            InitializeComponent();
        }
        
        private double getCouldNumber(double ex, double e, int i)//获取服从（ex,e2）分布的正态随机数
        {
            return ex + (redomNumber(i) * e);
        }

        private double redomNumber(int i )//获取服从（0,1）分布的正态随机数
        {
            double c ;
            if (phase == 0)
            {
                do
                {                    
                    a = r.NextDouble() * 2 - 1.0;
                    b = r.NextDouble() * 2 - 1.0;
                    d = a * a + b * b;
                }
                while (d == 0 || d >= 1);
                c = a * Math.Sqrt((-2 * Math.Log(d)) / d);
            }
            else
            {
                c = b * Math.Sqrt((-2 * Math.Log(d)) / d);
            }
            phase = 1 - phase;
            return   c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x, xx, y, temp;
            double ex, en, he;
            ex = double.Parse(textBox1.Text);//熵
            en = double.Parse(textBox2.Text);//期望
            he = double.Parse(textBox3.Text);//超熵
            for (int i = 0; i < int.Parse(textBox4.Text); i++)//i代表云滴数
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
                Graphics g = this.panel1.CreateGraphics();
                g.FillEllipse(brush, 150+t.X*3,250- t.Y*210, 2, 2);//将云集合中的每一个云滴都绘制到panel上
            }
        }

        //绘制XY轴
        public static void DrawXY(Panel pan)
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
        public static void DrawYLine(Panel pan, double maxY, int len)
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
        public static void DrawXLine(Panel pan, double maxX, int len)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawYLine(panel1, 1, 10);
            DrawXLine(panel1, 40, 8);
            DrawXY(panel1);
            
        }
    }
}
