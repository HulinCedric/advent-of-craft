using static Day08.PasswordRules;

namespace Day08;

public static class PasswordValidator
{
    private const int MinimumLength = 8;

    private static readonly List<char> SpecialCharacters = ['.', '*', '#', '@', '$', '%', '&'];

    public static bool IsValid(this string password)
        => password.HasLengthGreaterOrEqualsTo(MinimumLength) &&
           password.ContainsAtLeastOne(CapitalLetter()) &&
           password.ContainsAtLeastOne(LowercaseLetter()) &&
           password.ContainsAtLeastOne(Number()) &&
           password.ContainsAtLeastOne(SpecialCharacter(SpecialCharacters)) &&
           password.ContainsOnly(
               CapitalLetter(),
               LowercaseLetter(),
               Number(),
               SpecialCharacter(SpecialCharacters));
}