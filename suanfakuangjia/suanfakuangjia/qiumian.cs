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
    public partial class qiumian : Form
    {
        public qiumian()
        {
            InitializeComponent();
        }
        public int al1;
        public int al2;
        public int bl1;
        public int bl2;
        private void button16_Click(object sender, EventArgs e)
        {
             al1= int.Parse(Alon.Text);
           al2 = int.Parse(Alat.Text);
            bl1 = int.Parse(Blon.Text);
            bl2 = int.Parse(Blat.Text);
            this.Hide();
            this.Close();
        }
    }
}
