using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace AoC
{
    public class Day05Test
    {
        readonly string input =
@"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47";

        readonly Int64 resultA = 143;
        readonly Int64 resultB = 123;

        [Fact]
        public void Day05a()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine /*, StringSplitOptions.RemoveEmptyEntries*/);

            var result = Day05.Day05a(lines);
            Assert.Equal(resultA, result);

            Console.WriteLine("Day05a : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }


        [Fact]
        public void Day05b()
        {
            var sw = Stopwatch.StartNew();
            var lines = input.Split(Environment.NewLine/*, StringSplitOptions.RemoveEmptyEntries*/);

            var result = Day05.Day05b(lines);
            Assert.Equal(resultB, result);

            Console.WriteLine("Day05b : {0}   Time: {1}", result, sw.ElapsedMilliseconds);
        }

        public Day05Test(ITestOutputHelper output)
        {
            var converter = new AoCUtils.Converter(output);
            Console.SetOut(converter);
        }

    }

}
