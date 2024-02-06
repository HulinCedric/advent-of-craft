using FluentAssertions;
using Xunit;

namespace Day04.Tests;

public class ArticleTests
{
    [Fact]
    // It_Should_Add_A_Comment_With_The_Given_Text
    // It_Should_Add_A_Comment_With_The_Given_Author
    // It_Should_Add_A_Comment_With_The_Date_Of_The_Day
    public void It_Should_Add_Valid_Comment()
    {
        var article = new Article(
            "Lorem Ipsum",
            "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore"
        );
        const string text = "Amazing article !!!";
        const string author = "Pablo Escobar";
        var today = DateOnly.FromDateTime(DateTime.Today);
       
        article.AddComment(text, author);
        
        ShouldHaveCommentWith(article, text, author, today);
    }

    private static void ShouldHaveCommentWith(Article article, string text, string author, DateOnly today)
    {
        article.Comments
            .Should().HaveCount(1)
            .And.ContainSingle(comment => comment.Text == text);
        article.Comments
            .Should().HaveCount(1)
            .And.ContainSingle(comment => comment.Author == author);
        article.Comments
            .Should().ContainSingle(comment => comment.CreationDate == today);
    }

    [Fact]
    public void It_Should_Throw_An_Exception_When_Adding_Existing_Comment()
    {
        var article = new Article(
            "Lorem Ipsum",
            "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore"
        );
        article.AddComment("Amazing article !!!", "Pablo Escobar");

        var act = () => article.AddComment("Amazing article !!!", "Pablo Escobar");
        act.Should().Throw<CommentAlreadyExistException>();
    }
}