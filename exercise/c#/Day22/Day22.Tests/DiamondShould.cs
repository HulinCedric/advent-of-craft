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

        var lines = diamond.Lines().Select(line => line.Trim());

        return lines.First() == "A";
    }

    [Property]
    public bool Contains_A_on_last_line(char letter)
    {
        var diamond = Diamond.Print(letter);

        var lines = diamond.Lines().Select(line => line.Trim());

        return lines.Last() == "A";
    }

    [Property]
    public bool Have_a_vertically_symmetric_contour(char letter)
    {
        var lines = Diamond.Print(letter).Lines();

        return lines.All(line => LeadingSpaces(line) == TrailingSpaces(line));
    }

    private static int TrailingSpaces(string line)
        => line.Reverse().TakeWhile(char.IsWhiteSpace).Count();

    private static int LeadingSpaces(string line)
        => line.TakeWhile(char.IsWhiteSpace).Count();
}