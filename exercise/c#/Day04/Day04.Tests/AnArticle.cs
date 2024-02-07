using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using Xunit;

namespace Day04.Tests;

public class AnArticle
{
    private const string CommentText = "Amazing article !!!";
    private const string CommentAuthor = "Pablo Escobar";

    private readonly Article _article;
    private readonly FakeTimeProvider _clock;

    public AnArticle()
    {
        _clock = new FakeTimeProvider();
        _article = new Article(
            "Lorem Ipsum",
            "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
            _clock);
    }

    [Fact]
    public void Can_be_commented()
    {
        _article.AddComment(CommentText, CommentAuthor);

        _article.ShouldHaveComments(count: 1);
        _article.ShouldHaveCommentWith(CommentText, CommentAuthor, _clock.Today());
    }

    [Fact]
    public void Can_be_commented_multiple_times()
    {
        const string secondCommentText = "Lorem Ipsum";
        const string secondCommentAuthor = "Ipsum Lorem";

        _article.AddComment(CommentText, CommentAuthor);
        _article.AddComment(secondCommentText, secondCommentAuthor);

        _article.ShouldHaveComments(count: 2);
        _article.ShouldHaveCommentWith(secondCommentText, secondCommentAuthor, _clock.Today());
    }

    [Fact]
    public void Cannot_be_commented_twice_with_the_same_comment()
    {
        _article.AddComment(CommentText, CommentAuthor);

        _article.Invoking(_ => _.AddComment(CommentText, CommentAuthor))
            .Should()
            .Throw<CommentAlreadyExistException>();
    }

    [Fact]
    public void Can_be_commented_twice_with_the_same_comment_on_a_different_day()
    {
        _article.AddComment(CommentText, CommentAuthor);

        _clock.AddDays(1);

        _article.AddComment(CommentText, CommentAuthor);

        _article.ShouldHaveComments(count: 2);
        _article.ShouldHaveCommentWith(CommentText, CommentAuthor, _clock.Today());
    }
}