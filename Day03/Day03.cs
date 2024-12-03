using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AoC
{
    public static class Day03
    {
        public static Int64 Day03a(string[] input)
        {
            Int64 sum = 0;
            // mul(X,Y), where X and Y are each 1-3 digit number
            var regex = new Regex( @"mul\(([\d]{1,3}),([\d]{1,3})\)" );
            foreach (var i in input)
            {
                var matches = regex.Matches(i);
                foreach (Match match in matches)
                {
                    sum += Int64.Parse(match.Groups[1].Value) * Int64.Parse(match.Groups[2].Value);
                }
            }
            return sum;
        }

        public static Int64 Day03b(string[] input)
        {
            Int64 sum = 0;
            bool do_mul = true;
            // mul(X,Y), where X and Y are each 1-3 digit number
            var regex = new Regex(@"((mul)\(([\d]{1,3}),([\d]{1,3})\))|(do(n't)?)\(\)");
            foreach (var i in input)
            {
                var matches = regex.Matches(i);
                foreach (Match match in matches)
                {
                    if (do_mul && match.Groups[2].Value == "mul")
                    {
                        sum += Int64.Parse(match.Groups[3].Value) * Int64.Parse(match.Groups[4].Value);
                    }
                    else if (match.Groups[5].Value == "do")
                    {
                        do_mul = true;
                    }
                    else if (match.Groups[5].Value == "don't")
                    {
                        do_mul = false;
                    }
                }
            }
            return sum;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day03.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day03a : {0}   Time: {1}", Day03a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day03b : {0}   Time: {1}", Day03b(lines), sw.ElapsedMilliseconds);
        }
    }
}
