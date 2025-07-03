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
    public partial class zxshchsh : Form
    {


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
        public zxshchsh()
        {
            InitializeComponent();
        }
        int[,] t;
        int n1 = 0;
        List<int> W3;
        List<int> W4;

        int i, j, L = 0, len;
        int z1 = 0;
        string D;

        List<Point> points = new List<Point>();
        List<PointF> pointlist = new List<PointF>();//存放点数据

  
        private Pen pen1;

        Graphics g;

       
        public Point p;
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

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            points.Clear();
            pointlist.Clear();
           
            g = pictureBox1.CreateGraphics();//创建画板
            pictureBox1.Cursor = Cursors.Cross;
            pen1 = new Pen(Color.Black, 3);
           
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            Point point = new Point(e.X, e.Y);
            pointlist.Add(point);
            g.FillEllipse(Brushes.Red, e.X - 2, e.Y - 2, 4, 4);
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
               //int l = 0;
                for (int i = 0; i < Q.Length; i++)
                {
                    if (h[u, i] == 1)
                    {
                        if (t[u, i] + d[u] <= Q[i])
                        {
                            g.DrawLine(new Pen(Brushes.Red, 2), pointlist[u], pointlist[i]);
                            System.Threading.Thread.Sleep(400);
                            if (Q[i] != max && h[w, i] != 0)
                                g.DrawLine(new Pen(Brushes.Yellow, 2), pointlist[w], pointlist[i]);
                            Q[i] = t[u, i] + d[u];
                        }
                        else
                        {
                            g.DrawLine(new Pen(Brushes.Red, 2), pointlist[u], pointlist[i]);
                            System.Threading.Thread.Sleep(400);
                            g.DrawLine(new Pen(Brushes.Yellow, 2), pointlist[u], pointlist[i]);
                            System.Threading.Thread.Sleep(400);
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
        private void button3_Click(object sender, EventArgs e)
        {
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

            string str = textBox1.Text;
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

        private void button5_Click(object sender, EventArgs e)
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
             n1 = 0;
            pictureBox1.Invalidate();
            //points.Clear();
            pointlist.Clear();
            pList.Clear();
            eList.Clear();
            nes.Clear();
            
            z1 = 0;
            L = 0;
            //List<PointF> pointlist = new List<PointF>();//存放点数据
        }


        //输出路径函数
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

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
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
            start = Convert.ToInt32(textBox2.Text);
            end = Convert.ToInt32(textBox3.Text);
            showpath(start, end);
            //textBox2.Text = W[0].ToString();
            for (int i = 0; i < W4.Count()-1; i++)
            {
                g.DrawLine(pen, pointlist[W4[i]], pointlist[W4[i + 1]]);
                ed = W4[i + 1];
            }
            g.DrawLine(pen, pointlist[ed], pointlist[end]);
            label11.Text = dis[start, end].ToString();//最终距离



        }

        private void zxshchsh_Load(object sender, EventArgs e)
        {
            //W = new List<int>();
            //dis = ADD;//初始化变量
            //for (int i = 0; i < M; i++)
            //{
            //    for (int j = 0; j < M; j++)
            //    {
            //        path[i, j] = i;
            //        //path[j, i] = j;
            //    }
            //}

            ////floyd算法
            //for (int k = 0; k < M; k++)
            //{
            //    for (int i = 0; i < M; i++)
            //    {
            //        for (int j = 0; j < M; j++)
            //        {
            //            if (dis[i, j] > dis[i, k] + dis[k, j])
            //            {
            //                dis[i, j] = dis[i, k] + dis[k, j];
            //                //dis[j, i] = dis[i, k] + dis[k, j];
            //                path[i, j] = k;
            //                //path[j, i] = k;

            //            }
            //        }
            //    }
            //}

            ////输出矩阵
            ////Console.Write("新的距离矩阵为：\n");
            ////for (int i = 0; i < M; i++)
            ////{
            ////    for (int j = 0; j < M; j++)
            ////    {
            ////        listBox1.Items.Add(dis[i, j]);
            ////    }
            ////    //Console.Write("\n");
            ////}
            //////最后路径矩阵
            ////for (int i = 0; i < M; i++)
            ////{
            ////    for (int j = 0; j < M; j++)
            ////    {
            ////        listBox1.Text = path[i, j].ToString();
            ////    }
            ////    //Console.Write("\n");
            ////}
            ////Console.Write("\n程序完毕\n");
            ////getchar();
            ////输出路径
            //showpath(start, end);
            //label1.Text = W[0].ToString();
            //label2.Text = W[1].ToString();
            //label3.Text = W[2].ToString();
            //textBox1.Text = dis[start, end].ToString();//最终距离
        }

        private void button7_Click(object sender, EventArgs e)
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
            X1[10] =70;
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
            


        }
    }
}
