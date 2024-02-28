namespace Day12;

public static class GreeterFactory
{
    public const string Formal = "formal";
    public const string Casual = "casual";
    public const string Intimate = "intimate";

    private static readonly IReadOnlyDictionary<string, Greeter> Mapping =
        new Dictionary<string, Greeter>
        {
            { Casual, () => "Sup bro?" },
            { Formal, () => "Good evening, sir." },
            { Intimate, () => "Hello Darling!" }
        };

    public static Greeter Create(string? formality = null)
        => Mapping.GetValueOrDefault(formality ?? "", () => "Hello.");
}