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
    public partial class tindv : Form
    {
        public tindv()
        {
            InitializeComponent();
        }
        public int value;
        private void button1_Click(object sender, EventArgs e)
        {
            value = Convert.ToInt32(numericUpDown1.Value);
            this.Hide();
            this.Close();
        }
    }
}
