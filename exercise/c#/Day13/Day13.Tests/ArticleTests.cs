using FluentAssertions;
using Xunit;

namespace Day13.Tests;

public class ArticleTestBuilder
{
    public const string Author = "Pablo Escobar";
    public const string CommentText = "Amazing article !!!";

    private readonly List<(string, string)> _comments = new();

    public static ArticleTestBuilder AnArticle()
        => new();

    public Article Build()
    {
        var article = new Article(
            "Lorem Ipsum",
            "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore");

        foreach (var comment in _comments)
        {
            article.AddComment(comment.Item1, comment.Item2);
        }

        return article;
    }

    public ArticleTestBuilder Commented()
    {
        _comments.Add((CommentText, Author));

        return this;
    }
}

public class ArticleTests
{
    [Fact]
    public void Should_Add_Comment_In_An_Article()
    {
        var article = ArticleTestBuilder.AnArticle().Build();

        article.AddComment(ArticleTestBuilder.CommentText, ArticleTestBuilder.Author);

        article.Comments
            .Should()
            .HaveCount(1)
            .And.ContainSingle(
                comment => comment.Text == ArticleTestBuilder.CommentText &&
                           comment.Author == ArticleTestBuilder.Author);
    }

    [Fact]
    public void Should_Add_Comment_In_An_Article_Containing_Already_A_Comment()
    {
        const string newComment = "Finibus Bonorum et Malorum";
        const string newAuthor = "Al Capone";

        var article = ArticleTestBuilder.AnArticle()
            .Commented()
            .Build();

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
            var article = ArticleTestBuilder.AnArticle().Build();

            article.AddComment(ArticleTestBuilder.CommentText, ArticleTestBuilder.Author);

            var act = () => article.AddComment(ArticleTestBuilder.CommentText, ArticleTestBuilder.Author);
            act.Should().Throw<CommentAlreadyExistException>();
        }
    }
}