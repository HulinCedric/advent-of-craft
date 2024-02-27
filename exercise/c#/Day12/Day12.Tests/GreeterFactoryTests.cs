using FluentAssertions;
using Xunit;
using static Day12.GreeterFactory;

namespace Day12.Tests;

public class GreeterFactoryTests
{
    [Theory]
    [InlineData("", "Hello.")]
    [InlineData(Formal, "Good evening, sir.")]
    [InlineData(Casual, "Sup bro?")]
    [InlineData(Intimate, "Hello Darling!")]
    public void Greet(string formality, string expectedGreet)
        => GreeterWith(formality)
            .Greet()
            .Should()
            .Be(expectedGreet);
}