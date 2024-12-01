using System.Diagnostics;

namespace AoC
{
    public static class Day01
    {
        public static Int64 Day01a(string[] input)
        {
            List<Int64> list1 = new List<Int64>();
            List<Int64> list2 = new List<Int64>();
            foreach (string s in input)
            {
                var nums = s.Split(' ');
                list1.Add(Int64.Parse(nums[0]));
                list2.Add(Int64.Parse(nums[3]));
            }
            list1.Sort();
            list2.Sort();
            var diffs = list1.Zip(list2, (first, second) => Math.Abs(first - second));
            var diffsum = diffs.Sum();

            return diffsum;
        }

        public static Int64 Day01b(string[] input)
        {
            return 0;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day01.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day01a : {0}   Time: {1}", Day01a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day01b : {0}   Time: {1}", Day01b(lines), sw.ElapsedMilliseconds);
        }
    }
}
