using LanguageExt;

namespace Day16;

public record Article
{
    private readonly string _content;
    private readonly string _name;

    public Article(string name, string content) : this(name, content, Seq<Comment>.Empty)
    {
    }

    private Article(string name, string content, Seq<Comment> comments)
    {
        _name = name;
        _content = content;
        Comments = comments;
    }

    public Seq<Comment> Comments { get; }

    private Article AddComment(
        string text,
        string author,
        DateOnly creationDate)
    {
        var comment = new Comment(text, author, creationDate);
        if (Comments.Contains(comment))
        {
            throw new CommentAlreadyExistException();
        }

        return new Article(_name, _content, Comments.Add(comment));
    }

    public Article AddComment(string text, string author)
        => AddComment(text, author, DateOnly.FromDateTime(DateTime.Now));
}