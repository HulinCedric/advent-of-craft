using FluentAssertions;
using Xunit;
using static Day13.Tests.ArticleTestBuilder;

namespace Day13.Tests;

public class ArticleTests
{
    private readonly CommentFaker _commentFaker = new();
    private readonly Comment newComment;
    private Article _article;

    public ArticleTests()
        => newComment = _commentFaker.Generate();

    [Fact]
    public void Should_Add_Comment_In_An_Article()
    {
        Given(AnArticle());
        When(article => article.AddComment(newComment.Text, newComment.Author));
        Then(
            article =>
            {
                article.Comments.Should().HaveCount(1);
                article.Comments.Last().Should().BeEquivalentTo(newComment);
            });
    }

    [Fact]
    public void Should_Add_Comment_In_An_Article_Containing_Already_A_Comment()
    {
        Given(AnArticle().Commented());
        When(article => article.AddComment(newComment.Text, newComment.Author));
        Then(
            article =>
            {
                article.Comments.Should().HaveCount(2);
                article.Comments.Last().Should().BeEquivalentTo(newComment);
            });
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
            article.AddComment(newComment.Text, newComment.Author);

            var act = () => article.AddComment(newComment.Text, newComment.Author);
            act.Should().Throw<CommentAlreadyExistException>();
        }
    }
}