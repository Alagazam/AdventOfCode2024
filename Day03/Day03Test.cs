using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day03Test
    {
        readonly string input =
@"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        readonly string input2 =
@"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        readonly Int64 resultA = 161;
        readonly Int64 resultB = 48;

        [Fact]
        public void Day03a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day03.Day03a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day03a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day03b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input2.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = Day03.Day03b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day03b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day03Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
