namespace Day12;

public static class Greeter
{
    public static GreetingStrategy New(string? formality = null)
        => formality switch
        {
            "formal" => new FormalGreeter(),
            "casual" => new CasualGreeter(),
            "intimate" => new IntimateGreeter(),
            _ => new DefaultGreeter()
        };
}