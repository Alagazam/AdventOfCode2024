using System.Diagnostics;

namespace AoC
{
    using Position = Tuple<int, int>;

    public static class Day06
    {
        private static Position FindGuard(char[][] grid)
        {
            for (int row = 0; row != grid.Length; ++row)
            {
                var col = Array.IndexOf(grid[row], '^');
                if (col != -1) return new Position(row, col);
            }
            return new Position(-1, -1);
        }

        public static Int64 Day06a(string[] input)
        {
            var grid = input.Select(s => s.ToCharArray()).ToArray();

            int count = 1;
            Position guard = FindGuard(grid);

            Position dir = new Position(-1, 0);

            while (guard.Item1 >= 0 && guard.Item1 < grid.Length && guard.Item2 >= 0 && guard.Item2 < grid[0].Length)
            {
                if (grid[guard.Item1][guard.Item2] == '.') ++count;
                grid[guard.Item1][guard.Item2] = 'X';
                Position next = new Position(guard.Item1 + dir.Item1, guard.Item2 + dir.Item2);
                if (next.Item1 >= 0 && next.Item1 < grid.Length && next.Item2 >= 0 && next.Item2 < grid[0].Length)
                {
                    if (grid[next.Item1][next.Item2] == '#')
                    {
                        dir = new Position(dir.Item2, -dir.Item1);
                    }
                    else
                    {
                        guard = next;
                    }
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        public static Int64 Day06b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day06.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day06a : {0}   Time: {1}", Day06a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day06b : {0}   Time: {1}", Day06b(lines), sw.ElapsedMilliseconds);
        }
    }
}
