namespace Day12;

public class Greeter 
{
    private Greeter(string? formality = null)
    {
        Formality = formality;
    }

    public static GreetingStrategy New(string? formality = null)
        => formality switch
        {
            "formal" => new FormalGreeter(),
            "casual" => new CasualGreeter(),
            "intimate" => new IntimateGreeter(),
            _ => new DefaultGreeting()
        };

    public string? Formality { get;  }

    public string Greet()
        => Formality switch
        {
            "formal" => new FormalGreeter().Greet(),
            "casual" => new CasualGreeter().Greet(),
            "intimate" => new IntimateGreeter().Greet(),
            _ => new DefaultGreeting().Greet()
        };
}