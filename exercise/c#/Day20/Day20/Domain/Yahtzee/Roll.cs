using LanguageExt;

namespace Day20.Domain.Yahtzee;

public record Roll
{
    private Roll(int[] Dice)
    {
        this.Dice = Dice;
    }

    private const int RollLength = 5;
    private const int MinimumDie = 1;
    private const int MaximumDie = 6;
    public int[] Dice { get; }

    public static Either<string, Roll> Parse(int[] dice)
    {
        var error = Validate(dice);
        return error is null 
                   ? new Roll(dice) 
                   : error;
    }

    private static string? Validate(int[] dice)
    {
        if (HasInvalidLength(dice))
        {
            return "Invalid dice... A roll should contain 5 dice.";
        }

        if (ContainsInvalidDie(dice))
        {
            return "Invalid die value. Each die must be between 1 and 6.";
        }

        return null;
    }

    private static bool HasInvalidLength(int[] dice)
        => dice is not { Length: RollLength };

    private static bool ContainsInvalidDie(IEnumerable<int> dice)
        => !dice.All(IsValidDie);

    private static bool IsValidDie(int die)
        => die is >= MinimumDie and <= MaximumDie;
}