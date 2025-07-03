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
    public partial class jibentongji : Form
    {
        public jibentongji()
        {
            InitializeComponent();
        }
        int num1;
        int ran11;
        int sst11;
        int[] arr; //从1至20中取出6个互不相同的随机数
        //List<int> arr1;
        int[] b;
        double ave;


        public int[] getRandomNum(int num, int minValue, int maxValue)
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[num];
            int tmp = 0;
            for (int i = 0; i <= num - 1; i++)
            {
                tmp = ra.Next(minValue, maxValue); //随机取数
                arrNum[i] = getNum(arrNum, tmp, minValue, maxValue, ra); //取出值赋到数组中
            }
            return arrNum;
        }
        public int getNum(int[] arrNum, int tmp, int minValue, int maxValue, Random ra)
        {
            int n = 0;
            while (n <= arrNum.Length - 1)
            {
                if (arrNum[n] == tmp) //利用循环判断是否有重复
                {
                    tmp = ra.Next(minValue, maxValue); //重新随机获取。
                    getNum(arrNum, tmp, minValue, maxValue, ra);//递归:如果取出来的数字和已取得的数字有重复就重新随机获取。
                }
                n++;
            }
            return tmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            arr = new int[num1];
            num1 = Convert.ToInt32(textBox1.Text);
            sst11 = Convert.ToInt32(textBox2.Text);
            ran11 = Convert.ToInt32(textBox3.Text);
            string lt11 = label1.Text;
            arr = getRandomNum(num1, sst11, ran11);
            int i = 0;
            string temp = "";
            while (i <= arr.Length - 1)
            {
                temp = arr[i].ToString();
                
                lt11 = label1.Text + temp+" ";
                label1.Text = lt11;
                i++;
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
            voronoi vrn11 = new voronoi();
            vrn11.TopLevel = false;
            vrn11.FormBorderStyle = FormBorderStyle.None;
            vrn11.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(vrn11);
            vrn11.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            double t11;
            t11=arr.Average();
            label5.Text = Convert.ToString(t11);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int max1 = arr.Max();
            int min1 = arr.Min();
            int jicha = max1 - min1;
            label12.Text = Convert.ToString(jicha);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double avg = arr.Average();
            //总体方差
            double variance = arr.Sum(x => Math.Pow(x - avg, 2)) / arr.Length;
            label9.Text = Convert.ToString(variance);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double avg = arr.Average();
            //总体方差
            double variance = arr.Sum(x => Math.Pow(x - avg, 2)) / arr.Length;
            double standDeviation = Math.Sqrt(variance);
            label11.Text = Convert.ToString(standDeviation);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            int t;
            double mid;
            for (i = 0; i < arr.Length - 1; i++)//i为排序的趟数
            {
                for (j = 0; j < arr.Length - i - 1; j++)//j为第i趟需比较的次数
                {
                    if (arr[j] > arr[j + 1])
                    {
                        t = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = t;
                    }
                }
            }
            if (arr.Length % 2 == 0)
            {
                mid = (arr[arr.Length / 2] + arr[arr.Length / 2 - 1]) / 2;
            }
            else
                mid = arr[(arr.Length - 1) / 2];
            label17.Text = mid.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double sum = 0;
            double average;
            int i;
            string lt11 = label1.Text;
            for (i = 0; i <= arr.Length - 1; i++)
            {
                sum = sum + arr[i];
            }
            average = sum / arr.Length;
            b = new int[arr.Length];
            for (i = 0; i <= arr.Length - 1; i++)
            {
                b[i] = arr[i] - Convert.ToInt32(average);
                lt11 = label5.Text + b[i] + " ";
                label18.Text = lt11;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double sum1 = 0;
            int i;

            int[] c = new int[arr.Length];
            for (i = 0; i <= arr.Length - 1; i++)
            {
                if (b[i] < 0)
                    c[i] = Math.Abs(b[i]);
                else
                    c[i] = b[i];
            }
            for (i = 0; i <= arr.Length - 1; i++)
            {
                sum1 = sum1 + c[i];
            }
            ave = sum1 / arr.Length;
            label19.Text = ave.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double sum2 = 0;
            int i;
            for (i = 0; i < arr.Length - 1; i++)
            {
                sum2 = sum2 + (b[i] - ave) * (b[i] - ave);
            }
            label20.Text = sum2.ToString();
        }
    }
}
