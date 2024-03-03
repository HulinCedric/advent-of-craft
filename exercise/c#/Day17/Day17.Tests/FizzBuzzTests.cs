using FluentAssertions.LanguageExt;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace Day17.Tests;

public class FizzBuzzTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(67, "67")]
    [InlineData(82, "82")]
    [InlineData(3, "Fizz")]
    [InlineData(66, "Fizz")]
    [InlineData(99, "Fizz")]
    [InlineData(5, "Buzz")]
    [InlineData(50, "Buzz")]
    [InlineData(85, "Buzz")]
    [InlineData(15, "FizzBuzz")]
    [InlineData(30, "FizzBuzz")]
    [InlineData(45, "FizzBuzz")]
    public void Returns_Number_Representation(int input, string expectedResult)
        => FizzBuzz.Convert(input)
            .Should()
            .BeSome(expectedResult);

    [Property]
    public Property Fails_For_Numbers_Out_Of_Range()
        => Prop.ForAll(
            OutOfRangeNumber(),
            x => FizzBuzz.Convert(x).IsNone);

    private static Arbitrary<int> OutOfRangeNumber()
        => Arb.Default.Int32().Filter(x => x is < FizzBuzz.Min or > FizzBuzz.Max);
}