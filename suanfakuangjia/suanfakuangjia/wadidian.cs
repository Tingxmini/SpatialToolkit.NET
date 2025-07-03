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
    public partial class wadidian : Form
    {
        public wadidian()
        {
            InitializeComponent();
        }
        public double gaoch2;
        private void button1_Click(object sender, EventArgs e)
        {
            gaoch2 = Convert.ToDouble(textBox1.Text);
            this.Hide();
            this.Close();
        }
    }
}
