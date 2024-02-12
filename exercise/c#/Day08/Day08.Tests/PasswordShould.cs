using FluentAssertions;
using Xunit;

namespace Day08.Tests;

public class PasswordShould
{
    [Theory]
    [InlineData("Aa1Cc2.", "Too short")]
    [InlineData("aa1cc2dd3.", "No capital letter")]
    [InlineData("AA1CC2DD3.", "No lowercase letter")]
    [InlineData("AaACcCDdD.", "No number")]
    [InlineData("Aa1Cc2Dd3A", "No special character")]
    [InlineData("Aa1Cc2Dd3._", "Unauthorized character")]
    [InlineData("Aa1Cc2Dd3.)", "Unauthorized character")]
    [InlineData("Aa1Cc2Dd3./", "Unauthorized character")]
    public void Be_invalid(string password, string reason)
        => Password.IsValid(password).Should().BeFalse(reason);

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
}

public class Password
{
    private const int MinimumLength = 8;
    private const string SpecialCharacters = ".*#@$%&";

    public static bool IsValid(string password)
        => HasLengthGreaterOrEqualsToMinimumLength(password) &&
           ContainsAtLeastOneCapitalLetter(password) &&
           ContainsAtLeastOneLowercaseLetter(password) &&
           ContainsAtLeastANumber(password) &&
           ContainsAtLeastASpecialCharacter(password) &&
           ContainsOnlyAuthorizedCharacters(password);

    private static bool ContainsOnlyAuthorizedCharacters(string password)
        => password.All(c => char.IsLetterOrDigit(c) || SpecialCharacters.Contains(c));

    private static bool ContainsAtLeastASpecialCharacter(string password)
        => password.Any(SpecialCharacters.Contains);

    private static bool ContainsAtLeastANumber(string password)
        => password.Any(char.IsDigit);

    private static bool HasLengthGreaterOrEqualsToMinimumLength(string password)
        => password.Length >= MinimumLength;

    private static bool ContainsAtLeastOneCapitalLetter(string password)
        => password.Any(char.IsUpper);

    private static bool ContainsAtLeastOneLowercaseLetter(string password)
        => password.Any(char.IsLower);
}