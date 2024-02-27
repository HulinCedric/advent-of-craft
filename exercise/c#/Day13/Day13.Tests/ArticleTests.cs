using FluentAssertions;
using Xunit;
using static Day13.Tests.ArticleBuilder;

namespace Day13.Tests;

public class ArticleTests
{
    private readonly Comment _newComment = new CommentGenerator().Generate();

    private Article _article;

    [Fact]
    public void Should_Add_Comment_In_An_Article()
    {
        Given(AnArticle());
        When(article => article.AddComment(_newComment.Text, _newComment.Author));
        Then(
            article =>
            {
                article.Comments.Should().HaveCount(1);
                article.Comments.Last().Should().BeEquivalentTo(_newComment);
            });
    }

    [Fact]
    public void Should_Add_Comment_In_An_Article_Containing_Already_A_Comment()
    {
        Given(AnArticle().Commented());
        When(article => article.AddComment(_newComment.Text, _newComment.Author));
        Then(
            article =>
            {
                article.Comments.Should().HaveCount(2);
                article.Comments.Last().Should().BeEquivalentTo(_newComment);
            });
    }

    private void Given(ArticleBuilder articleBuilder)
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
            article.AddComment(_newComment.Text, _newComment.Author);

            var act = () => article.AddComment(_newComment.Text, _newComment.Author);
            act.Should().Throw<CommentAlreadyExistException>();
        }
    }
}