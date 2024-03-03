using System.Collections.Immutable;
using LanguageExt;

namespace Day19;

public class Article
{
    private readonly string _name;
    private readonly string _content;
    public ImmutableArray<Comment> Comments { get; }

    private Article(string name, string content, IEnumerable<Comment> comments)
    {
        _name = name;
        _content = content;
        Comments = comments.ToImmutableArray();
    }

    public Article(string name, string content)
        : this(name, content, Array.Empty<Comment>())
    {
    }

    public Either<Error, Article> AddComment(string text, string author)
    {
        var comment = NewComment(text, author);

        return Comments.Contains(comment)
                   ? ToCommentAlreadyExistFailure()
                   : new Article(_name, _content, Comments.Append(comment));
    }

    private static Comment NewComment(string text, string author)
        => new(text, author, Now());

    private static DateOnly Now()
        => DateOnly.FromDateTime(DateTime.Now);

    private static Error ToCommentAlreadyExistFailure()
        => Error.New("This comment already exists in this article");
}

public record Comment(string Text, string Author, DateOnly CreationDate);

public record Error(string Message)
{
    public static Error New(string message)
        => new(message);
    
    public static implicit operator Error(string message)
        => New(message);
}