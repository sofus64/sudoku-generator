using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_generator
{
    internal class MyRandom
    {
        public static int RandomNumber(int num)
        {
            Random rnd = new();
            return rnd.Next(1, num+1);
        }   
    }
}
