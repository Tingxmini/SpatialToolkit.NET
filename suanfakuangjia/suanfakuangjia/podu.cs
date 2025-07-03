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
    public partial class podu : Form
    {
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

        private double[,] deep1;
        private double[,] HH1;

        double px;
        double py;
        Graphics g;
        List<Point> points = new List<Point>();
        List<PointF> pointlist = new List<PointF>();//存放点数据
        List<double> W;

        private Pen pen1;

       
        public podu()
        {
            InitializeComponent();
        }
        private void openDEM_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                DEM = new myDEM(filename);
                Bitmap bm = new Bitmap(DEM.ColCount,DEM.RowCount);
                for(int i=0;i<DEM.ColCount;i++)
                    for (int j = 0; j < DEM.RowCount; j++)
                    {
                        int gray = Convert.ToInt32(DEM.CellData[j,i]*255/DEM.MaxZ);
                        if (gray < 0) gray = 0;
                        if (gray > 255) gray = 255;
                        bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                pictureBox1.BackgroundImage = bm;
                arr=new double[DEM.RowCount+2,DEM.ColCount+2];
                initialArr();
                initialSlopeWE();
                initialSlopeSN();
            }
        }
        private void Slope_Click(object sender, EventArgs e)
        {
            slope=new double[DEM.RowCount,DEM.ColCount];
            for(int i=0;i<DEM.RowCount;i++)
                for (int j = 0; j < DEM.ColCount; j++)
                {
                    slope[i, j] = Math.Sqrt(slopeWE[i, j] * slopeWE[i, j] + slopeSN[i, j] * slopeSN[i, j]);
                }
            double maxSlope = -1;
            double minSlope = 100;
            for(int i=0;i<slope.GetLength(0);i++)
                for (int j = 0; j < slope.GetLength(1); j++)
                {
                    if(slope[i,j]>maxSlope)
                        maxSlope=slope[i,j];
                    if(slope[i,j]<minSlope)
                        minSlope=slope[i,j];
                }
            //MessageBox.Show(maxSlope.ToString()+"\n"+minSlope.ToString());
            Bitmap bm = new Bitmap(slope.GetLength(1), slope.GetLength(0));
            for(int i=0;i<bm.Width;i++)
                for (int j = 0; j < bm.Height; j++)
                {
                    int gray = Convert.ToInt32(slope[j,i]*255/maxSlope);
                    bm.SetPixel(i,j,Color.FromArgb(gray,gray,gray));
                }
            pictureBox1.BackgroundImage = bm;
        }
        private void Aspect_Click(object sender, EventArgs e)
        {
            aspect=new double[DEM.RowCount,DEM.ColCount];
            for (int i = 0; i < DEM.RowCount; i++)
                for (int j = 0; j < DEM.ColCount; j++)
                {
                    if (slopeSN[i, j] == 0 && slopeWE[i, j] == 0)
                        aspect[i, j] = 1000;
                    else 
                    {
                        aspect[i, j] = (180 / 3.1415926) * Math.Atan2(slopeSN[i,j],-slopeWE[i,j]);
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
                        int gray = Convert.ToInt32((aspect[j, i]-minAspect)* 255 / (maxAspect-minAspect));
                        bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                    }
                    else
                    {
                        bm.SetPixel(i, j, Color.FromArgb(65,105,255));
                    }
                }
            pictureBox1.BackgroundImage = bm;
        }
       
        #region 封装的方法
        private void initialArr()
        {
            arr[0, 0] = DEM.CellData[0, 0];
            arr[arr.GetLength(0)-1,arr.GetLength(1)-1]=DEM.CellData[DEM.RowCount-1,DEM.ColCount-1];
            arr[0, arr.GetLength(1) - 1] = DEM.CellData[0, DEM.ColCount - 1];
            arr[arr.GetLength(0) - 1, 0] = DEM.CellData[DEM.RowCount - 1, 0];
            for (int i = 1; i < arr.GetLength(1) - 1; i++)
                arr[0, i] = DEM.CellData[0,i - 1];
            for (int i = 1; i < arr.GetLength(1) - 1; i++)
                arr[1002, i] = DEM.CellData[1000, i - 1];
            for (int i = 1; i < arr.GetLength(0) - 1; i++)              
                arr[i, 0] = DEM.CellData[i - 1, 0];
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
                arr[i, 1002] = DEM.CellData[i - 1, 1000];
            for(int i=0;i<DEM.RowCount;i++)
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
            for (int i = 0; i < slopeWE1.GetLength(0)-2; i++)
                for (int j = 0; j < slopeWE1.GetLength(1)-2; j++)
                {
                    slopeWE1[i, j] = ((slope1[i + 2, j] + 2 * slope1[i + 1, j] + slope1[i, j]) - (slope1[i + 2, j + 2] + 2 * slope1[i + 1, j + 2] + slope1[i, j + 2])) / 240;
                }
        }
        private void initialSlopeSN1()
        {
            slopeSN1 = new double[DEM.RowCount, DEM.ColCount];
            for (int i = 0; i < slopeSN1.GetLength(0)-2; i++)
                for (int j = 0; j < slopeSN1.GetLength(1)-2; j++)
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
        #endregion

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

        private void button5_Click(object sender, EventArgs e)
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
            for (int i = 0; i < DEM.RowCount-2; i++)
                for (int j = 0; j < DEM.ColCount-2; j++)
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

        private void button4_Click(object sender, EventArgs e)
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
            for (int i = 0; i < DEM.RowCount-2; i++)
                for (int j = 0; j < DEM.ColCount-2; j++)
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

        private void button6_Click(object sender, EventArgs e)
        {
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
                    if (Center > double.Parse(textBox1.Text))
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

        private void button7_Click(object sender, EventArgs e)
        {
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
                    if (Center > double.Parse(textBox1.Text))
                        if (Center < Up)
                            if (Center < Down)
                                if (Center < Left)
                                    if (Center < Right)
                                        if (Center < UpLeft)
                                            if (Center < UpRight)
                                                if (Center < DownLeft)
                                                    if (Center < DownRight)
                                                        g.FillEllipse(Brushes.Red, xx, yy, 5, 5);





                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            pictureBox1.BackgroundImage = null;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(DEM.ColCount, DEM.RowCount);
            for (int i = 0; i < DEM.ColCount; i++)
                for (int j = 0; j < DEM.RowCount; j++)
                {
                    int gray = Convert.ToInt32(DEM.CellData[j, i] * 255 / DEM.MaxZ);
                    if (gray < 0) gray = 0;
                    if (gray > 255) gray = 255;
                    bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            pictureBox1.BackgroundImage = bm;
        }

        private void button10_Click(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
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
                    sloper[i, j] = 1/Math.Cos(slope1[i, j]);
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

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            points.Clear();
           

            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            points.Add(point);
            g.FillEllipse(Brushes.Red, e.X - 2, e.Y - 2, 4, 4);
        }
        
        private void button13_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            int h = pictureBox1.Width;
            int f = pictureBox1.Height;
            int c = 0;
            int d = 0;
            Double D;
            W = new List<double>();
            int q1=0;
            int x1 = Convert.ToInt32(points[0].X) * DEM.ColCount / h;
            int x2 = Convert.ToInt32(points[1].X) * DEM.ColCount / h;
            int y1 = Convert.ToInt32(points[0].Y) * DEM.RowCount / f;
            int y2 = Convert.ToInt32(points[1].Y) * DEM.RowCount / f;

            for (int i = 0; i < DEM.ColCount; i++)
            {
                for (int j = 0; j < DEM.RowCount; j++)
                {
                    double cross = (x2  - x1) * (j - x1) + (y2  - y1) * (i - y1);
                    //if () return false;
                    double d2 = (x2 - x1) * (x2 - x1 )+ (y2 - y1) * (y2 - y1);
                    //if (cross >= d2) return false;
                    if(cross >= 0&& cross <= d2)
                    {
                    double r = cross / d2;
                    px = x1 + (x2 - x1) * r;
                    py = y1 + (y2 - y1) * r;
                    }
                    //判断距离是否小于误差
                    if(Math.Sqrt((j - px) * (j - px) + (py - i) * (py - i)) <= 1)
                    {
                        W.Add(DEM.CellData[i, j]);
                        g.FillEllipse(Brushes.Red, Convert.ToInt32(j) * h /DEM.ColCount , Convert.ToInt32(i) *  f/ DEM.RowCount, 3, 3);
                    }
                }
            }
            for(int k=0;k<W.Count-1;k++)
            {
                if (W[k] > DEM.CellData[x1, y1] || W[k] > DEM.CellData[x2, y2])
                {
                    q1 = 1;
                }
                
                    
            }
            
            if (q1==1)
            {
              MessageBox.Show("不可通视");
            }
            if(q1==0)
            {
              MessageBox.Show("可以通视");
            }
            

        }

        private void button14_Click(object sender, EventArgs e)
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
    }
}
