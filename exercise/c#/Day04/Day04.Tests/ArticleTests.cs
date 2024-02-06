using FluentAssertions;
using Xunit;

namespace Day04.Tests;

public class ArticleTests
{
    private const string CommentText = "Amazing article !!!";
    private const string CommentAuthor = "Pablo Escobar";
    
    private readonly Article _article = new(
        "Lorem Ipsum",
        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore"
    );

    [Fact]
    // It_Should_Add_A_Comment_With_The_Given_Text
    // It_Should_Add_A_Comment_With_The_Given_Author
    // It_Should_Add_A_Comment_With_The_Date_Of_The_Day
    public void It_Should_Add_Valid_Comment()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
       
        _article.AddComment(CommentText, CommentAuthor);

        _article.ShouldHaveCommentsCount(1);
        _article.ShouldHaveCommentWith(CommentText, CommentAuthor, today);
    }

    [Fact]
    public void It_Should_Throw_An_Exception_When_Adding_Existing_Comment()
    {
        _article.AddComment(CommentText, CommentAuthor);

        var act = () => _article.AddComment(CommentText, CommentAuthor);
        act.Should().Throw<CommentAlreadyExistException>();
    }
}