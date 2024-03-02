namespace Day16.Tests;

public class ArticleBuilder
{
    public const string Author = "Pablo Escobar";
    public const string CommentText = "Amazing article !!!";
    private readonly Dictionary<string, string> _comments = new();

    public static ArticleBuilder AnArticle()
        => new();

    public ArticleBuilder Commented()
    {
        _comments.Add(CommentText, Author);
        return this;
    }

    public Article Build()
        => _comments
            .Aggregate(
                new Article(
                    "Lorem Ipsum",
                    "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore"),
                (current, comment) => current.AddComment(comment.Key, comment.Value));
}