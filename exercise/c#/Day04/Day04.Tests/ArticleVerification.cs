using FluentAssertions;

namespace Day04.Tests;

public static class ArticleVerification
{
    public static void ShouldHaveCommentWith(this Article article, string text, string author, DateOnly today)
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
}