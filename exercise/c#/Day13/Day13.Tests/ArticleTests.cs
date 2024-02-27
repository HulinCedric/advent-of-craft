using FluentAssertions;
using Xunit;

namespace Day13.Tests;

public class ArticleTestBuilder
{
    public static ArticleTestBuilder Article()
        => new();

    public Article Build()
        => new(
            "Lorem Ipsum",
            "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore");
}

public class ArticleTests
{
    private const string Author = "Pablo Escobar";
    private const string CommentText = "Amazing article !!!";

    [Fact]
    public void Should_Add_Comment_In_An_Article()
    {
        var article = ArticleTestBuilder.Article().Build();
        article.AddComment(CommentText, Author);

        article.Comments
            .Should()
            .HaveCount(1)
            .And.ContainSingle(comment => comment.Text == CommentText && comment.Author == Author);
    }

    [Fact]
    public void Should_Add_Comment_In_An_Article_Containing_Already_A_Comment()
    {
        const string newComment = "Finibus Bonorum et Malorum";
        const string newAuthor = "Al Capone";

        var article = ArticleTestBuilder.Article().Build();
        article.AddComment(CommentText, Author);
        article.AddComment(newComment, newAuthor);

        article.Comments.Should().HaveCount(2);

        var lastComment = article.Comments.Last();
        lastComment.Text.Should().Be(newComment);
        lastComment.Author.Should().Be(newAuthor);
    }

    public class Fail : ArticleTests
    {
        [Fact]
        public void When_Adding_An_Existing_Comment()
        {
            var article = ArticleTestBuilder.Article().Build();
            article.AddComment(CommentText, Author);

            var act = () => article.AddComment(CommentText, Author);
            act.Should().Throw<CommentAlreadyExistException>();
        }
    }
}