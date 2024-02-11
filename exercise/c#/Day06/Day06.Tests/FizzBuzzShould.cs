using Day06.Tests.Data;
using FluentAssertions;
using Xunit;

namespace Day06.Tests;

public class FizzBuzzShould
{
    [Theory]
    [ClassData(typeof(Numbers))]
    [ClassData(typeof(FizzNumbers))]
    [ClassData(typeof(BuzzNumbers))]
    [ClassData(typeof(FizzBuzzNumbers))]
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