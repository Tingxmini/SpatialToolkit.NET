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
    public partial class main1 : Form
    {
        public main1()
        {
            InitializeComponent();
        }

        private void 点在多边形内ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fengxiangmeigui fxmg2 = new fengxiangmeigui();
            //fxmg2.Show();
            //podu pd1 = new podu();
            //pd1.Show();
            podu  pd1 = new podu();
            //tiji.ShowDialog();
            //设置子窗口不显示为顶级窗口
            pd1.TopLevel = false;
            //设置子窗口的样式，没有上面的标题栏
            pd1.FormBorderStyle = FormBorderStyle.None;
            //填充
            pd1.Dock = DockStyle.Fill;
            
            //this.Controls.Clear();
            ////加入控件
            this.Controls.Add(pd1);
            //让窗体显示
            pd1.Show();

        }

        private void pointweedingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            suijishengchengshu sjs = new suijishengchengshu();
            sjs.Show();
        }

        private void 多边形面积计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zhixin zx2 = new zhixin();
            zx2.Show();
        }

        private void 线与线的距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 两点之间的距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            voronoi vr = new voronoi();
            vr.Show();

        }

        private void 点到线段的距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 风向玫瑰图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 多边形质心与中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zhengtaiyun zty = new zhengtaiyun();
            zty.Show();
        }

        private void 生成voronoi图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 不规则三角网体积和表面积计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 三角形生长法生成tinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 表面积和体积计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 矢量数据面积量算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jisuan jss = new jisuan();
            jss.Show();
        }

        private void 矢量数据距离量算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 两点之间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            矢量距离计算 sljs = new 矢量距离计算();
            sljs.Show();
        }

        private void 点与线之间距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pointtoline ptl = new pointtoline();
            ptl.Show();
        }

        private void 线与线之间距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ltl ltl1 = new ltl();
            ltl1.Show();
        }

        private void 判断点在多边形内外ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 m2 = new Form2();
            m2.Show();
        }

        private void pointWeedingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pointweeding ptwd = new pointweeding();
            ptwd.Show();
        }

        private void 多边形质心与中心计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zhixin zx = new zhixin();
            zx.Show();
        }

        private void 风向玫瑰图1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fengxiangmeigui m12 = new fengxiangmeigui();
            m12.Show();
        }

        private void 矢量数据的距离量算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            voronoi vr = new voronoi();
            vr.Show();
        }

        private void 三角形生长法生成TINToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            podu11 m11 = new podu11();
            m11.Show();
        }

        private void 表面积计算和空间体积量测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main m1 = new Main();
            m1.Show();
        }

        private void 线平滑与点抽稀ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 逐点插入法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tinzhudian tzd = new tinzhudian();
            tzd.Show();
        }

        private void 等高线生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frm1 = new frmMain();
            frm1.Show();
        }

        private void 凸壳生成法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tukeshengcheng tksc = new tukeshengcheng();
            tksc.Show();
        }
    }
}
