namespace Day02;

public static class FizzBuzz
{
    public static string Convert(int input)
    {
        if (input <= 0)
        {
            throw new OutOfRangeException();
        }

        if (input > 100)
        {
            throw new OutOfRangeException();
        }

        if (IsDivisibleBy(input, 3) &&
            IsDivisibleBy(input, 5))
        {
            return "FizzBuzz";
        }

        if (IsDivisibleBy(input, 3))
        {
            return "Fizz";
        }

        if (IsDivisibleBy(input, 5))
        {
            return "Buzz";
        }

        return input.ToString();
    }

    private static bool IsDivisibleBy(int number, int divisor)
        => number % divisor == 0;
}