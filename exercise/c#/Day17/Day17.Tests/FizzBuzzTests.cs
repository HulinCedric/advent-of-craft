using Day17.Tests.Generators;
using FluentAssertions.LanguageExt;
using FsCheck.Xunit;
using Xunit;
using static Day17.FizzBuzz;

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
    public void Returns_Number_Representation(int number, string expectedRepresentation)
        => Convert(number)
            .Should()
            .BeSome(expectedRepresentation);

    [Property(Arbitrary = [typeof(ValidNumber)])]
    public bool Returns_Valid_Representation_For_Valid_Number(int number)
        => Convert(number).Exists(representation => ValidRepresentationsFor(number).Contains(representation));

    [Property(Arbitrary = [typeof(OutOfRangeNumber)])]
    public bool Fails_For_Numbers_Out_Of_Range(int number)
        => Convert(number).IsNone;

    private static IEnumerable<string> ValidRepresentationsFor(int input)
    {
        yield return "Fizz";
        yield return "Buzz";
        yield return "FizzBuzz";
        yield return $"{input}";
    }
}