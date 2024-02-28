using LanguageExt;

namespace Day14;

public static class FizzBuzz
{
    private const int Min = 0;
    private const int Max = 100;
    private const int Fizz = 3;
    private const int Buzz = 5;
    private const int Fizz_Buzz = 15;

    private static readonly IReadOnlyDictionary<Predicate<int>, Func<int, string>> mapping =
        new Dictionary<Predicate<int>, Func<int, string>>
        {
            { i => Is(Fizz_Buzz, i), i => "FizzBuzz" },
            { i => Is(Fizz, i), i => "Fizz" },
            { i => Is(Buzz, i), i => "Buzz" },
            { i => true, i => i.ToString() }
        };

    private static bool Is(int divisor, int input)
        => input % divisor == 0;

    private static bool IsOutOfRange(int input)
        => input is <= Min or > Max;

    public static Option<string> Convert(int input)
    {
        if (IsOutOfRange(input))
            return Option<string>.None;
        
        var mappingFunction = mapping
            .Where(kvp => kvp.Key(input))
            .Select(kvp => kvp.Value)
            .FirstOrDefault();

        return mappingFunction != null
                   ? mappingFunction(input)
                   : Option<string>.None;
    }
}