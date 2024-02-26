namespace Day12;

public class Greeter
{
    public string? Formality { get; set; }

    public string Greet()
        => Formality switch
        {
            "formal" => new FormalGreeter().Greet(),
            "casual" => new CasualGreeter().Greet(),
            "intimate" => new IntimateGreeter().Greet(),
            _ => new DefaultGreeting().Greet()
        };
}