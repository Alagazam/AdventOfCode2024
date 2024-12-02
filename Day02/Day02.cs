using System.Diagnostics;
using System.Windows.Markup;

namespace AoC
{
    public static class Day02
    {
        private static bool Test(Int64[] values)
        {
            bool safe = true;
            int dir = Math.Sign(values[0] - values[1]);
            if (dir == 0) { return false; }
            for (int i = 0; i != values.Length - 1; ++i)
            {
                var diff = values[i] - values[i + 1];
                if (Math.Sign(diff) != dir) { safe = false; break; }
                if (Math.Abs(diff) > 3) { safe = false; break; }
            }

            return safe;
        }

        public static Int64 Day02a(string[] input)
        {
            int count = 0;
            foreach (string s in input)
            {
                var values = s.Split(' ').Select(Int64.Parse).ToArray();
                if (Test(values)) { count++; }
            }

            return count;
        }

        public static Int64 Day02b(string[] input)
        {
            int count = 0;
            foreach (string s in input)
            {
                var values = s.Split(' ').Select(Int64.Parse).ToArray();
                if (Test(values)) { count++; }
                else
                {
                    bool safe = false;
                    for (int n = 0; n != values.Length; ++n)
                    {
                        var newValues = values.Take(n).Concat(values.Skip(n+1).Take(values.Length-n)).ToArray();
                        if (Test(newValues)) { count++; safe = true; Console.WriteLine("Safe: {0}   {1}", string.Join(", ", values), string.Join(", ", newValues));  break; }
                    }
                    if (safe) Console.Write("");
                }
            }

            return count;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day02.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day02a : {0}   Time: {1}", Day02a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day02b : {0}   Time: {1}", Day02b(lines), sw.ElapsedMilliseconds);
        }
    }
}
