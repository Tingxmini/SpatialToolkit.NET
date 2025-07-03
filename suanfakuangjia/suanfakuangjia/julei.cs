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
    public partial class julei : Form
    {
        public julei()
        {
            InitializeComponent();
        }
        public int kzhi1;
        private void button20_Click(object sender, EventArgs e)
        {
            kzhi1 = Convert.ToInt32(textBox6.Text);
            this.Hide();
            this.Close();
        }
    }
}
