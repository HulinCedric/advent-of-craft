namespace Day02;

public static class FizzBuzz
{
    public static string Convert(int number)
    {
        if (number <= 0)
        {
            throw new OutOfRangeException();
        }

        if (number > 100)
        {
            throw new OutOfRangeException();
        }

        if (number.IsDivisibleBy(3) &&
            number.IsDivisibleBy(5))
        {
            return "FizzBuzz";
        }

        if (number.IsDivisibleBy(3))
        {
            return "Fizz";
        }

        if (number.IsDivisibleBy(5))
        {
            return "Buzz";
        }

        return number.ToString();
    }

    private static bool IsDivisibleBy(this int number, int divisor)
        => number % divisor == 0;
}