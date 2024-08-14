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
        private int[,] _board;
        private int _size;
        private int _boxSize;

        public Sudoku(int size = 9)
        {
            _size = IsValidSudokuSize(size) ? size : 9;
            _boxSize = (int)Math.Sqrt(size);
            _board = new int[size, size];
        }

        public void GenerateBoard()
        {
            FillDiagonal();
        }

        private void FillDiagonal()
        {
            for (int i = 0; i < _size; i += _boxSize)
            {
                FillBox(i, i);
            }
        }

        private void FillBox(int rowStartIndex, int colStartIndex)
        {
            for (int i = 0; i < _boxSize; i++)
            {
                for (int j = 0; j < _boxSize; j++)
                {
                    int number;
                    do
                    {
                        number = MyRandom.RandomNumber(_size);
                    }
                    while (IsNumberUsedInBox(rowStartIndex, colStartIndex, number));
                    _board[rowStartIndex + i, colStartIndex + j] = number;
                }
            }
        }

        private bool IsNumberUsedInBox(int rowStartIndex, int colStartIndex, int number)
        {
            for (int i = 0; i < _boxSize; i++)
            {
                for (int j = 0; j < _boxSize; j++)
                {
                    if (_board[rowStartIndex + i, colStartIndex + j] == number) return true;
                }
            }
            return false;
        }

        private bool IsNumberUsedInRow(int rowIndex, int number)
        {
            for (int colIndex = 0; colIndex < _size; colIndex++)
            {
                if (_board[rowIndex, colIndex] == number) return true;
            }
            return false;
        }

        private bool IsNumberUsedInCol(int colIndex, int number)
        {
            for (int rowIndex = 0; rowIndex < _size; rowIndex++)
            {
                if (_board[rowIndex, colIndex] == number) return true;
            }
            return false;
        }

        private bool IsValidNumberForCell(int rowIndex, int colIndex, int number)
        {
            return (IsNumberUsedInRow(rowIndex, number) &&
                    IsNumberUsedInRow(rowIndex, number) &&
                    IsNumberUsedInBox(rowIndex - rowIndex % _boxSize, colIndex - colIndex % _boxSize, number));
        }

        private bool IsValidSudokuSize(int size)
        {
            double result = Math.Sqrt(size);
            bool isSquare = result % 1 == 0;
            return isSquare;
        }

        public void PrintGrid()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                        Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private HashSet<int[,]> FindSolutions()
        {
            HashSet<int[,]> solutions = new();
            return solutions;
        }
    }
}
