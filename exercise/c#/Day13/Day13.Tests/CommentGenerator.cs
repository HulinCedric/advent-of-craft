using Bogus;

namespace Day13.Tests;

internal sealed class CommentGenerator : Faker<Comment>
{
    public CommentGenerator()
        => CustomInstantiator(
            faker => new Comment(
                faker.Lorem.Sentence(),
                faker.Person.FullName,
                DateOnly.FromDateTime(DateTime.Now)));
}