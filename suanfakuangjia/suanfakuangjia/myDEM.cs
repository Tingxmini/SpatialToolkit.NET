using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace suanfakuangjia
{
    class myDEM
    {
        private int rowCount;
        private int colCount;
        private double minX; 
        private double maxX;
        private double minY; 
        private double maxY;
        private double minZ;
        private double maxZ;
        private double widthX;
        private double widthY;
        private double[,] cellData;
        private string filename;
        public myDEM(string fp)
        {           
            this.filename = fp;
            initialZ();
        }
        #region  类属性
        public int RowCount
        {
            get { return rowCount; }
            set { rowCount = value; }
        }
        public int ColCount
        {
            get { return colCount; }
            set { colCount = value; }
        }           
        public double[,] CellData
       {
           get { return cellData; }
           set { cellData = value; }
       }   
        public double MinX
        {
            get { return minX; }
            set { minX = value; }
        }
        public double MaxX
        {
            get { return maxX; }
            set { maxX = value; }
        }
        public double MinY
        {
            get { return minY; }
            set { minY = value; }
        }
        public double MaxY
        {
            get { return maxY; }
            set { maxY = value; }
        }
        public double MinZ
        {
            get { return minZ; }
            set { minZ = value; }
        }
        public double MaxZ
        {
            get { return maxZ; }
            set { maxZ = value; }
        }
        public double WidthX
        {
            get { return widthX; }
            set { widthX = value; }
        }
        public double WidthY
        {
            get { return widthY; }
            set { widthY = value; }
        }
        #endregion
        #region 封装的方法
        private void initialZ()
        { 
            
            using(StreamReader sr=new StreamReader(filename))
            {
                sr.ReadLine();
                string[] split = { " " };
                //获取行列数
                string rowcol = sr.ReadLine();
                rowCount = Convert.ToInt32(rowcol.Split(split, StringSplitOptions.RemoveEmptyEntries)[0]);
                colCount = Convert.ToInt32(rowcol.Split(split, StringSplitOptions.RemoveEmptyEntries)[1]);
                cellData = new double[rowCount,colCount];
                //获取最小最大X
                string[] X = sr.ReadLine().Split(split, StringSplitOptions.RemoveEmptyEntries);
                minX = Convert.ToDouble(X[0]);
                maxX = Convert.ToDouble(X[1]);
                //获取最大最小Y
                string[] Y = sr.ReadLine().Split(split, StringSplitOptions.RemoveEmptyEntries);
                minY = Convert.ToDouble(Y[0]);
                maxY = Convert.ToDouble(Y[1]);
                //获取最大最小Z
                string[] Z = sr.ReadLine().Split(split, StringSplitOptions.RemoveEmptyEntries);
                minZ = Convert.ToDouble(Z[0]);
                maxZ = Convert.ToDouble(Z[1]);

                widthX = (maxX-minX) / rowCount;
                widthY = (MaxY-minY) / colCount;

                int p = 0, prow = 0, pcol = 0;               
                string str;
                while((str=sr.ReadLine())!=null)
                {
                    if (p % 102 != 0 || p == 0)
                    {
                        string[] ptemp = str.Split(' ');
                        for (int i = 0; i < ptemp.Length; i++)
                        {
                            if (ptemp[i] != "")
                            {
                                cellData[prow, pcol] = double.Parse(ptemp[i]);                               
                                pcol++;
                            }
                        }

                    }
                    else
                    {
                        prow++;
                        pcol = 0;
                    }
                    p++;
                }
            }
        }       
        #endregion
    }
}
