using FluentAssertions;
using Xunit;

namespace Day06.Tests;

public class FizzBuzzShould
{
    [Theory]
    [InlineData(01, "1")]
    [InlineData(03, "Fizz")]
    [InlineData(05, "Buzz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(30, "FizzBuzz")]
    [InlineData(45, "FizzBuzz")]
    [InlineData(50, "Buzz")]
    [InlineData(66, "Fizz")]
    [InlineData(67, "67")]
    [InlineData(82, "82")]
    [InlineData(85, "Buzz")]
    [InlineData(99, "Fizz")]
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