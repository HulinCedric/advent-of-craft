using FluentAssertions;
using Xunit;

namespace Day04.Tests;

public class ArticleTests
{
    private const string CommentText = "Amazing article !!!";
    private const string CommentAuthor = "Pablo Escobar";

    private readonly Article _article = new(
        "Lorem Ipsum",
        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore");

    [Fact]
    public void Should_add_comment()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        _article.AddComment(CommentText, CommentAuthor);

        _article.ShouldHaveCommentsCount(1);
        _article.ShouldHaveCommentWith(CommentText, CommentAuthor, today);
    }

    [Fact]
    public void Should_add_comment_in_an_article_already_containing_a_comment()
    {
        const string secondCommentText = "Lorem Ipsum";
        const string secondCommentAuthor = "Ipsum Lorem";
        var today = DateOnly.FromDateTime(DateTime.Today);

        _article.AddComment(CommentText, CommentAuthor);
        _article.AddComment(secondCommentText, secondCommentAuthor);

        _article.ShouldHaveCommentsCount(2);
        _article.ShouldHaveCommentWith(secondCommentText, secondCommentAuthor, today);
    }

    [Fact]
    public void Should_fail_when_adding_existing_comment()
    {
        _article.AddComment(CommentText, CommentAuthor);

        var act = () => _article.AddComment(CommentText, CommentAuthor);
        act.Should().Throw<CommentAlreadyExistException>();
    }
}