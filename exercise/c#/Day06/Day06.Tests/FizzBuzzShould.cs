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
    public void Convert_number(int number, string expected)
        => FizzBuzz.Convert(number)
            .Should()
            .Be(expected);

    [Theory]
    [ClassData(typeof(OutOfRangeNumbers))]
    public void Fails_when_the_number_is_out_of_range(int number)
        => ((Action)(() => FizzBuzz.Convert(number)))
            .Should()
            .Throw<OutOfRangeException>();
}