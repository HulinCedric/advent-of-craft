using System.Collections.Immutable;

namespace Day21.FunctionalCore_ImperativeShell;

public class FileSystemPersister : IPersistFile
{
    public FileContent ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new FileContent(Path.GetFileName(filePath), ImmutableList<string>.Empty);
        }

        var allLines = File.ReadAllLines(filePath)
            .Where(line => line is not "")
            .ToImmutableList();

        return new FileContent(Path.GetFileName(filePath), allLines);
    }

    public void ApplyUpdate(string directory, FileUpdated fileUpdated)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var filePath = Path.Combine(directory, fileUpdated.FileName);
        File.WriteAllLines(filePath, fileUpdated.NewContent.Split(Environment.NewLine));
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