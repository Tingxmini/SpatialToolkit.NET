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
    public partial class 矢量距离计算 : Form
    {

        public 矢量距离计算()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)//欧氏距离
        {
            int x1 = int.Parse(X1.Text);
            int y1 = int.Parse(Y1.Text);
            int x2 = int.Parse(X2.Text);
            int y2 = int.Parse(Y2.Text);
            double result = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            result1.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)//绝对值距离
        {
            int x1 = int.Parse(X1.Text);
            int y1 = int.Parse(Y1.Text);
            int x2 = int.Parse(X2.Text);
            int y2 = int.Parse(Y2.Text);

            double result = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            result2.Text = result.ToString();
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

        private void button4_Click(object sender, EventArgs e)//切式距离  切比雪夫距离
        {

            int x1 = int.Parse(X1.Text);
            int y1 = int.Parse(Y1.Text);
            int x2 = int.Parse(X2.Text);
            int y2 = int.Parse(Y2.Text);
            double res = Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
            result4.Text = res.ToString();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Alon_ = int.Parse(Alon.Text);
            int Alat_ = int.Parse(Alat.Text);
            int Blon_ = int.Parse(Blon.Text);
            int Blat_ = int.Parse(Blat.Text);
            double res;
            if (Alon_ > 180 || Alat_ > 90 || Blon_ > 180 || Blat_ > 90)
                result5.Text = "请输入正确的经纬度";
            else
            {
                res = 6371 * Math.Pow(Math.Abs(Math.Sin(Alat_) * Math.Sin(Blat_) + Math.Cos(Alat_) * Math.Cos(Blat_) * Math.Cos(Alon_ - Blon_)), -1);
                result5.Text = res.ToString().Substring(0, 8) + "千米";
            }
        }
    }
}
