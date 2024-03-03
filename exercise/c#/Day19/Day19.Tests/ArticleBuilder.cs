using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Either<LanguageExt.Common.Error,Day19.Article>;

namespace Day19.Tests;

public class ArticleBuilder
{
    public const string Author = "Pablo Escobar";
    public const string CommentText = "Amazing article !!!";

    private readonly Dictionary<string, string> _comments = new();
    private readonly Bogus.Randomizer _random = new();

    public static ArticleBuilder AnArticle() => new();

    public ArticleBuilder Commented()
    {
        _comments.Add(CommentText, Author);
        return this;
    }

    public Either<Error, Article> Build()
        => _comments
            .Fold(
                Right(new Article(_random.String(), _random.String())),
                (article, comment) => article.Bind(a=>a.AddComment(comment.Key, comment.Value)));
}