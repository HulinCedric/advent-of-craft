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
        => password.IsValid().Should().BeFalse(reason);

    [Theory]
    [InlineData("Aa1Cc2Dd3.")]
    [InlineData("Aa1Cc2Dd3*")]
    [InlineData("Aa1Cc2Dd3#")]
    [InlineData("Aa1Cc2Dd3@")]
    [InlineData("Aa1Cc2Dd3$")]
    [InlineData("Aa1Cc2Dd3%")]
    [InlineData("Aa1Cc2Dd3&")]
    public void Be_valid(string password)
        => password.IsValid().Should().BeTrue();
}