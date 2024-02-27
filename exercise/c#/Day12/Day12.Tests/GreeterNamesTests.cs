using FluentAssertions;
using Xunit;

namespace Day12.Tests;

public class GreeterTests
{
    [Theory]
    [InlineData("", "Hello.")]
    [InlineData("formal", "Good evening, sir.")]
    [InlineData("casual", "Sup bro?")]
    [InlineData("intimate", "Hello Darling!")]
    public void Greet(string formality, string expectedGreet)
        => Greeter.With(formality)
            .Greet()
            .Should()
            .Be(expectedGreet);
}