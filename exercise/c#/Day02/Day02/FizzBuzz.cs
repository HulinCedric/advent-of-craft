namespace Day02;

public static class FizzBuzz
{
    public static string Convert(int number)
        => number switch
        {
            <= 0 => throw new OutOfRangeException(),
            > 100 => throw new OutOfRangeException(),
            _ when number.IsDivisibleBy(3) && number.IsDivisibleBy(5) => "FizzBuzz",
            _ when number.IsDivisibleBy(3) => "Fizz",
            _ when number.IsDivisibleBy(5) => "Buzz",
            _ => number.ToString()
        };

    private static bool IsDivisibleBy(this int number, int divisor)
        => number % divisor == 0;
}