using Day13.Tests.Builders;
using Day13.Tests.Setup;
using Day13.Tests.Verification;
using FluentAssertions;
using Xunit;
using static Day13.Tests.Builders.ArticleBuilder;
using static Day13.Tests.Builders.CommentBuilder;

namespace Day13.Tests;

public class AnArticle
{
    private readonly Comment _newComment = AComment().Build();

    private Article _article;
    private ArticleBuilder _context;

    [Fact]
    public void Can_be_commented()
    {
        Given(AnArticle());
        When(article => article.AddComment(_newComment.Text, _newComment.Author));
        Then(article =>
        {
            article.ShouldHaveCommentsCount(1);
            article.ShouldHaveComment(_newComment);
        });
    }

    [Fact]
    public void Can_be_commented_multiple_times()
    {
        Given(AnArticle().Commented());
        When(article => article.AddComment(_newComment.Text, _newComment.Author));
        Then(article =>
        {
            article.ShouldHaveCommentsCount(2);
            article.ShouldHaveComment(_newComment);
        });
    }

    [Fact]
    public void Can_be_commented_twice_with_the_same_comment_on_a_different_day()
    {
        Given(AnArticle());
        When((article, context) =>
        {
            article.AddComment(_newComment.Text, _newComment.Author);
            
            context.OneDayLater();
            
            article.AddComment(_newComment.Text, _newComment.Author);
        });
        Then(article =>
        {
            article.ShouldHaveCommentsCount(2);
            article.ShouldHaveComment(_newComment.SameOnTheNextDay());
        });
    }

    private void Given(ArticleBuilder articleBuilder)
    {
        _context = articleBuilder;
        _article = articleBuilder.Build();
    }

    private void When(Action<Article> act)
        => act(_article);

    private void When(Action<Article, ArticleBuilder> act)
        => act(_article, _context);

    private void Then(Action<Article> act)
        => act(_article);

    public class Fail : AnArticle
    {
        [Fact]
        public void Cannot_be_commented_twice_with_the_same_comment()
        {
            var article = AnArticle().Build();
            article.AddComment(_newComment.Text, _newComment.Author);

            var act = () => article.AddComment(_newComment.Text, _newComment.Author);
            act.Should().Throw<CommentAlreadyExistException>();
        }
    }
}