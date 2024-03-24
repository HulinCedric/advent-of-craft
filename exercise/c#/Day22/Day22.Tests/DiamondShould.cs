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

    [Property]
    public bool Contains_A_on_first_line(char letter)
    {
        var diamond = Diamond.Print(letter);

        var lines = diamond.Split(Environment.NewLine).Select(line => line.Trim());

        return lines.First() == "A";
    }
    
    [Property]
    public bool Contains_A_on_last_line(char letter)
    {
        var diamond = Diamond.Print(letter);

        var lines = diamond.Split(Environment.NewLine).Select(line => line.Trim());

        return lines.Last() == "A";
    }
}