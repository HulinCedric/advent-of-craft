namespace Day08;

public static class PasswordValidator
{
    private const int MinimumLength = 8;
    private const string SpecialCharacters = ".*#@$%&";

    public static bool IsValid(string password)
        => HasLengthGreaterOrEqualsToMinimumLength(password) &&
           ContainsAtLeastOne(password, CapitalLetter()) &&
           ContainsAtLeastOne(password, LowercaseLetter()) &&
           ContainsAtLeastOne(password, Number()) &&
           ContainsAtLeastOne(password, SpecialCharacter()) &&
           ContainsOnly(password, AuthorizedCharacters());

    private static bool HasLengthGreaterOrEqualsToMinimumLength(string password)
        => password.Length >= MinimumLength;

    private static bool ContainsAtLeastOne(string password, Func<char, bool> predicate)
        => password.Any(predicate);

    private static bool ContainsOnly(string password, Func<char, bool> predicate)
        => password.All(predicate);

    private static Func<char, bool> CapitalLetter()
        => char.IsUpper;

    private static Func<char, bool> LowercaseLetter()
        => char.IsLower;

    private static Func<char, bool> Number()
        => char.IsDigit;

    private static Func<char, bool> SpecialCharacter()
        => SpecialCharacters.Contains;

    private static Func<char, bool> AuthorizedCharacters()
        => c => char.IsLetterOrDigit(c) || SpecialCharacters.Contains(c);
}