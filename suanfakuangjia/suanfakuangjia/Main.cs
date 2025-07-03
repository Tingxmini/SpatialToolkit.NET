using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace suanfakuangjia
{
    public partial class Main : Form
    {
        string rowIndex;
        bool isopen;
        bool iscal;
        private string curFileName;
        private string TempStr1;
        private string[] TempStr2;
        private double[,] Value1, Value2, Value3;
        private suanfakuangjia.Data.Triangle[] Tri;
        private Data.Line[] Line;
        int o, K, wid, hig, k;
        double x;
        double Z=0;
        private System.Drawing.Bitmap curBitmap;

        public Main()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "文本文件(*.txt)|*.txt";
            openDlg.Title = "选择已知点文件";
            openDlg.ShowHelp = true;
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    curFileName = openDlg.FileName;
                    StreamReader myStreamReader = new StreamReader(curFileName, true);
                    TempStr1 = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    string[] a = new string[] { ",", "\n", "\r" };
                    TempStr2 = TempStr1.Split(a, StringSplitOptions.RemoveEmptyEntries);
                    Value1 = new double[TempStr2.Length / 3, 4];
                    Data.db_Value1 = new double[TempStr2.Length / 3, 4];
                    Value3 = new double[TempStr2.Length / 3, 3];
                    int j = 0;
                    double max1 = 0, max2 = 0, min1 = 0, min2 = 0;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("X", typeof(String));
                    dt.Columns.Add("Y", typeof(String));
                    dt.Columns.Add("Z", typeof(String));
                    this.dataGridView1.DataSource = dt;                 //将datatable绑定到datagridview上显示结果  
                    for (int i = 0; i < TempStr2.Length;)
                    {
                        if (i == 0)
                        {
                            textBox1.Text = TempStr2[i];
                            i = i + 1;
                        }
                        else
                        {
                            Value1[j, 0] = j + 1;
                            Value1[j, 1] = double.Parse(TempStr2[i]);
                            Value1[j, 2] = double.Parse(TempStr2[i + 1]);
                            Value1[j, 3] = double.Parse(TempStr2[i + 2]);
                            Data.db_Value1[j, 0] = j + 1;
                            Data.db_Value1[j, 1] = double.Parse(TempStr2[i]);
                            Data.db_Value1[j, 2] = double.Parse(TempStr2[i + 1]);
                            Data.db_Value1[j, 3] = double.Parse(TempStr2[i + 2]);
                            if (j == 0)
                            {
                                max1 = Value1[j, 1];
                                min1 = Value1[j, 1];
                                max2 = Value1[j, 2];
                                min2 = Value1[j, 2];
                            }
                            else
                            {
                                if (max1 < Value1[j, 1])
                                    max1 = Value1[j, 1];
                                if (max2 < Value1[j, 2])
                                    max2 = Value1[j, 2];
                                if (min1 > Value1[j, 1])
                                    min1 = Value1[j, 1];
                                if (min2 > Value1[j, 2])
                                    min2 = Value1[j, 2];
                            }


                            DataRow dr = dt.NewRow();

                            dr[0] = Value1[j, 1];
                            dr[1] = Value1[j, 2];
                            dr[2] = Value1[j, 3];
                            dt.Rows.Add(dr);
                            j++;
                            i = i + 3;
                        }
                    }
                    j = 0;
                    for (int i = 1; i < TempStr2.Length; i = i + 3)
                    {
                        Value3[j, 0] = j + 1;
                        Value3[j, 1] = 10 * (double.Parse(TempStr2[i]) - min1 + 5);
                        Value3[j, 2] = 10 * (double.Parse(TempStr2[i + 1]) - min2 + 5);
                        j++;
                    }
                    wid = (int)(10 * (max2 - min2 + 10));
                    hig = (int)(10 * (max1 - min1 + 10));
                    dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.AllowUserToAddRows = false;
                    groupBox1.Text = "地形特征点坐标";
                    isopen = true;
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                MessageBox.Show("打开失败！");
                isopen = false;
            }
        }

        private void 保存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "文本文件(.txt)|*.txt|所有文件|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(dlg.FileName);

                sw.WriteLine(textBox1.Text);
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value + "," + dataGridView1.Rows[i].Cells[1].Value + "," + dataGridView1.Rows[i].Cells[2].Value);
                }

                sw.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(isopen==false)
            {
                MessageBox.Show("请先打开文件！");
                return;
            }

            Data.db_count = dataGridView1.RowCount;

            k = TempStr2.Length / 3;
            Value2 = new double[k, k];
            double Min = 0, midx, midy;
            int m = 0, n = 1, L = 0, g = 0, h = 1;
            K = 0;
            int[] AA = new int[k];
            for (int i = 0; i < k; i++)
                for (int j = i + 1; j < k; j++)
                {
                    Value2[i, j] = (Value1[i, 1] - Value1[j, 1]) * (Value1[i, 1] - Value1[j, 1]) +
                        (Value1[i, 2] - Value1[j, 2]) * (Value1[i, 2] - Value1[j, 2]);
                    if (i == 0 && j == 1)
                        Min = Value2[0, 1];
                    else
                    {
                        if (Min > Value2[i, j])
                        {
                            m = i; n = j;
                            Min = Value2[i, j];

                        }
                    }
                }

            Tri = new Data.Triangle[k * (k - 1) / 2];
            Line = new Data.Line[k * (k - 1) / 2];
            Tri[0] = new Data.Triangle();
            Tri[0].Line[0] = new Data.Line();
            Tri[0].Line[1] = new Data.Line();
            Tri[0].Line[2] = new Data.Line();

            Tri[0].ID = 1;
            Tri[0].Peak[0] = m;
            Tri[0].Peak[1] = n;

            Tri[0].Line[0].ID = 1;
            Tri[0].Line[0].Point[0] = m;
            Tri[0].Line[0].Point[1] = n;

            Line[0] = new Data.Line();
            Line[1] = new Data.Line();
            Line[2] = new Data.Line();
            Line[0].ID = 1;
            Line[0].Point[0] = m;
            Line[0].Point[1] = n;
            o = 1;
            int q = 0;
            midx = (Value1[m, 1] + Value1[n, 1]) / 2;
            midy = (Value1[m, 2] + Value1[n, 2]) / 2;

            for (int j = 0; j < k; j++)
            {
                if ((j != m) && (j != n))
                {
                    Min = (midx - Value1[j, 1]) * (midx - Value1[j, 1]) + (midy - Value1[j, 2]) * (midy - Value1[j, 2]);
                    q = j;
                    break;
                }
            }
            for (int i = 0; i < k; i++)
            {
                if ((i != m) && (i != n) && ((midx - Value1[i, 1]) * (midx - Value1[i, 1]) + (midy - Value1[i, 2]) * (midy - Value1[i, 2]) < Min))
                {
                    Min = (midx - Value1[i, 1]) * (midx - Value1[i, 1]) + (midy - Value1[i, 2]) * (midy - Value1[i, 2]);
                    q = i;
                }
            }
            Line[1].ID = 2;
            Line[1].Point[0] = Tri[0].Line[0].Point[1];
            Line[1].Point[1] = q;
            Line[2].ID = 3;
            Line[2].Point[0] = q;
            Line[2].Point[1] = Line[0].Point[0];
            Line[0].Bor[0] = Tri[0].ID;
            Line[1].Bor[0] = Tri[0].ID;
            Line[2].Bor[0] = Tri[0].ID;

            Tri[0].Peak[2] = q;
            Tri[0].Line[1] = Line[1];
            Tri[0].Line[2] = Line[2];

            o = 3;
            L = 1;
            K = 0;
            ArrayList List1 = new ArrayList();
            ArrayList List2 = new ArrayList();
            Data.Line[] Linetemp = new Data.Line[2];
            CIrregularTriangulation BB = new CIrregularTriangulation();
            CIrregularTriangulation CC = new CIrregularTriangulation();
            while (K < L)
            {
                int d;
                d = CC.SS(BB, Tri, K, k, ref L, Value1, Line, ref o);
                K++;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("顶点1", typeof(String));
            dt.Columns.Add("顶点2", typeof(String));
            dt.Columns.Add("顶点3", typeof(String));
            dt.Columns.Add("体积", typeof(String));
            this.dataGridView1.DataSource = dt;                
            Data.dc_v = new double[L];
            for (int i = 0; i < L; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = Tri[i].Peak[0];
                dr[1] = Tri[i].Peak[1];
                dr[2] = Tri[i].Peak[2];

                double AB = Math.Sqrt((Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[1], 2]) * (Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[1], 2]) + (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[1], 1]) * (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[1], 1]));
                double AC = Math.Sqrt((Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[2], 2]) * (Value1[Tri[i].Peak[0], 2] - Value1[Tri[i].Peak[2], 2]) + (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[2], 1]) * (Value1[Tri[i].Peak[0], 1] - Value1[Tri[i].Peak[2], 1]));
                double BC = Math.Sqrt((Value1[Tri[i].Peak[1], 2] - Value1[Tri[i].Peak[2], 2]) * (Value1[Tri[i].Peak[1], 2] - Value1[Tri[i].Peak[2], 2]) + (Value1[Tri[i].Peak[1], 1] - Value1[Tri[i].Peak[2], 1]) * (Value1[Tri[i].Peak[1], 1] - Value1[Tri[i].Peak[2], 1]));
                       
                double M = (AB + AC + BC) / 2;
                double S = Math.Sqrt(M * (M - AB) * (M - AC) * (M - BC));
                Z = Z + S;
                this.textBox3.Text = Z.ToString();
               
                Data.dc_v[i] = S / 3 * (Data.db_h - Value1[Tri[i].Peak[0], 3] + Data.db_h - Value1[Tri[i].Peak[1], 3] + Data.db_h - Value1[Tri[i].Peak[2], 3]);
                Data.dc_v[i] = Math.Round(Data.dc_v[i], 3); Data.dc_v[i] = Math.Abs(Data.dc_v[i]);
                dr[3] = Data.dc_v[i];
                dt.Rows.Add(dr);
                for (int j= 0; j <= i; j++)
                {
                    x = x + Data.dc_v[j];

                }
                
                this.textBox2.Text=x.ToString();
            }
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = false;
            groupBox1.Text = "TIN三角形点号";

            curBitmap = new Bitmap(wid, hig);
            for (int i = 0; i < K; i++)
            {
                Graphics myGraphics = Graphics.FromImage(curBitmap);    //创建Graphics对象
                myGraphics.DrawLine(new Pen(Color.Red, 1), new PointF((float)Value3[Tri[i].Peak[0], 2], (float)Value3[Tri[i].Peak[0], 1]), new PointF((float)Value3[Tri[i].Peak[1], 2], (float)Value3[Tri[i].Peak[1], 1]));
                myGraphics.DrawLine(new Pen(Color.Red, 1), new PointF((float)Value3[Tri[i].Peak[1], 2], (float)Value3[Tri[i].Peak[1], 1]), new PointF((float)Value3[Tri[i].Peak[2], 2], (float)Value3[Tri[i].Peak[2], 1]));
                myGraphics.DrawLine(new Pen(Color.Red, 1), new PointF((float)Value3[Tri[i].Peak[0], 2], (float)Value3[Tri[i].Peak[0], 1]), new PointF((float)Value3[Tri[i].Peak[2], 2], (float)Value3[Tri[i].Peak[2], 1]));
                myGraphics.Dispose();
                this.pictureBox1.Image = curBitmap;
            }
            Data.db_num1 = K;
            Data.db_num2 = o;
            Data.db_num3 = k;
            iscal = true;
            MessageBox.Show("计算完成！");

        }

        private void 添加ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.Rows.Add();
            DataGridViewRow r = dataGridView1.Rows[i];
        }

        private void 插入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(rowIndex);
            dataGridView1.Rows.Insert(i, new DataGridViewRow());
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iscal == false)
            {
                MessageBox.Show("请先计算！");
            }
            else
            {
                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "文本文件（*.txt）|*.txt|所有（*.*）|*.*";//文件类型
                open.FilterIndex = 1;//默认值类型为第一项
                open.RestoreDirectory = true;
                string localFilePath = "";
                string fileNameExt = "";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    localFilePath = open.FileName.ToString(); //获得文件路径 
                    //获取文件名，不带路径
                    fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
                if (localFilePath != "" && fileNameExt != "")
                {
                    FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                    //通过指定字符编码方式可以实现对汉字的支持，否则在用记事本打开查看会出现乱码
                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));

                    sw.WriteLine("                                   三角形信息");
                    sw.WriteLine("三角形编号    顶点1   顶点2   顶点3   边1   边2   边3   相临三角形1 相临三角形2 相临三角形3    土方量");
                    for (int i = 0; i < K; i++)
                    {
                        sw.WriteLine("{0,6}{1,12}{2,8}{3,8}{4,6}{5,6}{6,6}  {7,8}    {8,8}    {9,8}    {10,12}", (i + 1).ToString(), Tri[i].Peak[0].ToString(),
                               Tri[i].Peak[1].ToString(), Tri[i].Peak[2].ToString(), Tri[i].Line[0].ID.ToString(), Tri[i].Line[1].ID.ToString(), Tri[i].Line[2].ID.ToString(),
                               Tri[i].Bor[0].ToString(), Tri[i].Bor[1].ToString(), Tri[i].Bor[2].ToString(), Data.dc_v[i].ToString());
                    }
                    sw.WriteLine("\r\n");
                    sw.WriteLine("*********************************************************************************************");
                    sw.WriteLine("                  边信息");
                    sw.WriteLine("边编号   顶点1   顶点2  相临三角形1 相临三角形2");
                    for (int i = 0; i < o; i++)
                    {
                        sw.WriteLine("{0,5}{1,8}{2,8}{3,8}      {4,6}", (i + 1).ToString(), Line[i].Point[0].ToString(), Line[i].Point[1].ToString(),
                            Line[i].Bor[0].ToString(), Line[i].Bor[1].ToString());
                    }

                    sw.WriteLine("\r\n");
                    sw.WriteLine("*********************************************************************************************");
                    sw.WriteLine("                  离散特征点信息");
                    sw.WriteLine("  点号           X              Y               Z");
                    for (int i = 0; i < k; i++)
                    {
                        sw.WriteLine("{0,5}   {1,14}  {2,14}  {3,12}", (i + 1).ToString(), Value1[i, 1].ToString(),
                               Value1[i, 2].ToString(), Value1[i, 3].ToString());
                    }

                    sw.Close();

                    MessageBox.Show("保存路径：" + localFilePath);
                }
            }
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int t = Convert.ToInt16(rowIndex);
            dataGridView1.Rows.RemoveAt(t);
        }
        
        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                SolidBrush v_SolidBrush = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor);
                int v_LineNo = 0;
                v_LineNo = e.RowIndex + 1;
                string v_Line = v_LineNo.ToString();
                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);

            }
            catch (Exception ex)
            {
                MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }

    }
}
