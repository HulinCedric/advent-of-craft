using FsCheck.Xunit;

namespace Day22.Tests;

public class DiamondShould
{
    [Property]
    public bool Not_be_empty(char letter)
    {
        var diamond = Diamond.Print(letter);
        return string.IsNullOrWhiteSpace(diamond) == false;
    }
}