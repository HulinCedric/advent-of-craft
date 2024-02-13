namespace Day08;

internal static class PasswordValidatorRules
{
    internal static bool HasLengthGreaterOrEqualsTo(this string password, int minimumLength)
        => password.Length >= minimumLength;

    internal static bool ContainsAtLeastOne(this string password, Func<char, bool> predicate)
        => password.Any(predicate);

    internal static bool ContainsOnly(this string password, params Func<char, bool>[] predicates)
        => password.All(c => predicates.Any(p => p(c)));

    internal static Func<char, bool> CapitalLetter()
        => char.IsUpper;

    internal static Func<char, bool> LowercaseLetter()
        => char.IsLower;

    internal static Func<char, bool> Number()
        => char.IsDigit;

    internal static Func<char, bool> SpecialCharacter(IEnumerable<char> characters)
        => characters.Contains;
}