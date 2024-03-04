namespace Day20.Domain.Yahtzee;

public record DiceRoll(int[] Dice)
{
    public static DiceRoll Parse(int[] dice)
    {
        DiceRollValidator.ValidateRoll(dice);
        
        return new DiceRoll(dice);
    }
}