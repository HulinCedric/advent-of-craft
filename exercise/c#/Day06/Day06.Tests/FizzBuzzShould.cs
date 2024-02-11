using FluentAssertions;
using Xunit;

namespace Day06.Tests;

public class FizzBuzzShould
{
    public static TheoryData<int, string> BuzzNumbers
        => new()
        {
            { 5, "Buzz" },
            { 50, "Buzz" },
            { 85, "Buzz" }
        };

    public static TheoryData<int, string> FizzBuzzNumbers
        => new()
        {
            { 15, "FizzBuzz" },
            { 30, "FizzBuzz" },
            { 45, "FizzBuzz" }
        };

    public static TheoryData<int, string> FizzNumbers
        => new()
        {
            { 3, "Fizz" },
            { 66, "Fizz" },
            { 99, "Fizz" }
        };

    public static TheoryData<int, string> Numbers
        => new()
        {
            { 01, "1" },
            { 67, "67" },
            { 82, "82" }
        };

    [Theory]
    [MemberData(nameof(Numbers))]
    [MemberData(nameof(FizzNumbers))]
    [MemberData(nameof(BuzzNumbers))]
    [MemberData(nameof(FizzBuzzNumbers))]
    public void Convert_number(int input, string output)
        => FizzBuzz.Convert(input)
            .Should()
            .Be(output);

    [Theory]
    [InlineData(0)]
    [InlineData(101)]
    [InlineData(-1)]
    public void Fails_when_the_number_is_out_of_range(int input)
        => ((Action)(() => FizzBuzz.Convert(input)))
            .Should()
            .Throw<OutOfRangeException>();
}