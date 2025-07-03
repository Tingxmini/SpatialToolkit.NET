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
    public partial class kochqx : Form
    {
        public kochqx()
        {
            InitializeComponent();
        }
        public int value;

        private void button6_Click(object sender, EventArgs e)
        {
            value = Convert.ToInt32(comboBox3.Text);
            this.Hide();
            this.Close();
        }
    }
}
