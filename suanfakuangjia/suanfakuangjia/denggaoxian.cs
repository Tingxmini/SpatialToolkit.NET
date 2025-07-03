using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace suanfakuangjia
{
    public partial class frmMain : Form
    {
        #region 属性

        public static bool showPoint = false;
        public static bool drawLines = true;
        private float[,] _Data;
    
        public float[,] Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        private float[] _ContourValues;
  
        public float[] ContourValues
        {
            get { return _ContourValues; }
            set { _ContourValues = value; }
        }
   
        public frmMain()
        {
            InitializeComponent();
            MakeTestData();
        
            gg = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false; 
            initValue();  //重新初始化绘制路径的数组
            MakeTestData();
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
    
            if (this.Data == null) return;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            Pen pen = new Pen(Color.DarkGray, 1);
            //等值线
            if (drawLines)
            {
                this.plotContour(e.Graphics, pictureBox1.Size);
            }
            //网格

                int ww = pictureBox1.Width / (Data.GetLength(0) - 1); //x轴间隔长度
                int yy = pictureBox1.Height / (Data.GetLength(1) - 1);//y轴间隔长度

             
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    for (int i = 0; i < Data.GetLength(0); i++)
                    {
                        e.Graphics.DrawString(Data[i, j].ToString("f0"), DefaultFont, Brushes.Blue, i * pictureBox1.Width / (Data.GetLength(0) - 1), j * pictureBox1.Height / (Data.GetLength(1) - 1), sf);
                    }
                }
            
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

   


      

        Graphics gg = null;  //绘制路径的对象
        Pen pens = new Pen(Color.Black, 1);
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (drawValues[nums].color != Color.FromArgb(0, 0, 0))
            {
                pens.Color = drawValues[nums].color;
                gg.DrawLine(pens, drawValues[nums].x1, drawValues[nums].y1, drawValues[nums].x2, drawValues[nums].y2);
                nums++;
            }
            else
            {
                this.timer1.Enabled = false;
                nums = 0;
            }
        }

        #endregion

        #region 绘制等值线操作

        /// <summary>
        /// 生成测试数据
        /// </summary>
        public void MakeTestData()
        {
            const int nx = 10, ny = 10, nv = 7;

            _ContourValues = new float[nv];
            for (int i = 0; i < nv; i++)
            {
                _ContourValues[i] = i*10;
            }


            _Data = new float[nx,ny];  //nx列,ny行
            Random ran = new Random();
            for(int j=0;j<ny;j++)
            {
                for(int i=0;i<nx;i++)
                {
                    if (j > 7)
                    {
                        _Data[i, j] = ran.Next(0, 70);
                    }
                    else
                    {
                        _Data[i, j] = ran.Next(0, 70);
                    }
                    //如果格点值等于等值线值,格点值加一个小值
                    for (int k = 0; k < nv; k++)
                    {
                        if (_Data[i, j] == ContourValues[k])
                            _Data[i, j] += 0.0001f;
                    }
                }
            }
        }
        
        int v1, v2, v3, small, medium, large;
        int[] ix = new int[4], iy = new int[4];
        float x1, x2, y1, y2, target;
        float[] X= new float[5], Y= new float[5], value= new float[5];

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        int iX(float x,int width) 
        { 
            return (int)Math.Round(width/(Data.GetLength(0)-1) * x); 
        }

        int iY(float y,int height) 
        { 
            return (int)Math.Round(height/(Data.GetLength(1)-1) * y); 
        }

     
        /// <summary>
        /// 插值计算
        /// </summary>
        /// <param name="xa"></param>
        /// <param name="ya"></param>
        /// <param name="xb"></param>
        /// <param name="yb"></param>
        /// <param name="yy"></param>
        /// <returns></returns>
        float interp(float xa, float ya, float xb, float yb, float yy)
        {
            if ((yb - ya) != 0.0F)
            {
                return xa + (yy - ya) * (xb - xa) / (yb - ya);
            }
            else
            {
                return 0.0F;
            }
        }

        Font font = new Font("Times New Roman", 8.0f);
        Brush brush = new SolidBrush(Color.Blue);

        public void plotContour(Graphics g,Size size)
        {
            nums = 0;
            Pen pen = new Pen(Color.Black, 1);
           
            for (int j = 0; j < Data.GetLength(1)-1; j++)
            {
                for (int i = 0; i < Data.GetLength(0)-1; i++)
                {
                    //网格四个角坐标,变量值
                    X[0] = i; Y[0] = j; value[0] = Data[i, j];
                    X[1] = i + 1; Y[1] = j; value[1] = Data[i + 1, j];
                    X[2] = i + 1; Y[2] = j+1; value[2] = Data[i + 1, j+1];
                    X[3] = i ; Y[3] = j+1; value[3] = Data[i, j+1];
                    //网格中心点坐标,变量值
                    X[4] = 0.5F * (X[0] + X[1]); Y[4] = 0.5F * (Y[1] + Y[2]); value[4] = 0.25F * (value[0] + value[1] + value[2] + value[3]);                    
                    v3 = 4;

                    //巡检单元格范围内所有的点信息
                    for (v1 = 0; v1 < 4; v1++)
                    {
                        v2 = v1 + 1;
                        if (v1 == 3) v2 = 0;

                        reorder(v1, v2, v3);
                        //巡检点范围内所有的点信息
                        for (int lines = 0; lines < ContourValues.Length; lines++)
                        {
                            target = ContourValues[lines];

                            if (value[small] < target && target < value[large])
                            {
                                x1 = interp(X[small], value[small], X[large], value[large], target);
                                y1 = interp(Y[small], value[small], Y[large], value[large], target);

                                if (target > value[medium])
                                {
                                    x2 = interp(X[medium], value[medium], X[large], value[large], target);
                                    y2 = interp(Y[medium], value[medium], Y[large], value[large], target);
                                }
                                else
                                {
                                    x2 = interp(X[small], value[small], X[medium], value[medium], target);
                                    y2 = interp(Y[small], value[small], Y[medium], value[medium], target);
                                }
                                
                            //    pen.Color = getSpectrumColor(target);
                                g.DrawLine(pen, iX(x1,size.Width), iY(y1,size.Height), iX(x2,size.Width), iY(y2,size.Height));
                                //g.DrawString(target.ToString(), font, brush, new PointF((iX(x1, size.Width) + iX(x2, size.Width)) / 2, (iY(y1, size.Height)+iY(y2,size.Height) / 2)));

                              //  drawValues[nums].color = getSpectrumColor(target);
                                drawValues[nums].x1 = iX(x1, size.Width);
                                drawValues[nums].y1 = iY(y1, size.Height);
                                drawValues[nums].x2 = iX(x2, size.Width);
                                drawValues[nums].y2 = iY(y2, size.Height);
                                nums++;
                            }
                        } 
                    }
                }
            }
        }
        int nums = 0;
        struct DrawValues
        {
            public Color color;
            public int x1;
            public int y1;
            public int x2;
            public int y2;
        }

        DrawValues []drawValues = new DrawValues[9999999]; //存储绘制点的信息

        /// <summary>
        /// 根据i,j,k三点值，算出大中小三点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        void reorder(int i, int j, int k)
        {
            int temp;

            large = i;
            medium = j;
            small = k;

            if (value[small] > value[medium])
            {
                temp = medium;
                medium = small;
                small = temp;
            }

            if (value[medium] > value[large])
            {
                temp = large;
                large = medium;
                medium = temp;
            }

            if (value[small] > value[medium])
            {
                temp = medium;
                medium = small;
                small = temp;
            }
        }

        //数组重新初始化
        private void initValue()
        {
            drawValues = new DrawValues[9999999]; //存储绘制点的信息
        }
 
        #endregion
    }
}