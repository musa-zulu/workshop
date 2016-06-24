namespace FizzBuzzKata
{
    public class FizzBuzz
    {
        public string IsFizzBuzz(int input)
        {
            if (IsDivisibleByBothThreeAndFive(input))
                return GetFizzbuzz();
            if (IsDivisibleByThree(input))
                return GetFizz();
            return IsDivisibleByFive(input) ? GetBuzz() : input.ToString();
        }

        private static bool IsDivisibleByBothThreeAndFive(int input)
        {
            return IsDivisibleByThree(input) && IsDivisibleByFive(input);
        }

        private static bool IsDivisibleByFive(int input)
        {
            return input % 5 == 0;
        }

        private static string GetFizzbuzz()
        {
            return "FizzBuzz";
        }

        private static string GetFizz()
        {
            return "Fizz";
        }

        private static string GetBuzz()
        {
            return "Buzz";
        }

        private static bool IsDivisibleByThree(int input)
        {
            return input % 3 == 0;
        }
    }
}