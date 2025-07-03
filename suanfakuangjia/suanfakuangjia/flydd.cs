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
    public partial class flydd : Form
    {
        public flydd()
        {
            InitializeComponent();
        }
        public int st11;
        public int ed11;
        private void button6_Click(object sender, EventArgs e)
        {
            st11 = Convert.ToInt32(textBox2.Text);
            ed11 = Convert.ToInt32(textBox3.Text);
            this.Hide();
            this.Close();
        }
    }
}
