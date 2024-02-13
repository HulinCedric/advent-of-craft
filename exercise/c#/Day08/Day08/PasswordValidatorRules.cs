namespace Day08;

internal static class PasswordValidatorRules
{
    internal const int MinimumLength = 8;
    internal const string SpecialCharacters = ".*#@$%&";

    internal static bool HasLengthGreaterOrEqualsToMinimumLength(this string password)
        => password.Length >= MinimumLength;

    internal static bool ContainsAtLeastOne(this string password, Func<char, bool> predicate)
        => password.Any(predicate);

    internal static bool ContainsOnly(this string password, Func<char, bool> predicate)
        => password.All(predicate);

    internal static Func<char, bool> CapitalLetter()
        => char.IsUpper;

    internal static Func<char, bool> LowercaseLetter()
        => char.IsLower;

    internal static Func<char, bool> Number()
        => char.IsDigit;

    internal static Func<char, bool> SpecialCharacter()
        => SpecialCharacters.Contains;

    internal static Func<char, bool> AuthorizedCharacters()
        => c => char.IsLetterOrDigit(c) || SpecialCharacters.Contains(c);
}