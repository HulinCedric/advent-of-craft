namespace Day08;

using Rule = Func<char, bool>;

internal static class PasswordRules
{
    internal static bool HasLengthGreaterOrEqualsTo(this string password, int minimumLength)
        => password.Length >= minimumLength;

    internal static bool ContainsAtLeastOne(this string password, Rule rule)
        => password.Any(rule);

    internal static bool ContainsOnly(this string password, params Rule[] rules)
        => password.All(c => rules.Any(p => p(c)));

    internal static Rule CapitalLetter()
        => char.IsUpper;

    internal static Rule LowercaseLetter()
        => char.IsLower;

    internal static Rule Number()
        => char.IsDigit;

    internal static Rule SpecialCharacter(IEnumerable<char> characters)
        => characters.Contains;
}