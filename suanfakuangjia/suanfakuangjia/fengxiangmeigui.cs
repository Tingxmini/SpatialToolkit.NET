using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;  //添加引用
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions; 

namespace suanfakuangjia
{
    public partial class fengxiangmeigui : Form
    {
        public fengxiangmeigui()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            file1.InitialDirectory = "d:\\";
            file1.Filter = "文本文件|*.txt";
            file1.RestoreDirectory = true;
            file1.FilterIndex = 1;
            if (file1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file1.FileName;
            }
            else
            {
                MessageBox.Show("请选择文件!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jieshi shuoming = new jieshi();
            shuoming.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {//10月CH7Avg|NNE,148|NE,80|ENE,52|E,60|ESE,126|SE,341|SSE,512|S,296|SSW,222|SW,226|WSW,319|W,440|WNW,421|NW,503|NNW,363|N,355
            //10月CH7Avg|NE,80|E,60|SE,341|S,296|SW,226|W,440|NW,503|N,355
            int tu_count = 0;
            int tu_error = 0;
            //try
            //{
            string[] fx = new string[16] { "E|458|243", "ESE|440|325|", "SE|393|393|", "SSE|320|443|", "S|245|458", "SSW|156|445|", "SW|78|388", "WSW|22|320|", "W|30|243", "WNW|22|166|", "NW|83|88", "NNW|157|40|", "N|245|25", "NNE|320|40|", "NE|397|93", "ENE|440|166|" };////风向标在x,y轴方向的长度
                string[] data = File.ReadAllLines(textBox1.Text, Encoding.GetEncoding("GB2312"));
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Trim() != "")
                    {
                        string[] split = data[i].Split(new Char[] { '|' });
                        Bitmap image = new Bitmap(500, 500);
                    //Graphics g = Graphics.FromImage(image);  //创建画布
                    Graphics g = pictureBox1.CreateGraphics();
                    g.Clear(Color.White);   //清空背景色
                        Font font1 = new Font("宋体", 20);   //设置字体类型和大小
                        Brush brush = new SolidBrush(Color.Black);  //设置画刷颜色
                        Pen pen = new Pen(Color.Black, 1);  //创建画笔对象
                        float[] dashValues = { 5, 5 };
                        pen.DashPattern = dashValues;
                        g.DrawString(split[0], font1, brush, 5, 460);//图上写文字
                        for (int j = 0; j < split.Length; j++)
                        {
                            if (split[j].Substring(0, 2) == "C,")
                            {
                                g.DrawString(split[j].Replace(",","="), font1, brush, 350, 460);//图上写文字
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
                        if (comboBox1.Text == "8风向")
                        {
                            xian_count = 8;
                        }
                        if (comboBox1.Text == "16风向")
                        {
                            xian_count = 16;
                        }
                        for (int j = 0; j < xian_count; j++)
                        {
                            double hudu = (j * 360.0 / double.Parse(xian_count.ToString())) / 180 * Math.PI;
                            if (comboBox1.Text == "16风向")
                            {
                                xian[j] = "250,250," + Math.Round(250 + (200 * Math.Cos(hudu)), 0).ToString() + "," + Math.Round(250 + (200 * Math.Sin(hudu)), 0).ToString() + "," + fx[j].Split(new Char[] { '|' })[0] + "," + fx[j].Split(new Char[] { '|' })[1] + "," + fx[j].Split(new Char[] { '|' })[2] + "";
                            }
                            if (comboBox1.Text == "8风向")
                            {
                                xian[j] = "250,250," + Math.Round(250 + (200 * Math.Cos(hudu)), 0).ToString() + "," + Math.Round(250 + (200 * Math.Sin(hudu)), 0).ToString() + "," + fx[j * 2].Split(new Char[] { '|' })[0] + "," + fx[j * 2].Split(new Char[] { '|' })[1] + "," + fx[j * 2].Split(new Char[] { '|' })[2] + "";
                            }
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
                                //Regex reg = new Regex("^[0-9]+$");
                                //Match ma = reg.Match(split[j].Split(new Char[] { ',' })[1]);////判断是否为数字
                                //if (ma.Success)
                                //{////是数字
                                if (split[j].Split(new Char[] { ',' })[0] != "C")
                                {
                                    if (double.Parse(split[j].Split(new Char[] { ',' })[1]) > max_zhi)
                                    {
                                        max_zhi = double.Parse(split[j].Split(new Char[] { ',' })[1]);
                                    }
                                }
                               // }
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
                        for (int m = 0; m < fx.Length ; m++)
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
                        Pen Polygon_pen = new Pen(Color.Blue   , 2);  //创建画笔对象
                        g.DrawPolygon(Polygon_pen, points);  //绘制多边形
                        g.FillPolygon(Brushes.Blue , points);////充填颜色

                        //g.FillPolygon(new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red , Color.White ), points);//左斜线填充
                       
                        #endregion
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        tu_count++;
                    //image.Save("D:/" + "hhh.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("8风向");
            comboBox1.Items.Add("16风向");
            comboBox1.Text = "8风向";
        }
    }
}
