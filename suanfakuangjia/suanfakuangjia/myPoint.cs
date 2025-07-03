using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEM渲染
{
    class myPoint
    {
        private double x;      
        private double y;
        private double z;
        public myPoint(double x1,double y1,double z1)
        {
            x = x1;
            y = y1;
            z = z1;
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Z
        {
            get { return z; }
            set { z = value; }
        }
    }
}
