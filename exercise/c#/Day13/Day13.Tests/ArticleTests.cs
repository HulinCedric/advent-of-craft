using Bogus;
using FluentAssertions;
using Xunit;
using static Day13.Tests.ArticleTestBuilder;

namespace Day13.Tests;

public class ArticleTests
{
    private readonly CommentFaker _commentFaker = new();
    private Article _article;

    [Fact]
    public void Should_Add_Comment_In_An_Article()
    {
        var comment = _commentFaker.Generate();

        Given(AnArticle());
        When(article => article.AddComment(comment.Text, comment.Author));
        Then(
            article =>
            {
                article.Comments.Should().HaveCount(1);
                AssertComment(article.Comments.Last(), comment.Text, comment.Author);
            });
    }

    [Fact]
    public void Should_Add_Comment_In_An_Article_Containing_Already_A_Comment()
    {
        var newComment = _commentFaker.Generate();

        Given(AnArticle().Commented());
        When(article => article.AddComment(newComment.Text, newComment.Author));
        Then(
            article =>
            {
                article.Comments.Should().HaveCount(2);
                AssertComment(article.Comments[1], newComment.Text, newComment.Author);
            });
    }

    private static void AssertComment(Comment comment, string expectedComment, string expectedAuthor)
    {
        comment.Text.Should().Be(expectedComment);
        comment.Author.Should().Be(expectedAuthor);
        comment.CreationDate.Should().Be(DateOnly.FromDateTime(DateTime.Now));
    }

    private void Given(ArticleTestBuilder articleBuilder)
        => _article = articleBuilder.Build();

    private void When(Action<Article> act)
        => act(_article);

    private void Then(Action<Article> act)
        => act(_article);

    public class Fail : ArticleTests
    {
        [Fact]
        public void When_Adding_An_Existing_Comment()
        {
            var comment = _commentFaker.Generate();
            var article = AnArticle().Build();
            article.AddComment(comment.Text, comment.Author);

            var act = () => article.AddComment(comment.Text, comment.Author);
            act.Should().Throw<CommentAlreadyExistException>();
        }
    }
}

internal sealed class CommentFaker : Faker<Comment>
{
    public CommentFaker()
        => CustomInstantiator(
            faker => new Comment(
                faker.Lorem.Sentence(),
                faker.Person.FullName,
                DateOnly.FromDateTime(faker.Date.Recent())));
}