using System.Collections.Immutable;
using Day21.FunctionalCore_ImperativeShell;

namespace Day21.Tests.FunctionalCore_ImperativeShell;

public class FakePersister
    : IPersistFile
{
    private readonly Dictionary<string, FileContent> _files = new();

    public FileContent ReadFile(string filePath) => _files[filePath];

    public void ApplyUpdate(string directory, FileUpdated fileUpdated)
    {
        var filePath = Path.Combine(directory, fileUpdated.FileName);

        var newFileContent = fileUpdated.NewContent.Split(Environment.NewLine).ToImmutableList();

        _files[filePath] = new FileContent(fileUpdated.FileName, newFileContent);
    }

    public List<FileContent> ReadDirectory(string directory) =>
        _files
            .Where(kvp => Path.GetDirectoryName(kvp.Key) == directory)
            .Select(kvp => kvp.Value)
            .ToList();
}