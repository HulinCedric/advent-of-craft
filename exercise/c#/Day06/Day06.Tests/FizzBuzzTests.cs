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
    [InlineData(3)]
    [InlineData(66)]
    [InlineData(99)]
    public void Returns_Fizz_For_(int input) => FizzBuzz.Convert(input).Should().Be("Fizz");

    [Theory]
    [InlineData(5)]
    [InlineData(50)]
    [InlineData(85)]
    public void Returns_Buzz_For_(int input) => FizzBuzz.Convert(input).Should().Be("Buzz");

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    public void Returns_FizzBuzz_For_(int input) => FizzBuzz.Convert(input).Should().Be("FizzBuzz");

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