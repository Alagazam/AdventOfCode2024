using System.Diagnostics;

namespace AoC
{
    public static class Day05
    {

        public static Int64 Day05a(string[] input)
        {
            var ordering = GetOrdering(input);

            int row = Array.IndexOf(input, "");

            int sum = 0;
            for (int i = row + 1; i != input.Length; ++i)
            {
                var values = input[i].Split(',').Select(int.Parse).ToArray();

                bool correctOrder = IsOrderCorrect(ordering, values);

                if (correctOrder) sum += values[values.Length / 2];
            }

            return sum;
        }

        private static List<Tuple<int, int>> GetOrdering(string[] input)
        {
            var ordering = new List<Tuple<int, int>>();
            foreach (string s in input)
            {
                if (s.Length == 0) break;
                var values = s.Split('|');
                ordering.Add(Tuple.Create(int.Parse(values[0]), int.Parse(values[1])));
            }
            return ordering;
        }

        private static bool IsOrderCorrect(List<Tuple<int, int>> ordering, int[] values)
        {
            bool allCorrectOrder = true;
            for (int first = 0; first != values.Length - 1; ++first)
            {
                bool firstIsCorrect = true;
                for (int second = first + 1; second != values.Length; ++second)
                {
                    bool thisPairCorrect = IsPairCorrectOrder(ordering, values[first], values[second]);
                    if (thisPairCorrect) continue;
                    firstIsCorrect = false; break;
                }
                if (!firstIsCorrect) { allCorrectOrder = false; break; }
            }

            return allCorrectOrder;
        }

        private static bool IsPairCorrectOrder(List<Tuple<int, int>> ordering, int firstVal, int secondVal)
        {
            foreach (var order in ordering)
            {
                if (order.Item1 == firstVal && order.Item2 == secondVal)
                {
                    return true;
                }
            }
            return false;
        }

        public static Int64 Day05b(string[] input)
        {
            var ordering = GetOrdering(input);

            int row = Array.IndexOf(input, "");

            int sum = 0;
            for (int i = row + 1; i != input.Length; ++i)
            {
                var values = input[i].Split(',').Select(int.Parse).ToArray();

                bool correctOrder = IsOrderCorrect(ordering, values);

                if (!correctOrder)
                {
                    var order = GetCorrectOrder(ordering, values);
                    sum += order[order.Length / 2];
                }
            }

            return sum;
        }

        private static int[] GetCorrectOrder(List<Tuple<int, int>> ordering, int[] values)
        {
            List<int> newList = new List<int>();
            foreach (var value in values)
            {
                if (newList.Count == 0) newList.Add(value);
                else
                {
                    int index = -1;
                    bool before = false;
                    foreach (var newListValue in newList)
                    {
                        foreach(var order in ordering )
                        {
                            // Found rule placing value befor current position in newList -> the right position is found
                            if (order.Item1 == value && order.Item2 == newListValue)
                            {
                                index = newList.IndexOf(newListValue);
                                before = true;
                                break;
                            }
                            // Found rule placing value after current position in newList -> posible position is found, but needs to check rest of list
                            if (order.Item1 == newListValue && order.Item2 == value)
                            {
                                index = newList.IndexOf(newListValue) + 1;
                                break;
                            }
                        }
                        if (before) break;
                    }
                    if (index != -1)
                    {
                        newList.Insert(index, value);
                    }
                }
            }
            return newList.ToArray();
        }

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Day05.txt");
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Day05a : {0}   Time: {1}", Day05a(lines), sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine("Day05b : {0}   Time: {1}", Day05b(lines), sw.ElapsedMilliseconds);
        }
    }
}
