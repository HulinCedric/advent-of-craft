using FluentAssertions;
using Xunit;

namespace Day08.Tests;

public class PasswordShould
{
    [Fact]
    public void Be_invalid_when_contains_less_than_8_characters()
        => Password.IsValid("1234567").Should().BeFalse();

    [Fact]
    public void Be_invalid_when_contains_no_capital_letter()
        => Password.IsValid("12345678").Should().BeFalse();

    [Fact]
    public void Be_invalid_when_contains_no_lowercase_letter()
        => Password.IsValid("A2345678").Should().BeFalse();

    [Fact]
    public void Be_valid()
        => Password.IsValid("Aa345678").Should().BeTrue();

    // TODO Contains at least a number
    // TODO Contains at least a special character in this list . * # @ $ % &.
    // TODO Any other characters are not authorized.
}

public class Password
{
    private const int MaxLength = 8;

    public static bool IsValid(string password)
        => IsLessOrEqualsTo(password, MaxLength) &&
           ContainsAtLeastOneCapitalLetter(password) &&
           ContainsAtLeastOneLowercaseLetter(password);

    private static bool IsLessOrEqualsTo(string password, int maxLength)
        => password.Length >= maxLength;

    private static bool ContainsAtLeastOneCapitalLetter(string password)
        => password.Any(char.IsUpper);

    private static bool ContainsAtLeastOneLowercaseLetter(string password)
        => password.Any(char.IsLower);
}