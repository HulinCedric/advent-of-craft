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