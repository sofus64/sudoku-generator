namespace sudoku_generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sudoku = new Sudoku();
            sudoku.GenerateBoard();
            sudoku.PrintGrid();
        }
    }
}
