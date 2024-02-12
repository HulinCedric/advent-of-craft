using FluentAssertions;
using Xunit;

namespace Day08.Tests;

public class PasswordShould
{
    [Fact]
    public void Be_invalid_when_contains_less_than_8_characters()
        => Password.IsValid("1234567").Should().BeFalse();

    [Fact]
    public void Be_valid_when_contains_at_least_8_characters()
        => Password.IsValid("12345678").Should().BeTrue();

    // TODO Contains at least one capital letter
    // TODO Contains at least one lowercase letter
    // TODO Contains at least a number
    // TODO Contains at least a special character in this list . * # @ $ % &.
    // TODO Any other characters are not authorized.
}

public class Password
{
    public static bool IsValid(string password)
        => password.Length >= 8;
}