using System.Reflection;

namespace Day12;

public static class GreeterFactory
{
    private static readonly Dictionary<string, Type> GreeterTypes;

    static GreeterFactory()
        => GreeterTypes = Assembly.GetExecutingAssembly()
               .GetTypes()
               .Where(
                   t => t.GetInterfaces().Contains(typeof(IGreeter)) &&
                        !t.IsAbstract &&
                        t.GetConstructor(Type.EmptyTypes) != null)
               .ToDictionary(t => t.Name.ToLower().Replace("greeter", ""), t => t);

    public static IGreeter GreeterWith(string? formality = null)
    {
        formality = formality?.ToLower() ?? "";
        if (GreeterTypes.TryGetValue(formality, out var type))
        {
            return (IGreeter)Activator.CreateInstance(type)!;
        }

        return new DefaultGreeter();
    }
}