namespace Day03;

public record Person(string FirstName, string LastName, params Pet[] Pets)
{
    public int YoungestPetAge()
        => Pets.Any() ? Pets.Min(pet => pet.Age) : int.MaxValue;
}

public record Pet(PetType Type, string Name, int Age);

public enum PetType
{
    Cat,
    Dog,
    Hamster,
    Turtle,
    Bird,
    Snake
}