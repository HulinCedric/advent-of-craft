using FluentAssertions;

namespace Day04.Tests;

public static class ArticleVerification
{
    public static void ShouldHaveComments(this Article article, int count)
        => article.Comments
            .Should()
            .HaveCount(count);

    public static void ShouldHaveCommentWith(this Article article, string text, string author, DateOnly creationDate)
        => article.Comments
            .Should()
            .ContainSingle(comment => comment == new Comment(text, author, creationDate));
}