using FluentAssertions;

namespace Day13.Tests.Verification;

public static class ArticleVerification
{
    public static void ShouldHaveCommentsCount(this Article article, int count)
        => article.Comments
            .Should()
            .HaveCount(count);

    public static void ShouldHaveComment(this Article article, Comment expectedComment)
        => article.Comments
            .Should()
            .ContainSingle(comment => comment == expectedComment);
}