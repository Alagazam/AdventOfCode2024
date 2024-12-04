using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day04Test
    {
        readonly string input =
@"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";

        readonly Int64 resultA = 18;
        readonly Int64 resultB = 9;

        [Fact]
        public void Day04a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day04.Day04a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day04a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day04b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day04.Day04b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day04b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day04Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
