using FluentAssertions;
using Xunit;

namespace Day12.Tests;

public class GreeterTests
{
    [Theory]
    [InlineData("", "Hello.")]
    [InlineData(Greeter.Formal, "Good evening, sir.")]
    [InlineData(Greeter.Casual, "Sup bro?")]
    [InlineData(Greeter.Intimate, "Hello Darling!")]
    public void Greet(string formality, string expectedGreet)
    {
        var greeter = Greeter.New(formality);
        greeter.Greet().Should().Be(expectedGreet);
    }
}