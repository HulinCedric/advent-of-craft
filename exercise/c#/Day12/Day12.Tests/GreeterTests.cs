using FluentAssertions;
using Xunit;

namespace Day12.Tests;

public class GreeterTests
{
    [Fact]
    public void SaysHello()
    {
        var greeter = Greeter.New();
        greeter.Greet().Should().Be("Hello.");
    }

    [Fact]
    public void SaysHelloFormally()
    {
        var greeter = Greeter.New(formality: "formal");

        greeter.Greet().Should().Be("Good evening, sir.");
    }

    [Fact]
    public void SaysHelloCasually()
    {
        var greeter = Greeter.New(formality: "casual");

        greeter.Greet().Should().Be("Sup bro?");
    }

    [Fact]
    public void SaysHelloIntimately()
    {
        var greeter = Greeter.New(formality: "intimate");

        greeter.Greet().Should().Be("Hello Darling!");
    }
}