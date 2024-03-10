using System.Collections.Immutable;
using Day21.FunctionalCore_ImperativeShell.Domain;

namespace Day21.FunctionalCore_ImperativeShell.Infrastructure;

public class FileSystemFileRepository : IFileRepository
{
    public FileContent ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new FileContent(Path.GetFileName(filePath), ImmutableList<string>.Empty);
        }

        var allLines = File.ReadAllLines(filePath).ToImmutableList();

        return new FileContent(Path.GetFileName(filePath), allLines);
    }

    public void ApplyUpdate(string directory, FileUpdated fileUpdated)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var filePath = Path.Combine(directory, fileUpdated.FileName);
        var allLines = fileUpdated.NewContent.Split(
            Environment.NewLine,
            StringSplitOptions.RemoveEmptyEntries);
        
        File.WriteAllLines(filePath, allLines);
    }

    public List<FileContent> ReadDirectory(string directory)
    {
        if (!Directory.Exists(directory))
        {
            return [];
        }

        var files = Directory.GetFiles(directory);
        return files.Select(ReadFile).ToList();
    }
}