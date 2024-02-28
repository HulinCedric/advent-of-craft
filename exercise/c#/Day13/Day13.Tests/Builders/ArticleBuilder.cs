using Bogus;
using Day13.Tests.TestDoubles;
using static Day13.Tests.Builders.CommentBuilder;

namespace Day13.Tests.Builders;

public class ArticleBuilder
{
    private readonly Clock _clock = new(DateOnly.FromDateTime(DateTime.Today));
    private readonly List<Comment> _comments = [];
    private readonly Faker _faker = new();

    public static ArticleBuilder AnArticle()
        => new();

    public Article Build()
    {
        var article = new Article(
            _faker.Lorem.Sentence(),
            _faker.Lorem.Paragraph(),
            _clock);

        foreach (var comment in _comments)
        {
            article.AddComment(comment.Text, comment.Author);
        }

        return article;
    }

    public ArticleBuilder Commented()
    {
        _comments.Add(AComment().Build());

        return this;
    }

    public void OneDayLater()
        => _clock.AddDays(1);
}