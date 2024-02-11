using FluentAssertions;
using Xunit;

namespace Day06.Tests;

public class FizzBuzzTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(67, "67")]
    [InlineData(82, "82")]
    public void Returns_The_Given_Number_For_(int input, string output) => FizzBuzz.Convert(input).Should().Be(output);

    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(66, "Fizz")]
    [InlineData(99, "Fizz")]
    public void Returns_Fizz_For_(int input, string output) => FizzBuzz.Convert(input).Should().Be(output);

    [Theory]
    [InlineData(5, "Buzz")]
    [InlineData(50, "Buzz")]
    [InlineData(85, "Buzz")]
    public void Returns_Buzz_For_(int input, string output) => FizzBuzz.Convert(input).Should().Be(output);

    [Theory]
    [InlineData(15, "FizzBuzz")]
    [InlineData(30, "FizzBuzz")]
    [InlineData(45, "FizzBuzz")]
    public void Returns_FizzBuzz_For_(int input, string output) => FizzBuzz.Convert(input).Should().Be(output);

    [Theory]
    [InlineData(0)]
    [InlineData(101)]
    [InlineData(-1)]
    public void Throws_An_Exception_For_(int input)
    {
        var act = () => FizzBuzz.Convert(input);
        act.Should().Throw<OutOfRangeException>();
    }
}