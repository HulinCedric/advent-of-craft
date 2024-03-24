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
    public bool Contain_A_on_first_line(char letter)
    {
        var diamond = Diamond.Print(letter);
        
        var lines = diamond.Split(Environment.NewLine);
        
        return lines.First().Contains("A");
    }
}