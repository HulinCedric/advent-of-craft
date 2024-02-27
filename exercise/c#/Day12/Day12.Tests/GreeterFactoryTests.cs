using FluentAssertions;
using Xunit;
using static Day12.GreeterFactory;

namespace Day12.Tests;

public class GreeterFactoryTests
{
    [Theory]
    [InlineData(null, "Hello.")]
    [InlineData("", "Hello.")]
    [InlineData("unknown", "Hello.")]
    [InlineData("formal", "Good evening, sir.")]
    [InlineData("casual", "Sup bro?")]
    [InlineData("intimate", "Hello Darling!")]
    public void Greet(string formality, string expectedGreet)
        => GreeterWith(formality)
            .Greet()
            .Should()
            .Be(expectedGreet);
}