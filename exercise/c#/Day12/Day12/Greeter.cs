namespace Day12;

public class Greeter
{
    public string? Formality { get; set; }

    public string Greet()
        => Formality switch
        {
            "formal" => FormalGreeter.FormalGreeting(),
            "casual" => CasualGreeter.CasualGreeting(),
            "intimate" => IntimateGreeter.IntimateGreeting(),
            _ => new DefaultGreeting().Greet()
        };
}