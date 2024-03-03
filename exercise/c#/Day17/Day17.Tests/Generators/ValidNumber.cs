using FsCheck;

namespace Day17.Tests.Generators;

public static class ValidNumber
{
    public static Arbitrary<int> Generate()
        => Arb.Default.Int32().Filter(x => x is >= FizzBuzz.Min and <= FizzBuzz.Max);
}