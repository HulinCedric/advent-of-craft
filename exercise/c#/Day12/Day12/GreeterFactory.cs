namespace Day12;

public static class GreeterFactory
{
    public const string Formal = "formal";
    public const string Casual = "casual";
    public const string Intimate = "intimate";

    public static IGreeter GreeterWith(string? formality = null)
        => formality switch
        {
            Formal => new FormalGreeter(),
            Casual => new CasualGreeter(),
            Intimate => new IntimateGreeter(),
            _ => new DefaultGreeter()
        };
}