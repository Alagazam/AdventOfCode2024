using System.Diagnostics;

namespace AoC
{
    public static class Day04
    {
        public static int CheckForXMAS(string[] input, int row, int col)
        {
            int count = 0;
            if (input[row][col] != 'X') return 0;
            // check up
            if (CheckDir(input, row, col, -1, -1)) ++count;
            if (CheckDir(input, row, col, -1,  0)) ++count;
            if (CheckDir(input, row, col, -1,  1)) ++count;

            // checke left - right
            if (CheckDir(input, row, col,  0, -1)) ++count;
            if (CheckDir(input, row, col,  0,  1)) ++count;

            // check down
            if (CheckDir(input, row, col,  1, -1)) ++count;
            if (CheckDir(input, row, col,  1,  0)) ++count;
            if (CheckDir(input, row, col,  1,  1)) ++count;

            return count;
        }
        public static bool CheckDir(string[] input, int row, int col, int drow, int dcol)
        {
            string mas = "XMAS";

            for (int i = 1; i != mas.Length; ++i)
            {
                if (row + drow * i < 0 || row + drow * i >= input.Length) return false;
                if (col + dcol * i < 0 || col + dcol * i >= input[0].Length) return false;
                if (input[row + drow * i][col + dcol * i] != mas[i]) return false;
            }

            return true;
        }

        public static Int64 Day04a(string[] input)
        {
            int count = 0;
            for (int row = 0; row != input.Length; ++row)
            {
                for (int col = 0; col != input[0].Length; ++col)
                {
                    count += CheckForXMAS(input, row, col);
                }
            }
            return count;
        }

        public static int CheckForMAS(string[] input, int row, int col)
        {
            if (input[row][col] != 'A') return 0;

            if (input[row-1][col-1] == 'M' && input[row + 1][col + 1] == 'S'
                || input[row - 1][col - 1] == 'S' && input[row + 1][col + 1] == 'M')
            {
                if (input[row - 1][col + 1] == 'M' && input[row + 1][col - 1] == 'S'
                    || input[row - 1][col + 1] == 'S' && input[row + 1][col - 1] == 'M')
                {
                    return 1;
                }
            }

            return 0;
        }
        public static Int64 Day04b(string[] input)
        {
            int count = 0;
            for (int row = 1; row != input.Length - 1; ++row)
            {
                for (int col = 1; col != input[0].Length - 1; ++col)
                {
                    count += CheckForMAS(input, row, col);
                }
            }
            return count;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day04.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day04a : {0}   Time: {1}", Day04a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day04b : {0}   Time: {1}", Day04b(lines), sw.ElapsedMilliseconds);
        }
    }
}
