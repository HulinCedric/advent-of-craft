using LanguageExt;

namespace Day20.Domain.Yahtzee;

public record Roll
{
    private const int RollLength = 5;
    private const int MinimumDie = 1;
    private const int MaximumDie = 6;

    private Roll(int[] Dice) => this.Dice = Dice;

    public int[] Dice { get; }

    public static Either<string, Roll> Parse(int[] dice)
    {
        if (HasInvalidLength(dice))
        {
            return "Invalid dice... A roll should contain 5 dice.";
        }

        if (ContainsInvalidDie(dice))
        {
            return "Invalid die value. Each die must be between 1 and 6.";
        }

        return new Roll(dice);
    }

    private static bool HasInvalidLength(int[] dice) => dice is not { Length: RollLength };

    private static bool ContainsInvalidDie(IEnumerable<int> dice) => !dice.All(IsValidDie);

    private static bool IsValidDie(int die) => die is >= MinimumDie and <= MaximumDie;

    public Dictionary<int, int> GroupDieByFrequency() =>
        Dice.GroupBy(d => d).ToDictionary(g => g.Key, g => g.Count());
}