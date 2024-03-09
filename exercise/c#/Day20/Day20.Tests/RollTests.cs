using FluentAssertions.LanguageExt;
using Xunit;
using static Day20.Domain.Yahtzee.Roll;

namespace Day20.Tests;

public class RollTests
{
    public static List<object[]> InvalidRollLengths() =>
    [
        [1],
        [1, 1],
        [1, 6, 2],
        [1, 6, 2, 5],
        [1, 6, 2, 5, 4, 1],
        [1, 6, 2, 5, 4, 1, 2]
    ];

    [Theory]
    [MemberData(nameof(InvalidRollLengths))]
    public void Invalid_Roll_Lengths_Parse(params int[] dice) =>
        Parse(dice)
            .Should()
            .Be("Invalid dice... A roll should contain 5 dice.");

    public static List<object[]> InvalidDieInRolls() =>
    [
        [1, 1, 1, 1, 7],
        [0, 1, 1, 1, 2],
        [1, 1, -1, 1, 2]
    ];

    [Theory]
    [MemberData(nameof(InvalidDieInRolls))]
    public void Invalid_Die_In_Rolls_Parse(params int[] dice) =>
        Parse(dice)
            .Should()
            .Be("Invalid die value. Each die must be between 1 and 6.");
}