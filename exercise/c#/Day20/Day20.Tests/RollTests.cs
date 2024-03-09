using FluentAssertions;
using Xunit;

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
    public void Invalid_Roll_Lengths_Parse_Unsafely(params int[] dice)
    {
        AssertThrow<ArgumentException>(() => Domain.Yahtzee.Roll.ParseUnsafe(dice),
                                       "Invalid dice... A roll should contain 5 dice.");
    }

    public static List<object[]> InvalidDieInRolls() =>
    [
        [1, 1, 1, 1, 7],
        [0, 1, 1, 1, 2],
        [1, 1, -1, 1, 2]
    ];
        
    [Theory]
    [MemberData(nameof(InvalidDieInRolls))]
    public void Invalid_Die_In_Rolls_Parse(params int[] dice)
    {
        AssertThrow<ArgumentException>(() => Domain.Yahtzee.Roll.ParseUnsafe(dice),
                                       "Invalid die value. Each die must be between 1 and 6.");
    }
        
    private static void AssertThrow<TException>(Action act, string expectedMessage) where TException : Exception
        => act.Should()
            .Throw<TException>()
            .WithMessage(expectedMessage);
}