using static Day08.PasswordValidatorRules;

namespace Day08;

public static class PasswordValidator
{
    public static bool IsValid(string password)
        => password.HasLengthGreaterOrEqualsToMinimumLength() &&
           password.ContainsAtLeastOne(CapitalLetter()) &&
           password.ContainsAtLeastOne(LowercaseLetter()) &&
           password.ContainsAtLeastOne(Number()) &&
           password.ContainsAtLeastOne(SpecialCharacter()) &&
           password.ContainsOnly(AuthorizedCharacters());
}