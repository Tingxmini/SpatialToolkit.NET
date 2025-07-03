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
    public partial class tzhengdian : Form
    {
        public tzhengdian()
        {
            InitializeComponent();
        }
        public double gaoch1;
        private void button1_Click(object sender, EventArgs e)
        {
            gaoch1 = Convert.ToDouble(textBox1.Text);
            this.Hide();
            this.Close();
        }
    }
}
