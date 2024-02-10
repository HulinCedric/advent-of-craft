using static System.Environment;
using static System.String;

namespace Day05.Tests;

public static class FormatExtensions
{
    internal static string Format(this IEnumerable<Person> population)
        => Join(NewLine, population.Select(Format));

    private static string Format(Person person)
        => $"{person.FirstName} {person.LastName}{FormatOwnedPets(person.Pets)}";

    private static string FormatOwnedPets(Pet[] pets)
        => pets.Any() ? $" who owns : {FormatPets(pets)}" : Empty;

    private static string FormatPets(Pet[] pets)
        => Join(" ", pets.Select(pet => pet.Name));
}