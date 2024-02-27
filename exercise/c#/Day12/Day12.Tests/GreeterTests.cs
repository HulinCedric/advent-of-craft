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
        var greeter = Greeter.New(Greeter.Formal);

        greeter.Greet().Should().Be("Good evening, sir.");
    }

    [Fact]
    public void SaysHelloCasually()
    {
        var greeter = Greeter.New(Greeter.Casual);

        greeter.Greet().Should().Be("Sup bro?");
    }

    [Fact]
    public void SaysHelloIntimately()
    {
        var greeter = Greeter.New(Greeter.Intimate);

        greeter.Greet().Should().Be("Hello Darling!");
    }
}