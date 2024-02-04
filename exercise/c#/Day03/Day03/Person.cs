namespace Day03;

public record Person(string FirstName, string LastName, params Pet[] Pets)
{
    public int YoungestPetAge()
        => HasPets() ? Pets.Min(pet => pet.Age) : int.MaxValue;

    private bool HasPets()
        => Pets.Any();
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