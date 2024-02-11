using FluentAssertions;
using Xunit;

namespace Day06.Tests;

public class FizzBuzzTests
{
    #region "Normal" numbers

    [Theory]
    [InlineData(1, "1")]
    [InlineData(67, "67")]
    [InlineData(82, "82")]
    public void Returns_The_Given_Number_For_(int input, string output) => FizzBuzz.Convert(input).Should().Be(output);
    
    #endregion

    #region Fizz

    [Theory]
    [InlineData(3)]
    [InlineData(66)]
    [InlineData(99)]
    public void Returns_Fizz_For_(int input) => FizzBuzz.Convert(input).Should().Be("Fizz");

    #endregion

    #region Buzz

    [Theory]
    [InlineData(5)]
    [InlineData(50)]
    [InlineData(85)]
    public void Returns_Buzz_For_(int input) => FizzBuzz.Convert(input).Should().Be("Buzz");

    #endregion

    #region FizzBuzz

    [Theory]
    [InlineData(15)]
    public void Returns_FizzBuzz_For_(int input) => FizzBuzz.Convert(input).Should().Be("FizzBuzz");

    [Fact]
    public void Returns_FizzBuzz_For_30() => FizzBuzz.Convert(30).Should().Be("FizzBuzz");

    [Fact]
    public void Returns_FizzBuzz_For_45() => FizzBuzz.Convert(45).Should().Be("FizzBuzz");

    #endregion

    #region Failures

    [Fact]
    public void Throws_An_Exception_For_0()
    {
        var act = () => FizzBuzz.Convert(0);
        act.Should().Throw<OutOfRangeException>();
    }

    [Fact]
    public void Throws_An_Exception_For_101()
    {
        var act = () => FizzBuzz.Convert(101);
        act.Should().Throw<OutOfRangeException>();
    }

    [Fact]
    public void Throws_An_Exception_For_Minus_1()
    {
        var act = () => FizzBuzz.Convert(-1);
        act.Should().Throw<OutOfRangeException>();
    }

    #endregion
}