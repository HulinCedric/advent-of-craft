using static System.Environment;
using static System.String;

namespace Day05.Tests;

public static class FormatExtensions
{
    internal static string Format(this IEnumerable<Person> population)
        => Join(NewLine, population.Select(Format));

    private static string Format(this Person person)
        => $"{person.FirstName} {person.LastName}{person.Pets.FormatOwned()}";

    private static string FormatOwned(this Pet[] pets)
        => pets.Any()
               ? $" who owns : {pets.Format()}"
               : Empty;

    private static string Format(this Pet[] pets)
        => Join(" ", pets.Select(pet => pet.Name));
}