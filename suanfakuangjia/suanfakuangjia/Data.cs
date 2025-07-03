using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suanfakuangjia
{
    class Data
    {
        static public int db_count { get; set; }//表格行数计数器
        static public int db_num1 { get; set; }//三角形计数器
        static public int db_num2 { get; set; }//边计数器
        static public int db_num3 { get; set; }//离散点计数器
        static public double db_h { get; set; }//表格行数计数器
        static public double[,] db_Value1 { get; set; }//存文件数据
        static public double[] dc_v { get; set; }//存土方量
        public class Line
        {
            public int ID;
            public int[] Point = new int[2];
            public int[] Bor = new int[2];
        }
        public class Triangle
        {
            public int ID;
            public int[] Peak = new int[3];
            public Line[] Line = new Line[3];
            public int[] Bor = new int[3];

        }
    }
}
