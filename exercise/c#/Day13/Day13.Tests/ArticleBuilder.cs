using Bogus;

namespace Day13.Tests;

public class ArticleBuilder
{
    private readonly CommentGenerator _commentGenerator = new();
    private readonly List<Comment> _comments = [];

    private readonly Faker _faker = new();

    public static ArticleBuilder AnArticle()
        => new();

    public Article Build()
    {
        var article = new Article(
            _faker.Lorem.Sentence(),
            _faker.Lorem.Paragraph());

        foreach (var comment in _comments)
        {
            article.AddComment(comment.Text, comment.Author);
        }

        return article;
    }

    public ArticleBuilder Commented()
    {
        _comments.Add(_commentGenerator.Generate());

        return this;
    }
}