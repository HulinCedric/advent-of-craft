using Day20.Domain.Yahtzee;
using FluentAssertions;
using Xunit;

namespace Day20.Tests;

public class YahtzeeCalculatorTests
{
    public static List<object[]> Numbers() =>
    [
        [RollBuilder.NewRoll(1, 2, 1, 1, 3), 1, 3],
        [RollBuilder.NewRoll(2, 3, 4, 5, 6), 1, 0],
        [RollBuilder.NewRoll(4, 4, 4, 4, 4), 1, 0],
        [RollBuilder.NewRoll(4, 1, 4, 4, 5), 4, 12]
    ];

    [Theory]
    [MemberData(nameof(Numbers))]
    public void Count_And_Add_Numbers_For_Numbers(RollBuilder roll, int number, int expectedResult) =>
        YahtzeeCalculator.Number(roll.Build(), number).Should().Be(expectedResult);

    public static List<object[]> ThreeOfAKinds() =>
    [
        [RollBuilder.NewRoll(3, 3, 3, 4, 5), 18],
        [RollBuilder.NewRoll(2, 3, 4, 5, 6), 0],
        [RollBuilder.NewRoll(4, 4, 4, 4, 4), 20],
        [RollBuilder.NewRoll(1, 1, 2, 1, 5), 10]
    ];

    [Theory]
    [MemberData(nameof(ThreeOfAKinds))]
    public void Total_Of_All_Dice_For_Three_Of_A_Kind(RollBuilder roll, int expectedResult) =>
        YahtzeeCalculator.ThreeOfAKind(roll.Build()).Should().Be(expectedResult);

    public static List<object[]> FourOfAKinds() =>
    [
        [RollBuilder.NewRoll(3, 3, 3, 3, 5), 17],
        [RollBuilder.NewRoll(2, 3, 4, 5, 6), 0],
        [RollBuilder.NewRoll(4, 4, 4, 4, 4), 20],
        [RollBuilder.NewRoll(1, 1, 1, 1, 5), 9]
    ];

    [Theory]
    [MemberData(nameof(FourOfAKinds))]
    public void Total_Of_All_Dice_For_Four_Of_A_Kind(RollBuilder roll, int expectedResult) =>
        YahtzeeCalculator.FourOfAKind(roll.Build()).Should().Be(expectedResult);


    public static List<object[]> FullHouses() =>
    [
        [RollBuilder.NewRoll(2, 2, 3, 3, 3), 25],
        [RollBuilder.NewRoll(2, 3, 4, 5, 6), 0],
        [RollBuilder.NewRoll(2, 2, 4, 3, 3), 0],
        [RollBuilder.NewRoll(4, 4, 1, 4, 1), 25]
    ];

    [Theory]
    [MemberData(nameof(FullHouses))]
    public void Twenty_Five_For_Full_Houses(RollBuilder roll, int expectedResult) =>
        YahtzeeCalculator.FullHouse(roll.Build()).Should().Be(expectedResult);

    public static List<object[]> SmallStraights() =>
    [
        [RollBuilder.NewRoll(1, 2, 3, 4, 5), 30],
        [RollBuilder.NewRoll(5, 4, 3, 2, 1), 30],
        [RollBuilder.NewRoll(2, 3, 4, 5, 1), 30],
        [RollBuilder.NewRoll(1, 2, 3, 4, 6), 30],
        [RollBuilder.NewRoll(1, 1, 1, 3, 2), 0]
    ];

    [Theory]
    [MemberData(nameof(SmallStraights))]
    public void Thirty_For_Small_Straights(RollBuilder roll, int expectedResult) =>
        YahtzeeCalculator.SmallStraight(roll.Build()).Should().Be(expectedResult);

    public static List<object[]> LargeStraights() =>
    [
        [RollBuilder.NewRoll(1, 2, 3, 4, 5), 40],
        [RollBuilder.NewRoll(5, 4, 3, 2, 1), 40],
        [RollBuilder.NewRoll(2, 3, 4, 5, 6), 40],
        [RollBuilder.NewRoll(1, 4, 1, 3, 2), 0]
    ];

    [Theory]
    [MemberData(nameof(LargeStraights))]
    public void Forty_For_Large_Straights(RollBuilder roll, int expectedResult) =>
        YahtzeeCalculator.LargeStraight(roll.Build()).Should().Be(expectedResult);

    public static List<object[]> Yahtzees() =>
    [
        [RollBuilder.NewRoll(4, 4, 4, 4, 4), 50],
        [RollBuilder.NewRoll(2, 2, 2, 2, 2), 50],
        [RollBuilder.NewRoll(1, 4, 1, 3, 2), 0]
    ];

    [Theory]
    [MemberData(nameof(Yahtzees))]
    public void Fifty_For_Yahtzees(RollBuilder roll, int expectedResult) =>
        YahtzeeCalculator.Yahtzee(roll.Build()).Should().Be(expectedResult);

    public static List<object[]> Chances() =>
    [
        [RollBuilder.NewRoll(3, 3, 3, 3, 3), 15],
        [RollBuilder.NewRoll(6, 5, 4, 3, 3), 21],
        [RollBuilder.NewRoll(1, 4, 1, 3, 2), 11]
    ];

    [Theory]
    [MemberData(nameof(Chances))]
    public void Total_Of_All_Dice_For_Chance(RollBuilder roll, int expectedResult) =>
        YahtzeeCalculator.Chance(roll.Build()).Should().Be(expectedResult);
}