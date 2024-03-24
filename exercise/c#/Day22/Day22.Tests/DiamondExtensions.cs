namespace Day22.Tests;

public static class DiamondExtensions
{
    public static string[] Lines(this string diamond)
        => diamond.Split(Environment.NewLine);
}