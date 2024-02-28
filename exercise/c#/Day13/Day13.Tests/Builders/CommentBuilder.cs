using Bogus;

namespace Day13.Tests.Builders;

public class CommentBuilder
{
    private readonly Faker _faker = new();

    public static CommentBuilder AComment()
        => new();

    public Comment Build()
        => new(
            _faker.Lorem.Sentence(),
            _faker.Person.FullName,
            DateOnly.FromDateTime(DateTime.Now));
}