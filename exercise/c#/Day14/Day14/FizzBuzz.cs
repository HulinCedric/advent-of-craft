using LanguageExt;

namespace Day14;

using Result = Option<string>;

public static class FizzBuzz
{
    private const int Min = 0;
    private const int Max = 100;

    private static readonly Dictionary<int, string> Mapping = new()
    {
        { 15, "FizzBuzz" },
        { 3, "Fizz" },
        { 5, "Buzz" }
    };

    public static Result Convert(int input)
        => IsOutOfRange(input)
               ? ToFailure()
               : ConvertSafely(input);

    private static Result ConvertSafely(int input)
        => Mapping
            .Find(kvp => Is(kvp.Key, input))
            .Map(kvp => kvp.Value)
            .FirstOrDefault(input.ToString());

    private static bool Is(int divisor, int input)
        => input % divisor == 0;

    private static bool IsOutOfRange(int input)
        => input is <= Min or > Max;

    private static Result ToFailure()
        => Result.None;
}