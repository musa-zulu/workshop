using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKataCalculator
{
    public class StringCalculator : IStringCalculator
    {

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var delimiters = new List<string> { ",", "\n" };

            input = HandleNumbersWithCustomDelimiters(input, delimiters);
            var numbers = SplitNumbers(input, delimiters);

            CheckNegative(numbers);
            numbers = FilterNumbersGreaterThan(1000, numbers);
            return numbers.Sum();
        }

        private static string HandleNumbersWithCustomDelimiters(string input, List<string> delimiters)
        {
            if (!HasCustomDelimiterSlash(input)) return input;
            var index = input.IndexOf("\n", StringComparison.Ordinal);
            AddNewDelimitersToList(input, delimiters, index);
            input = ExtractNumbersPart(input, index);
            return input;
        }

        private static IEnumerable<int> FilterNumbersGreaterThan(int max, IEnumerable<int> numbers)
        {
            return numbers.Where(n => n <= max);
        }

        private static string ExtractNumbersPart(string input, int index)
        {
            input = input.Substring(index + 1);
            return input;
        }

        private static void AddNewDelimitersToList(string input, List<string> delimiters, int index)
        {
            delimiters.AddRange(input.Substring(0, index)
                .Replace("//", "")
                .Trim(']', '[')
                .Split(new[] { "][" },
                StringSplitOptions.RemoveEmptyEntries));
        }

        private static bool HasCustomDelimiterSlash(string input)
        {
            return input.StartsWith("//");
        }

        private static void CheckNegative(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0);
            if (negatives.Any())
                throw new ApplicationException("negatives are not allowed : " + string.Join(",", negatives));
        }

        private static IEnumerable<int> SplitNumbers(string input, List<string> delimiters)
        {
            return input.Split(delimiters.ToArray(), StringSplitOptions.None).Select(int.Parse);
        }
    }

    public interface IStringCalculator
    {
        int Add(string input);
    }
}