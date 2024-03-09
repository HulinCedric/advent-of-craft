using Day20.Domain.Yahtzee;

namespace Day20.Tests;

public class RollBuilder
{
    private readonly int[] _dice;

    private RollBuilder(int[] dice) => _dice = dice;

    public static RollBuilder NewRoll(int dice1, int dice2, int dice3, int dice4, int dice5)
        => new([dice1, dice2, dice3, dice4, dice5]);

    public override string ToString() => $"[{string.Join(", ", _dice)}]";

    public Roll Build()
        => Roll.ParseUnsafe(_dice);
}