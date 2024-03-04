namespace Day20.Domain.Yahtzee;

public record Roll(int[] Dice)
{
    public static Roll Parse(int[] dice)
    {
        DiceRollValidator.ValidateRoll(dice);
        
        return new Roll(dice);
    }
}