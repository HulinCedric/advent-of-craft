namespace Day02;

public static class FizzBuzz
{
    public static string Convert(int number)
        => number switch
        {
            _ when number.IsOutOfRange() => ToFailure(),
            _ when number.IsDivisibleBy(15) => "FizzBuzz",
            _ when number.IsDivisibleBy(3) => "Fizz",
            _ when number.IsDivisibleBy(5) => "Buzz",
            _ => number.Representation()
        };

    private static bool IsOutOfRange(this int number)
        => number is <= 0 or > 100;

    private static string ToFailure()
        => throw new OutOfRangeException();

    private static bool IsDivisibleBy(this int number, int divisor)
        => number % divisor == 0;

    private static string Representation(this int number)
        => number.ToString();
}