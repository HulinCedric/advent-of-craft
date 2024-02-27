using Bogus;

namespace Day13.Tests;

internal sealed class CommentFaker : Faker<Comment>
{
    public CommentFaker()
        => CustomInstantiator(
            faker => new Comment(
                faker.Lorem.Sentence(),
                faker.Person.FullName,
                DateOnly.FromDateTime(DateTime.Now)));
}