using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            FillRestOfBoard();
        }

        private void FillBox(int rowStartIndex, int colStartIndex)
        {
            for (int boxRowIndex = 0; boxRowIndex < _boxSize; boxRowIndex++)
            {
                for (int boxColIndex = 0; boxColIndex < _boxSize; boxColIndex++)
                {
                    int number;
                    do
                    {
                        number = MyRandom.RandomNumber(_size);
                    }
                    while (IsNumberUsedInBox(rowStartIndex, colStartIndex, number));
                    _board[rowStartIndex + boxRowIndex, colStartIndex + boxColIndex] = number;
                }
            }
        }

        private void FillDiagonal()
        {
            for (int i = 0; i < _size; i += _boxSize)
            {
                FillBox(i, i);
            }
        }

        private bool FillRestOfBoard(int rowIndex = 0, int colIndex = 0)
        {
            bool NextCell()
            {
                return FillRestOfBoard(rowIndex, colIndex + 1);
            }

            if (rowIndex == _size - 1 && colIndex == _size)
            {
                return true;
            }

            if (colIndex == _size)
            {
                rowIndex++;
                colIndex = 0;
            }

            if (_board[rowIndex, colIndex] != 0)
            {
                return NextCell();
            }

            for (int number = 1; number <= _size; number++)
            {
                if (IsValidNumberForCell(rowIndex, colIndex, number))
                {
                    _board[rowIndex, colIndex] = number;
                    if (NextCell())
                    {
                        return true;
                    }
                    _board[rowIndex, colIndex] = 0;
                }
            }

            return false;
        }

        private bool IsNumberUsedInBox(int rowStartIndex, int colStartIndex, int number)
        {
            for (int boxRowIndex = 0; boxRowIndex < _boxSize; boxRowIndex++)
            {
                for (int boxColIndex = 0; boxColIndex < _boxSize; boxColIndex++)
                {
                    if (_board[rowStartIndex + boxRowIndex, colStartIndex + boxColIndex] == number) return true;
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
            return !(IsNumberUsedInRow(rowIndex, number) ||
                    IsNumberUsedInCol(colIndex, number) ||
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
        // Idea for later: run a check to see if a board has multiple solutions
        //private HashSet<int[,]> FindSolutions()
        //{
        //    HashSet<int[,]> solutions = new();
        //    return solutions;
        //}
    }
}
