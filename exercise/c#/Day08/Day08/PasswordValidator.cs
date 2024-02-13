namespace Day08;

public static class PasswordValidator
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

    private static bool HasLengthGreaterOrEqualsToMinimumLength(string password)
        => password.Length >= MinimumLength;

    private static bool ContainsAtLeastOneCapitalLetter(string password)
        => password.Any(char.IsUpper);

    private static bool ContainsAtLeastOneLowercaseLetter(string password)
        => password.Any(char.IsLower);

    private static bool ContainsAtLeastANumber(string password)
        => password.Any(char.IsDigit);

    private static bool ContainsAtLeastASpecialCharacter(string password)
        => password.Any(SpecialCharacters.Contains);

    private static bool ContainsOnlyAuthorizedCharacters(string password)
        => password.All(c => char.IsLetterOrDigit(c) || SpecialCharacters.Contains(c));
}