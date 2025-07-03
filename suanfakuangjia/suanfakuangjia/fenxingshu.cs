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
    public partial class fenxingshu : Form
    {
        public fenxingshu()
        {
            InitializeComponent();
        }
        public int lent1;
        public int widt1;

        private void 欧式距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 绝对值距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 切氏距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 计算球面距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 线到线的距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 多边形面积计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 多边形质心计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 多边形中心计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 生成Koch曲线ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            lent1 = Convert.ToInt32(textBox4.Text);
            widt1 = Convert.ToInt32(textBox5.Text);
            this.Hide();
            this.Close();
        }
    }
}
