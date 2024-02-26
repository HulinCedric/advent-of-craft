namespace Day12;

public class Greeter
{
    public string? Formality { get; set; }

    public string Greet()
    {
        if (Formality == null)
        {
            return "Hello.";
        }

        if (Formality == "formal")
        {
            return "Good evening, sir.";
        }

        if (Formality == "casual")
        {
            return "Sup bro?";
        }

        if (Formality == "intimate")
        {
            return "Hello Darling!";
        }

        return "Hello.";
    }
}