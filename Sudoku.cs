using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_generator
{
    internal class Sudoku
    {
        private int[,] Board;
        private int Size;
        private int BoxSize;

        public Sudoku(int Size = 9)
        {
            this.Size = Size;
            BoxSize = (int)Math.Sqrt(Size);
            Board = new int[Size, Size];
        }




    }
}
