namespace Day03;

public record Person(string FirstName, string LastName, params Pet[] Pets)
{
    public int YoungestPetAge()
    {
        return YoungestPetIfAny()?.Age ?? int.MaxValue;
    }

    private Pet? YoungestPetIfAny()
        => Pets.MinBy(p => p.Age);
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