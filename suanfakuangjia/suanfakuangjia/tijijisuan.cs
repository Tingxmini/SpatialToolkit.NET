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
    public partial class tijijisuan : Form
    {
        public tijijisuan()
        {
            InitializeComponent();
        }
        public string zdgc;
        private void button8_Click(object sender, EventArgs e)
        {
            zdgc = textBox1.Text;
            this.Hide();
            this.Close();
        }
    }
}
