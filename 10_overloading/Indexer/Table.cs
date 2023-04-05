using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_overloading.Indexer
{
    public class Table
    {
        private int[,] array;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public Table(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            array = new int[rows, cols];
        }
        public int this[int r, int c]
        {
            get { return array[r, c]; }
            set { array[r, c] = value; }
        }
    }
}
