using FluentAssertions;
using Xunit;
using static Day13.Tests.ArticleTestBuilder;

namespace Day13.Tests;

public class ArticleTests
{
    [Fact]
    public void Should_Add_Comment_In_An_Article()
    {
        var article = AnArticle().Build();

        article.AddComment(CommentText, Author);

        article.Comments
            .Should()
            .HaveCount(1)
            .And.ContainSingle(
                comment => comment.Text == CommentText &&
                           comment.Author == Author);
    }

    [Fact]
    public void Should_Add_Comment_In_An_Article_Containing_Already_A_Comment()
    {
        const string newComment = "Finibus Bonorum et Malorum";
        const string newAuthor = "Al Capone";

        var article = AnArticle()
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
            var article = AnArticle().Build();

            article.AddComment(CommentText, Author);

            var act = () => article.AddComment(CommentText, Author);
            act.Should().Throw<CommentAlreadyExistException>();
        }
    }
}