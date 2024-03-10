using System.Collections.Immutable;

namespace Day21.FunctionalCore_ImperativeShell;

public class Persister
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

    public void WithAlreadyExistingFile(string directory, FileContent fileContent)
    {
        var filePath = Path.Combine(directory, fileContent.FileName);

        _files[filePath] = fileContent;
    }

    public void WithAlreadyExistingFiles(string directoryName, List<FileContent> files)
    {
        foreach (var file in files)
        {
            WithAlreadyExistingFile(directoryName, file);
        }
    }
}