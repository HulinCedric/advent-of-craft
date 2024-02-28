using FluentAssertions;
using Xunit;
using static Day12.GreeterFactory;

namespace Day12.Tests;

public class GreeterTests
{
    [Theory]
    [InlineData("", "Hello.")]
    [InlineData(Formal, "Good evening, sir.")]
    [InlineData(Casual, "Sup bro?")]
    [InlineData(Intimate, "Hello Darling!")]
    public void Greet(string formality, string expectedGreet)
        => Create(formality)()
            .Should()
            .Be(expectedGreet);
}