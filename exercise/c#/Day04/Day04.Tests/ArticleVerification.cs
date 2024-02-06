using FluentAssertions;

namespace Day04.Tests;

public static class ArticleVerification
{
    public static void ShouldHaveCommentWith(this Article article, string text, string author, DateOnly creationDate)
        => article.Comments
            .Should()
            .HaveCount(1)
            .And.ContainSingle(comment => comment == new Comment(text, author, creationDate));
}