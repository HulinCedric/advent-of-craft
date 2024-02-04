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

        if (input.IsDivisibleBy(3) &&
            input.IsDivisibleBy(5))
        {
            return "FizzBuzz";
        }

        if (input.IsDivisibleBy(3))
        {
            return "Fizz";
        }

        if (input.IsDivisibleBy(5))
        {
            return "Buzz";
        }

        return input.ToString();
    }

    private static bool IsDivisibleBy(this int number, int divisor)
        => number % divisor == 0;
}