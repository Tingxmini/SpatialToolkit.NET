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
    public partial class djsktra : Form
    {
        public djsktra()
        {
            InitializeComponent();
        }
        public string qidian1;
        private void button3_Click(object sender, EventArgs e)
        {
            qidian1 = textBox1.Text;
            this.Hide();
            this.Close();
        }
    }
}
