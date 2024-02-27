using FluentAssertions;
using Xunit;
using static Day13.Tests.ArticleTestBuilder;

namespace Day13.Tests;

public class ArticleTests
{
    private Article _article;

    [Fact]
    public void Should_Add_Comment_In_An_Article()
    {
        Given(AnArticle());
        When(article => article.AddComment(CommentText, Author));
        Then(
            article =>
            {
                article.Comments.Should().HaveCount(1);
                AssertComment(article.Comments.Last(), CommentText, Author);
            });
    }

    [Fact]
    public void Should_Add_Comment_In_An_Article_Containing_Already_A_Comment()
    {
        const string newComment = "Finibus Bonorum et Malorum";
        const string newAuthor = "Al Capone";

        Given(AnArticle().Commented());
        When(article => article.AddComment(newComment, newAuthor));
        Then(
            article =>
            {
                article.Comments.Should().HaveCount(2);
                AssertComment(article.Comments[1], newComment, newAuthor);
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
            var article = AnArticle().Build();
            article.AddComment(CommentText, Author);

            var act = () => article.AddComment(CommentText, Author);
            act.Should().Throw<CommentAlreadyExistException>();
        }
    }
}