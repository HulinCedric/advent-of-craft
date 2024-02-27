namespace Day12;

public class Greeter
{
    private Greeter(string? formality = null)
    {
        Formality = formality;
    }

    public static Greeter New(string? formality = null)
    {
        return new Greeter(formality);
    }

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