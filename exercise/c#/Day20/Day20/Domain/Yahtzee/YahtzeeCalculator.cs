namespace Day20.Domain.Yahtzee;

public static class YahtzeeCalculator
{
    public static int Number(Roll roll, int number)
        => Calculate(d => d.Where(die => die == number).Sum(), roll.Dice);

    public static int ThreeOfAKind(int[] dice) => CalculateNOfAKind(dice, 3);

    public static int FourOfAKind(int[] dice) => CalculateNOfAKind(dice, 4);

    public static int Yahtzee(int[] dice)
        => Calculate(d =>
                         HasNOfAKind(d, 5)
                             ? Scores.YahtzeeScore
                             : 0,
                     dice);

    private static int CalculateNOfAKind(int[] dice, int n)
        => Calculate(d => HasNOfAKind(d, n) ? d.Sum() : 0, dice);

    public static int FullHouse(int[] dice)
        => Calculate(d =>
        {
            var dieFrequency = GroupDieByFrequency(d);
            return dieFrequency.ContainsValue(3) && dieFrequency.ContainsValue(2) ? Scores.HouseScore : 0;
        }, dice);

    public static int LargeStraight(int[] dice)
        => Calculate(d => d
                              .OrderBy(x => x)
                              .Zip(
                                  d.OrderBy(x => x).Skip(1),
                                  (a, b) => b - a
                              ).All(diff => diff == 1)
                              ? Scores.LargeStraightScore
                              : 0, dice);

    public static int SmallStraight(int[] dice)
        => Calculate(d =>
        {
            var sortedDice = string.Concat(d.OrderBy(x => x).Distinct());
            return IsSmallStraight(sortedDice) ? 30 : 0;
        }, dice);

    private static bool IsSmallStraight(string diceString)
        => diceString.Contains("1234") || diceString.Contains("2345") || diceString.Contains("3456");

    private static bool HasNOfAKind(IEnumerable<int> dice, int n)
        => GroupDieByFrequency(dice).Values.Any(count => count >= n);

    public static int Chance(int[] dice) => Calculate(d => d.Sum(), dice);

    private static Dictionary<int, int> GroupDieByFrequency(IEnumerable<int> dice)
        => dice.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

    private static int Calculate(Func<List<int>, int> compute, int[] dice)
    {
        DiceRollValidator.ValidateRoll(dice);
        return compute(dice.ToList());
    }

    private static class Scores
    {
        public const int YahtzeeScore = 50;
        public const int HouseScore = 25;
        public const int LargeStraightScore = 40;
    }

  
}