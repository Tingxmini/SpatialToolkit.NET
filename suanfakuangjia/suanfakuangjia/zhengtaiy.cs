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
    public partial class zhengtaiy : Form
    {
        public zhengtaiy()
        {
            InitializeComponent();
        }
        public double qiwang;
        public double shang;
        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            qiwang = Convert.ToDouble(textBox1.Text);
            shang = Convert.ToDouble(textBox2.Text);
            this.Hide();
            this.Close();
        }
    }
}
