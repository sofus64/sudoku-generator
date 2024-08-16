namespace sudoku_generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var sudoku = new Sudoku();
            sudoku.GenerateBoard();
            sudoku.PrintGrid();
            Console.WriteLine("");
            Console.WriteLine("Press any key to generate new sudoku..");
            Console.ReadKey(true);
            Console.Clear();
            Run();
        }
    }
}
