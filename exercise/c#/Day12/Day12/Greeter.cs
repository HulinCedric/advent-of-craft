namespace Day12;

public class Greeter
{
    public string? Formality { get; set; }

    public string Greet()
        => Formality switch
        {
            "formal" => FormalGreeting(),
            "casual" => CasualGreeting(),
            "intimate" => IntimateGreeting(),
            _ => DefaultGreeting()
        };

    private static string DefaultGreeting()
        => "Hello.";

    private static string IntimateGreeting()
        => "Hello Darling!";

    private static string CasualGreeting()
        => "Sup bro?";

    private static string FormalGreeting()
        => "Good evening, sir.";
}