using Ardalis.SmartEnum;

namespace Day12;

public class Greeter : SmartEnum<Greeter, string>
{
    public static readonly Greeter Formal = new(GreeterNames.Formal, "Good evening, sir.");
    public static readonly Greeter Intimate = new(GreeterNames.Intimate, "Hello Darling!");
    public static readonly Greeter Casual = new(GreeterNames.Casual, "Sup bro?");
    public static readonly Greeter Default = new(GreeterNames.Default, "Hello.");

    private Greeter(string name, string value) : base(name, value)
    {
    }

    public string Greet()
        => Value;

    public static Greeter With(string? formality = null)
        => TryFromName(formality, out var greeter)
               ? greeter
               : Default;
}