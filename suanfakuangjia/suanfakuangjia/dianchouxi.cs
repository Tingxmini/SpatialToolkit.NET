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
    public partial class dianchouxi : Form
    {
        public dianchouxi()
        {
            InitializeComponent();
        }
        public float yz1;
        private void button4_Click(object sender, EventArgs e)
        {
            yz1 =  Convert.ToSingle(comboBox1.Text);
            this.Hide();
            this.Close();
        }
    }
}
