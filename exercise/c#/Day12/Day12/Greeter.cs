namespace Day12;

public class Greeter
{
    public string? Formality { get; set; }

    public string Greet()
        => Formality switch
        {
            "formal" => "Good evening, sir.",
            "casual" => "Sup bro?",
            "intimate" => "Hello Darling!",
            _ => "Hello."
        };
}