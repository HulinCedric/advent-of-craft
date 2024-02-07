using FluentAssertions;
using Xunit;

namespace Day04.Tests;

public class AnArticle
{
    private const string CommentText = "Amazing article !!!";
    private const string CommentAuthor = "Pablo Escobar";

    private readonly Article _article = new(
        "Lorem Ipsum",
        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore");

    private readonly DateOnly _today = DateOnly.FromDateTime(DateTime.Today);

    [Fact]
    public void Can_be_commented()
    {
        _article.AddComment(CommentText, CommentAuthor);

        _article.ShouldHaveCommentsCount(1);
        _article.ShouldHaveCommentWith(CommentText, CommentAuthor, _today);
    }

    [Fact]
    public void Can_be_commented_multiple_times()
    {
        const string secondCommentText = "Lorem Ipsum";
        const string secondCommentAuthor = "Ipsum Lorem";

        _article.AddComment(CommentText, CommentAuthor);
        _article.AddComment(secondCommentText, secondCommentAuthor);

        _article.ShouldHaveCommentsCount(2);
        _article.ShouldHaveCommentWith(secondCommentText, secondCommentAuthor, _today);
    }

    [Fact]
    public void Cannot_be_commented_twice_with_the_same_comment()
    {
        _article.AddComment(CommentText, CommentAuthor);

        _article.Invoking(_ => _.AddComment(CommentText, CommentAuthor))
            .Should()
            .Throw<CommentAlreadyExistException>();
    }
}