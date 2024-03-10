using System.Collections.Immutable;
using Day21.FunctionalCore_ImperativeShell.Domain;

namespace Day21.Tests.FunctionalCore_ImperativeShell.Common.TestDoubles;

public class InMemoryFileRepository
    : IFileRepository
{
    private static readonly ImmutableList<string> NoContent = ImmutableList<string>.Empty;
    private readonly Dictionary<string, FileContent> _files = new();

    public FileContent ReadFile(string filePath) =>
        _files.TryGetValue(filePath, out var file)
            ? file
            : new FileContent(Path.GetFileName(filePath), NoContent);

    public void ApplyUpdate(string directory, FileUpdated fileUpdated)
    {
        var filePath = Path.Combine(directory, fileUpdated.FileName);

        var newFileContent = fileUpdated.NewContent
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .ToImmutableList();

        _files[filePath] = new FileContent(fileUpdated.FileName, newFileContent);
    }

    public List<FileContent> ReadDirectory(string directory) =>
        _files
            .Where(kvp => Path.GetDirectoryName(kvp.Key) == directory)
            .Select(kvp => kvp.Value)
            .ToList();
}