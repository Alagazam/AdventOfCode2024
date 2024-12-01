using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day01Test
    {
        readonly string input =
@"3   4
4   3
2   5
1   3
3   9
3   3";

        readonly Int64 resultA = 11;
        readonly Int64 resultB = 0;

        [Fact]
        public void Day01a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day01.Day01a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day01a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day01b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day01.Day01b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day01b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day01Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
