using System.Collections.Immutable;

namespace Day16;

public class Article
{
    private readonly string _content;
    private readonly string _name;

    public Article(string name, string content) : this(name, content, ImmutableList<Comment>.Empty)
    {
    }

    private Article(string name, string content, IEnumerable<Comment> comments)
    {
        _name = name;
        _content = content;
        Comments = comments.ToImmutableList();
    }

    public ImmutableList<Comment> Comments { get; }

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

        var updatedComments = Comments.ToList();
        updatedComments.Add(comment);
        return new Article(_name, _content, updatedComments);
    }

    public Article AddCommentImmutably(string text, string author)
        => AddComment(text, author, DateOnly.FromDateTime(DateTime.Now));
}