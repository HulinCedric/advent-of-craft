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

    public static Roll Parse(int[] dice)
    {
        Validate(dice);

        return new Roll(dice);
    }

    private static void Validate(int[] dice)
    {
        if (HasInvalidLength(dice))
        {
            throw new ArgumentException("Invalid dice... A roll should contain 5 dice.");
        }

        if (ContainsInvalidDie(dice))
        {
            throw new ArgumentException("Invalid die value. Each die must be between 1 and 6.");
        }
    }

    private static bool HasInvalidLength(int[] dice) => dice is not { Length: RollLength };
    private static bool ContainsInvalidDie(IEnumerable<int> dice) => !dice.All(IsValidDie);
    private static bool IsValidDie(int die) => die is >= MinimumDie and <= MaximumDie;
}