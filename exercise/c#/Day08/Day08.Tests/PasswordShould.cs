using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace Day08.Tests;

public class PasswordShould
{
    [Fact]
    public void Be_invalid_when_contains_less_than_8_characters()
        => Password.IsValid("Aa1Cc2.").Should().BeFalse();

    [Fact]
    public void Be_invalid_when_contains_no_capital_letter()
        => Password.IsValid("aa1cc2dd3.").Should().BeFalse();

    [Fact]
    public void Be_invalid_when_contains_no_lowercase_letter()
        => Password.IsValid("AA1CC2DD3.").Should().BeFalse();

    [Fact]
    public void Be_invalid_when_contains_no_number()
        => Password.IsValid("AaACcCDdD.").Should().BeFalse();

    [Fact]
    public void Be_invalid_when_contains_no_special_character()
        => Password.IsValid("Aa1Cc2Dd3A").Should().BeFalse();

    [Theory]
    [InlineData("Aa1Cc2Dd3.")]
    [InlineData("Aa1Cc2Dd3*")]
    [InlineData("Aa1Cc2Dd3#")]
    [InlineData("Aa1Cc2Dd3@")]
    [InlineData("Aa1Cc2Dd3$")]
    [InlineData("Aa1Cc2Dd3%")]
    [InlineData("Aa1Cc2Dd3&")]
    public void Be_valid(string password)
        => Password.IsValid(password).Should().BeTrue();

    [Theory]
    [InlineData("Aa1Cc2Dd3._")]
    [InlineData("Aa1Cc2Dd3.)")]
    [InlineData("Aa1Cc2Dd3./")]
    public void Be_invalid_when_contains_unauthorized_character(string password)
        => Password.IsValid(password).Should().BeFalse();
}

public class Password
{
    private const int MinimumLength = 8;
    private const string SpecialCharacters = ".*#@$%&";

    public static bool IsValid(string password)
        => HasLengthGreaterOrEqualsTo(password, MinimumLength) &&
           ContainsAtLeastOneCapitalLetter(password) &&
           ContainsAtLeastOneLowercaseLetter(password) &&
           ContainsAtLeastANumber(password) &&
           ContainsAtLeastASpecialCharacter(password, SpecialCharacters) &&
           ContainsOnlyAuthorizedCharacters(password, SpecialCharacters);

    private static bool ContainsOnlyAuthorizedCharacters(string password, string specialCharacters)
        => !password.Any(c => !char.IsLetterOrDigit(c) && !specialCharacters.Contains(c));

    private static bool ContainsAtLeastASpecialCharacter(string password, string specialCharacters)
        => password.Any(specialCharacters.Contains);

    private static bool ContainsAtLeastANumber(string password)
        => password.Any(char.IsDigit);

    private static bool HasLengthGreaterOrEqualsTo(string password, int minimumLength)
        => password.Length >= minimumLength;

    private static bool ContainsAtLeastOneCapitalLetter(string password)
        => password.Any(char.IsUpper);

    private static bool ContainsAtLeastOneLowercaseLetter(string password)
        => password.Any(char.IsLower);
}